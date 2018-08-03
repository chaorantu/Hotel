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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString();
            this.ControlBox = false;
            System.Windows.Forms.Timer time1=new System.Windows.Forms.Timer();
            timer1.Tick+=new EventHandler(timer1_Tick);
            timer1.Start();
            DataGridViewCheckBoxColumn select = new DataGridViewCheckBoxColumn();
            select.HeaderText = "选择";
            dataGridView1.Columns.Insert(0, select);
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlCommand com = new SqlCommand("update Tbl_Guest set State='2' where StartDate<='" + DateTime.Now.ToString() + "'and EndDate>='" + DateTime.Now.ToString() + "'", con);
            com.ExecuteScalar();
            refresh();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            SelectRoomType form = new SelectRoomType();
            form.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string roomnum = TxtRoomNum.Text;
            if (roomnum == "")
            { MessageBox.Show("请输入房号！"); }
            else
            {
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Tbl_Guest where RoomNum='" + roomnum + "'", con);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
                ChangeState();
            }
        }
        private void refresh()
        {
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Tbl_Guest", con);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[1].HeaderText = "房间号";
            dataGridView1.Columns[2].HeaderCell.Value = "房间类型";
            dataGridView1.Columns[3].HeaderCell.Value = "房间价格";
            dataGridView1.Columns[4].HeaderCell.Value = "房间名";
            dataGridView1.Columns[5].HeaderCell.Value = "房客姓名";
            dataGridView1.Columns[6].HeaderCell.Value = "身份证";
            dataGridView1.Columns[7].HeaderCell.Value = "开始时间";
            dataGridView1.Columns[8].HeaderCell.Value = "结束时间";
            dataGridView1.Columns[9].HeaderCell.Value = "状态";
            ChangeState();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlDataAdapter data1 = new SqlDataAdapter("select *from Tbl_Guest where State='1'", con);
                DataTable tab1 = new DataTable();
                data1.Fill(tab1);
                dataGridView1.DataSource = tab1;
                dataGridView1.AllowUserToAddRows = false;
                ChangeState();
            }
            else if (radioButton2.Checked==true)
            {
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlDataAdapter data2 = new SqlDataAdapter("select *from Tbl_Guest where State='2'", con);
                DataTable tab2 = new DataTable();
                data2.Fill(tab2);
                dataGridView1.DataSource = tab2;
                dataGridView1.AllowUserToAddRows = false;
                ChangeState();
            }
            else if (radioButton3.Checked==true)
            {
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlDataAdapter data3 = new SqlDataAdapter("select *from Tbl_Guest where State='3'", con);
                DataTable tab3 = new DataTable();
                data3.Fill(tab3);
                dataGridView1.DataSource = tab3;
                dataGridView1.AllowUserToAddRows = false;
                ChangeState();
            }
            else
            {
                MessageBox.Show("请选择查找类型！");
            }
        }
        private void ChangeState()
        {
            int n = dataGridView1.RowCount;
            for (int i = 0; i < n; i++)
            {
                if (dataGridView1.Rows[i].Cells[9].Value.Equals("0"))
                {
                    dataGridView1.Rows[i].Cells[9].Value = "未预约";
                }
                else if (dataGridView1.Rows[i].Cells[9].Value.Equals("1"))
                {
                    dataGridView1.Rows[i].Cells[9].Value = "已预约";
                }
                else if (dataGridView1.Rows[i].Cells[9].Value.Equals("2"))
                {
                    dataGridView1.Rows[i].Cells[9].Value = "正在使用";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[9].Value = "过期";
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = 0; int j = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    n++;
                    j = i;
                }
            }
            if (n != 1)
            {
                MessageBox.Show("请确定选择的房间！");
                refresh();
            }
            else
            {
                string name = dataGridView1.Rows[j].Cells[5].Value.ToString();
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlCommand com = new SqlCommand("update Tbl_Guest set State='3'where Name='" + name + "'and State='2' ", con);
                string m=com.ExecuteNonQuery().ToString();
                    if (m.Equals("1")==true)
                    { MessageBox.Show("" + name + "退房成功！"); }
                    else
                    { MessageBox.Show("退房失败，请选择正确的房号！"); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                    con.Open();
                    string name = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    SqlCommand com = new SqlCommand("delete from Tbl_Guest where Name='" + name + "'and State='3'", con);
                    string m = com.ExecuteNonQuery().ToString();
                    if (m.Equals("1") == true)
                    {
                        MessageBox.Show("" + name + "删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！只能删除过期的信息！");
                    }
                }
            } refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            Landing form = new Landing();
            form.Show();
        }
        private void remind()
        {
            for ( int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                   
                    SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                    con.Open();
                    string name = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string roomname = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    SqlCommand com = new SqlCommand("select count(*) from Tbl_Guest where Name='" + name + "'and EndDate ='" + DateTime.Now.ToString() + "'", con);
                    int m = (int)com.ExecuteScalar();
                    if (m == 1)
                    {
                        MessageBox.Show(""+roomname+"号房今日到期，请提醒" + name + "退房！");
                    }
                
            } 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int n = 0; int j = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    n++;
                    j = i;
                }
            }
            if (n != 1)
            {
                MessageBox.Show("请确定选择的房间！");
                refresh();
            }
            else
            {
                string name = dataGridView1.Rows[j].Cells[5].Value.ToString();
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlCommand com = new SqlCommand("delete from Tbl_Guest where Name='" + name + "'and State='1'", con);
                string m=com.ExecuteNonQuery().ToString();
                if (m.Equals("1") == true)
                {
                    MessageBox.Show("" + name + "退订成功！");
                }
                else
                {
                    MessageBox.Show("退订失败，请选择正确的房号！");
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            remind();
        }
    }
}
