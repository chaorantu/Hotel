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
    public partial class AddGuest : Form
    {
        public AddGuest(string starttime,string endtime,string roomtype0)
        {
            InitializeComponent();
            this.ControlBox = false;
            roomtype = roomtype0;
            comboBox1.TextChanged += new System.EventHandler(CbbRoomNum_TextChanged);
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlCommand com = new SqlCommand("select distinct RoomNum from Tbl_Guest where RoomType='" + roomtype + "' and (State='0'or StartDate>='" + endtime + "' or EndDate<='" + starttime + "')", con);
             SqlDataReader reader= com.ExecuteReader();
             while (reader.Read())
             {
                 comboBox1.Items.Add(reader[0].ToString());
             }
             reader.Close();
             TxtRoomType.Text = roomtype;
             TxtStartTime.Text = starttime;
             TxtEndTime.Text = endtime;
            DateTime dat1=DateTime.Parse(starttime);
            DateTime dat2=DateTime.Parse(endtime);
             SqlCommand com1 = new SqlCommand("select RoomPrice from Tbl_RoomType where RoomType='" + TxtRoomType.Text + "'", con);
             string pri = com1.ExecuteScalar().ToString();
             TimeSpan spn = (dat2 - dat1);
             string n = spn.Days.ToString();
             TxtRoomPrice.Text = (int.Parse(n) * int.Parse(pri)).ToString();
        }
        private string roomtype;

        private void AddGuest_Load(object sender, EventArgs e)
        {

        }

        private void CbbRoomNum_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlCommand com = new SqlCommand("select RoomName from Tbl_Room where RoomNum='" + comboBox1.Text + "'", con);
            string name = com.ExecuteScalar().ToString();
            TxtRoomName.Text = name;
        }
        private void CbbRoomNum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = TxtName.Text;
            string idnum = TxtIdNum.Text;
            if (name == "")
            { MessageBox.Show("姓名不能为空！"); }
            else if (idnum == "")
            { MessageBox.Show("身份证号不能为空！"); }
            else if (TxtIdNum.Text.Length != 18)
            { MessageBox.Show("身份证号应为18位"); }
            else
            {
                SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
                con.Open();
                SqlCommand com = new SqlCommand("select State from Tbl_Guest where RoomNum='" + comboBox1.Text + "'", con);
                string state = com.ExecuteScalar().ToString();
                if (state.Equals("0"))
                {
                    SqlCommand com1 = new SqlCommand("update Tbl_Guest set Name='" + name + "',IdNum='" + idnum + "',StartDate='" + TxtStartTime.Text + "' ,EndDate='" + TxtEndTime.Text + "',State='1'where RoomNum='" + comboBox1.Text + "'", con);
                    com1.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand com2 = new SqlCommand("insert into Tbl_Guest(RoomNum,RoomName,RoomType,RoomPrice,State,StartDate,EndDate,Name,IdNum)values('" + comboBox1.Text + "','" + TxtRoomName.Text + "','" + TxtRoomType.Text + "','" + TxtRoomPrice.Text + "','1','" + TxtStartTime.Text + "','" + TxtEndTime.Text + "','" + name + "','" + idnum + "')", con);
                    com2.ExecuteNonQuery();
                }
                MessageBox.Show("添加成功！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            SelectRoom form = new SelectRoom(roomtype);
            form.Show();
        }
    }
}
