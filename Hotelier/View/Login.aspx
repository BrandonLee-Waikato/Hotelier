<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hotelier.View.Login" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link rel="stylesheet" href="../Assets/Libraries/Bootstrap/css/bootstrap.min.css" />
    <style>
        body{
            /*height: 100vh;*/
            background-image: url(../Assets/Images/Hotel1.jpeg);
            background-size: cover;
        }
        .container-fluid {
            opacity:0.9;
            
        }
    </style>
</head>


<body>
    

    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="row" style="height: 300px"></div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4 bg-light rounded-3" >
                        <h1 class="text-success text-center">Hoteiler-Hotel Management</h1>

                        <%--login module--%>
                        <form>
                            <div class="mb-3">
                                <label for="UserTb" class="form-label">Username</label>
                                <input type="text" class="form-control" id="UserTb" runat="server" required="required">
                                <!-- <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> -->
                            </div>
                            <div class="mb-3">
                                <label for="PasswordTb" class="form-label">Password</label>
                                <input type="password" class="form-control" id="PasswordTb" runat="server" required="required">
                            </div>

                            <div class="mb-3">
                                <label id="ErrMsg" class="text-danger" runat="server"></label>
                                <input type="radio" id="AdminCb" runat="server" name="Role">  <label class="text-success" for="AdminCb">Admin</label>
                                <input type="radio" id="UserCb" runat="server" name="Role"> <label class="text-success" for="UserCb">User</label>
                            </div>

                            <div class="d-grid">
                                <asp:Button ID="LoginBtn" runat="server" Text="Login" class="btn btn-success btn-block" OnClick="LoginBtn_Click" />
                            </div>

                            <br />

                        </form>

                    </div>
             <div class="col-md-4"></div>
    </div>
</div>
        </div>
    </form>
</body>
</html>
