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
using System.IO;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class RoomType : Form
    {
        public RoomType()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "房间类型";
            DataGridViewCheckBoxColumn select = new DataGridViewCheckBoxColumn();
            select.HeaderText = "选择";
            dataGridView1.Columns.Insert(0, select);
            refresh();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtRoomType.Text == "")
            { MessageBox.Show("请填写房型！"); }
            else if (TxtRoomPrice.Text == "")
            { MessageBox.Show("请填写价格！"); }
            else
            {
                string roomtype = TxtRoomType.Text;
                string roomprice = TxtRoomPrice.Text;
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlCommand com = new SqlCommand("insert into Tbl_RoomType(RoomType,RoomPrice,PictureLoaction)values('" + roomtype + "','" + roomprice + "','"+textBox1.Text+"')", con);
                com.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
                refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Management form = new Management();
            form.Show();
        }
        private void refresh()
        {
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Tbl_RoomType order by RoomPrice", con);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[1].HeaderText = "房间类型";
            dataGridView1.Columns[2].HeaderCell.Value = "房间价格";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                    con.Open();
                    string roomtype = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    SqlCommand com = new SqlCommand("delete from Tbl_RoomType where RoomType='" + roomtype + "'", con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("" + roomtype + "房型删除成功！");

                }
            } refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileinfo = new FileInfo(openFileDialog1.FileName);
                textBox1.Text = fileinfo.FullName;
            }
        }
    }
}
