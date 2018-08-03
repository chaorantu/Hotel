using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Landing : Form
    {
        public Landing()
        {
            InitializeComponent();
            Ok.Focus();
            this.ControlBox = false;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            string username = UserNameTxt.Text;
            string userpassword = UserPasswordTxt.Text;
            if (username == "" || userpassword == "")
            {
                if (username != "")
                { MessageBox.Show("用户名不能为空！"); }
                else if (userpassword != "")
                { MessageBox.Show("密码不能为空！"); }
                else
                { MessageBox.Show("用户名和密码不能为空！"); }
            }
            else
            {
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                string sql = "select count(*) from TBL_WORKER where UserName='" + username + "' and UserPassword='" + userpassword + "'";
                SqlCommand com = new SqlCommand(sql, con);
                int num = (int)com.ExecuteScalar();
                if (num == 1)
                {
                    SqlCommand com1 = new SqlCommand("select Status from TBL_WORKER where UserName='" + username + "'", con);
                    int i = (int)com1.ExecuteScalar();
                    if (i == 0)
                    {
                        Hide();
                        MessageBox.Show("管理员登陆成功!");
                        Management form = new Management();
                        form.Show();
                        
                    }
                    if (i == 1)
                    {
                        Hide();
                        MessageBox.Show("前台登陆成功!");
                        Main form = new Main();
                        form.Show();
                        
                        
                    }
                    
                }
                else
                { MessageBox.Show("用户名或密码错误！"); }

            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Landing_Load(object sender, EventArgs e)
        {
            this.Text = "登陆";
        }
    }
}
