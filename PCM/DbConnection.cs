using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PCM
{
    public class DbConnection
    {
        public string ConString;
        public SqlConnection con;
        public DbConnection()
        {
            ConString = "Data Source = LAPTOP-40LE9VPO; Initial Catalog = PsManager; MultipleActiveResultSets=true; Integrated Security = True";
            con = new SqlConnection(ConString);
            con.Open();
        }
        public bool Write(string Query)
        {
            //Query = "INSERT INTO [item] (item_name,price,quantity) VALUES('MirandaCan', 5, 20)";
            SqlCommand comd = new SqlCommand(Query, con);
            comd.ExecuteNonQuery();
            return false;
        }
        public SqlDataReader Read(string Query)
        {
            SqlCommand sda = new SqlCommand(Query, con);
            SqlDataReader dr = sda.ExecuteReader(); 
            return dr;
        }
        //~DbConnection()
        //{
        //        con.Close();
        //}
    }
}
