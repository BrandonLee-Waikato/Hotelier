using Hotelier.View.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                ShowRooms();
            }
        }

        private void ShowRooms()
        {
            string Query = "select *  from RoomTb1";
            RoomsGV.DataSource = Con.GetData(Query);
            RoomsGV.DataBind();
            //RoomsGV.HeaderRow.Cells[1].Text = "ID";
            //RoomsGV.HeaderRow.Cells[2].Text = "Room Type";
            //RoomsGV.HeaderRow.Cells[3].Text = "Label";
        }

        // 定义 CategoriesGV_SelectedIndexChanged 事件处理程序
        //protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // 在这里处理 GridView 的选择逻辑
        //    int selectedIndex = RoomsGV.SelectedIndex;
        //    // 您可以根据需要获取数据并进行操作
        //    GridViewRow selectedRow = RoomsGV.Rows[selectedIndex];
        //    // 例如，您可以从选择的行中获取数据
        //    string roomId = selectedRow.Cells[0].Text;
        //    // 然后执行一些操作
        //}

    }
}