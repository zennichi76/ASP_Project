<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EADP_Project.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .fullscreen_bg {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background-size: cover;
            background-position: 50% 50%;
            background-image: url("/img/login_bg.jpeg");
            background-repeat: repeat;
        }

        .form-signin {
            height: 200px;
            width: 400px;
            position: fixed;
            top: 45%;
            left: 50%;
            margin-top: -100px;
            margin-left: -200px;
        }

        h2 {
            color: white;
        }

        h1 {
            color: white;
            font-family: monospace;
            font-size: 3em;
        }

        #LoginBtn, #RegistrationBtn {
            margin-top: 25px;
        }

        a:link, a:visited {
            color: white;
            text-decoration: none;
            cursor: default;
        }
    </style>
</head>
<body>
    <div id="fullscreen_bg" class="fullscreen_bg" />
    <form id="form1" class="form-signin" runat="server">
        <div runat="server" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; z-index: 10; background-color: rgba(0,0,0,0.5);" id="modalOverlay">
                <div class="content" style="width: 600px; height: 100% auto; position: fixed; top: 50%; left: 50%; margin-top: -350px; margin-left: -350px; background-color: white; border-radius: 5px; text-align:left; z-index: 11; padding: 50px;">
                    <p>
                        <asp:Label ID="MessageLabel" runat="server"></asp:Label>
                    </p>
                    <p>Please enter the code on your Google Authenticator App</p>
                    <asp:TextBox ID="gAuthTb" runat="server" CssClass="form-control col-lg-5" ></asp:TextBox>
                    <asp:Button ID="ProceedBtn" style="margin-top:15px" runat="server" CssClass="btn btn-light" Text="Proceed" UseSubmitBehavior="False" CausesValidation="False" OnClick="LoginBtn_Click" />
                </div>
        </div>
        <div class="container">
            <h1>TEAM ORION</h1>
            <h2>Please sign in</h2>
            <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>
            <label for="inputID" class="sr-only">User ID</label>
            <asp:TextBox ID="username_tb" runat="server" placeholder="Username" required="required" CssClass="form-control"></asp:TextBox>
            <label for="inputPassword" class="sr-only">Password</label>
            <asp:TextBox ID="password_tb" runat="server" placeholder="Password" required="required" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:Button ID="LoginBtn" CssClass="btn btn-primary" runat="server" Text="Sign in" OnClick="LoginBtn_Click" />
            <asp:Button ID="RegistrationBtn" CssClass="btn btn-danger" runat="server" Text="Register" OnClick="RegisterBtn_Click" CausesValidation="False" UseSubmitBehavior="False" />

            <div class="row">
                <asp:Button ID="ForgetSecQnsBtn" CssClass="btn btn-link" runat="server" Text="Forget Security Questions" CausesValidation="False" UseSubmitBehavior="False" ForeColor="White" OnClick="ForgetSecQnsBtn_Click" />
            </div>

        </div>

        <script src="js/popper.min.js"></script>
        <script src="js/jquery-3.2.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script type="text/javascript">
     // window.onload = assignName();
            $(document).ready(function () {

            });

            function uuidv4() {
                return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
                    (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16))
            }
            function assignName() {
                var winBrow = "guid_" + uuidv4();
                return winBrow;
            }

            console.log(assignName());
            // Check browser support
            if (typeof (Storage) !== "undefined") {
                // Store
                sessionStorage.setItem("browid", assignName());

            } else {
                alert("Sorry, your browser does not support Web Storage...");
            }
        </script>

    </form>




</body>
</html>
