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
    public partial class Add_NewUser : Form
    {
        public static Add_NewUser obj;
        public static DbConnection con = new DbConnection();
        admin add_user = new admin();
        public Add_NewUser()
        {
            InitializeComponent();
            obj = this;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            main_ِِAdmin form = new main_ِِAdmin();
            form.Show();
            this.Hide();
        }

        private void add_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes
                add_user.Add_user();
            }
            else
            {
                // user clicked no
            }
        }

        private void Add_NewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
