using Hotelier.Models;
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

            RoomGrid.HeaderRow.Cells[1].Text = "RoomID";
            RoomGrid.HeaderRow.Cells[2].Text = "Room Name";
            RoomGrid.HeaderRow.Cells[3].Text = "Room Type";
            RoomGrid.HeaderRow.Cells[4].Text = "Room Location";
            RoomGrid.HeaderRow.Cells[5].Text = "Room Price";
            RoomGrid.HeaderRow.Cells[6].Text = "Room Label";
            RoomGrid.HeaderRow.Cells[7].Text = "Room Status";
        }
        private void GetCategories()
        {
            string Query = "Select * from CategoryTb1";
            if (!Page.IsPostBack)
            {
                CatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
                CatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();
                CatCb.DataSource = Con.GetData(Query);
                CatCb.DataBind();
            }
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RNameTb.Value;
                string RCat = CatCb.SelectedValue.ToString();
                string Rloc = LocationTb.Value;
                string Cost = CostTb.Value;
                string Label = LabelTb.Value;
                string Status = StatusCb.SelectedValue.ToString();
                string Query = "insert into RoomTb1 values('{0}','{1}','{2}','{3}','{4}','{5}')";

                Query = string.Format(Query, RName, RCat, Rloc, Cost, Label, Status);
                Con.SetData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room added successfully";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.ToString();
            }
        }
        int Key = 0;
        protected void RoomGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(RoomGrid.SelectedRow.Cells[1].Text);
            RNameTb.Value = RoomGrid.SelectedRow.Cells[2].Text;
            CatCb.SelectedValue = RoomGrid.SelectedRow.Cells[3].Text;
            LocationTb.Value = RoomGrid.SelectedRow.Cells[4].Text;
            CostTb.Value = RoomGrid.SelectedRow.Cells[5].Text;
            LabelTb.Value = RoomGrid.SelectedRow.Cells[6].Text;
            StatusCb.SelectedValue = RoomGrid.SelectedRow.Cells[7].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RNameTb.Value;
                string RCat = CatCb.SelectedValue.ToString();
                string Rloc = LocationTb.Value;
                string Cost = CostTb.Value;
                string Label = LabelTb.Value;
                string Status = StatusCb.SelectedValue.ToString();
                string Query = "update RoomTb1 set RName = '{0}', RCategory = '{1}', RLocation = '{2}', RCost = '{3}', RLabels = '{4}', Status = '{5}' where RId = {6}";

                Query = string.Format(Query, RName, RCat, Rloc, Cost, Label, Status, RoomGrid.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room updated";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {

                // 创建SQL命令和参数
                string Query = "delete from RoomTb1 where RId = {0}";
                Query = string.Format(Query, RoomGrid.SelectedRow.Cells[1].Text);

                // 创建Functions对象并调用setData方法
                Functions functions = new Functions();
                functions.SetData(Query);
                ShowRooms();

                ErrMsg.InnerText = "Room deleted.";

                //删除后清空表单信息
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";
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