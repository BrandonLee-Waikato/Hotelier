using Hotelier.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            ShowCategories();
        }

        private void ShowCategories()
        {
            string Query = "select CatId as Id, CatName as Categories, CatLabels from CategoryTb1";
            CategoriesGV.DataSource = Con.GetData(Query);
            CategoriesGV.DataBind();
            CategoriesGV.HeaderRow.Cells[1].Text = "ID";
            CategoriesGV.HeaderRow.Cells[2].Text = "Room Type";
            CategoriesGV.HeaderRow.Cells[3].Text = "Label";
        }
        //protected void SaveBtm_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string CatName = CatNameTb.Value;
        //        string Label = LabelTb.Value;
        //        System.Diagnostics.Debug.WriteLine("CatName: " + CatName + ", Label: " + Label);
        //        // 创建SQL命令和参数
        //        string query = "INSERT INTO CategoryTb1 (CatName, CatLabels) VALUES (@CatName, @Label)";
        //        SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@CatName", CatName),
        //            new SqlParameter("@Label", Label)
        //        };

        //        // 创建Functions对象并调用setData方法
        //        Functions functions = new Functions();
        //        functions.SetData(query, parameters);
        //        ShowCategories();

        //        ErrMsg.InnerText = "Room type added successfully.";
        //    }
        //    catch (Exception ex)
        //    {
        //        // 仅向用户显示通用错误消息，避免泄露敏感信息
        //        ErrMsg.InnerText = "Error adding room type. Please try again. Detailed error: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
        //    }
        //}

        protected void SaveBtm_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;
                string Label = LabelTb.Value;
                string Query = "insert into CategoryTb1 values('{0}','{1}')";
                //string Query = "INSERT INTO CategoryTb1 (CatName, CatLabels) VALUES (@CatName, @Label)";

                Query = string.Format(Query, CatName, Label);
                Con.SetData(Query);
                ShowCategories();
                ErrMsg.InnerText = "Room type added";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.ToString();
            }
        }

        int Key = 0;
        protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(CategoriesGV.SelectedRow.Cells[1].Text);
            CatNameTb.Value = CategoriesGV.SelectedRow.Cells[2].Text;
            LabelTb.Value = CategoriesGV.SelectedRow.Cells[3].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;
                string Label = LabelTb.Value;
                System.Diagnostics.Debug.WriteLine("CatName: " + CatName + ", Label: " + Label);
                // 创建SQL命令和参数
                string Query = "update CategoryTb1 set CatName = '{0}',CatLabels = '{1}' where CatId = {2}";
                Query = string.Format (Query, CatName, Label, CategoriesGV.SelectedRow.Cells[1].Text);
                //SqlParameter[] parameters = new SqlParameter[]
                //{
                //    new SqlParameter("@CatName", CatName),
                //    new SqlParameter("@Label", Label)
                //};

                // 创建Functions对象并调用setData方法
                Functions functions = new Functions();
                functions.SetData(Query);
                ShowCategories();

                ErrMsg.InnerText = "Room type edit successfully.";
            }
            catch (Exception ex)
            {
                // 仅向用户显示通用错误消息，避免泄露敏感信息
                ErrMsg.InnerText = "Error adding room type. Please try again. Detailed error: " + ex.Message;
                System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;
                string Label = LabelTb.Value;
                System.Diagnostics.Debug.WriteLine("CatName: " + CatName + ", Label: " + Label);
                // 创建SQL命令和参数
                string Query = "delete from CategoryTb1 where CatId = {0}";
                Query = string.Format(Query, CategoriesGV.SelectedRow.Cells[1].Text);

                // 创建Functions对象并调用setData方法
                Functions functions = new Functions();
                functions.SetData(Query);
                ShowCategories();

                ErrMsg.InnerText = "Room type deleted.";
            }
            catch (Exception ex)
            {
                // 仅向用户显示通用错误消息，避免泄露敏感信息
                ErrMsg.InnerText = "Error adding room type. Please try again. Detailed error: " + ex.Message;
                System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
            }
        }




    }
}