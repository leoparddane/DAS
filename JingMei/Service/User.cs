using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class User : IUser
    {
        public bool checkPwd(string username, string pwd)
        {
            bool result = false;
            if (Common.Auth.CheckPwd(pwd, username))
            {
                //是否禁用
                if (Common.Auth.CheckStatu(username))
                {
                    result=true;
                }
            }
            return result;
        }

        public int getUserID(string username)
        {
            return new BLL.UserBLL().GetModel(p=>p.username==username).id;
        }
        /// <summary>
        /// 检查用户是否具有查看功能的权限
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="projectStatuID"></param>
        /// <returns></returns>
        public bool checkPerimission(int userid,int projectStatuID, int type)
        {
            bool result = false;
            var user = new BLL.UserBLL().GetModel(p => p.id == userid);
            if(user!=null)
            {
                var model = new BLL.permissionBLL().GetModel(p => p.departmentID == user.departmentID && p.projectStatusID == projectStatuID);
                if (model!=null)
                {
                    try
                    {
                        result = check(Convert.ToInt32(model.permissions), type);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 检查用户是否具有某个流程的审核权限
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="projectStatuID"></param
        /// <param name="type"></param>
        /// <returns></returns>
        public bool hsaCheckPermission(int userid,int projectStatuID)
        {
            bool result = false;
            var user = new BLL.UserBLL().GetModel(p => p.id == userid);
            if (user != null)
            {
                if (new BLL.CheckPermissionBLL().Exist(p => p.userID == userid && p.projectStatuID == projectStatuID))
                {

                    result = true;
                }
            }
            return result;
        }
        public bool check(int permission,int type)
        {
            bool result = false;
            if(type==1)
            {
                result = (permission % 10) == 1;
            }
            else
            {
                for (int i = 0; i < type-1; i++)
                {
                    permission /= 10;
                }
                result = (permission % 10) == 1;
            }
            return result;
        }
    }
}
