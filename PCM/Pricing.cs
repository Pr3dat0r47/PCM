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

namespace PCM
{
    public partial class Pricing : Form
    {
        public static Pricing obj;
        public static DbConnection Connection = new DbConnection();
        public Pricing()
        {
            InitializeComponent();
            obj = this;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //main_ِِAdmin form = new main_ِِAdmin;
            //form.Show();
            //this.Hide();
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
                admin adm = new admin();
                adm.Edit_setting();
            }
            else
            {
                // user clicked no
            }
        }

        private void Pricing_Load(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string query = "select * from item where item_name like 'Playstation%' ";
            SqlDataReader da = Pricing.Connection.Read(query);
            DataTable dt = new DataTable();
            dt.Load(da);
            foreach (DataRow dr in dt.Rows)
            {
                // MessageBox.Show(item_Name);
                Pricing.obj.comboBox1.Items.Add(dr["item_name"].ToString());
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string query = "select * from item where item_name not like 'Playstation%' ";
            SqlDataReader da = Pricing.Connection.Read(query);
            DataTable dt = new DataTable();
            dt.Load(da);
            foreach (DataRow dr in dt.Rows)
            {
                // MessageBox.Show(item_Name);
                Pricing.obj.comboBox1.Items.Add(dr["item_name"].ToString());
            }
        }
    }
}
