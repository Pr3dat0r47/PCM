using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PCM
{
    public class Playstation : Item
    {
        int DeviceID;
        bool Availability;
        public DateTime STime ,ETime;
        public void StartTime ()
        {
            this.Availability = false;
            STime = DateTime.Now;
            string Query = "UPDATE item SET start_time = '"+ STime.ToString() +"' WHERE item_name ='" + this.Name + "'";
            Form1.Connection.Write(Query);
            //DateTime m = new DateTime(2019, 3, 1, 7, 0, 0);
            //var date1 = new DateTime(2019, 3, 1, 9, 0, 0);
            //label1.Text = (date1 - m).TotalMinutes.ToString();
        }
        public int EndTime ()
        {
            string Query = "select start_time from item where item_name = '" + this.Name +"'";
            SqlDataReader dr = Form1.Connection.Read(Query);
            Query = "UPDATE item SET start_time = '0' WHERE item_name ='" + this.Name + "'";
            Form1.Connection.Write(Query);
            while (dr.Read())
            {
                STime = Convert.ToDateTime(dr["start_time"]);
            }
            ETime = DateTime.Now;
            int TotalTime = Convert.ToInt32((ETime - STime).TotalMinutes);
            this.Availability = true;
            return TotalTime;
        }
    }
}