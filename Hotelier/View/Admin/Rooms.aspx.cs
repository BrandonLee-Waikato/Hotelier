using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotelier.View.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowRooms();
            GetCategories();
        }

        private void ShowRooms()
        {
            string Query = "select * from RoomTb1";
            RoomGrid.DataSource = Con.GetData(Query);
            RoomGrid.DataBind();
            //CategoriesGV.HeaderRow.Cells[1].Text = "ID";
            //CategoriesGV.HeaderRow.Cells[2].Text = "Room Type";
            //CategoriesGV.HeaderRow.Cells[3].Text = "Label";
        }
        private void GetCategories()
        {
            string Query = "Select * from CategoryTb1";
            CatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
            CatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();
            CatCb.DataSource = Con.GetData(Query);
            CatCb.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
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
    }
}