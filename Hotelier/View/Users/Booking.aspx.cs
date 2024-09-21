using Hotelier.View.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            string Query = "select RId as Id, RName as Name, RCategory as categories, Rcost as Cost, Status from RoomTb1";

            RoomsGV.DataSource = Con.GetData(Query);
            RoomsGV.DataBind();

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
    }
}