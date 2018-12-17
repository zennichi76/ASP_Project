<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EADP_Project.Registration" %>

<head>

    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12" style="margin-top: 25px">
                <div class="card">
                    <div class="card-header">
                        <h4>Registration</h4>
                    </div>
                    <div class="card-body">
                        <%--Test Content
                        Only commit those files you have changed ok?--%>

                        <div class="form-group">
                            
                            <asp:TextBox ID="inputNameTB" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="inputNRICTB" runat="server" CssClass="form-control" placeholder="Type in your NRIC, This will be used as your user id"></asp:TextBox>
                           
                        </div>


                        <div class="form-group">
                            <asp:TextBox ID="emailTB" runat="server" CssClass="form-control" placeholder="Type in your Email" TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="passwordTB" runat="server" CssClass="form-control" placeholder="Type In Your Password" TextMode="Password"></asp:TextBox>
                        
                            <br />
                            <asp:TextBox ID="ConfirmPasswordTB" runat="server" CssClass="form-control" placeholder="Please Confirm Your Password" TextMode="Password"></asp:TextBox>
                       
                        </div>

                        <div class="form-group">
                            <select id="SecurityQuestion1" class="form-control">
                                <option selected>Security Question 1</option>
                                <option>...</option>
                            </select>
                            <input type="text" class="form-control" id="securityQuestion1" placeholder="Full Name">
                        </div>
                         <br />
                        <div class="form-group">
                            <select id="SecurityQuestion2" class="form-control">
                                <option selected>Security Question 2</option>
                                <option>...</option>
                            </select>
                            <input type="text" class="form-control" id="securityQuestion2" placeholder="Full Name">
                        </div>
                         <br />
                        <div class="form-group">
                            <select id="SecurityQuestion3" class="form-control">
                                <option selected>Security Question 3</option>
                                <option>...</option>
                            </select>
                            <input type="text" class="form-control" id="securityQuestion3" placeholder="Full Name">
                        </div>

                        <div class="form-group col-md-6">
                            captcha
                        </div>

                        <button type="submit" class="btn btn-primary">Register</button>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

