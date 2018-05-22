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
    public partial class ReadyDownload : Form
    {
        WF.ProjectStatusEnum statu;
        public ReadyDownload(WF.ProjectStatusEnum statu)
        {
            this.statu = statu;
            InitializeComponent();

            //判断权限
            if (!Public.Permission.CheckPermission(statu, Public.PermissionEnum.DOWNLOAD))
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
                if((bool)item.Cells[0].EditedFormattedValue)
                {
                    rowIndexs.Add(item.Index);
                }
            }
            if(rowIndexs.Count<=0)
            {
                MessageBox.Show("请选择要保存的文件");
                return;
            }
            bool downLoadErrorFlag = false;
            //选择要保存的位置
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                string savePath = folderBrowserDialog1.SelectedPath;
                //保存所有文件
                //获取要保存的文件信息
                foreach (var item in rowIndexs)
                {
                    ResourceService.ResourceClient service = new ResourceService.ResourceClient("ResourceService");
                    service.Open();
                    //检测服务器上是否有此文件
                    try
                    {
                        Stream stream = service.Download(Convert.ToInt32(dataGridView1.Rows[item].Cells[1].Value));
                        if (stream != null)
                        {
                            if (stream.CanRead)
                            {
                                string filename = dataGridView1.Rows[item].Cells[4].Value.ToString();
                                filename = filename.Substring(filename.LastIndexOf('\\'));
                                using (FileStream fs = new FileStream(savePath + filename, FileMode.Create, FileAccess.Write, FileShare.None))
                                {
                                    const int bufferLength = 1024;
                                    byte[] myBuffer = new byte[bufferLength];
                                    int count;
                                    while ((count = stream.Read(myBuffer, 0, bufferLength)) > 0)
                                    {
                                        fs.Write(myBuffer, 0, count);
                                    }
                                    fs.Close();
                                    stream.Close();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(dataGridView1.Rows[item].Cells[4].Value + "无此文件,请联系管理员");
                        downLoadErrorFlag = true;
                        //return;
                    }
                    service.Close();
                }
                if(!downLoadErrorFlag)
                {
                    MessageBox.Show("所有文件下载成功");
                }
            }
        }

        void bind()
        {
            var source = new BLL.zz_ext_resourceInfoBLL().GetModels(p=>p.statu==(int)statu).ToList();
            dataGridView1.DataSource = source;

            var notes = new BLL.zz_ext_resourceNotesBLL().GetModels(p => p.statu == (int)statu ).ToList();
            dataGridView2.DataSource = notes;
        }

        private void ReadyDownload_Load(object sender, EventArgs e)
        {
            bind();
        }
    }
    
}
