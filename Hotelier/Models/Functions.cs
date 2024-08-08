//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace Hotelier.Models
//{
//    public class Functions
//    {
//        private SqlConnection Con;
//        private SqlCommand Cmd;
//        //Store temporary data
//        private DataTable dt;
//        private string Constr;
//        private SqlDataAdapter sda;

//        //If database is closed, then open database
//        public int setData(String Query)
//        {
//            int Cnt;
//            if(Con.State == ConnectionState.Closed)
//            {
//                Con.Open();
//            }
//            Cmd.CommandText = Query;
//            Cnt = Cmd.ExecuteNonQuery();
//            Con.Close();
//            return Cnt;
//        }

//        public DataTable GetData(string Query)
//        {
//            dt = new DataTable();
//            sda = new SqlDataAdapter(Query, Constr);
//            sda.Fill(dt);
//            return dt;
//        }
//        //Connect Database 
//        public Functions()
//        {
//            Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Brandon\Documents\HotelierDb.mdf;Integrated Security=True;Connect Timeout=30";

//            Con = new SqlConnection(Constr);
//            Cmd = new SqlCommand();
//            Cmd.Connection = Con;
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotelier.Models
{
    public class Functions
    {
        private string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Brandon\Documents\HotelierDb.mdf;Integrated Security=True;Connect Timeout=30";

        public int SetData(string query, SqlParameter[] parameters)
        {
            int count;
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    count = cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            return count;
        }

        public DataTable GetData(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }
    }
}
