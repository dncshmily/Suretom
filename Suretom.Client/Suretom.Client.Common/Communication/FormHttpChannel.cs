using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Media.Imaging;

namespace Suretom.Client.Common
{
    /// <summary>
    /// POST表单数据
    /// 与服务器端接口的http通信类
    /// </summary>
    public class FormHttpChannel : IHttpChannel
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <returns></returns>
        public string Get(string url, Encoding encode = null)
        {
            var result = string.Empty;

            try
            {
                //var webClient = new WebClient { Encoding = Encoding.UTF8 };
                //if (encode != null)
                //    webClient.Encoding = encode;

                //ServicePointManager.Expect100Continue = false;
                //if (url.StartsWith("https")) ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //webClient.Headers.Add("Content-Type", "multipart/form-data");
                //var sendData = Encoding.GetEncoding("UTF-8").GetBytes("");
                //webClient.Headers.Add("ContentLength", sendData.Length.ToString(CultureInfo.InvariantCulture));
                //var readData = webClient.DownloadData(url);

                //result = Encoding.GetEncoding("UTF-8").GetString(readData);

                WebRequest request = WebRequest.Create(url);
                if (url.ToLower().StartsWith("https"))
                {
                    //用于解决：基础连接已经关闭: 未能为 SSL/TLS 安全通道建立信任关系。
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }

                request.Method = "Get";
                request.Timeout = 120000;
                request.ContentType = "multipart/form-data";

                var stream1 = request.GetResponse().GetResponseStream();
                // 把 Stream 转换成 byte[]
                byte[] bytes = new byte[stream1.Length];
                stream1.Read(bytes, 0, bytes.Length);
                // 设置当前流的位置为流的开始
                stream1.Seek(0, SeekOrigin.Begin);
                // 把 byte[] 写入文件
                FileStream fs = new FileStream("I:\\project\\Demo\\001.jpg", FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bytes);
                bw.Close();
                fs.Close();

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求的Url</param>
        /// <param name="requestParam">请求参数，必须为Json字符串</param>
        /// <returns></returns>
        public HttpResult Post(string url, string requestParam)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                if (url.ToLower().StartsWith("https"))
                {
                    //用于解决：基础连接已经关闭: 未能为 SSL/TLS 安全通道建立信任关系。
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                }

                request.Method = "POST";
                request.Timeout = 200000;
                request.ContentType = "application/x-www-form-urlencoded";

                var postData = System.Text.Encoding.UTF8.GetBytes(requestParam);
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postData, 0, postData.Length);
                requestStream.Close();

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            string value = reader.ReadToEnd();
                            if (value.IndexOf("-ERR") == 0 || value.IndexOf("-err") == 0)
                            {
                                value = value.Replace("-ERR ", "").Replace("-err ", "");

                                return new HttpResult(value);
                            }
                            else
                            {
                                var result = JObject.Parse(value);
                                var success = result["status"]?.ToString() == "200" ? true : false;
                                if (success)
                                {
                                    return new HttpResult(true, result["data"]);
                                }
                                else
                                    return new HttpResult(result["message"]?.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new HttpResult(ex.Message);
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="url">请求的Url</param>
        /// <param name="requestParam">请求参数</param>
        /// <param name="fileBytes">文件数据</param>
        /// <returns></returns>
        public HttpResult UpdateFile(string url, IList<UpdateFileParam> updateFileParams)
        {
            try
            {
                //验证参数
                var fileParam = updateFileParams.FirstOrDefault(x => x.IsFile);
                if (fileParam != null)
                {
                    if (fileParam.FileContent == null)
                    {
                        throw new Exception("未设置文件流");
                    }
                    if (fileParam.FileContent.Length == 0)
                    {
                        throw new Exception("文件无数据");
                    }
                }
                else
                {
                    throw new Exception("无文件参数");
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 120000;
                SetHttpWebRequest(request);

                //分隔符;
                string boundary = string.Format("----WebKitFormBoundary{0}", DateTime.Now.Ticks.ToString("x"));
                request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);

                //请求流写入数据
                using (var postStream = new MemoryStream())
                {
                    SetFormPostStream(postStream, updateFileParams, boundary);

                    request.ContentLength = postStream.Length;

                    postStream.Position = 0;

                    //直接写入流
                    Stream requestStream = request.GetRequestStream();
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }
                }

                //请求
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            string value = reader.ReadToEnd();
                            if (value.IndexOf("-ERR") == 0 || value.IndexOf("-err") == 0)
                            {
                                value = value.Replace("-ERR ", "").Replace("-err ", "");

                                return new HttpResult(value);
                            }
                            else
                            {
                                var result = JObject.Parse(value);
                                var success = result["status"]?.ToString() == "200" ? true : false;
                                if (success)
                                {
                                    return new HttpResult(true, result["data"]);
                                }
                                else
                                    return new HttpResult(result["message"]?.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var fileParam = updateFileParams.FirstOrDefault(x => x.IsFile);
                if (fileParam != null && fileParam.FileContent != null)
                {
                    fileParam.FileContent.Dispose();
                }

                return new HttpResult(ex.Message);
            }
        }

        /// <summary>
        /// 把json字符串转为键值对字符串
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        private string JsonStr2KvStr(string jsonStr)
        {
            //if (jsonStr.Contains("&"))
            //{
            //    throw new ArgumentException("jsonStr中禁止使用&");
            //}

            JToken jToken;
            try
            {
                jToken = JToken.Parse(jsonStr);
            }
            catch
            {
                throw new ArgumentException("jsonStr的值不是有效的json字符串");
            }

            if (jToken.Type != JTokenType.Object)
            {
                throw new ArgumentException("jsonStr必须为对象序列化生成的字符串");
            }

            var kvSb = new StringBuilder();

            foreach (var t in ((JObject)jToken).Properties())
            {
                //kvSb.Append(System.Web.HttpUtility.UrlEncode(t.Name));
                kvSb.Append(t.Name);
                kvSb.Append("=");
                kvSb.Append(System.Web.HttpUtility.UrlEncode(t.Value.ToString(Formatting.None).Trim('\"')));
                kvSb.Append("&");
            }

            return kvSb.ToString().TrimEnd('&');
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cookieContainer"></param>
        private void SetHttpWebRequest(HttpWebRequest request, CookieContainer cookieContainer = null)
        {
            string refererUrl = null;
            request.Timeout = 60000;
            request.Method = "POST";
            request.Accept = "*/*"; //"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36"; ;
            if (!string.IsNullOrEmpty(refererUrl))
                request.Referer = refererUrl;
            if (cookieContainer != null)
                request.CookieContainer = cookieContainer;
            //request.Headers["Cookie"] = "";
            request.Headers["client"] = "true";
            request.Headers["X-Requested-With"] = "XMLHttpRequest";
        }

        /// <summary>
        /// 设置流内容
        /// </summary>
        /// <param name="postStream"></param>
        /// <param name="diList"></param>
        /// <param name="boundary"></param>
        private void SetFormPostStream(Stream postStream, IList<UpdateFileParam> diList, string boundary)
        {
            //文件数据模板
            string fileFormdata =
                                    "\r\n--" + boundary +
                                    "\r\nContent-Disposition: form-data; name =\"{0}\"; filename=\"{1}\"" +
                                    "\r\nContent-Type: application/octet-stream" +
                                    "\r\n\r\n";
            //文本数据模板
            string dataFormdata =
                                    "\r\n--" + boundary +
                                    "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                    "\r\n\r\n{1}";
            foreach (var item in diList)
            {
                string formdata = null;
                if (item.IsFile)
                {
                    //上传文件
                    formdata = string.Format(
                        fileFormdata,
                        item.Key,
                        item.Value);
                }
                else
                {
                    //上传文本
                    formdata = string.Format(dataFormdata, item.Key, item.Value);
                }

                //统一处理
                byte[] formdataBytes = null;

                //第一行不需要换行
                if (postStream.Length == 0)
                    formdataBytes = Encoding.UTF8.GetBytes(formdata.Substring(2, formdata.Length - 2));
                else
                    formdataBytes = Encoding.UTF8.GetBytes(formdata);
                postStream.Write(formdataBytes, 0, formdataBytes.Length);

                //写入文件内容
                if (item.IsFile && item.FileContent != null && item.FileContent.Length > 0)
                {
                    using (var stream = item.FileContent)
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = 0;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            postStream.Write(buffer, 0, bytesRead);
                        }
                    }

                    //using (var stream = new System.IO.FileStream(item.Value, FileMode.Open))
                    //{
                    //    byte[] buffer = new byte[1024];
                    //    int bytesRead = 0;
                    //    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    //    {
                    //        postStream.Write(buffer, 0, bytesRead);
                    //    }
                    //}
                }
            }

            //结尾
            var footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            postStream.Write(footer, 0, footer.Length);
        }
    }
}