using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Hotelier.View
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }

        protected void ResetPasswordBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UserNameTb.Text.Trim();

                if (string.IsNullOrEmpty(username))
                {
                    ErrMsg.Text = "Please enter your username.";
                    return;
                }

                // 检查用户是否存在
                string checkUserQuery = "SELECT UId, UName FROM UserTb1 WHERE UName = @UName";
                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@UName", username)
                };
                DataTable dt = Con.GetData(checkUserQuery, checkParams);

                if (dt.Rows.Count == 0)
                {
                    ErrMsg.Text = "Username does not exist.";
                    return;
                }

                // 用户名存在，显示密码修改部分
                PasswordPanel.Visible = true;

                // 禁用用户名输入框和按钮
                UserNameTb.Enabled = false;
                ResetPasswordBtn.Enabled = false;

                // 保存用户名到 ViewState
                ViewState["Username"] = username;
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Username"] == null)
                {
                    ErrMsg.Text = "Session expired. Please try again.";
                    return;
                }

                string username = ViewState["Username"].ToString();
                string oldPassword = OldPasswordTb.Text.Trim();
                string newPassword = NewPasswordTb.Text.Trim();
                string confirmNewPassword = ConfirmNewPasswordTb.Text.Trim();

                if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmNewPassword))
                {
                    ErrMsg.Text = "Please fill all the fields.";
                    return;
                }

                if (newPassword != confirmNewPassword)
                {
                    ErrMsg.Text = "New passwords do not match.";
                    return;
                }

                // 检查旧密码是否正确
                string checkPasswordQuery = "SELECT UPass FROM UserTb1 WHERE UName = @UName";
                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@UName", username)
                };
                DataTable dt = Con.GetData(checkPasswordQuery, checkParams);

                if (dt.Rows.Count == 0)
                {
                    ErrMsg.Text = "User not found.";
                    return;
                }

                string currentPasswordInDb = dt.Rows[0]["UPass"].ToString();

                if (currentPasswordInDb != oldPassword)
                {
                    ErrMsg.Text = "Old password is incorrect.";
                    return;
                }

                // 更新密码（实际应用中应对密码进行哈希处理）
                string updateQuery = "UPDATE UserTb1 SET UPass = @UPass WHERE UName = @UName";
                SqlParameter[] updateParams = new SqlParameter[]
                {
                    new SqlParameter("@UPass", newPassword), // 这里应使用哈希后的密码
                    new SqlParameter("@UName", username)
                };
                Con.SetData(updateQuery, updateParams);

                // 设置成功消息
                ErrMsg.CssClass = "text-success";
                ErrMsg.Text = "Password has been changed successfully. Redirecting to login page...";

                // 重置表单
                UserNameTb.Text = "";
                UserNameTb.Enabled = true;
                ResetPasswordBtn.Enabled = true;
                PasswordPanel.Visible = false;
                ViewState["Username"] = null;

                // 注册 JavaScript 定时重定向脚本
                string script = "setTimeout(function(){ window.location.href = 'Login.aspx'; }, 1500);";
                ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}
