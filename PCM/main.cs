using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCM
{
    public partial class main_ِِAdmin : Form
    {
        public static DbConnection Connection = new DbConnection();
        public main_ِِAdmin()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Add_item form = new Add_item();
            form.Show();
            this.Hide();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Edit_Users form = new Edit_Users();
            form.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            add_quantity form = new add_quantity();
            form.Show();
            this.Hide();
        }

        private void Button_delete_song_Click(object sender, EventArgs e)
        {
            delete_item form = new delete_item();
            form.Show();
            this.Hide();
        }

        private void main_ِِAdmin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Add_NewDevice form = new Add_NewDevice();
            form.Show();
            this.Hide();
        }

        private void Button_Delete_artist_Click(object sender, EventArgs e)
        {
            Delete_Device form = new Delete_Device();
            form.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Pricing form = new Pricing();
            form.Show();
            this.Hide();
        }

        private void BunifuFlatButton7_Click(object sender, EventArgs e)
        {
            show_price obj = new show_price();
            obj.Show();
        }
    }
}
