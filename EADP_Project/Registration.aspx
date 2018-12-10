<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EADP_Project.Registration" %>
<head>

    <title>

    </title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12" style="margin-top:25px">
                <div class="card">
                    <div class="card-header"><h4>Registration</h4></div>
                    <div class="card-body">
                        <%--Test Content
                        Only commit those files you have changed ok?--%>

                        <div class="form-row">

                            <div class="form-group">
                                <label for="Name">Name:</label>
                                <input type="text" class="form-control" id="inputName" placeholder="Full Name">

                            </div>
                            </div>

                            <div class="form-group">
                                 <label for="inputEmail">Email</label>
                                <input type="email" class="form-control" id="inputEmail" placeholder="Email">

                            </div>
                             <label for="inputPassword4">Password</label>
                                <input type="password" class="form-control" id="inputPassword" placeholder="Password">

                                <label for="inputNRIC">NRIC</label>
                                <input type="email" class="form-control" id="inputNRIC" placeholder="Type in your NRIC, This will be used as your user id">

                            <div class="form-group">
                                


                                <label for="inputPassword4">Confirm Password</label>
                                <input type="password" class="form-control" id="inputConfirmPassword" placeholder="Password">
                            </div>
                            <div class="form-group col-md-6">
                                <select id="SecurityQuestion1" class="form-control">
                                    <option selected>Security Question 1</option>
                                    <option>...</option>
                                </select>
                                <input type="text" class="form-control" id="securityQuestion1" placeholder="Full Name">
                            </div>
                            <div class="form-group col-md-6">
                                <select id="SecurityQuestion2" class="form-control">
                                   <option selected>Security Question 2</option>
                                    <option>...</option>
                                </select>
                                <input type="text" class="form-control" id="securityQuestion2" placeholder="Full Name">
                            </div>
                            <div class="form-group col-md-6">
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

