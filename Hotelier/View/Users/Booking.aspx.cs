using Hotelier.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotelier.View.Users
{
    public partial class Booking : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                LoadRoomCards();
                ShowRooms();
                ShowBookings();

                // 检查是否有房间ID传递过来
                if (Request.QueryString["RId"] != null)
                {
                    int roomId = Convert.ToInt32(Request.QueryString["RId"]);
                    SelectRoom(roomId);
                }
            }
        }

        private void LoadRoomCards()
        {
            string categoryId = Request.QueryString["CategoryId"];
            string Query;
            if (!string.IsNullOrEmpty(categoryId))
            {
                Query = "SELECT RId, RName, RDescription, RImagePath FROM RoomTb1 WHERE Status = 'Available' AND RCategory = @CategoryId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CategoryId", categoryId)
                };
                RoomsRepeater.DataSource = Con.GetData(Query, parameters);
            }
            else
            {
                Query = "SELECT RId, RName, RDescription, RImagePath FROM RoomTb1 WHERE Status = 'Available'";
                RoomsRepeater.DataSource = Con.GetData(Query);
            }
            RoomsRepeater.DataBind();
        }

        private void ShowRooms()
        {
            string St = "Available";
            string Query = "select RId as Id, RName as Name, RCategory as categories, Rcost as Cost, Status from RoomTb1 where status = '" + St + "'";

            RoomsGV.DataSource = Con.GetData(Query);
            RoomsGV.DataBind();
        }

        private void ShowBookings()
        {
            string Query = "SELECT * FROM BookingTb1";
            var data = Con.GetData(Query);

            if (data != null && data.Rows.Count > 0)
            {
                BookingGV.DataSource = data;
                BookingGV.DataBind();
                BookingGV.HeaderRow.Cells[1].Text = "Order Number";
                BookingGV.HeaderRow.Cells[2].Text = "Date";
                BookingGV.HeaderRow.Cells[3].Text = "Room Number";
                BookingGV.HeaderRow.Cells[4].Text = "UserID";
                BookingGV.HeaderRow.Cells[5].Text = "Check in time";
                BookingGV.HeaderRow.Cells[6].Text = "Check out time";
                BookingGV.HeaderRow.Cells[7].Text = "Total Amount";
            }
            else
            {
                ErrMsg.InnerText = "No booking records found.";
            }
        }

        int Key = 0;
        int Days = 1;
        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Key = Convert.ToInt32(RoomsGV.SelectedRow.Cells[1].Text);
            RoomTb.Value = RoomsGV.SelectedRow.Cells[2].Text;
            int Cost = Days * Convert.ToInt32(RoomsGV.SelectedRow.Cells[4].Text);
            AmountTb.Value = Cost.ToString();
        }

        private void UpdateRoom()
        {
            try
            {
                string st = "Booked";
                string Query = "UPDATE RoomTb1 SET Status = @Status WHERE RId = @RId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Status", st),
                    new SqlParameter("@RId", Key)
                };
                Con.SetData(Query, parameters);
                ShowRooms();
                ErrMsg.InnerText = "Room Status Updated";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Error updating room status. Please try again. Detailed error: " + ex.Message;
            }
        }

        int TCost;
        private void GetCost()
        {
            DateTime DIn = Convert.ToDateTime(DateInTb.Value);
            DateTime DOut = Convert.ToDateTime(DateOutTb.Value);
            TimeSpan value = DOut.Subtract(DIn);
            int Days = Convert.ToInt32(value.TotalDays);
            TCost = Days * Convert.ToInt32(RoomsGV.SelectedRow.Cells[4].Text);
        }

        protected void BookBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RId = RoomsGV.SelectedRow.Cells[1].Text;
                string BDate = System.DateTime.Today.Date.ToString();
                string InDate = DateInTb.Value;
                string OutDate = DateOutTb.Value;
                string Agent = Session["UId"] as string;
                GetCost();
                int Amount = Convert.ToInt32(AmountTb.Value.ToString());
                string Query = "insert into BookingTb1 values('{0}',{1},{2},'{3}','{4}','{5}')";
                Query = string.Format(Query, BDate, RId, Agent, InDate, OutDate, TCost);
                Con.SetData(Query);
                UpdateRoom();
                ShowRooms();
                ShowBookings();

                ErrMsg.InnerText = "Room booked";

                RoomTb.Value = "";
                AmountTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            // 清空文本框
            RoomTb.Value = "";
            AmountTb.Value = "";
            DateInTb.Value = "";
            DateOutTb.Value = "";

            // 清空 GridView 选择
            RoomsGV.SelectedIndex = -1;

            // 清空错误消息
            ErrMsg.InnerText = "";
        }

        private void SelectRoom(int roomId)
        {
            // 在 RoomsGV 中找到对应的房间并选中
            foreach (GridViewRow row in RoomsGV.Rows)
            {
                if (Convert.ToInt32(row.Cells[1].Text) == roomId)
                {
                    RoomsGV.SelectedIndex = row.RowIndex;
                    RoomsGV_SelectedIndexChanged(null, null);
                    break;
                }
            }
        }


    }
}
