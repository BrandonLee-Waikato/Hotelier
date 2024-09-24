using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Hotelier.View
{
    public partial class Register : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UserNameTb.Text.Trim();
                string phone = PhoneTb.Text.Trim();
                string address = AddressTb.Text.Trim();
                string gender = GenderDd.SelectedValue;
                string password = PasswordTb.Text;
                string confirmPassword = ConfirmPasswordTb.Text;

                // 输入验证
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) ||
                    string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(password))
                {
                    ErrMsg.Text = "Please fill all the fields.";
                    return;
                }

                if (password != confirmPassword)
                {
                    ErrMsg.Text = "Passwords do not match.";
                    return;
                }

                // 检查用户名是否已存在
                string checkUserQuery = "SELECT COUNT(*) FROM UserTb1 WHERE UName = @UName";
                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@UName", username)
                };
                DataTable dt = Con.GetData(checkUserQuery, checkParams);

                if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    ErrMsg.Text = "Username already exists.";
                    return;
                }

                // 密码哈希（建议在实际应用中使用更强的哈希算法和盐值）
                string hashedPassword = password; // 这里只是示例，实际应用中请使用哈希函数

                // 插入新用户
                string insertQuery = "INSERT INTO UserTb1 (UName, UPhone, UGen, UAdd, UPass) VALUES (@UName, @UPhone, @UGen, @UAdd, @UPass)";
                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@UName", username),
                    new SqlParameter("@UPhone", phone),
                    new SqlParameter("@UGen", gender),
                    new SqlParameter("@UAdd", address),
                    new SqlParameter("@UPass", hashedPassword)
                };
                Con.SetData(insertQuery, insertParams);
                ErrMsg.CssClass = "text-success";
                ErrMsg.Text = "Registration successful!";

                // 清空输入框
                UserNameTb.Text = "";
                PhoneTb.Text = "";
                AddressTb.Text = "";
                GenderDd.SelectedIndex = 0;
                PasswordTb.Text = "";
                ConfirmPasswordTb.Text = "";

                // 重定向到登录页面
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}
