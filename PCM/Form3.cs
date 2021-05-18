using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace PCM
{
    public partial class Add_item : Form
    {
        public static Add_item add;
        public string icon_name;
        public string icon_Path;

        public Add_item()
        {
            InitializeComponent();
            add = this;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

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

        private void delete_Button_Click(object sender, EventArgs e)
        {
            admin addItem = new admin();
            addItem.Add_Item();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void BunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    icon_Path = fi.FullName;
                }
                item_pic.Text = icon_Path;
            }
        }
    }
}
