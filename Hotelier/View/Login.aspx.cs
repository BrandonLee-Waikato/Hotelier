using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Hotelier.View
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            Session["UserName"] = null;
            Session["UId"] = null;
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (AdminCb.Checked)
            {
                // 管理员登录验证
                if (UserTb.Text == "Admin" && PasswordTb.Text == "password")
                {
                    Session["UserName"] = "Admin";
                    Response.Redirect("Admin/Rooms.aspx");
                }
                else
                {
                    ErrMsg.Text = "Invalid Admin!";
                }
            }
            else if (UserCb.Checked)
            {
                // 用户登录验证，使用参数化查询
                string Query = "SELECT UId, UName, UPass FROM UserTb1 WHERE UName = @UName AND UPass = @UPass";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UName", UserTb.Text),
                    new SqlParameter("@UPass", PasswordTb.Text)
                };
                DataTable dt = Con.GetData(Query, parameters);

                if (dt.Rows.Count == 0)
                {
                    ErrMsg.Text = "Invalid User!";
                }
                else
                {
                    Session["UserName"] = dt.Rows[0]["UName"].ToString();
                    Session["UId"] = dt.Rows[0]["UId"].ToString();
                    Response.Redirect("Users/Booking.aspx"); // 跳转到用户界面
                }
            }
            else
            {
                ErrMsg.Text = "Please select a role.";
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        
        protected void FotgetBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }
    }
}
