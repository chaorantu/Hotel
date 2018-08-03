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
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "新增房间";
            CbbFloor.TextChanged += new System.EventHandler(CbbFloor_TextChanged);
            CbbRoomType.TextChanged += new System.EventHandler(CbbRoomType_TextChanged);
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlCommand com = new SqlCommand("select RoomType from Tbl_RoomType order by RoomPrice", con);
           SqlDataReader reader = com.ExecuteReader();
           while (reader.Read())
           {
               CbbRoomType.Items.Add(reader[0].ToString());
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CbbFloor.Text == "")
            { MessageBox.Show("请选择楼层！"); }
            else if (TxtRoomNum.Text == "")
            { MessageBox.Show("请选择填写房号！"); }
            else if (CbbRoomType.Text == "")
            { MessageBox.Show("请选择房型！"); }
            else if (TxtRoomName.Text == "")
            { MessageBox.Show("请填写房名！"); }
            else
            {
                string roomnum = TxtRoomNum.Text;
                string roomtype = CbbRoomType.Text;
                string roomprice = TxtRoomPrice.Text;
                string roomname = TxtRoomName.Text;
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlCommand com = new SqlCommand("insert into Tbl_Room(RoomNum,RoomName,RoomType,RoomPrice)values('" + roomnum + "','" + roomname + "','" + roomtype + "','" + roomprice + "')", con);
                com.ExecuteNonQuery();
                SqlCommand com1 = new SqlCommand("insert into Tbl_Guest(RoomNum,RoomName,RoomType,RoomPrice,State)values('" + roomnum + "','" + roomname + "','" + roomtype + "','" + roomprice + "','0')", con);
                com1.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
               
                TxtRoomNum.Text = (int.Parse(TxtRoomNum.Text) + 1).ToString();
            }
        }

        private void CbbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CbbFloor_TextChanged(object sender, EventArgs e)
        {
            TxtRoomNum.Text = CbbFloor.Text + "01";

        }
        private void CbbRoomType_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlCommand com = new SqlCommand("select RoomPrice from Tbl_RoomType where RoomType='"+CbbRoomType.Text+"'", con);
            string num = com.ExecuteScalar().ToString();
            TxtRoomPrice.Text = num;
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Management form = new Management();
            form.Show();
        }
    }
}
