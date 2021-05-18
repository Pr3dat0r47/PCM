using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;

namespace PCM
{
    public partial class Form1 : Form 
    {
        public static DbConnection Connection = new DbConnection();
        public static Form1 temp;
        public Form1()
        {
            InitializeComponent();
            FillFlow_Devices();
        }
        public void FillFlow_Devices()
        {
            DevicesUc temp;
            string Query = "select * from item where isDevice = 1";
            SqlDataReader dr = Connection.Read(Query);
            while (dr.Read())
            {
                temp = new DevicesUc(dr["item_name"].ToString())
                {
                    DeviceID = Convert.ToInt32(dr["item_id"])
                };
                temp.Margin = new System.Windows.Forms.Padding(50, 30, 30, 30);
                flowLayoutPanel1.Controls.Add(temp);
            }
            //temp = this;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            User test = new User();
            test.Login();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //DevicesUc Test = new DevicesUc();
            //Test.Margin = new System.Windows.Forms.Padding(90, 30, 30, 30);
            //flowLayoutPanel1.Controls.Add(Test);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(64)))), ((int)(((byte)(69)))));
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(64)))), ((int)(((byte)(69)))));
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
        }

        private void BunifuFlatButton7_Click(object sender, EventArgs e)
        {

        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            show_price obj = new show_price();
            obj.Show();
        }
    }
}
