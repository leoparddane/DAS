using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win.init
{
    public partial class init : Form
    {
        WF.ProjectStatusEnum statu = WF.ProjectStatusEnum.ProjectInit;
        public init()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new createProduct().ShowDialog();
            bind();
        }

        private void btnreflash_Click(object sender, EventArgs e)
        {
            bind();
        }
        void bind()
        {
            var list=new BLL.ProjectBLL().GetModels(p => p.currentStatuID == (int)WF.ProjectStatusEnum.ProjectInit).ToList();
            if (txtProjectID.Text.Trim() != "")
                list = list.Where(p => p.id.Contains(txtProjectID.Text.Trim())).ToList();
            dataGridView1.DataSource = list;
        }

        private void init_Load(object sender, EventArgs e)
        {
            bind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                new ReadyUpload(statu).ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                new ReadyDownload(statu).ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!Public.Common.hasSelect(dataGridView1))
            {
                return;
            }
            //检查用户是否具有审核的权限
            try
            {
                var checkService = new UserService.UserClient("UserService");
                checkService.Open();
                if (!checkService.hsaCheckPermission(Public.LoginUser.userID, (int)statu))
                {
                    MessageBox.Show("无审核权限");
                    return;
                }
                checkService.Close();
            }
            catch (Exception)
            {
                
            }
            bool final = true;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //选中状态
                if((bool)item.Cells[0].EditedFormattedValue)
                {
                    string projectID = item.Cells[1].Value.ToString().Trim();
                    if (Common.WFInstanceHelper.resumeBookMark(item.Cells[2].Value.ToString().Trim(), projectID, new WF.Project(),Public.LoginUser.userID))
                    {
                        try
                        {
                            int createPerson = Convert.ToInt32(item.Cells[6].Value.ToString().Trim());
                            //创建对应的消息提醒结构
                            var notice = new Model.notice();
                            //notice.userID = createPerson;
                            notice.projectID = projectID;
                            notice.projectStatu = (int)WF.ProjectStatusEnum.ProjectInit;
                            notice.statu = false;
                            notice.time = DateTime.Now;
                            new BLL.NoticeBLL().Add(notice);
                        }
                        catch (Exception)
                        {
                        }
                    }  
                    else
                    {
                        final = false;
                    }
                }
            }
            if(final)
            {
                MessageBox.Show("提交成功");
            }
            else
            {
                MessageBox.Show("提交失败");
            }
            bind();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                new FileDelete(statu).ShowDialog();
            }
            catch (Exception)
            {
            }
            
        }

        static bool selectStatu = false;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //全选
            if (e.RowIndex == -1)
            {
                selectStatu = !selectStatu;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    item.Cells[0].Value = selectStatu;
                }
            }
            else
            {
                //单选
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new ProductInfo(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()).ShowDialog();
        }
    }
}
