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
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "房间管理";
      
        }

        private void Management_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn select = new DataGridViewCheckBoxColumn();
            select.HeaderText = "选择";
            dataGridView1.Columns.Insert(0, select);
            refresh();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                    con.Open();
                    string roomnum=dataGridView1.Rows[i].Cells[1].Value.ToString();
                    SqlCommand com = new SqlCommand("delete from TBL_ROOM where RoomNum='"+roomnum+"'",con);
                    com.ExecuteNonQuery();
                    MessageBox.Show(""+roomnum+"房间信息删除成功！");
                    
                }
            } refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            AddRoom form = new AddRoom();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            RoomType form = new RoomType();
            form.Show();
        }
        private void refresh()
        {
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Tbl_Room", con);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[1].HeaderText = "房间号";
            dataGridView1.Columns[2].HeaderCell.Value = "房间名";
            dataGridView1.Columns[3].HeaderCell.Value = "房间类型";
            dataGridView1.Columns[4].HeaderCell.Value = "房间价格";
        }

        private void button4_Click(object sender, EventArgs e)
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
            if (n!=1)
            { MessageBox.Show("请确定要修改的项！");
            refresh();
            }
            else
            {
                string roomnum = dataGridView1.Rows[j].Cells[1].Value.ToString();
                Hide();
                Change form = new Change(roomnum);
                form.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Landing form = new Landing();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
