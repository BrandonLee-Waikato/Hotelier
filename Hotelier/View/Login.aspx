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
                                <label for="exampleInputEmail1" class="form-label">Email</label>
                                <input type="email" class="form-control" id="EmailTb">
                                <!-- <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> -->
                            </div>
                            <div class="mb-3">
                                <label for="exampleInputPassword1" class="form-label">Password</label>
                                <input type="password" class="form-control" id="PasswordTb">
                            </div>
                            <div class="mb-3 form-check">
                                <input type="radio" class="form-radio-input" id="AdminCb" value="Admin">  <label class="text-success" for="AdminCb">Admin</label>
                   
                                <input type="radio" class="form-radio-input" id="UserCb"> <label class="text-success" for="UserCb">User</label>
                    
                            </div>
                            <asp:Button ID="LoginBtn" runat="server" Text="Login" class="btn btn-success btn-block" OnClick="LoginBtn_Click" />
                        </form>

                    </div>
             <div class="col-md-4"></div>
    </div>
</div>
        </div>
    </form>
</body>
</html>
