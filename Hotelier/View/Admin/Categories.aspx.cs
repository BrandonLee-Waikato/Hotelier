using Hotelier.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotelier.View.Admin
{
    public partial class Categories : System.Web.UI.Page
    {     
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

        }
        protected void SaveBtm_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;
                string Label = LabelTb.Value;

                // 创建SQL命令和参数
                string query = "INSERT INTO CategoryTbl (CatName, CatLabels) VALUES (@CatName, @Label)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CatName", CatName),
                    new SqlParameter("@Label", Label)
                };

                // 创建Functions对象并调用setData方法
                Functions functions = new Functions();
                functions.SetData(query, parameters);

                ErrMsg.InnerText = "Room type added successfully.";
            }
            catch (Exception ex)
            {
                // 仅向用户显示通用错误消息，避免泄露敏感信息
                ErrMsg.InnerText = "Error adding room type. Please try again.";
                // 实际项目中应记录异常详细信息，例如使用日志文件
                Console.WriteLine(ex.ToString());
            }
        }

        //protected void SaveBtm_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string CatName = CatNameTb.Value;
        //        string Label = LabelTb.Value;
        //        String Query = "insert into CategoryTbl(CatName, CatLabels) values('{0}','{1}')";
        //        string query = "INSERT INTO CategoryTbl (CatName, CatLabels) VALUES (@CatName, @Label)";

        //        //Query = string.Format(Query, CatName, Label);
        //        Con.setData(Query);
        //        ErrMsg.InnerText = "Room type added";
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrMsg.InnerText = ex.ToString();
        //    }
        //}
    }
}