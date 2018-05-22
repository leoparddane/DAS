using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win.Message
{
    public partial class Messages : Form
    {
        static Messages messagesDialog=null;
        List<Model.notice> notices = new List<Model.notice>();
        static Timer timer;
        static Timer openTime;
        private Messages()
        {
            InitializeComponent();
        }
        public static Messages getInstance(Timer timer,Timer openTime)
        {
            Messages.timer = timer;
            Messages.openTime = openTime;
            if (messagesDialog==null)
            {
                messagesDialog = new Messages();
            }
            return messagesDialog;
        }
      
        private void Messages_Load(object sender, EventArgs e)
        {
            //设置窗体显示位置
            int screamWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screamHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(screamWidth - this.Width + 7, screamHeight - this.Height - 12);
            if (messagesDialog == null)
            {
                messagesDialog = new Messages();
            }
            this.Height = height = 0;
            getInfos();
            //设置显示内容
            if (notices.Count > 0)
            {
                lblInfo.Text = "【" + notices[index].project.projectName + "】等待审核";
            }
            else
            {
                this.Close();
            }
        }

        private void getInfos()
        {
            //清空并重新绑定
            notices.Clear();
            //获取当前用户所有的可以审核的项目状态
            var checkItems = new BLL.CheckPermissionBLL().GetModels(p => p.userID == Public.LoginUser.userID);
            foreach (var item in checkItems)
            {
                //获取所有的未读消息
                var info = new BLL.NoticeBLL().GetModels(p => p.projectStatu == item.projectStatuID && p.statu == false);
                notices.AddRange(info);
            }
        }

        static int height = 0;
        private void showScore_Tick(object sender, EventArgs e)
        {
            if(height<=200)
            {
                height += 20;
                this.Height = height;
            }
        }
        private void Messages_FormClosing(object sender, FormClosingEventArgs e)
        {
            messagesDialog = null;
            index = 0;

            //如果点击关闭按钮则不再次查询，开启主窗口中的另一个timer
            //设置为10分钟后再次检测
            Messages.timer.Enabled = false;
            Messages.openTime.Enabled = true;
        }
        static int index = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //设为已读
            if (index < notices.Count)
                win.Public.Notice.ReadNotice(notices[index].projectID);
            //显示下一条
            if (++index< notices.Count)
            {
                lblInfo.Text = "【"+notices[index].project.projectName+"】等待审核";
            }
            else
            {
                this.Close();
            }
        }
    }
}
