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
    public partial class ProductInfo : Form
    {
        string projectID = "";
        public ProductInfo(string projectID)
        {
            this.projectID = projectID;
            InitializeComponent();
        }

        private void ProductInfo_Load(object sender, EventArgs e)
        {
            bind();
        }
        protected void bind()
        {
            //查询基本信息
            var project = new BLL.ProjectBLL().GetModel(p => p.id == projectID) ;
            if(project!=null)
            {
                //填充信息
                txtProjectID.Text = project.id;
                txtProjectName.Text = project.projectName;
                txtCusLH.Text = project.customerLH;
                //查询产品信息
                var list = new BLL.ProductInfoBLL().GetModels(p => p.projectID == projectID).ToList();
                dataGridView1.DataSource = list;
            }
        }
    }
}
