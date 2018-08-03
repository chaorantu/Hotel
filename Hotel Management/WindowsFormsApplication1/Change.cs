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
    public partial class Change : Form
    {
        public Change(string roomnum)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "修改房间信息";
            CbbRoomType.TextChanged += new System.EventHandler(CbbRoomType_TextChanged);
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
           
            SqlDataAdapter com1 = new SqlDataAdapter("select RoomNum, RoomType ,RoomName from Tbl_Room where RoomNum='" + roomnum + "'", con);
            DataTable ds = new DataTable();
            com1.Fill(ds);
           
            TxtRoomNum.Text = ds.Rows[0][0].ToString();
            TxtRoomName.Text = ds.Rows[0][2].ToString();
            SqlCommand com = new SqlCommand("select RoomType  from Tbl_RoomType order by RoomPrice", con);
            SqlDataReader reader = com.ExecuteReader();
            int n = 0;
            int j=2;
            while (reader.Read())
            {
                if (reader[0].ToString().Equals(ds.Rows[0][1].ToString())==true)
                { j= n; }
                CbbRoomType.Items.Add(reader[0].ToString());
                n++;
            }
            reader.Close();
            CbbRoomType.SelectedIndex = j;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CbbRoomType.Text == "")
            {
                MessageBox.Show("请选择房型");
            }
            else if (TxtRoomName.Text == "")
            {
                MessageBox.Show("请填写房名");
            }
            else
            {
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlCommand com = new SqlCommand("update Tbl_Room set RoomType='" + CbbRoomType.Text + "',RoomName='" + TxtRoomName.Text + "',RoomPrice='" + TxtRoomPrice.Text + "' where RoomNum='" + TxtRoomNum.Text + "'", con);
                com.ExecuteNonQuery();
                MessageBox.Show("修改成功！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Management form = new Management();
            form.Show();
        }
        private void CbbRoomType_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlCommand com = new SqlCommand("select RoomPrice from Tbl_RoomType where RoomType='" + CbbRoomType.Text + "'", con);
            string num = com.ExecuteScalar().ToString();
            TxtRoomPrice.Text = num;
        }
    }
}
