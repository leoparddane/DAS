using Service;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace win
{
    public partial class createProduct : Form
    {
        public createProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtProjectID.Text.Trim()!="" &&
                txtProjectName.Text.Trim() != "" &&
                txtCusLH.Text.Trim() != "" &&
                dataGridView1.Rows.Count>0)
            {
                var projectID = txtProjectID.Text.Trim();
                var projectName = txtProjectName.Text.Trim();
                var model = new Model.project();
                model.id = projectID;
                model.projectName = projectName;
                model.currentStatuID = (int)WF.ProjectStatusEnum.ProjectInit;
                model.date = DateTime.Now;
                model.createPerson = Public.LoginUser.userID;
                model.customerLH = txtCusLH.Text.Trim();
                if (Common.WFInstanceHelper.CreateInstance(model))
                {
                    //写入产品信息
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        try
                        {
                            var productInfo = new Model.productInfo();
                            productInfo.projectID = projectID;
                            productInfo.productID = item.Cells[0].Value.ToString();
                            productInfo.innerID = item.Cells[1].Value.ToString();
                            new BLL.ProductInfoBLL().Add(productInfo);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("添加产品信息过程发生异常");
                            break;
                        }
                    }
                    MessageBox.Show("项目创建成功");
                    //清空所有数据
                    txtCusLH.Clear();
                    txtInnerID.Clear();
                    txtProductID.Clear();
                    txtProjectID.Clear();
                    txtProjectName.Clear();
                    
                    dataGridView1.Rows.Clear();
                    //重新获取id
                    getID();
                }
                else
                    MessageBox.Show("项目创建失败");
            }
            else
                MessageBox.Show("请填写完整");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(productFile.ShowDialog()==DialogResult.OK)
            {
                string[] fileNames = productFile.FileNames;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productID=txtProductID.Text.Trim();
            string innerID= txtInnerID.Text.Trim();
            if(productID!=""&& innerID!="")
            {
                //判断是否已经添加
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if(item.Cells[0].Value.ToString()== productID)
                    {
                        MessageBox.Show("请勿重复添加");
                        return;
                    }
                }
                int index= dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = productID;
                dataGridView1.Rows[index].Cells[1].Value = innerID;
            }
            else
            {
                MessageBox.Show("请填写完整");
            }
        }

        private void createProduct_Load(object sender, EventArgs e)
        {
            getID();

        }
        protected void getID()
        {
            string produceID = "PG" + DateTime.Now.Year.ToString() + '-';
            //获取最大id并暂时保留此id到临时表
            ObjectParameter objectParameter = new ObjectParameter("newProjectID", 0);
            var newID = new Model.JingMeiEntities().getNewProjectID3(objectParameter).ToList();
            produceID += newID[0].Value.ToString("D4");
            txtProjectID.Text = produceID;
        }
    }
}
