using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PCM
{
    class reciept
    {
        public int reciept_id;
        public DateTime reciept_date;
        public int total_items;
        public float total_price;
        public bool isPaid;
        DbConnection myconn = new DbConnection();

        public void create_reciept()
        {
            reciept_date = DateTime.Now;
            total_items = 0;
            total_price = 0;
            string initialize_reciept = "insert into reciept (reciept_date,total_items,total_price) values(GETDATE(),'" + total_items + "','" + total_price + "')";
            myconn.Write(initialize_reciept);
            string get_id = "select reciept_id from reciept where total_items=0";
            var reader = myconn.Read(get_id);
            while (reader.Read())
                this.reciept_id = Convert.ToInt32(reader["reciept_id"]);
            reader.Close();
        }

        public void buy_item(string item_name)
        {

            int item_id = 0;
            string search_itemID="select item_id from item where item_name='"+item_name+"'";
            var myreader = myconn.Read(search_itemID);
            while (myreader.Read())
                item_id = Convert.ToInt32(myreader["item_id"]);
            myreader.Close();
            string buy = "insert into reciept_item (reciept_id,item_id) values ('" + this.reciept_id + "','" + item_id + "')";
            myconn.Write(buy);
        }

        public void remove_bought_item(string undesired_item)
        {
            int item_id = 0;
            string search_itemID = "select item_id from item where item_name='" + undesired_item + "'";
            var myreader = myconn.Read(search_itemID);
            while (myreader.Read())
                item_id = Convert.ToInt32(myreader["item_id"]);
            myreader.Close();
            string remove_item = "delete from reciept_item where item_id='" + item_id + "' ";
            myconn.Write(remove_item);
        }

        public Dictionary<Item,int> get_items()
        {
            Dictionary<Item, int> sold_items = new Dictionary<Item, int>();
            string get_ids = "select item_id from reciept_item where reciept_id='" + this.reciept_id + "'";
            var rd = myconn.Read(get_ids);
            int quantityInreciept = 0;
            for(int i=0; rd.Read(); i++)
            {
                string get_names = "select item_name,quantity,price,isDevice from item where item_id='" + Convert.ToInt32(rd[0]) + "'";
                Item sitem = new Playstation();
                var rd1 = myconn.Read(get_names);
                while (rd1.Read())
                {                   
                    sitem.Name= Convert.ToString(rd1[0]);
                    sitem.Quantity = Convert.ToInt32(rd1[1]);
                    sitem.Price = (float)rd1[2];
                    sitem.isDevice = Convert.ToBoolean(rd1[3]);

                }                    
                rd1.Close();

                string get_quantity= "select count (reciept_id) from reciept_item where item_id='" + Convert.ToInt32(rd[0]) + "'";
                var rd2 = myconn.Read(get_quantity);
                while (rd2.Read())
                    quantityInreciept = Convert.ToInt32(rd1[0]);
                rd2.Close();
                sold_items.Add(sitem, quantityInreciept);
                this.total_items++;
            }

            return sold_items;
        }

        public void print_reciept()
        {

        }
    }
}
