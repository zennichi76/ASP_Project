<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EADP_Project.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .fullscreen_bg{
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background-size: cover;
            background-position: 50% 50%;
            background-image: url("/img/login_bg.jpeg");
            background-repeat:repeat;
        }
        .form-signin{
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
        h1{
            color: white;
            font-family: monospace;
            font-size: 3em;
        }
        #LoginBtn{
            margin-top: 25px;
        }
    </style>
</head>
<body>
    <div id="fullscreen_bg" class="fullscreen_bg"/>
    <form id="form1" class="form-signin" runat="server">
        <div class="container">
            <h1>TEAM ORION</h1>
            <h2>Please sign in</h2>
            <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>
            <label for="inputID" class="sr-only">User ID</label>
            <asp:TextBox ID="username_tb" runat="server" placeholder="Username" required="required" CssClass="form-control"></asp:TextBox>
            <label for="inputPassword" class="sr-only">Password</label>
            <asp:TextBox ID="password_tb" runat="server" placeholder="Password" required="required" CssClass="form-control" TextMode="Password"></asp:TextBox>          
            <asp:Button ID="LoginBtn" CssClass="btn btn-primary" runat="server" Text="Sign in" OnClick="LoginBtn_Click" />
        </div>
    </form>
    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
