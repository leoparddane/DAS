using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF;
using win.Public;

namespace win
{
    public partial class mainFrame : Form
    {
        public mainFrame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new createProduct().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nexgNode();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ReadyUpload(WF.ProjectStatusEnum.ProjectInit).ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //更新状态为图纸设计分支
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.DiagramDesignProject);
            nexgNode();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //更新状态
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(),WF.ProjectStatusEnum.ProjectStart);
            nexgNode();
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            //更新状态为NG
            //更新状态
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.ProjectNG);
            nexgNode();
        }

        private void mainFrame_Load(object sender, EventArgs e)
        {
            //加载菜单数据库
            //menu1.DB = System.Environment.CurrentDirectory+@"\menu\option.accdb";
            //加载所有项目
            bind();
        }
        private void bind()
        {
            //ProjectService.ProjectClient service = new ProjectService.ProjectClient("ProjectService");
            //service.Open();
            ////service.getProjectStatu("a");
            //var data=service.getAllList();
            ////dataGridView1.DataSource = data;
            //service.Close();
            var models = new BLL.ProjectBLL().GetModelList();
            dataGridView1.DataSource = models;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var service =new ProjectService.ProjectClient("ProjectService");
                service.Open();
                textBox4.Text = service.getProjectStatuName(textBox3.Text.Trim());
                service.Close();
                
            }
        }

        private void reflash_Click(object sender, EventArgs e)
        {
            bind();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var service = new ProjectService.ProjectClient("ProjectService");
                service.Open();
                textBox4.Text = service.getProjectStatuName(textBox3.Text.Trim());
                service.Close();
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            nexgNode();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //更新状态为图纸设计、方案确定分支
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.DesignProject);
            nexgNode();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.DemoMaker);
            nexgNode();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.DemoMaker);
            nexgNode();
        }

        private void nexgNode()
        {
            if (Common.WFInstanceHelper.resumeBookMark(textBox1.Text.Trim(), textBox2.Text.Trim(), new WF.Project(), Public.LoginUser.userID))
                MessageBox.Show("Success");
            else
                MessageBox.Show("Error");
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            //更新状态为测试NG
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.TestNG);
            nexgNode();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //更新状态为测试OK
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.DemoOK);
            nexgNode();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //更新状态为客户确认通过，即流程完成
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.Finish);
            nexgNode();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //更新状态为客户确认NG
            Public.ProjectUtility.updateProjectStatu(textBox3.Text.Trim(), WF.ProjectStatusEnum.NO);
            nexgNode();
        }

        private void 项目准备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check(WF.ProjectStatusEnum.ProjectInit, new init.init());
        }
        /// <summary>
        /// 如果有了这个文档，就打开已有的，否则创建一个新的文档
        /// </summary>
        /// <param name="item"></param>
        private void showMid(System.Windows.Forms.Form item)
        {
            try
            {
                bool hasChild = false;
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    if (this.MdiChildren[i].Name == item.Name)
                    {
                        this.MdiChildren[i].BringToFront();
                        ((Button)this.MdiChildren[i].Controls["btnReflash"]).PerformClick();
                        //((Form)this.MdiChildren[i]).Controls[""]
                        hasChild = true;
                    }
                }
                if (!hasChild)
                {
                    item.MdiParent = this;
                    item.WindowState = FormWindowState.Maximized;
                    item.Show();
                }
            }
            catch (Exception)
            {
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void 项目评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check(WF.ProjectStatusEnum.ProjectEvaluation, new evaluation.evaluation());
        }

        private void check(WF.ProjectStatusEnum status,Form form)
        {
            var service = new UserService.UserClient("UserService");
            service.Open();
            if (!service.checkPerimission(Public.LoginUser.userID, (int)status, (int)PermissionEnum.LOOK))
            {
                MessageBox.Show("无此权限");
            }
            else
            {
                showMid(form);
            }
            service.Close();
        }

        private void 项目启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check(WF.ProjectStatusEnum.ProjectStart, new start.start());
        }

        private void 设计方案项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check(WF.ProjectStatusEnum.DesignProject, new designProject.designProject());
        }

        private void 替代项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check(WF.ProjectStatusEnum.DiagramDesignProject, new DiagramDesignProject.DiagramDesignProject());
        }

        private void 样品制作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check(WF.ProjectStatusEnum.DemoMaker, new demo.demo());
        }

        private void 样品确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check(WF.ProjectStatusEnum.Check, new check.check());
        }

        private void 关于AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new load().ShowDialog();
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var messageDialog = Message.Messages.getInstance(hasMessage, openHasMessage);
            messageDialog.Show();
        }
        delegate void closeTime();
        private void hasMessage_Tick(object sender, EventArgs e)
        {
            try
            {
                //关闭另一个计时器
                openHasMessage.Enabled = false;
                var messageService = new ProjectService.ProjectClient("ProjectService");
                messageService.Open();
                if(messageService.hasUnreadMessage(Public.LoginUser.userID))
                {
                    Message.Messages.getInstance(hasMessage,openHasMessage).Show();
                }
                //审核未通过的记录
                if (messageService.hasNGMessage(Public.LoginUser.userID))
                {
                    Message.NGMessage.getInstance(hasMessage, openHasMessage).Show();
                }
                messageService.Close();

                //如果因为网络异常修改了tick时间，则此处恢复
                hasMessage.Interval = 1000;
            }
            catch (Exception)
            {
                //如果发生异常
                //按照tcp的时间策略周期性的检测网络是否通畅
                if(hasMessage.Interval<int.MaxValue)
                    hasMessage.Interval += hasMessage.Interval;
            }
        }

        private void openHasMessage_Tick(object sender, EventArgs e)
        {
            hasMessage.Enabled = true;
        }

        private void 项目进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMid(new projectInfo());
        }
    }
}
