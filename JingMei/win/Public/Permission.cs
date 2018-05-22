using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF;

namespace win.Public
{
    class Permission
    {
        public static bool CheckPermission(ProjectStatusEnum statu, PermissionEnum permission)
        {
            bool result = false;
            //检查用户是否具有审核的权限
            try
            {
                var checkService = new UserService.UserClient("UserService");
                checkService.Open();
                result = checkService.checkPerimission(Public.LoginUser.userID, (int)statu, (int)permission);
                checkService.Close();
            }
            catch
            {

            }
            return result;
        }
    }
}
