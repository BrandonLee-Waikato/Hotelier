using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hotelier.Models
{
    public class Functions
    {
        private string Constr;

        // 构造函数，初始化数据库连接
        //public Functions()
        //{
        //    // 获取当前运行目录的绝对路径
        //    string basePath = AppDomain.CurrentDomain.BaseDirectory;

        //    // 拼接数据库文件的完整路径
        //    string dbPath = System.IO.Path.Combine(basePath, @"Assets\Database\HotelierDb.mdf");

        //    // 更新连接字符串为绝对路径  C:\project\Assets\Database
        //    Constr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
        //}

        //public Functions()
        //{
        //    Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=HotelierDb;Integrated Security=True;Connect Timeout=30";
        //} 

        //public Functions()
        //{
        //    Constr = @"Data Source=EC2AMAZ-B2S1NMD;Initial Catalog=HotelierDb;Integrated Security=True;Connect Timeout=30";
        //}

        //public Functions()
        //{
        //    Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Brandon\Documents\HotelierDb.mdf;Integrated Security=True;Connect Timeout=30";
        //}
        //public Functions()
        //{
        //    Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Hotelier\Assets\Database\HotelierDb.mdf;Integrated Security=True;Connect Timeout=30";
        //}


        public Functions()
        {
            Constr = ConfigurationManager.ConnectionStrings["HotelierConnection"].ConnectionString;
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
