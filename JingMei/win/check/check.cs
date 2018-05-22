using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win.check
{
    public partial class check : Form
    {
        WF.ProjectStatusEnum statu = WF.ProjectStatusEnum.Check;
        public check()
        {
            InitializeComponent();
        }

        private void btnReflash_Click(object sender, EventArgs e)
        {
            bind();
        }
        void bind()
        {
            var list = new BLL.ProjectBLL().GetModels(p => p.currentStatuID == (int)statu).ToList();
            if (txtProjectID.Text.Trim() != "")
                list = list.Where(p => p.id.Contains( txtProjectID.Text.Trim())).ToList();
            dataGridView1.DataSource = list;
            dataGridView1.ClearSelection();
        }

        private void evaluation_Load(object sender, EventArgs e)
        {
            bind();
        }

        private void btnOK_Click(object sender, EventArgs e)
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
            checks(WF.ProjectStatusEnum.Finish);
            
            bind();
        }

        

        private void checks(WF.ProjectStatusEnum status)
        {
            bool result = true;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //更新状态
                if ((bool)item.Cells[0].EditedFormattedValue)
                {
                    string projectID = item.Cells[1].Value.ToString().Trim();
                    Public.ProjectUtility.updateProjectStatu(projectID, status);
                    if (Common.WFInstanceHelper.resumeBookMark(item.Cells[2].Value.ToString().Trim(), projectID, new WF.Project(), Public.LoginUser.userID))
                    {
                        Public.Notice.updateNotice(projectID, status);
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            if (result)
            {
                MessageBox.Show("审批成功");
            }
            else
            {
                MessageBox.Show("审批失败");
            }
        }

        private void btnNG_Click(object sender, EventArgs e)
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
            checks(WF.ProjectStatusEnum.NO);
            bind();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                new ReadyUpload(statu).ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                new ReadyDownload(statu).ShowDialog();
            }
            catch (Exception)
            {
            }
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
