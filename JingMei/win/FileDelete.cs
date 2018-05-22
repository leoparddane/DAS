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
    public partial class FileDelete : Form
    {
        WF.ProjectStatusEnum statu;
        public FileDelete(WF.ProjectStatusEnum statu)
        {
            this.statu = statu;
            InitializeComponent();

            //判断权限
            if (!Public.Permission.CheckPermission(statu, Public.PermissionEnum.DELETE))
            {
                MessageBox.Show("无此权限");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> rowIndexs = new List<int>();
            //判断是否选中的数量大于0
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //只判断一次，在判断的同时把所有选中的行索引保存下来
                if ((bool)item.Cells[0].EditedFormattedValue)
                {
                    rowIndexs.Add(item.Index);
                }
            }
            List<int> rowIndexs2 = new List<int>();
            //判断是否选中的数量大于0
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                //只判断一次，在判断的同时把所有选中的行索引保存下来
                if ((bool)item.Cells[0].EditedFormattedValue)
                {
                    rowIndexs2.Add(item.Index);
                }
            }
            if (rowIndexs.Count+ rowIndexs2.Count <= 0)
            {
                MessageBox.Show("请选择要删除的文件");
                return;
            }
            bool downLoadErrorFlag = false;

            //获取要删除的文件信息
            foreach (var item in rowIndexs)
            {
                ResourceService.ResourceClient service = new ResourceService.ResourceClient("ResourceService");
                service.Open();
                //检测服务器上是否有此文件
                if (service.deleteFile(Convert.ToInt32(dataGridView1.Rows[item].Cells[1].Value)))
                {

                }
                else
                {
                    MessageBox.Show(dataGridView1.Rows[item].Cells[4].Value + "无此文件,请联系管理员");
                    downLoadErrorFlag = true;
                }
                service.Close();
            }
            //删除备注
            var notesBll = new BLL.ResourcePathBLL();
            foreach (var item in rowIndexs2)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[item].Cells[1].Value.ToString());
                    var model = notesBll.GetModel(p => p.id == id);
                    notesBll.Delete(model, false);
                }
                catch (Exception)
                {
                }
            }
            if (!downLoadErrorFlag)
            {
                MessageBox.Show("所有文件删除成功");
                bind();
            }
        }

        void bind()
        {
            var source = new BLL.zz_ext_resourceInfoBLL().GetModels(p => p.statu == (int)statu).ToList();
            dataGridView1.DataSource = source;

            var notes = new BLL.zz_ext_resourceNotesBLL().GetModels(p => p.statu == (int)statu).ToList();
            dataGridView2.DataSource = notes;
        }

        private void ReadyDownload_Load(object sender, EventArgs e)
        {
            bind();
        }
    }

}
