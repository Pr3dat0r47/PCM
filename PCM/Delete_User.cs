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
    public partial class Delete_User : Form
    {
        public static Delete_User obj;
        admin del_user = new admin();
        public static DbConnection Connection = new DbConnection();
        public Delete_User()
        {
            InitializeComponent();
            obj = this;
            del_user.delete_user_fill_combobox();
        }

        private void add_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes
                del_user.Delete_user();

            }
            else
            {
                // user clicked no
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            main_ِِAdmin form = new main_ِِAdmin();
            form.Show();
            this.Hide();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Delete_User_Load(object sender, EventArgs e)
        {

        }
    }
}
