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
    public partial class SelectRoomType : Form
    {
        public SelectRoomType()
        {
            InitializeComponent();
            this.ControlBox = false;
            SqlConnection con = new SqlConnection("server=TCR-PC\\SQLEXPRESS;database=Hotel Management;uid=sa;pwd=tcr1994");
            con.Open();
            SqlCommand com = new SqlCommand("select count(*) from Tbl_RoomType", con);
             n=(int)com.ExecuteScalar();
            SqlDataAdapter com1 = new SqlDataAdapter("select RoomType, RoomPrice ,PictureLoaction from Tbl_RoomType ", con);
            DataTable ds = new DataTable();
            com1.Fill(ds);
            for (int i = 0; i < n;i++ )
            {
                PictureBox pic1 = new PictureBox();
                pic1.Name = "" + ds.Rows[i][0].ToString() + "";
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Size = new Size(200, 100);
                Label text1 = new Label();
                text1.Font = new Font("宋体", 9);
                text1.Text = ""+ds.Rows[i][0].ToString()+"\n价格："+ds.Rows[i][1].ToString()+"";
                //pic1.Location = new Point(i * 150 + 10, 10)
                this.tableLayoutPanel1.Controls.Add(pic1);
                string aa=ds.Rows[i][2].ToString();
                pic1.Image = Image.FromFile(aa);
                //text1.Location = new Point(3,3);
                text1.Parent = pic1;
                text1.BackColor = Color.Transparent;
                //this.Controls.Add(text1);
                text1.BringToFront();
                
                pic1.Click += new System.EventHandler(this.pictureBox_Click);
            }
        }
        private int n;
        private void pictureBox_Click(object sender, EventArgs e)
        {
            string roomtype = ((PictureBox)sender).Name;
            MessageBox.Show("" + roomtype + "");
            SelectRoom form = new SelectRoom(roomtype);
            form.Show();
            Hide();
        }

        private void test_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Main form = new Main();
            form.Show();
        }
    }
}
