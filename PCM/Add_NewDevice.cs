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
    public partial class Add_NewDevice : Form
    {
        public static Add_NewDevice obj;
        admin add = new admin();
        public Add_NewDevice()
        {
            InitializeComponent();
            obj = this;
        }

        private void label4_Click(object sender, EventArgs e)
        {



        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            main_ِِAdmin form = new main_ِِAdmin();
            form.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void add_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes
                add.add_device();
            }
            else
            {
                // user clicked no
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
