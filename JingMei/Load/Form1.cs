using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Load
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<ServiceHost> serviceHost;
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建服务并加载
            serviceHost = new List<ServiceHost>();
            serviceHost.Add(new ServiceHost(typeof(Service.Project)));
            serviceHost.Add(new ServiceHost(typeof(Service.User)));

            ////上传服务
            //var host = new ServiceHost(typeof(Service.Resource));
            //BasicHttpBinding binding = new BasicHttpBinding();
            //binding.TransferMode = TransferMode.Streamed;
            //binding.MaxReceivedMessageSize = 20971520;
            //host.AddServiceEndpoint(typeof(Service.IResource), binding, "");
            //serviceHost.Add(host);

            serviceHost.Add(new ServiceHost(typeof(Service.Resource)));
            foreach (var item in serviceHost)
            {
                item.Open();
            }
            button2.Enabled = true;
            button1.Enabled = false;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in serviceHost)
            {
                item.Close();
            }
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            button1.PerformClick();
            this.Visible=false;
            this.Hide();
#endif
        }
    }
}
