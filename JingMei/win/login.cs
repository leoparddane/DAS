using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using win.ViewModel;

namespace win
{
    public partial class login : Form
    {
        loginModel model;
        public login(loginModel model)
        {
            this.model = model;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
#if DEBUG
            model.Success = true;
#endif
            var username = txtUsername.Text.Trim();
            var pwd = txtPwd.Text.Trim();

            

            //密码
            var service = new UserService.UserClient("UserService");
            try
            {
                service.Open();
                if (service.checkPwd(username, pwd))
                {
                    //是否禁用
                    if (Common.Auth.CheckStatu(username))
                    {
                        Public.LoginUser.username = username;
                        var userService = new UserService.UserClient("UserService");
                        userService.Open();
                        Public.LoginUser.userID = userService.getUserID(username);
                        userService.Close();

                        model.Success = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户已禁用");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                    return;
                }
                service.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接到服务器，请联系管理员");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
#if DEBUG
            txtUsername.Text = "a";
            txtPwd.Text = "123456";
            this.button1.PerformClick();
#endif

            //bind();
        }
        private void bind()
        {
            IList<ComboboxItem> li = new List<ComboboxItem>();
            comboBox1.Items.Clear();
            foreach (var item in new BLL.DepartmentBLL().GetList())
            {
                li.Add(new ComboboxItem() { Key=item.id,Value=item.departmentName});
                
            }
            //comboBox1.Items.Add(li);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.DataSource = li;
            comboBox1.SelectedIndex = 0;
        }
        public class ComboboxItem
        {
            public int Key { get; set; }
            public object Value { get; set; }
            
        }
    }
}
