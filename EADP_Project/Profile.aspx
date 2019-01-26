﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EADP_Project.Profile" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.simulate.js"></script>
      <script type="text/javascript">
        


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12">
                <div runat="server" id="mainPanel" class="card" style="margin: 0 auto; margin-top: 25px">
                    <div class="card-header">
                        <h4>Profile</h4>
                    </div>
                    <div class="card-body">
                        <a href="Dashboard.aspx">Return to Dashboard</a>
                        <p></p>
                        <p>
                            Username:
                            <asp:Label ID="UsernameTB" runat="server"></asp:Label>
                        <br>
                            Name:
                            <asp:Label ID="NameTB" runat="server"></asp:Label>
                        <br>
                            Email:
                            <asp:Label ID="EmailTB" runat="server"></asp:Label>
                        <br>
                            Access History 

                            <asp:GridView ID="accessLogView"  CssClass="table table-bordered table-light" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ip" HeaderText="IP Address" />
                                    <asp:BoundField HeaderText="Access Time" DataField="accessTime" />
                                </Columns>
                            </asp:GridView>

                        </p>
                        <p>
                            Change Email:                       
                        </p>
                        <p style="color: red">
                            <asp:Label ID="ErrorMsgLabelEmail" runat="server"></asp:Label>
                        </p>
                        <div class="row">
                            <asp:TextBox ID="newEmailTB" runat="server" Style="margin-left: 15px" CssClass="form-control col-lg-2" placeholder="New Email" OnTextChanged="newEmailTB_TextChanged" ></asp:TextBox>
                            
                        </div>
                        <asp:Button ID="Button2" CssClass="btn btn-outline-dark" runat="server" Style="margin-top: 15px" Text="Change Email" OnClick="Button2_Click" UseSubmitBehavior="False" />
                        <p></p>
                        <p>
                            Change Password:                       
                        </p>
                        <p style="color: grey">
                            Password Last Changed on <asp:Label ID="LastPwdChangeLbl" runat="server"></asp:Label> &nbsp;(Valid for: <asp:Label ID="DaysToChangeLbl" runat="server"></asp:Label> )
                        </p>
                        <p style="color: red">
                            <asp:Label ID="ErrorMsgLabel" runat="server"></asp:Label>
                        </p>

                        <div class="mt-1">
                            <asp:TextBox ID="ChangePwdTB" runat="server" TextMode="Password" CssClass="form-control col-lg-2" placeholder="New Password" onkeyup="CheckPasswordStrength(this.value)"></asp:TextBox>
                             <div class="mt-1">
                                <span id="password_strength"></span>
                                </div>
                            <asp:TextBox ID="ChangePwdConfirmTB" runat="server" TextMode="Password" CssClass="form-control col-lg-2" placeholder="Confirm Password"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button1" CssClass="btn btn-outline-dark" runat="server" Style="margin-top: 15px" Text="Change Password" OnClick="Button1_Click" UseSubmitBehavior="False" />
                    
                        <p></p>
                        <p>
                            Google Authenticator: <asp:LinkButton ID="gAuthEnableLink" runat="server" OnClick="gAuthEnableLink_Click" CausesValidation="False">Add Google Authenticator</asp:LinkButton>                       
                            <asp:LinkButton ID="gAuthDisableLink" runat="server" OnClick="gAuthDisableLink_Click" CausesValidation="False" >Remove Google Authenicator</asp:LinkButton>                       
                            <asp:Label ID="gAuthSuccessMessage" style="color: red" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="card"  runat="server" id="gAuthCard" style="margin: 0 auto; margin-top: 25px">
                    <div class="card-header">
                        <h4>Google Authenticator</h4>
                    </div>
                    <div class="card-body">
                        <p>To enable Google Authenticator, first scan this QR code in the Google Authenticator App on your phone:</p>
                        <asp:Image ID="gAuthImage" runat="server" />
                        <p>Alternatively, enter this secret key to your Google Authenticator App on your phone <br><asp:Label ID="gAuthManualKeyLbl" runat="server"></asp:Label></p>
                        <p>Next, enter the 6-digit passcode it gives you here to activate</p>
                        <asp:TextBox ID="gAuthPassTb" runat="server" CssClass="form-control col-lg-2" TextMode="Password"></asp:TextBox>
                        
                        <p style="color: red">
                            <asp:Label ID="GoogleAuthErrorMsgLabel" runat="server"></asp:Label>
                        </p>
                        <asp:Button ID="activateBtn" type="button" CssClass="btn btn-outline-dark" runat="server" Style="margin-top: 15px" Text="Activate" OnClick="activateBtn_Click" UseSubmitBehavior="False"/>
                     
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
                                <p><%--<span id="minute"></span>&nbsp;minutes and --%>
                                    Hello,You're going to be timed out due to inactivity in&nbsp;<span id="seconds"></span>&nbsp;seconds.<br />
                                    Do You want to reset?'
                                </p>
                            </div>
                            <div class="modal-footer">
                              <asp:Button ID="Button3" runat="server" Text="Yes" OnClick="ResetSessionBtn_OnClick"  class="btn btn-light"/>
                              <%--  <button type="button" class="btn btn-light" id="ResetSessionBtn" onserverclick="ResetSessionBtn_OnClick" runat="server" AutoPostBack="False">Yes</button>--%>
                                <button type="button" class="btn btn-primary" id="Button4" onserverclick="RemoveSessionBtn_OnClick" runat="server">No</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of session modal-->
            

       <div class="modal" tabindex="-1" role="dialog" id="sessionResetSucceed" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Session Reset Succeed</h5>
                    
                </div>
                <div class="modal-body">
                    <p>
                       Your Session is reset successfully!
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Thank You.</button>
                </div>
            </div>
        </div>
    </div>
    <!--end of session modal-->
     <div class="modal" tabindex="-1" role="dialog" id="errModal" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Session Reset Failed</h5>
                </div>
                <div class="modal-body">
                    <p>
                      Your session is not reset. You will be redirected to the login page.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" onserverclick="RemoveSessionBtn_OnClick" runat="server">Okay I got it.</button>
                </div>
            </div>
        </div>
    </div>
    <!--end of session modal-->

      <script type="text/javascript">
          function openModal() {
              $('#sessionResetSucceed').modal('show');
          }
          // Password Strength 
          function CheckPasswordStrength(password) {
                var password_strength = document.getElementById("password_strength");

                //TextBox left blank.
                if (password.length == 0) {
                    password_strength.innerHTML = "";
                    return;
                }

                //Regular Expressions.
                var regex = new Array();
                regex.push("[A-Z]"); //Uppercase Alphabet.
                regex.push("[a-z]"); //Lowercase Alphabet.
                regex.push("[0-9]"); //Digit.
                regex.push("[$@$!%*#?&]"); //Special Character.

                var passed = 0;

                //Validate for each Regular Expression.
                for (var i = 0; i < regex.length; i++) {
                    if (new RegExp(regex[i]).test(password)) {
                        passed++;
                    }
                }

                //Validate for length of Password.
                if (passed > 2 && password.length > 8) {
                    passed++;
                }

                //Display status.
                var color = "";
                var strength = "";
                switch (passed) {
                    case 0:
                    case 1:
                        strength = "Weak";
                        color = "red";
                        break;
                    case 2:
                        strength = "Good";
                        color = "darkorange";
                        break;
                    case 3:
                        strength = "Strong";
                        color = "green";
                        break;
                    case 4:
                        strength = "Very Strong";
                        color = "darkgreen";
                        break;

                }
                password_strength.innerHTML = strength;
                password_strength.style.color = color;
            }

          function openFModal() {
              $('#errModal').modal('show');
          }
          ////Testing for idle timeout 
          var idleTime = 0;
          var timeout = 0;
          var tempTime = 0;

          function sessionAlert(timeout) {
              //Increment the idle time counter every minute.
              var time = timeout;
              var seconds = timeout / 1000;
              var minute = timeout / 60000;
              console.log("reach");

              $("#seconds").html(seconds);
              setInterval(function () {
                  seconds--;
                  $("#seconds").html(seconds);
              }, 1000);
              setTimeout(function () {
                  //Show Popup before 20 seconds of timeout.
                  $('#sessionTimeOutWarningModal').modal('show');
              }, timeout - 30 * 1000);
              setTimeout(function () {
                  //Show Popup after the previous popup
                  $('#sessionTimeOutWarningModal').modal('hide');
                  $('#reloadWarning').modal('show');
                  //setTimeout(function () {
                  //    $("#RemoveSessionBtn").simulate("click");
                  //}, 6000);
              }, timeout - 0 * 1000);
          }


    </script>
    </form>
</asp:Content>
