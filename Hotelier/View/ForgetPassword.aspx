<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="Hotelier.View.ForgetPassword" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Hotelier - Forget Password</title>
    <!-- 引入必要的样式和脚本，与您的 Login.aspx 保持一致 -->
    <link href="~/Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Assets/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <!-- 如果需要自定义样式，可以取消注释以下行 -->
    <!-- <link href="~/Assets/CSS/custom.css" rel="stylesheet" /> -->

     <style>
      .bg-gradient-primary {
          background: url('../Assets/Images/ForgetPassword.jpg') no-repeat center center fixed;
          background-size: cover;
      }

      .glass-effect {
         background-color: rgba(255, 255, 255, 0.2); /* 半透明白色背景 */
         backdrop-filter: blur(5px); /* 毛玻璃效果 */
         -webkit-backdrop-filter: blur(10px); /* 兼容 Safari */
         border: 1px solid rgba(255, 255, 255, 0.3);
      }

      .hints{
            
    color: #fff;
    text-shadow:
      0 0 5px #fff,
      0 0 10px #fff,
      0 0 20px #fff,
      0 0 40px #0ff,
      0 0 80px #0ff,
      0 0 90px #0ff,
      0 0 100px #0ff,
      0 0 150px #0ff;
  
      }
 </style>
</head>
<body class="bg-gradient-primary" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <!-- 忘记密码表单 -->
            <div class="row justify-content-center">
                <div class="col-lg-7">
                    <div class="card o-hidden border-0 shadow-lg my-5 glass-effect">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="p-5">
                                <div class="text-center">
                                    <h3 class="hints">Enter your username and we'll help you reset your password.</h3>
                                </div>
                                <!-- 错误信息显示 -->
                                <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger"></asp:Label>
                                <div class="user">
                                    <!-- 用户名输入框 -->
                                    <div class="form-group">
                                        <asp:TextBox ID="UserNameTb" runat="server" CssClass="form-control form-control-user" Placeholder="Username"></asp:TextBox>
                                    </div>
                                    <!-- 重置密码按钮 -->
                                    <asp:Button ID="ResetPasswordBtn" runat="server" Text="Next" CssClass="btn btn-primary btn-user btn-block" OnClick="ResetPasswordBtn_Click" />
                                    <!-- 新的输入框和按钮，包裹在 Panel 中 -->
                                    <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                                        <!-- 旧密码输入框 -->
                                        <div class="form-group mt-3">
                                            <asp:TextBox ID="OldPasswordTb" runat="server" TextMode="Password" CssClass="form-control form-control-user" Placeholder="Old Password"></asp:TextBox>
                                        </div>
                                        <!-- 新密码输入框 -->
                                        <div class="form-group">
                                            <asp:TextBox ID="NewPasswordTb" runat="server" TextMode="Password" CssClass="form-control form-control-user" Placeholder="New Password"></asp:TextBox>
                                        </div>
                                        <!-- 确认新密码输入框 -->
                                        <div class="form-group">
                                            <asp:TextBox ID="ConfirmNewPasswordTb" runat="server" TextMode="Password" CssClass="form-control form-control-user" Placeholder="Confirm New Password"></asp:TextBox>
                                        </div>
                                        <!-- 修改密码按钮 -->
                                        <asp:Button ID="ChangePasswordBtn" runat="server" Text="Change Password" CssClass="btn btn-success btn-user btn-block" OnClick="ChangePasswordBtn_Click" />
                                    </asp:Panel>
                                </div>
                                <hr />
                                <div class="text-center">
                                    <a class="small" href="Login.aspx">Back to Login</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- 引入必要的脚本 -->
        <script src="~/Assets/vendor/jquery/jquery.min.js"></script>
        <script src="~/Assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="~/Assets/vendor/jquery-easing/jquery.easing.min.js"></script>
        <script src="~/Assets/JS/sb-admin-2.min.js"></script>
    </form>
</body>
</html>
