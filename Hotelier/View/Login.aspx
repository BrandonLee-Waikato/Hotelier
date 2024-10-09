<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hotelier.View.Login" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Hotelier - Login</title>

    <!-- Custom fonts for this template-->
    <link href="~/Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="~/Assets/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="~/Assets/CSS/custom.css" rel="stylesheet" />

     <style>
        .bg-gradient-primary {
            background: url('../Assets/Images/Hotel2.jpeg') no-repeat center center fixed;
            background-size: cover;
        }
        .glass-effect {
            background-color: rgba(255, 255, 255, 0.2); /* 半透明白色背景 */
            backdrop-filter: blur(5px); /* 毛玻璃效果 */
            -webkit-backdrop-filter: blur(10px); /* 兼容 Safari */
            border: 1px solid rgba(255, 255, 255, 0.3);
        }
        .col-lg-6 d-none d-lg-block bg-login-image{
            background: url('../Assets/Images/Hotel_Icon.png') no-repeat center center fixed;
        }
        .slidershow{
            border-radius: 30px; 
            width: 400px;
            height: 550px;
            overflow: hidden;
            /*margin-left: 50px;*/
        }
        .middle{
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%)
        }
        .navigation{
            position: absolute;
            bottom: 20px;
            left: 50%;
            transform: translate(-50%);
            display: flex;
        }
        .bar{
            border-radius: 50%;
            width: 20px;
            height: 20px;
            border: solid rgba(255, 255, 255, 0.5) 5px;
            margin: 6px;
            cursor: pointer;
            transition: 0.4s;
        }

        .bar:hover{
            background: #ffb71e;
        }

        input[name="r"]{
            position: absolute;
            visibility: hidden;
        }

        .slides{
            width: 700%;
            height: 100%;
            display: flex;
        }

        .slide{
            width: 20%;
            transition: 1.5s;
        }

        .slide img{
            width: 100%;
            height: 100%;
        }

        #r1:checked ~ .s1{
            margin-left: 0;
        }
        #r2:checked ~ .s1{
            margin-left: -20%;
        }
        #r3:checked ~ .s1{
            margin-left: -40%;
        }
        #r4:checked ~ .s1{
            margin-left: -60%;
        }
        #r5:checked ~ .s1{
            margin-left: -80%;
        }
        #r6:checked ~ .s1{
            margin-left: -100%;
        }
        #r7:checked ~ .s1{
            margin-left: -120%;
        }


        .neon {
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
<%--<body class="bg-gradient-primary">--%>
<body class="bg-gradient-primary" runat="server">

    <form id="form1" runat="server">
        <div class="container">

            <!-- Outer Row -->
            <div class="row justify-content-center">

                <div class="col-xl-10 col-lg-12 col-md-9">



                    <%--登录表单的主要容器是--%>
                    <%--<div class="card o-hidden border-0 shadow-lg my-5">--%>
                    <div class="card o-hidden border-0 shadow-lg my-5 glass-effect">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <!-- 左侧图片 -->
                                <div class="col-lg-6 d-none d-lg-block bg-login-image">
                                   <div class="slidershow middle">
                                        <div class="slides">
                                            <input type="radio" name="r" id="r1" checked/>
                                            <input type="radio" name="r" id="r2"/>
                                            <input type="radio" name="r" id="r3"/>
                                            <input type="radio" name="r" id="r4"/>
                                            <input type="radio" name="r" id="r5"/>
                                            <input type="radio" name="r" id="r6"/>
                                            <input type="radio" name="r" id="r7"/>
                                            <%--插入图片--%>
                                            <div class="slide s1">
                                                <img src="../Assets/Images/h1.jpg" alt="" />
                                            </div>
                                            <div class="slide">
                                                <img src="../Assets/Images/h7.jpg" alt="" />
                                            </div>
                                            <div class="slide">
                                                <img src="../Assets/Images/h5.jpg" alt="" />
                                            </div>
                                            <div class="slide">
                                                <img src="../Assets/Images/h4.jpg" alt="" />
                                            </div>
                                            <div class="slide">
                                                <img src="../Assets/Images/h6.jpg" alt="" />
                                            </div>
                                            <div class="slide">
                                                <img src="../Assets/Images/h2.jpg" alt="" />
                                            </div>
                                            <div class="slide">
                                                <img src="../Assets/Images/h3.jpg" alt="" />
                                            </div>

                                            <div class="navigation">
                                                <label for="r1" class="bar"></label>
                                                <label for="r2" class="bar"></label>
                                                <label for="r3" class="bar"></label>
                                                <label for="r4" class="bar"></label>
                                                <label for="r5" class="bar"></label>
                                                <label for="r6" class="bar"></label>
                                                <label for="r7" class="bar"></label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- 登录表单 -->
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <!-- 标题 -->
                                        <div class="text-center">
                                            <h2 class="neon">Welcome Back!</h2>
                                        </div>
                                        <!-- 错误信息显示 -->
                                        <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger"></asp:Label>

                                        <!-- 登录表单 -->
                                        <div class="user">
                                            <div class="form-group">
                                                <asp:TextBox ID="UserTb" runat="server" CssClass="form-control form-control-user" Placeholder="Enter Username..." AutoCompleteType="None"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="PasswordTb" runat="server" TextMode="Password" CssClass="form-control form-control-user" Placeholder="Password"></asp:TextBox>
                                            </div>
                                            <div class="form-group">

                                                <!-- 角色选择 -->
                                                <div class="custom-control custom-radio custom-control-inline">
                                                    <input type="radio" id="AdminCb" name="Role" value="Admin" class="custom-control-input" runat="server" />
                                                    <label class="custom-control-label" for="AdminCb">Admin</label>
                                                </div>
                                                <div class="custom-control custom-radio custom-control-inline">
                                                    <input type="radio" id="UserCb" name="Role" value="User" class="custom-control-input" runat="server" />
                                                    <label class="custom-control-label" for="UserCb">User</label>
                                                </div>
                                            </div>
                                            <!-- 登录按钮 -->
                                            <asp:Button ID="LoginBtn" runat="server" Text="Login" CssClass="btn btn-primary btn-user btn-block" OnClick="LoginBtn_Click" />
                                            <hr />
                                        </div>
                                        <!-- 其他链接 -->
                                        <a href="index.html" class="btn btn-google btn-user btn-block">
                                            <%--<i class="fab fa-google fa-fw"></i>--%> 
                                            Make your group trip dreams come true!
                                        </a>
                                        <a href="index.html" class="btn btn-facebook btn-user btn-block">
                                            <%--<i class="fab fa-facebook-f fa-fw"></i>--%>
                                            Break from your routine and play a little!
                                        </a>
                                        <hr />

                                        <div class="text-center">
                                            <%--<a class="small" href="Register.aspx">Create an Account!</a>--%>
                                            <asp:Button ID="RegisterBtn" runat="server" Text="Register" CssClass="btn btn-light btn-user btn-block" OnClick="RegisterBtn_Click" />
                                        </div>

                                        <div class="text-center">
                                            <%--<a class="small" href="ForgotPassword.aspx">Forgot Password?</a>--%>
                                            <asp:Button ID="FotgetBtn" runat="server" Text="Forget Password?" CssClass="btn btn-dark btn-user btn-block" OnClick="FotgetBtn_Click" />

                                        </div>
                                        
                                    </div>
                                </div>
                                <!-- 登录表单结束 -->



                            </div>
                        </div>
                    </div>

                </div>

            </div>

        </div>

        <!-- Bootstrap core JavaScript-->
        <script src="~/Assets/vendor/jquery/jquery.min.js"></script>
        <script src="~/Assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="~/Assets/vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for all pages-->
        <script src="~/Assets/JS/sb-admin-2.min.js"></script>

        <!--      Login with Google api async defer        -->
        <script src="https://apis.google.com/js/platform.js" async defer></script>
    </form>
</body>

    <script>
    var counter = 1;
    setInterval(function(){
        document.getElementById('r' + counter).checked = true;
        counter++;
        if(counter > 7){
            counter = 1;
        }
    }, 2500); // 500毫秒 = 0.5秒
    </script>

</html>
