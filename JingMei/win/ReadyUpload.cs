using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win
{
    public partial class ReadyUpload : Form
    {
        string projectID = "";
        WF.ProjectStatusEnum statu;
        public ReadyUpload(WF.ProjectStatusEnum statu)
        {
            this.statu = statu;
            InitializeComponent();
            //判断权限
            if (!Public.Permission.CheckPermission(statu, Public.PermissionEnum.UPLOAD))
            {
                MessageBox.Show("无此权限");
                this.Close();
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in openFileDialog1.FileNames)
                {
                    bool flag = false;
                    //判断是否存在相同的文件
                    foreach (var i in listBox1.Items)
                    {
                        if (i.ToString() == item)
                        {
                            flag = true;
                        }
                    }
                    if (true == flag)
                    {
                        MessageBox.Show("文件已存在");
                    }
                    else
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (projectID != "")
            {
                if (listBox1.Items.Count > 0)
                {
                    bool hasError = false;
                    var service = new ResourceService.ResourceClient("ResourceService");
                    service.Open();
                    foreach (var item in listBox1.Items)
                    {
                        try
                        {
                            service.UploadAsync(projectID, item.ToString(), Public.LoginUser.userID, File.OpenRead(item.ToString()));
                        }
                        catch (Exception)
                        {
                            hasError = true;
                        }
                    }
                    //service.Upload(textBox1.Text.Trim(), openFileDialog1.OpenFile());
                    service.Close();
                    if (hasError)
                        MessageBox.Show("上传过程中发生了异常");
                    else
                    {
                        MessageBox.Show("上传成功");
                    }

                }
                else
                {
                    if (txtInfo.Text.Trim() == "")
                    {
                        //必须填备注
                        MessageBox.Show("请选择需要上传的文件或填写备注信息");
                        return;
                    }
                }
                //备注
                if (txtInfo.Text.Trim() != "")
                {
                    var model = new Model.resourcePath();
                    model.dntime = DateTime.Now;
                    model.note = txtInfo.Text.Trim();
                    model.projectID = projectID;
                    model.statu = (int)statu;
                    model.type = 2;
                    model.uploadPerson = Public.LoginUser.userID;
                    try
                    {
                        new BLL.ResourcePathBLL().Add(model);
                        MessageBox.Show("添加备注成功");
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择项目");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                projectID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblProjectName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblProjectName.ForeColor = Color.Black;
            }
        }

        private void ReadyUpload_Load(object sender, EventArgs e)
        {
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
            var models = new BLL.ProjectBLL().GetModels(p => p.currentStatuID == (int)statu).ToList();
            dataGridView1.DataSource = models;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (MessageBox.Show("是否删除?", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                listBox1.Items.RemoveAt(index);
            }
        }
    }
}
