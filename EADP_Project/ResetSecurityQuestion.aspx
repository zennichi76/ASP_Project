﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetSecurityQuestion.aspx.cs" Inherits="EADP_Project.ResetSecurityQuestion" %>

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
                                <h4>Enter Your UserId</h4>
                                <asp:TextBox ID="inputIdTB" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="cancel_Click" />
                                <asp:Button ID="submitIdBtn" runat="server" Text="Continue" CssClass="btn btn-primary" OnClick="submitIdBtn_Click" />

                            </div>
                        </asp:Panel>

                        <asp:Panel ID="passwordPanel" runat="server" Visible="false">
                            <div class="enterPassword">
                                <h4>Enter Your Password</h4>
                                <asp:TextBox ID="inputPasswordTB" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:Button ID="cancelBtnForPassword" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="cancel_Click" />
                                <asp:Button ID="submitPasswordBtn" runat="server" Text="Continue" CssClass="btn btn-primary" OnClick="submitPasswordBtn_Click" />
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="answerSecurityQ" runat="server" Visible="false">
                            <div class="enterSecQ">
                                <h4>Answer Your Current Security Questions</h4>
                                <asp:Label ID="errLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <div class="row">
                                    <asp:DropDownList ID="imageDDL" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="imageDDL_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="row">
                                    <asp:Image ID="Image1" runat="server" />
                                </div>
                                <div class="row">
                                    <asp:TextBox ID="securityQntAnsTB" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:Button ID="cancelBtnForSecurityQuestion" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="cancel_Click" />
                                <asp:Button ID="submitAnsweredSQBtn" runat="server" Text="Continue" CssClass="btn btn-primary" OnClick="submitAnsweredSQBtn_Click" />
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="resetSeurityPanel" runat="server" Visible="false">
                            <div class="resetSecQ">
                              <p class="text-center">Reset Security Questions</p>
                            <div class="mt-2">
                                <asp:FileUpload ID="imageUpload" runat="server" CssClass="form-control-file" required />

                                <div class="mt-1">
                                    <asp:TextBox ID="firstImageAnsTB" runat="server" CssClass="form-control" placeholder="Answer to the first image" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="mt-2">
                                <asp:FileUpload ID="image2Upload" runat="server" CssClass="form-control-file" required/>
                                <div class="mt-1">
                                    <asp:TextBox ID="secondImageAnsTB" runat="server" CssClass="form-control" placeholder="Answer to the Second image" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="mt-2">
                                <asp:FileUpload ID="image3Upload" runat="server" CssClass="form-control-file" required/>
                                <div class="mt-1">
                                    <asp:TextBox ID="thirdImageAnsTB" runat="server" CssClass="form-control" placeholder="Answer to the third image" required></asp:TextBox>
                                </div>
                            </div>
                            <asp:Label ID="errLblForSQ" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="Red"></asp:Label> <br />
                            <p class="text-center font-weight-light">These images will be used to verify your identity and recover your password if you ever forget it.</p>

                                <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="cancel_Click" />
                                <asp:Button ID="submitSQBtn" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="submitSQBtn_Click" />
                            </div>
                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>

         <div class="modal" tabindex="-1" role="dialog" id="failModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Error:Unable to update Security Question</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                   Unable to update Security Question, Please try again.
                                </p>
                            </div>
                            <div class="modal-footer">
                                 <button type="button" class="btn btn-primary" data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>
                 <div class="modal" tabindex="-1" role="dialog" id="sModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Success</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                  Security Question is updated successfully! Click below to be redirected to Login Page.
                                </p>
                            </div>
                            <div class="modal-footer">
                                 <button type="button" class="btn btn-primary" runat="server" id="redirectLoginBtn" onserverclick="redirectLoginBtn_ServerClick">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>

        <div class="modal" tabindex="-1" role="dialog" id="wrongUserModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Wrong User ID</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                  User Does not exist.
                                </p>
                            </div>
                            <div class="modal-footer">
                                 <button type="button" class="btn btn-primary" data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>

          <div class="modal" tabindex="-1" role="dialog" id="wrongpwModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Wrong Password</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                  Input Password is incorect.
                                </p>
                            </div>
                            <div class="modal-footer">
                                 <button type="button" class="btn btn-primary" data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>

        <div class="modal" tabindex="-1" role="dialog" id="sessionTimeOutWarningModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Are you still there?</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Hello,You're going to be timed out due to inactivity in <span id="seconds"></span>&nbsp;seconds.<br />
                                    Do You want to reset?'
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-light" id="ResetSessionBtn" onserverclick="ResetSessionBtn_OnClick" runat="server">Yes</button>
                                <button type="button" class="btn btn-primary" id="RemoveSessionBtn" onserverclick="RemoveSessionBtn_OnClick" runat="server">No</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of session modal-->

                <div class="modal" tabindex="-1" role="dialog" id="redirectWarningModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Session Expired!</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Hello,Your session has timed out due to inactivity, Please proceed to login page
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" id="redirectBtn" onserverclick="RemoveSessionBtn_OnClick" runat="server">Return to LoginPage</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of redirect modal-->
               <script src="js/popper.min.js"></script>
        <script src="js/jquery-3.2.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.simulate.js"></script>
    <script type="text/javascript">

        ////Testing for idle timeout 
        var idleTime = 0;
        var timeout = 0;
        var tempTime = 0;

        function sessionAlert(timeout) {
            //Increment the idle time counter every minute.
            var time = timeout;
            var seconds = timeout / 1000;
            console.log("reach");
            setInterval(function () {
                seconds--;
                $("#seconds").html(seconds);
            }, 1000);
            setTimeout(function () {
                //Show Popup before 60 seconds of timeout.
                $('#sessionTimeOutWarningModal').modal('show');
            }, timeout - 60 * 1000);
            setTimeout(function () {
                //Show Popup after the previous popup
                $('#sessionTimeOutWarningModal').modal('hide');
                $('#redirectWarningModal').modal('show');
            }, timeout - 0 * 1000);
        }


        function openModal() {
            $('#failModal').modal('show');
        }

        function openSModal() {
            $('#sModal').modal('show');
        }

        function openUserDoesNotExist() {
            $('#wrongUserModal').modal('show');
        }

        function openWPModal() {
            $('#wrongpwModal').modal('show');
        }




</script>

    </form>



</body>
</html>
