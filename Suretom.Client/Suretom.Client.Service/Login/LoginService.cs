using Newtonsoft.Json;
using Suretom.Client.Common;
using Suretom.Client.IService;
using System;

namespace Suretom.Client.Service
{
    /// <summary>
    /// 登录服务，客户端调用服务接口需要先登录
    /// </summary>
    public class LoginService : ServiceBase, ILoginService
    {
        public LoginService()
        {
            Urls.Add("Code", "Home/VerifyCode");
            Urls.Add("Login", "Home/Login");
        }

        /// <summary>
        /// 设置登录信息
        /// </summary>
        /// <param name="token"></param>
        public void SetLoginInfo(string token)
        {
            GlobalContext.Token = token;
        }

        /// <summary>
        /// 设置登录信息
        /// </summary>
        /// <param name="token"></param>
        public void SetLoginInfo(string token, DataPlatformUserInfo dataPlatformUserInfo)
        {
            GlobalContext.Token = token;

            GlobalContext.DataPlatformUserInfo.UserCode = dataPlatformUserInfo.UserCode;
            GlobalContext.DataPlatformUserInfo.UserName = dataPlatformUserInfo.UserName;
            //GlobalContext.DataPlatformUserInfo.UserCurrentRole = dataPlatformUserInfo.UserCurrentRole;
            GlobalContext.DataPlatformUserInfo.UserCurrentRole = "兼职切题员";
        }

        /// <summary>
        /// 设置用户角色信息
        /// </summary>
        /// <param name="userCurrentRole"></param>
        public void SetUserRole(string userCurrentRole)
        {
            if (!string.IsNullOrEmpty(userCurrentRole))
            {
                GlobalContext.DataPlatformUserInfo.UserCurrentRole = userCurrentRole;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userPass"></param>
        /// <returns></returns>
        public string GetVerifyCode()
        {
            var param = new { GlobalContext.Token, };

            var result = Get(JsonConvert.SerializeObject(param), Urls["Code"], this.GetType());

            return result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userPass"></param>
        /// <returns></returns>
        public HttpResult Login(string userCode, string userPass, string verifycode)
        {
            if (string.IsNullOrEmpty(userCode))
                throw new ArgumentException("userCode");
            if (string.IsNullOrEmpty(userPass))
                throw new ArgumentException("userPass");

            var param = new { userCode, userPass, verifycode, GlobalContext.Token };

            var result = Post(JsonConvert.SerializeObject(param), Urls["Login"], this.GetType());

            return result;
        }
    }
}