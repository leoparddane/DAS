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
    public partial class NGMessage : Form
    {
        static NGMessage NGMessageDialog =null;
        List<Model.notice> notices = new List<Model.notice>();
        static Timer timer;
        static Timer openTime;
        private NGMessage()
        {
            InitializeComponent();
        }
        public static NGMessage getInstance(Timer timer,Timer openTime)
        {
            NGMessage.timer = timer;
            NGMessage.openTime = openTime;
            if (NGMessageDialog==null)
            {
                NGMessageDialog = new NGMessage();
            }
            return NGMessageDialog;
        }
      
        private void NGMessage_Load(object sender, EventArgs e)
        {
            //设置窗体显示位置
            int screamWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screamHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(screamWidth - this.Width + 7, screamHeight - this.Height - 12);
            if (NGMessageDialog == null)
            {
                NGMessageDialog = new NGMessage();
            }
            this.Height = height = 0;
            getInfos();
            //设置显示内容
            if (notices.Count > 0)
            {
                lblInfo.Text = "【" + notices[index].project.projectName + "】在流程【" + notices[index].projectStatu1.name + "】中审核NG";
            }
            else
            {
                this.Close();
            }
        }

        private void getInfos()
        {
            //清空并重新绑定
            this.notices.Clear();
            //获取所有的未读消息
            var userid = Public.LoginUser.userID;
            this.notices = new BLL.NoticeBLL().GetModels(p => p.userID== userid && p.statu == false).ToList();
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
        private void NGMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            NGMessageDialog = null;
            index = 0;

            //如果点击关闭按钮则不再次查询，开启主窗口中的另一个timer
            //设置为10分钟后再次检测
            NGMessage.timer.Enabled = false;
            NGMessage.openTime.Enabled = true;
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
                lblInfo.Text = "【" + notices[index].project.projectName + "】在流程【"+ notices[index].projectStatu1.name+ "】中审核NG";
            }
            else
            {
                this.Close();
            }
        }
    }
}
