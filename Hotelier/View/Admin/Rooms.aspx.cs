using Hotelier.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            if (!IsPostBack)
            {
                ShowRooms();
                GetCategories();
            }
        }

        private void ShowRooms()
        {
            string Query = "SELECT * FROM RoomTb1";
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
            string Query = "SELECT * FROM CategoryTb1";
            if (!Page.IsPostBack)
            {
                CatCb.DataTextField = "CatName";
                CatCb.DataValueField = "CatId";
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
                decimal Cost = decimal.Parse(CostTb.Value);
                string Label = LabelTb.Value;
                string Status = StatusCb.SelectedValue.ToString();
                string Description = DescriptionTb.Value;
                string ImagePath = "";

                // 处理图片上传
                if (ImageUpload.HasFile)
                {
                    string filename = Path.GetFileName(ImageUpload.FileName);
                    string filepath = Server.MapPath("~/Assets/Images/") + filename;
                    ImageUpload.SaveAs(filepath);
                    ImagePath = "Assets/Images/" + filename; // 存储相对路径
                }

                // 使用参数化查询防止SQL注入
                string Query = "INSERT INTO RoomTb1 (RName, RCategory, RLocation, RCost, RLabels, Status, RDescription, RImagePath) " +
                               "VALUES (@RName, @RCat, @Rloc, @Cost, @Label, @Status, @Description, @ImagePath)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@RName", RName),
                    new SqlParameter("@RCat", RCat),
                    new SqlParameter("@Rloc", Rloc),
                    new SqlParameter("@Cost", Cost),
                    new SqlParameter("@Label", Label),
                    new SqlParameter("@Status", Status),
                    new SqlParameter("@Description", Description),
                    new SqlParameter("@ImagePath", ImagePath)
                };

                Con.SetData(Query, parameters);
                ShowRooms();
                ErrMsg.InnerText = "Room added successfully";

                // 清空表单
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";
                DescriptionTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
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

            // 从数据库中获取描述和图片路径
            string Query = "SELECT RDescription, RImagePath FROM RoomTb1 WHERE RId = @RId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RId", Key)
            };
            var data = Con.GetData(Query, parameters);
            if (data.Rows.Count > 0)
            {
                DescriptionTb.Value = data.Rows[0]["RDescription"].ToString();
                ViewState["CurrentImagePath"] = data.Rows[0]["RImagePath"].ToString();
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RNameTb.Value;
                string RCat = CatCb.SelectedValue.ToString();
                string Rloc = LocationTb.Value;
                decimal Cost = decimal.Parse(CostTb.Value);
                string Label = LabelTb.Value;
                string Status = StatusCb.SelectedValue.ToString();
                string Description = DescriptionTb.Value;
                string ImagePath = "";

                // 处理图片上传（如果有新的图片）
                if (ImageUpload.HasFile)
                {
                    string filename = Path.GetFileName(ImageUpload.FileName);
                    string filepath = Server.MapPath("~/Assets/Images/") + filename;
                    ImageUpload.SaveAs(filepath);
                    ImagePath = "Assets/Images/" + filename; // 存储相对路径
                }
                else
                {
                    // 如果没有上传新图片，则使用原有的图片路径
                    ImagePath = ViewState["CurrentImagePath"] != null ? ViewState["CurrentImagePath"].ToString() : "";
                }

                // 使用参数化查询防止SQL注入
                string Query = "UPDATE RoomTb1 SET RName = @RName, RCategory = @RCat, RLocation = @Rloc, RCost = @Cost, " +
                               "RLabels = @Label, Status = @Status, RDescription = @Description, RImagePath = @ImagePath WHERE RId = @RId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@RName", RName),
                    new SqlParameter("@RCat", RCat),
                    new SqlParameter("@Rloc", Rloc),
                    new SqlParameter("@Cost", Cost),
                    new SqlParameter("@Label", Label),
                    new SqlParameter("@Status", Status),
                    new SqlParameter("@Description", Description),
                    new SqlParameter("@ImagePath", ImagePath),
                    new SqlParameter("@RId", Key)
                };

                Con.SetData(Query, parameters);
                ShowRooms();
                ErrMsg.InnerText = "Room updated successfully";

                // 清空表单
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";
                DescriptionTb.Value = "";
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
                string Query = "DELETE FROM RoomTb1 WHERE RId = @RId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@RId", Key)
                };

                Con.SetData(Query, parameters);
                ShowRooms();

                ErrMsg.InnerText = "Room deleted.";

                // 清空表单
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                LabelTb.Value = "";
                DescriptionTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}
