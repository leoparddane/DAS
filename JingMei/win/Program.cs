using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using win.ViewModel;

namespace win
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //过场界面
            new load().ShowDialog();
            //登录界面
            var loginModel=new loginModel();
            new login(loginModel).ShowDialog();
            if (loginModel.Success)
            {
                Application.Run(new mainFrame());
            }
        }
    }
}
