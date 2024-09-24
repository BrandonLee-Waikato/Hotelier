using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotelier.Models
{
    public class Functions
    {
        private string Constr;

        // 构造函数，初始化数据库连接
        public Functions()
        {
            Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Brandon\Documents\HotelierDb.mdf;Integrated Security=True;Connect Timeout=30";
        }

        // 执行不带参数的查询（INSERT、UPDATE、DELETE）
        public int SetData(string Query)
        {
            int Cnt;
            using (SqlConnection Con = new SqlConnection(Constr))
            {
                using (SqlCommand Cmd = new SqlCommand(Query, Con))
                {
                    if (Con.State == ConnectionState.Closed)
                        Con.Open();
                    Cnt = Cmd.ExecuteNonQuery();
                }
            }
            return Cnt;
        }

        // 执行不带参数的查询（SELECT），返回 DataTable
        public DataTable GetData(string Query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Con = new SqlConnection(Constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(Query, Con))
                {
                    sda.Fill(dt);
                }
            }
            return dt;
        }

        // 执行带参数的查询（SELECT），返回 DataTable
        public DataTable GetData(string Query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Con = new SqlConnection(Constr))
            {
                using (SqlCommand Cmd = new SqlCommand(Query, Con))
                {
                    if (parameters != null)
                    {
                        Cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(Cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 执行带参数的查询（INSERT、UPDATE、DELETE）
        public int SetData(string Query, SqlParameter[] parameters)
        {
            int Cnt;
            using (SqlConnection Con = new SqlConnection(Constr))
            {
                using (SqlCommand Cmd = new SqlCommand(Query, Con))
                {
                    if (parameters != null)
                    {
                        Cmd.Parameters.AddRange(parameters);
                    }
                    if (Con.State == ConnectionState.Closed)
                        Con.Open();
                    Cnt = Cmd.ExecuteNonQuery();
                }
            }
            return Cnt;
        }
    }
}
