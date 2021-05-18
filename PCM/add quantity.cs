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
    public partial class add_quantity : Form
    {
        public static add_quantity obj;
        admin admin = new admin();
        public add_quantity()
        {
            InitializeComponent();
            obj = this;
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
                admin.addQuantity();
            }
            else
            {
                // user clicked no
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        public void fill_comobox()
        {
            select_itemcomboBox1.Items.Clear();
            string query = "select * from item where item_name not like 'Playstation%' ";
            SqlDataReader da = Pricing.Connection.Read(query);
            DataTable dt = new DataTable();
            dt.Load(da);
            foreach (DataRow dr in dt.Rows)
            {
                // MessageBox.Show(item_Name);
                select_itemcomboBox1.Items.Add(dr["item_name"].ToString());
            }
        }
        public void Add_quantity_Load(object sender, EventArgs e)
        {
            fill_comobox();
        }
    }
}
