using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class admin
    {
        public static int GetUserID(string username)
        {
            var bll = new BLL.adminBLL();
            var id = bll.GetModel(p => p.username == username).id;
            return id;
        }
        public static string GetUserName(int id)
        {
            var bll = new BLL.adminBLL();
            var name = bll.GetModel(p => p.id == id).username;
            return name;
        }
    }
}
