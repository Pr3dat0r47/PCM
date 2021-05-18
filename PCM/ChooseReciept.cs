using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCM
{
    public partial class ChooseReciept : Form
    {
        public DevicesUc Device;
        public ChooseReciept(DevicesUc U)
        {
            InitializeComponent();
            Fill_combobox();
            Device =  U;
        }
        public void Fill_combobox()
        {
            comboBox1.Items.Clear();
            string query = "Select * from reciept where isPaid = 0";
            SqlDataReader da = Form1.Connection.Read(query);
            while (da.Read())
            {
                comboBox1.Items.Add(da["reciept_id"].ToString());
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار الفاتورة أو اضف فاتورة جديدة", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {
                string Query = "INSERT into [reciept_item] (reciept_id,item_id) VALUES(" + comboBox1.SelectedText + "," + Device.DeviceID + ")";
                Form1.Connection.Write(Query);
                Device.SentToReciept = true;
            }
        }
    }
}
