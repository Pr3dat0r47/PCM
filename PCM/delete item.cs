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
    public partial class delete_item : Form
    {
        public static delete_item d;
        public static DbConnection Connection = new DbConnection();
        admin fill = new admin();
        public delete_item()
        {
            InitializeComponent();
            d = this;
            
            
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            main_ِِAdmin form = new main_ِِAdmin();
            form.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

      

        private void delete_item_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true && comboBox1.SelectedItem != null)
            {
                if (MessageBox.Show("هل انت متأكد من حذف '"+comboBox1.SelectedItem.ToString()+"' ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // user clicked yes
                    fill.Delete_item();
                }
                else
                {
                    // user clicked no
                }
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (delete_item.d.radioButton3.Checked)
            {
                delete_item.d.comboBox1.Items.Clear();
                string query = "select * from item where item_name not like 'Playstation%' ";
                SqlDataReader da = Pricing.Connection.Read(query);
                DataTable dt = new DataTable();
                dt.Load(da);
                foreach (DataRow dr in dt.Rows)
                {
                    // MessageBox.Show(item_Name);
                    delete_item.d.comboBox1.Items.Add(dr["item_name"].ToString());
                }
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string query = "select * from item where item_name like 'Playstation%' ";
            SqlDataReader da = Pricing.Connection.Read(query);
            DataTable dt = new DataTable();
            dt.Load(da);
            foreach (DataRow dr in dt.Rows)
            {
                // MessageBox.Show(item_Name);
                comboBox1.Items.Add(dr["item_name"].ToString());
            }
        }
    }
}
