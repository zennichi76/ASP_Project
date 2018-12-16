<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetSecurityQuestion.aspx.cs" Inherits="EADP_Project.ResetSecurityQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>


    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12" style="margin-top: 25px">
                <div class="card">
                    <div class="card-header">
                        <h3>Reset Security Questions</h3>
                    </div>
                    <div class="card-body">
                        <asp:Panel ID="emailPanel" runat="server">
                            <div class="enterEmail">
                                <h4>Enter Your Email Address</h4>

                                <input type="email" class="form-control" id="inputEmail" placeholder="Email" />
                                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="cancel_Click" />
                                 <asp:Button ID="submitEmailBtn" runat="server" Text="Continue" CssClass="btn btn-primary" OnClick="submitEmailBtn_Click"  />
                                <%--<button class="btn btn-primary" id="submitEmailBtn">Continue</button>--%>

                            </div>
                        </asp:Panel>

                        <asp:Panel ID="passwordPanel" runat="server" Visible="false">
                            <div class="enterPassword">
                                <h4>Enter Your Password</h4>
                                <input type="password" class="form-control" id="inputPassword" placeholder="Password" />
                                <asp:Button ID="cancelBtnForPassword" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="cancel_Click" />
                                <asp:Button ID="submitPasswordBtn" runat="server" Text="Continue" CssClass="btn btn-primary" OnClick="submitPasswordBtn_Click" />
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="answerSecurityQ" runat="server" Visible="false">
                            <div class="enterSecQ">
                                <h4>Answer Your Current Security Questions</h4>
                                
                                <select id="SecurityQuestion" class="form-control">
                                <option>This will be populated with the security Question user choose</option>
                                    <option>SQ1</option>
                                    <option>SQ2</option>
                                    <option>SQ3</option>
                            </select>

                                 <input type="text" class="form-control" id="securityQuestion" placeholder="Full Name"/>

                                <asp:Button ID="cancelBtnForSecurityQuestion" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="cancel_Click" />
                                <asp:Button ID="submitAnsweredSQBtn" runat="server" Text="Continue" CssClass="btn btn-primary" OnClick="submitAnsweredSQBtn_Click" />
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="resetSeurityPanel" runat="server" Visible="false">
                            <div class="resetSecQ">
                               
                        <div class="form-group">
                            <select id="SecurityQuestion1" class="form-control">
                                <option selected>Security Question 1</option>
                                <option>...</option>
                            </select>
                            <input type="text" class="form-control" id="securityQuestion1" placeholder="Answer"/>
                        </div>
                         <br />
                        <div class="form-group">
                            <select id="SecurityQuestion2" class="form-control">
                                <option selected>Security Question 2</option>
                                <option>...</option>
                            </select>
                            <input type="text" class="form-control" id="securityQuestion2" placeholder="Answer"/>
                        </div>
                         <br />
                        <div class="form-group">
                            <select id="SecurityQuestion3" class="form-control">
                                <option selected>Security Question 3</option>
                                <option>...</option>
                            </select>
                            <input type="text" class="form-control" id="securityQuestion3" placeholder="Answer"/>
                        </div>

                                <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="cancel_Click" />
                                <asp:Button ID="submitSQBtn" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="submitSQBtn_Click" />
                            </div>
                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">



</script>


</body>
</html>
