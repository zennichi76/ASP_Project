<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EADP_Project.Registration" %>

<head>

    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12" style="margin-top: 25px">
                <asp:Panel ID="regsitrationPanel" runat="server">
                    <div class="card">
                    <div class="card-header">
                        <h4>Registration</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:TextBox ID="inputNameTB" runat="server" CssClass="form-control" placeholder="Full Name" required pattern="[a-zA-Z ]*"></asp:TextBox>
                                <span id="spnError" style="color: Red; display: none"></span>
                                 <asp:Label ID="errNameLbl" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="form-group col-md-6">
                                <asp:TextBox ID="inputNRICTB" runat="server" CssClass="form-control" placeholder="NRIC, This will be used as your user id" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="mt-1">
                                <asp:TextBox ID="emailTB" runat="server" CssClass="form-control" placeholder="email: @example.com" TextMode="Email" required></asp:TextBox>
                            </div>
                            <hr />
                            <div class="mt-1">
                                <asp:TextBox ID="passwordTB" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" required></asp:TextBox>
                            </div>
                            <div class="mt-1">
                                <asp:TextBox ID="ConfirmPasswordTB" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password" required></asp:TextBox>
                            </div>
                            <hr>
                            <p class="text-center">Security Questions</p>
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
                            <hr />

                            <div id="ReCaptchContainer"></div> 
                               <asp:Label ID="errCaptcha" runat="server" Text="Captcha Fail. Please Redo the captcha." Visible="false" Font-Bold="True" ForeColor="Red"></asp:Label> 

                            <hr />
                            <div class="text-center">
                                <asp:Button ID="RegisterBtn" runat="server" Text="Register" class="btn btn-primary" OnClick="RegisterBtn_Click" />
                            </div>

                        </div>

                    </div>
                </div>
                </asp:Panel>

                <div class="modal" tabindex="-1" role="dialog" id="userExistModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Error: NRIC / Email Exist</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                   The current NRIC Exist/ Email Exist! Please type a new NRIC/Email. <br /> 
                                    If you are an user, Please sign in instead.
                                </p>
                            </div>
                            <div class="modal-footer">
                                 <button type="button" class="btn btn-primary" id="closeModalBtn" data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of userExistModal-->

                <div class="modal" tabindex="-1" role="dialog" id="accountCreatedModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Account Created Successful</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                   Congratulation, Your account is created! You will be redirected to confirm your account.
                                </p>
                            </div>
                            <div class="modal-footer">
                               
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of userExistModal-->

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

           


            </div>


        </div>
      

        <script src="js/popper.min.js"></script>
        <script src="js/jquery-3.2.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.simulate.js"></script>
         <script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script> 

        <script type="text/javascript">

            //for captcha
            var your_site_key = '<%= ConfigurationManager.AppSettings["SiteKey"]%>';
            var renderRecaptcha = function () {
                grecaptcha.render('ReCaptchContainer', {
                    'sitekey': your_site_key,
                    'callback': reCaptchaCallback,
                    theme: 'light', //light or dark    
                    type: 'image',// image or audio    
                    size: 'normal'//normal or compact    
                });
            };

            var reCaptchaCallback = function (response) {
                if (response !== '') {
                  
                }
            };

        


            $(document).ready(function () {
                //for validating password is the same
                $('#<%=passwordTB.ClientID%>, #<%=ConfirmPasswordTB.ClientID%>').on('keyup', function () {
                    if ($('#<%=passwordTB.ClientID%>').val() == $('#<%=ConfirmPasswordTB.ClientID%>').val()) {
                        document.getElementById("<%=ConfirmPasswordTB.ClientID%>").style.borderColor = "green";
                        document.getElementById("<%=ConfirmPasswordTB.ClientID%>").style.borderWidth = "2px";
                    } else
                        document.getElementById("<%=ConfirmPasswordTB.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=ConfirmPasswordTB.ClientID%>").style.borderWidth = "2px";
                });
            });

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



            function openModal() {
                $('#userExistModal').modal('show');
            }

            function openRedirectModal() {
                $('#accountCreatedModal').modal('show');
            }

            //for validating NRIC
            function validateNRIC(nric) {
                if (nric.length != 9) {
                    return false;
                }

                nric = nric.toUpperCase();

                var i,
                    icArray = [];
                for (i = 0; i < 9; i++) {
                    icArray[i] = nric.charAt(i);
                }

                icArray[1] = parseInt(icArray[1], 10) * 2;
                icArray[2] = parseInt(icArray[2], 10) * 7;
                icArray[3] = parseInt(icArray[3], 10) * 6;
                icArray[4] = parseInt(icArray[4], 10) * 5;
                icArray[5] = parseInt(icArray[5], 10) * 4;
                icArray[6] = parseInt(icArray[6], 10) * 3;
                icArray[7] = parseInt(icArray[7], 10) * 2;

                var weight = 0;
                for (i = 1; i < 8; i++) {
                    weight += icArray[i];
                }

                var offset = (icArray[0] == "T" || icArray[0] == "G") ? 4 : 0;
                var temp = (offset + weight) % 11;

                var st = ["J", "Z", "I", "H", "G", "F", "E", "D", "C", "B", "A"];
                var fg = ["X", "W", "U", "T", "R", "Q", "P", "N", "M", "L", "K"];

                var theAlpha;
                if (icArray[0] == "S" || icArray[0] == "T") { theAlpha = st[temp]; }
                else if (icArray[0] == "F" || icArray[0] == "G") { theAlpha = fg[temp]; }

                return (icArray[8] === theAlpha);
                console.log("true");
            }

            $('#<%=inputNRICTB.ClientID%>').keyup(function () {
                var nric_num = $(this).val();
                nric_num = nric_num.replace(/[^0-9 a-z A-Z]+/g, "").replace(/(^\s||\s$)+/, "").toUpperCase();
                $(this).val(nric_num);
                if (nric_num.length == 9 && validateNRIC(nric_num)) {
                    document.getElementById("<%=inputNRICTB.ClientID%>").style.borderColor = "green";
                    document.getElementById("<%=inputNRICTB.ClientID%>").style.borderWidth = "2px";
                } else {
                    document.getElementById("<%=inputNRICTB.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=inputNRICTB.ClientID%>").style.borderWidth = "2px";
                }

            }).click(function () {
                $(this).select();
            }).blur(function () {

            });


            //for previewing images
            function ShowPreview(input) {
                if (input.files && input.files[0]) {
                    var ImageDir = new FileReader();
                    ImageDir.onload = function (e) {
                        $('#firstImagePreview').attr('src', e.target.result);
                        $('#firstImagePreview').css('height', '500px').show();	//	just that simple
                        $('#firstImagePreview').css('width', '500px').show();	//	just that simple

                    }
                    ImageDir.readAsDataURL(input.files[0]);
                }
            }

            function ShowSecPreview(input) {
                if (input.files && input.files[0]) {
                    var ImageDir = new FileReader();
                    ImageDir.onload = function (e) {
                        $('#secondImagePreview').attr('src', e.target.result);
                        $('#secondImagePreview').css('height', '300px').show();	//	just that simple
                        $('#secondImagePreview').css('width', '400px').show();	//	just that simple
                    }
                    ImageDir.readAsDataURL(input.files[0]);
                }
            }


            function ShowThirdPreview(input) {
                if (input.files && input.files[0]) {
                    var ImageDir = new FileReader();
                    ImageDir.onload = function (e) {
                        $('#ThirdImagePreview').attr('src', e.target.result);
                        $('#ThirdImagePreview').css('height', '300px').show();	//	just that simple
                        $('#ThirdImagePreview').css('width', '400px').show();	//	just that simple
                    }
                    ImageDir.readAsDataURL(input.files[0]);
                }
            }




        </script>



      
    </form>



</body>

