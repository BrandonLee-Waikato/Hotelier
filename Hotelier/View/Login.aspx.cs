using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotelier.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Con = new Models.Functions();
            Session["UserName"] = "";
            Session["UId"] = "";
        }
        Models.Functions Con;

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Admin/Rooms.aspx");
            if (AdminCb.Checked)
            {
                if (UserTb.Value == "Admin" && PasswordTb.Value == "password")
                {
                    Session["UserName"] = "Admin";
                    Response.Redirect("Admin/Rooms.aspx");
                }
                else
                {
                    ErrMsg.InnerText = "Invalid Admin!";
                }
            }
            else if (UserCb.Checked)
            {
                string Query = "select UId, UName, UPass from UserTb1 where UName = '{0}' and UPass = '{1}'";
                Query = string.Format(Query, UserTb.Value, PasswordTb.Value);
                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    ErrMsg.InnerText = "Invalid User!";
                }
                else
                {
                    Session["UserName"] = dt.Rows[0][1].ToString();
                    Session["UId"] = dt.Rows[0][0].ToString();
                    Response.Redirect("Users/Booking.aspx"); // 跳转到用户界面
                }
            }
            else
            {
                ErrMsg.InnerText = "Please select a role.";
            }

        }
    }
}