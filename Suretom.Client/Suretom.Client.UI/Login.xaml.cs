using Suretom.Client.Common;
using Suretom.Client.IService;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Suretom.Client.UI
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private NameValueCollection config = ConfigurationManager.AppSettings;

        //参数一：产生几个字符的验证码图片  参数二：验证码的形式(数字、字母、数字字母混合都有)
        private ValidCode validCode = new ValidCode(5, ValidCode.CodeType.Alphas);

        public Login()
        {
            InitializeComponent();

            //var loginService = GlobalContext.Resolve<ILoginService>();

            //var str = loginService.GetVerifyCode();

            //byte[] byteArray = Encoding.Default.GetBytes(str);

            //Stream stream = new MemoryStream(byteArray);

            //this.image1.Source = BitmapFrame.Create(stream);

            this.imageCode.Source = BitmapFrame.Create(validCode.CreateCheckCodeImage());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (config != null)
                {
                    txtName.Text = GetValue("login");
                    if (bool.TryParse(GetValue("checked"), out bool check) && check)
                    {
                        txtPassword.Password = decode(GetValue("password"));
                        chkName.IsChecked = check;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                this.imageCode.Source = BitmapFrame.Create(validCode.CreateCheckCodeImage());
                e.Handled = true;
            }
        }

        public class ValidCode
        {
            #region Private Fields

            private const double PI = 3.1415926535897932384626433832795;

            private const double PI2 = 6.283185307179586476925286766559;

            //private readonly int _wordsLen = 4;

            private int _len;

            private CodeType _codetype;

            private readonly Single _jianju = (float)18.0;

            private readonly Single _height = (float)24.0;

            private string _checkCode;

            #endregion Private Fields

            #region Public Property

            public string CheckCode
            {
                get
                {
                    return _checkCode;
                }
            }

            #endregion Public Property

            #region Constructors

            /// <summary>

            /// public constructors

            /// </summary>

            /// <param name="len"> 验证码长度 </param>

            /// <param name="ctype"> 验证码类型：字母、数字、字母+ 数字 </param>

            public ValidCode(int len, CodeType ctype)
            {
                this._len = len;

                this._codetype = ctype;
            }

            #endregion Constructors

            #region Public Field

            public enum CodeType
            { Words, Numbers, Characters, Alphas }

            #endregion Public Field

            #region Private Methods

            private string GenerateNumbers()
            {
                string strOut = "";

                System.Random random = new Random();

                for (int i = 0; i < _len; i++)
                {
                    string num = Convert.ToString(random.Next(10000) % 10);

                    strOut += num;
                }

                return strOut.Trim();
            }

            private string GenerateCharacters()
            {
                string strOut = "";

                System.Random random = new Random();

                for (int i = 0; i < _len; i++)
                {
                    string num = Convert.ToString((char)(65 + random.Next(10000) % 26));

                    strOut += num;
                }

                return strOut.Trim();
            }

            //

            private string GenerateAlphas()
            {
                string strOut = "";

                string num = "";

                System.Random random = new Random();

                for (int i = 0; i < _len; i++)
                {
                    if (random.Next(500) % 2 == 0)
                    {
                        num = Convert.ToString(random.Next(10000) % 10);
                    }
                    else
                    {
                        num = Convert.ToString((char)(65 + random.Next(10000) % 26));
                    }

                    strOut += num;
                }

                return strOut.Trim();
            }

            private System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
            {
                System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

                // 将位图背景填充为白色

                System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);

                graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);

                graph.Dispose();

                double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;

                for (int i = 0; i < destBmp.Width; i++)
                {
                    for (int j = 0; j < destBmp.Height; j++)
                    {
                        double dx = 0;

                        dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;

                        dx += dPhase;

                        double dy = Math.Sin(dx);

                        // 取得当前点的颜色

                        int nOldX = 0, nOldY = 0;

                        nOldX = bXDir ? i + (int)(dy * dMultValue) : i;

                        nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                        System.Drawing.Color color = srcBmp.GetPixel(i, j);

                        if (nOldX >= 0 && nOldX < destBmp.Width

                         && nOldY >= 0 && nOldY < destBmp.Height)
                        {
                            destBmp.SetPixel(nOldX, nOldY, color);
                        }
                    }
                }

                return destBmp;
            }

            #endregion Private Methods

            #region Public Methods

            public Stream CreateCheckCodeImage()
            {
                string checkCode;

                switch (_codetype)
                {
                    case CodeType.Alphas:

                        checkCode = GenerateAlphas();

                        break;

                    case CodeType.Numbers:

                        checkCode = GenerateNumbers();

                        break;

                    case CodeType.Characters:

                        checkCode = GenerateCharacters();

                        break;

                    default:

                        checkCode = GenerateAlphas();

                        break;
                }

                this._checkCode = checkCode;

                MemoryStream ms = null;

                //

                if (checkCode == null || checkCode.Trim() == String.Empty)

                    return null;

                Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * _jianju)), (int)_height);

                Graphics g = Graphics.FromImage(image);

                try
                {
                    Random random = new Random();

                    g.Clear(Color.White);

                    // 画图片的背景噪音线

                    for (int i = 0; i < 18; i++)
                    {
                        int x1 = random.Next(image.Width);

                        int x2 = random.Next(image.Width);

                        int y1 = random.Next(image.Height);

                        int y2 = random.Next(image.Height);

                        g.DrawLine(new Pen(Color.FromArgb(random.Next()), 1), x1, y1, x2, y2);
                    }

                    Font font = new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold);

                    LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);

                    if (_codetype != CodeType.Words)
                    {
                        for (int i = 0; i < checkCode.Length; i++)
                        {
                            g.DrawString(checkCode.Substring(i, 1), font, brush, 2 + i * _jianju, 1);
                        }
                    }
                    else
                    {
                        g.DrawString(checkCode, font, brush, 2, 2);
                    }

                    // 画图片的前景噪音点

                    for (int i = 0; i < 150; i++)
                    {
                        int x = random.Next(image.Width);

                        int y = random.Next(image.Height);

                        image.SetPixel(x, y, Color.FromArgb(random.Next()));
                    }

                    // 画图片的波形滤镜效果

                    if (_codetype != CodeType.Words)
                    {
                        image = TwistImage(image, true, 3, 1);
                    }

                    // 画图片的边框线

                    g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                    ms = new System.IO.MemoryStream();

                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                }
                finally
                {
                    g.Dispose();

                    image.Dispose();
                }

                return ms;
            }

            #endregion
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = txtName.Text.Trim();
                var password = txtPassword.Password.Trim();
                var verifycode = txtCode.Text.Trim();

                verifycode = "879hz";

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(txtPassword.Password.Trim()))
                {
                    MessageBox.Show("用户名密码输入完整");
                    return;
                }

                if (string.IsNullOrEmpty(txtCode.Text.Trim()))
                {
                    MessageBox.Show("请输入验证码");
                    return;
                }

                btnLogin.Content = "登录中...";
                var loginService = GlobalContext.Resolve<ILoginService>();

                var result = loginService.Login(name, txtPassword.Password.Trim(), txtCode.Text.Trim());

                if (result.Success)
                {
                    //记录用户名密码
                    if (chkName.IsChecked.Value)
                    {
                        SetValue("checked", "true");
                        SetValue("login", name);
                        SetValue("password", encode(txtPassword.Password.Trim()));
                    }

                    loginService.SetLoginInfo(result.Data["token"].ToString());

                    GlobalContext.UserInfo = new UserInfo
                    {
                        UserName = name,
                        PassWord = password,
                        verifycode = verifycode
                    };

                    var mainForm = new MainWindow();
                    mainForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mainForm.WindowState = WindowState.Maximized;
                    mainForm.Show();
                    this.Close();
                }
                else
                {
                    btnLogin.Content = "安 全 登 录";
                    MessageBox.Show(this, result.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                btnLogin.Content = "安 全 登 录";
                log.Error(ex);
            }
        }

        private bool CheckKey(string key) => config.AllKeys.Contains(key);

        private string GetValue(string key) => config.AllKeys.Contains(key) ? config[key]?.ToString() : "";

        private void SetValue(string key, string value = "")
        {
            if (config.AllKeys.Contains(key))
            {
                Configuration temp = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                temp.AppSettings.Settings[key].Value = value;
                temp.Save();
            }
        }

        private string encode(string str)
        {
            string htext = "";

            for (int i = 0; i < str.Length; i++)
            {
                htext = htext + (char)(str[i] + 10 - 1 * 2);
            }
            return htext;
        }

        private string decode(string str)
        {
            string dtext = "";

            for (int i = 0; i < str.Length; i++)
            {
                dtext = dtext + (char)(str[i] - 10 + 1 * 2);
            }
            return dtext;
        }
    }
}