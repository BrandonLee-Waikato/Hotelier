using Hotelier.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotelier.View.Users
{
    public partial class Booking : System.Web.UI.Page
    {
        public class roomInfo
        {
            public string roomId { get; set; }
            public string roomName { get; set; }
            public string category { get; set; }
            public string cost { get; set; }
            public string status { get; set; }
        }

        public class BookingInfo
        {
            public string orderNumber { get; set; }
            public DateTime date { get; set; }
            public string roomNumber { get; set; }
            public string userId { get; set; }
            public DateTime checkInTime { get; set; }
            public DateTime checkOutTime { get; set; }
            public decimal totalAmount { get; set; }
        }

        public List<roomInfo> roomList = new List<roomInfo>();
        public List<BookingInfo> BookingList = new List<BookingInfo>();

        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

            // 检查用户是否已登录，如果未登录，则默认设置 UId 为 2
            if (Session["UId"] == null)
            {
                Session["UId"] = "2"; // 假设 UId 是字符串类型
            }

            if (!IsPostBack)
            {
                ShowRooms();
                ShowBookings();
                SetMinDates();
            }
        }

        // 设置日期输入框的最小日期为今天
        private void SetMinDates()
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            DateInTb.Attributes["min"] = today;
            DateOutTb.Attributes["min"] = today;
        }

        private void ShowRooms()
        {
            string St = "Available";
            string Query = "SELECT RId as roomId, RName as roomName, RCategory as category, Rcost as cost, Status as status FROM RoomTb1 WHERE status = @Status";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", St)
            };
            var data = Con.GetData(Query, parameters);

            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    roomInfo room = new roomInfo()
                    {
                        roomId = row["roomId"].ToString(),
                        roomName = row["roomName"].ToString(),
                        category = row["category"].ToString(),
                        cost = row["cost"].ToString(),
                        status = row["status"].ToString(),
                    };

                    roomList.Add(room);
                }

                // 绑定数据到 GridView
                RoomsGV.DataSource = roomList;
                RoomsGV.DataBind();
            }
            else
            {
                ErrMsg.Text = "No available rooms found.";
            }
        }

        private void ShowBookings()
        {
            string Query = "SELECT BId as orderNumber, BDate as date, BRoom as roomNumber, Agent as userId, DateIn as checkInTime, DateOut as checkOutTime, Amount as totalAmount FROM BookingTb1 WHERE Agent = @Agent";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Agent", Session["UId"].ToString())
            };
            var data = Con.GetData(Query, parameters);

            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    BookingInfo booking = new BookingInfo()
                    {
                        orderNumber = row["orderNumber"].ToString(),
                        date = Convert.ToDateTime(row["date"]),
                        roomNumber = row["roomNumber"].ToString(),
                        userId = row["userId"].ToString(),
                        checkInTime = Convert.ToDateTime(row["checkInTime"]),
                        checkOutTime = Convert.ToDateTime(row["checkOutTime"]),
                        totalAmount = Convert.ToDecimal(row["totalAmount"])
                    };

                    BookingList.Add(booking);
                }

                // 绑定数据到 GridView
                BookingGV.DataSource = BookingList;
                BookingGV.DataBind();
            }
            else
            {
                // 如果没有预定记录，可以选择显示空表或提示信息
                BookingGV.DataSource = null;
                BookingGV.DataBind();
                ErrMsg.Text = "No booking records found.";
            }
        }

        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = RoomsGV.SelectedRow;

            if (selectedRow != null)
            {
                string roomId = selectedRow.Cells[1].Text.Trim(); // 假设 roomId 在第二个单元格
                string roomName = selectedRow.Cells[2].Text.Trim(); // roomName
                string costText = selectedRow.Cells[4].Text.Trim(); // cost

                // 转换成本
                decimal cost;
                if (!decimal.TryParse(costText, out cost))
                {
                    ErrMsg.Text = "Invalid room cost.";
                    return;
                }

                // 显示选中的房间信息
                SelectedRoomTb.Text = roomName;
                AmountTb.Text = cost.ToString("F2"); // 显示两位小数

                // 设置退房日期的最小值为入住日期加一天
                if (!string.IsNullOrEmpty(DateInTb.Text))
                {
                    DateTime checkInDate;
                    if (DateTime.TryParse(DateInTb.Text, out checkInDate))
                    {
                        DateTime minCheckOutDate = checkInDate.AddDays(1);
                        DateOutTb.Attributes["min"] = minCheckOutDate.ToString("yyyy-MM-dd");
                    }
                }

                // 显示 BookingPanel
                BookingPanel.Visible = true;
            }
        }

        protected void DateInTb_TextChanged(object sender, EventArgs e)
        {
            // 当入住日期改变时，自动设置退房日期的最小值为入住日期加1天
            if (!string.IsNullOrEmpty(DateInTb.Text))
            {
                DateTime checkInDate;
                if (DateTime.TryParse(DateInTb.Text, out checkInDate))
                {
                    // 设置退房日期的最小值为入住日期加1天
                    DateTime minCheckOutDate = checkInDate.AddDays(1);
                    DateOutTb.Attributes["min"] = minCheckOutDate.ToString("yyyy-MM-dd");

                    // 如果当前退房日期小于新的最小值，则清空
                    DateTime currentCheckOutDate;
                    if (DateTime.TryParse(DateOutTb.Text, out currentCheckOutDate))
                    {
                        if (currentCheckOutDate < minCheckOutDate)
                        {
                            DateOutTb.Text = "";
                        }
                    }
                }
            }
        }

        private void UpdateRoomStatus(string roomId, string status)
        {
            try
            {
                string Query = "UPDATE RoomTb1 SET Status = @Status WHERE RId = @RId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Status", status),
                    new SqlParameter("@RId", roomId)
                };
                Con.SetData(Query, parameters);
                ShowRooms();
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "Error updating room status. Please try again.";
                System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
            }
        }

        protected void BookBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 确保用户已选择房间
                if (RoomsGV.SelectedIndex < 0)
                {
                    ErrMsg.Text = "Please select a room to book.";
                    SuccessMsg.Text = "";
                    return;
                }

                string roomId = RoomsGV.SelectedRow.Cells[1].Text.Trim(); // 假设 roomId 在第二个单元格
                string roomName = SelectedRoomTb.Text.Trim();
                string BDate = DateTime.Today.ToString("yyyy-MM-dd");
                string InDate = DateInTb.Text;
                string OutDate = DateOutTb.Text;
                string Agent = Session["UId"].ToString(); // 已确保不为 null

                // 验证输入
                if (string.IsNullOrEmpty(InDate) || string.IsNullOrEmpty(OutDate))
                {
                    ErrMsg.Text = "Please select both check-in and check-out dates.";
                    SuccessMsg.Text = "";
                    return;
                }

                DateTime checkInDate;
                DateTime checkOutDate;

                if (!DateTime.TryParse(InDate, out checkInDate))
                {
                    ErrMsg.Text = "Invalid check-in date.";
                    SuccessMsg.Text = "";
                    return;
                }

                if (!DateTime.TryParse(OutDate, out checkOutDate))
                {
                    ErrMsg.Text = "Invalid check-out date.";
                    SuccessMsg.Text = "";
                    return;
                }

                if (checkInDate < DateTime.Today)
                {
                    ErrMsg.Text = "Check-in date cannot be in the past.";
                    SuccessMsg.Text = "";
                    return;
                }

                if (checkOutDate <= checkInDate)
                {
                    ErrMsg.Text = "Check-out date must be after check-in date.";
                    SuccessMsg.Text = "";
                    return;
                }

                // 计算总金额
                TimeSpan duration = checkOutDate - checkInDate;
                int days = duration.Days;
                decimal costPerDay;
                if (!decimal.TryParse(RoomsGV.SelectedRow.Cells[4].Text.Trim(), out costPerDay))
                {
                    ErrMsg.Text = "Invalid room cost.";
                    SuccessMsg.Text = "";
                    return;
                }
                decimal totalAmount = days * costPerDay;

                // 插入预定记录
                string Query = "INSERT INTO BookingTb1 (BDate, BRoom, Agent, DateIn, DateOut, Amount) VALUES (@BDate, @BRoom, @Agent, @DateIn, @DateOut, @Amount)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@BDate", BDate),
                    new SqlParameter("@BRoom", roomId),
                    new SqlParameter("@Agent", Agent),
                    new SqlParameter("@DateIn", checkInDate),
                    new SqlParameter("@DateOut", checkOutDate),
                    new SqlParameter("@Amount", totalAmount)
                };
                Con.SetData(Query, parameters);

                // 更新房间状态为 "Booked"
                UpdateRoomStatus(roomId, "Booked");

                // 更新预定列表
                ShowBookings();

                // 显示成功消息
                SuccessMsg.Text = $"Room '{roomName}' has been successfully booked from {checkInDate:yyyy-MM-dd} to {checkOutDate:yyyy-MM-dd}.";
                ErrMsg.Text = "";

                // 清空输入框
                SelectedRoomTb.Text = "";
                AmountTb.Text = "";
                DateInTb.Text = "";
                DateOutTb.Text = "";
                BookingPanel.Visible = false;
                RoomsGV.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "An error occurred while booking the room. Please try again.";
                SuccessMsg.Text = "";
                System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
            }
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            // 清空输入框
            SelectedRoomTb.Text = "";
            AmountTb.Text = "";
            DateInTb.Text = "";
            DateOutTb.Text = "";

            // 清空 GridView 选择
            RoomsGV.SelectedIndex = -1;

            // 隐藏 BookingPanel
            BookingPanel.Visible = false;

            // 清空错误和成功消息
            ErrMsg.Text = "";
            SuccessMsg.Text = "";
        }
    }
}
