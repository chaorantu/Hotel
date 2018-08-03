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
    public partial class SelectRoom : Form
    {
        private string roomtype;
        public SelectRoom(string roomtype0)
        {
            InitializeComponent();
            this.ControlBox = false;
            roomtype = roomtype0;
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Tbl_Guest where RoomType='"+roomtype+"' order by State", con);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].HeaderText = "房间号";
            dataGridView1.Columns[1].HeaderCell.Value = "房间类型";
            dataGridView1.Columns[2].HeaderCell.Value = "房间价格";
            dataGridView1.Columns[3].HeaderCell.Value = "房间名";
            dataGridView1.Columns[6].HeaderCell.Value = "开始时间";
            dataGridView1.Columns[7].HeaderCell.Value = "结束时间";
            dataGridView1.Columns[8].HeaderCell.Value = "状态";
            int n=dataGridView1.RowCount;
            for (int i = 0; i < n; i++)
            {
                if (dataGridView1.Rows[i].Cells[8].Value.Equals("0"))
                {
                    dataGridView1.Rows[i].Cells[8].Value= "未预约";
                }
                else if (dataGridView1.Rows[i].Cells[8].Value.Equals("1"))
                {
                    dataGridView1.Rows[i].Cells[8].Value = "已预约";
                }
                else if (dataGridView1.Rows[i].Cells[8].Value.Equals("2"))
                {
                    dataGridView1.Rows[i].Cells[8].Value = "正在使用";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string starttime = DtStartTime.Text;
            string endtime = DtEndTime.Text;
            DateTime dat1=DateTime.Parse(starttime);
            DateTime dat2=DateTime.Parse(endtime);
            //DateTime dat0=DateTime.Parse(DateTime.Now.ToString());
            TimeSpan spn1 = (dat1 - DateTime.Now);
            TimeSpan spn2 = (dat2 - dat1);
            string n = spn1.Days.ToString();
            string m = spn2.Days.ToString();
            if (int.Parse(n) >= 0 && int.Parse(m) > 0)
            {
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlCommand com = new SqlCommand("select count(*) from Tbl_Guest where RoomType='" + roomtype + "' and (State='0'or StartDate>='" + endtime + "' or EndDate<='" + starttime + "')", con);
                int num = (int)com.ExecuteScalar();
                if (num == 0)
                {
                    MessageBox.Show("没有符合的住房！");
                }
                else
                {
                    Hide();
                    AddGuest form = new AddGuest(starttime, endtime, roomtype);
                    form.Show();
                }
            }
            else
            { MessageBox.Show("输入有误！请重新输入！"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            SelectRoomType form = new SelectRoomType();
            form.Show();
        }
    }
}
