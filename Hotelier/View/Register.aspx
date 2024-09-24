<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Hotelier.View.Register" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Hotelier - Register</title>
    <!-- 引入必要的样式和脚本，与您的 Login.aspx 保持一致 -->
    <link href="~/Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Assets/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <%--<link href="~/Assets/CSS/custom.css" rel="stylesheet" />--%>

    <style>
         .bg-gradient-primary {
             background: url('../Assets/Images/Register.jpg') no-repeat center center fixed;
             background-size: cover;
         }

         .glass-effect {
            background-color: rgba(255, 255, 255, 0.2); /* 半透明白色背景 */
            backdrop-filter: blur(5px); /* 毛玻璃效果 */
            -webkit-backdrop-filter: blur(10px); /* 兼容 Safari */
            border: 1px solid rgba(255, 255, 255, 0.3);
         }
    </style>
</head>
<body class="bg-gradient-primary" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <!-- 注册表单 -->
            <div class="row justify-content-center">
                <div class="col-lg-7">
                    <div class="card o-hidden border-0 shadow-lg my-5 glass-effect">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Create an Account!</h1>
                                </div>
                                <!-- 错误信息显示 -->
                                <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger"></asp:Label>
                                <!-- 将 <form class="user"> 替换为 <div class="user"> -->
                                <div class="user">
                                    <div class="form-group">
                                        <asp:TextBox ID="UserNameTb" runat="server" CssClass="form-control form-control-user" Placeholder="Username"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="PhoneTb" runat="server" CssClass="form-control form-control-user" Placeholder="Phone Number"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="AddressTb" runat="server" CssClass="form-control form-control-user" Placeholder="Address"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="GenderDd" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="PasswordTb" runat="server" TextMode="Password" CssClass="form-control form-control-user" Placeholder="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="ConfirmPasswordTb" runat="server" TextMode="Password" CssClass="form-control form-control-user" Placeholder="Confirm Password"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="RegisterBtn" runat="server" Text="Register Account" CssClass="btn btn-primary btn-user btn-block" OnClick="RegisterBtn_Click" />
                                </div>
                                <!-- 移除多余的 </form> 标签 -->
                                <hr />
                                <div class="text-center">
                                    <a class="small" href="Login.aspx">Already have an account? Login!</a>
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
