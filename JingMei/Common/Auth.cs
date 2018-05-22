using System.Web;
namespace Common
{
    public class Auth
    {
        /// <summary>
        /// 判断密码是否正确
        /// </summary>
        /// <param name="enPwd">用户输入的密码</param>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public static bool CheckPwd(string pwd, string username)
        {
            bool result = false;
            BLL.UserBLL bll = new BLL.UserBLL();
            var user = bll.GetModel(p => p.username == username);
            if(user.pwd== Encrypt(pwd))
            {
                result = true;
            }
            return result;
        }
        public static bool CheckStatu(string username)
        {
            bool result = false;
            var count = new BLL.UserBLL().GetRecordCount(p => p.username == username && p.statu != 0);
            if (count >= 0)
                result = true;
            return result;
        }
        /// <summary>
        /// 获取密码的MD5 ToLower
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string Encrypt(string code)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(code, "MD5").ToLower();
        }


    }
}