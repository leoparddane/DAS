using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win
{
    public partial class projectInfo : Form
    {
        public projectInfo()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void bind()
        {
            if (txtProjectID.Text.Trim() != "")
            {
                var data = new BLL.ProjectInfoBLL().GetModels(p => p.id.Contains(txtProjectID.Text.Trim())).ToList();
                dataGridView1.DataSource = data;
            }
            else
            {
                var data = new BLL.ProjectInfoBLL().GetList();
                dataGridView1.DataSource = data;
            }
        }
    }
}
