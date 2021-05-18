using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PCM
{
    public class User
    {
        public bool Login()
        {
            bool valid_user = false;

            string queryadmin = "Select * from [user] where username='" + Form2.user.Username_textBox.Text.Trim() + "'  and password= '" + Form2.user.Password_textBox.Text.Trim() + "' and isAdmin = 1";
            SqlDataReader dt_admin = main_ِِAdmin.Connection.Read(queryadmin);
            DataTable dt = new DataTable();
            dt.Load(dt_admin);


            if (dt.Rows.Count == 1)
            {
                
                main_ِِAdmin admin = new main_ِِAdmin();
                Form2.user.Hide();
                admin.Show();
                dt.Clear();
            }
            else
            {

                string queryuser = "Select * from [user] where username='" + Form2.user.Username_textBox.Text.Trim() + "'  and password= '" + Form2.user.Password_textBox.Text.Trim() + "' and isAdmin = 0";
                SqlDataReader dt_user = main_ِِAdmin.Connection.Read(queryuser);
                dt.Load(dt_user);

                if (dt.Rows.Count == 1)
                {

                    Form2.user.Hide();
                    Form1 login_form = new Form1();
                    
                }
                else
                {
                    MessageBox.Show("Check your username or password ");
                }

               
            }
            return valid_user;
        }
        public void Logout()
        {
             
        }

      

    }
    public class admin : User
    {
       public void Add_user()
        {
            string username;
            string password;
            username = Add_NewUser.obj.textBox1.Text;
            password = Add_NewUser.obj.textBox2.Text;
            if (Add_NewUser.obj.textBox1.Text != null && Add_NewUser.obj.textBox2.Text == Add_NewUser.obj.textBox3.Text)
            {
                string query = "insert into [user] (username,password) values('" + username + "','" + password + "')";
                SqlDataReader da = Add_NewUser.con.Read(query);
                MessageBox.Show("تم اضافة المستخدم بنجاح");
            }
            else
            {
                MessageBox.Show("هناك خطأ راجع البيانات");

            }
        }
        public void Add_Item()
        {
            string Item_name;
            int Item_price;
            string Icon_path;
            string query;

            DbConnection write = new DbConnection();
            
            

            Item_name = Add_item.add.Item_name.Text;
            Item_price = int.Parse(Add_item.add.item_price.Text);
            Icon_path = Add_item.add.icon_Path;

            query = "INSERT into [item] (item_name,price,icon) VALUES('" + Item_name + "'," + Item_price + ",'" + Icon_path + "')";
            write.Write(query);
            MessageBox.Show("تم اضافة السلعة بنجاح");

        }
      
       
        public void Edit_setting()
        {
            if(Pricing.obj.comboBox1.SelectedItem != null && Pricing.obj.textBox1.Text == Pricing.obj.textBox2.Text)
            {
                string query = "update  item set price = "+int.Parse(Pricing.obj.textBox1.Text)+ " where item_name = '"+ Pricing.obj.comboBox1.SelectedItem + "'";
                SqlDataReader da = delete_item.Connection.Read(query);
            }
        }

        public void delete_user_fill_combobox()
        {
            Delete_User.obj.comboBox1.Items.Clear();
            string query = "Select * from [user] ";
            SqlDataReader da = delete_item.Connection.Read(query);
            DataTable dt = new DataTable();
            dt.Load(da);
            foreach (DataRow dr in dt.Rows)
            {
                // MessageBox.Show(item_Name);
                Delete_User.obj.comboBox1.Items.Add(dr["username"].ToString());
            }

        }
        public void Delete_user()
        {
            if (Delete_User.obj.comboBox1.SelectedItem != null)
            {
                string query = "delete from [user] where username = '"+Delete_User.obj.comboBox1.SelectedItem+"'";
                SqlDataReader da = Delete_User.Connection.Read(query);
            }
        }


        public void fill_combobox()
        {
            delete_item.d.comboBox1.Items.Clear();
            string query = "Select * from [item] ";
            SqlDataReader da = delete_item.Connection.Read(query);
            DataTable dt = new DataTable();
            dt.Load(da);
            foreach(DataRow dr in dt.Rows)
            {   
               // MessageBox.Show(item_Name);
                delete_item.d.comboBox1.Items.Add(dr["item_name"].ToString());
            }

        }
        public void delete_item_combobox()
        {
            string query;
            SqlDataReader da;
            if (delete_item.d.radioButton3.Checked)
            {
                delete_item.d.comboBox1.Items.Clear();
                query = "select * from item where item_name not like 'Playstation%' ";
                da = Pricing.Connection.Read(query);
                DataTable dt = new DataTable();
                dt.Load(da);
                foreach (DataRow dr in dt.Rows)
                {
                    // MessageBox.Show(item_Name);
                    delete_item.d.comboBox1.Items.Add(dr["item_name"].ToString());
                }
            }
            else if (delete_item.d.radioButton4.Checked)
            {
                delete_item.d.comboBox1.Items.Clear();
                query = "select * from item where item_name like 'Playstation%' ";
                da = Pricing.Connection.Read(query);
                DataTable dt = new DataTable();
                dt.Load(da);
                foreach (DataRow dr in dt.Rows)
                {
                    // MessageBox.Show(item_Name);
                    delete_item.d.comboBox1.Items.Add(dr["item_name"].ToString());
                }
            }
        }
        public void Delete_item()
        {
            
            string selected_item;
            if (delete_item.d.comboBox1.SelectedItem != null)
            {
                SqlDataReader da;
                selected_item = delete_item.d.comboBox1.SelectedItem.ToString();
                string get_item_id = "select item_id from item where item_name = '"+selected_item+"' ";
                da = delete_item.Connection.Read(get_item_id);
                DataTable dt = new DataTable();
                dt.Load(da);
                // int item_id = int.Parse(dt.Rows[0].ToString());
                int item_id = int.Parse(dt.Rows[0][0].ToString());
                da.Close();
                
                String query = "delete from [reciept_item] where item_id = "+item_id+"";
                da = delete_item.Connection.Read(query);
                da.Close();
                string query2 = "delete from [item] where item_name = '"+selected_item+"' ";
                da = delete_item.Connection.Read(query2);
                da.Close();

                delete_item.d.comboBox1.Text = "";
                delete_item_combobox();
                MessageBox.Show("تم حذف المنتج");
            }
        }
        public void add_device()
        {

            DbConnection write = new DbConnection();



            string Item_name = Add_NewDevice.obj.textBox1.Text;
            int Item_price = int.Parse(Add_NewDevice.obj.textBox2.Text);
            string playstation = "Playstation " + Add_NewDevice.obj.textBox1.Text;

            string query = "INSERT into [item] (item_name,price,isDevice) VALUES('" + playstation + "'," + Item_price + ",1)";
            write.Write(query);
            MessageBox.Show("تم اضافة الجهاز");
            Add_NewDevice.obj.textBox1.Clear();
            Add_NewDevice.obj.textBox2.Clear();
        }
        public void addQuantity()
        {
            DbConnection write = new DbConnection();
            string item_name = add_quantity.obj.select_itemcomboBox1.SelectedItem.ToString();
            int quantity = int.Parse(add_quantity.obj.textBox1.Text);
            string query = "UPDATE [item] set quantity = "+quantity+" where item_name = '"+item_name+"'";
            write.Write(query);
            add_quantity.obj.fill_comobox();
            MessageBox.Show("تم اضافة الكمية");
            
        }

        public void ShowPrices()
        {
            DbConnection read = new DbConnection();
            string query = "select item_name,quantity,price from item order by item_name";
            SqlDataReader dr =  read.Read(query);
            DataTable dt = new DataTable();
            dt.Load(dr);
            show_price.obj.dataGridView1.DataSource = dt;
        }
    }
}
