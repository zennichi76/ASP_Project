﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EADP_Project.Registration" %>

<head>

    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <style>
        ul, li {
              margin:0;
              padding:0;
              list-style-type:none;
               }

        form ul li {
                margin:10px 20px;

            }

        #pswd_info {
                position:absolute;
                bottom: 225px;
                bottom: -115px\9; /* IE Specific */
                right:55px;
                width:400px;
                padding:15px;
                background:#fefefe;
                font-size:.875em;
                border-radius:5px;
                box-shadow:0 1px 3px #ccc;
                border:1px solid #ddd;
                   }

        #pswd_info h4 {
                margin:0 0 10px 0;
                padding:0;
                font-weight:normal;
            }
        

        #pswd_info::before {
                content: "\25B2";
                position:absolute;
                top:-12px;
                left:45%;
                font-size:14px;
                line-height:14px;
                color:#ddd;
                text-shadow:none;
                display:block;
            }

        .invalid {
                background:url(../img/invalid.png) no-repeat 0 50%;
                padding-left:22px;
                line-height:24px;
                color:#ec3f41;
            }

        .valid {
                background:url(../img/valid.png) no-repeat 0 50%;
                padding-left:22px;
                line-height:24px;
                color:#3a7d34;
            }

        #pswd_info {
                display:none;
            }

    </style>

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
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:TextBox ID="inputNameTB" runat="server" CssClass="form-control" placeholder="Full Name" required pattern ="^[a-zA-Z\s]*$"></asp:TextBox>
                                <span id="spnError" style="color: Red; display: none"></span>
                                 <asp:Label ID="errNameLbl" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="form-group col-md-6">
                                <asp:TextBox ID="inputNRICTB" runat="server" CssClass="form-control" placeholder="NRIC, This will be used as your user id" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="mt-1">
                                <asp:TextBox ID="emailTB" runat="server" CssClass="form-control" placeholder="email: @example.com" TextMode="Email" required pattern="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ></asp:TextBox>
                            </div>
                            <hr />
                            <div class="mt-1">
                                <asp:TextBox ID="passwordTB" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" onkeyup="CheckPasswordStrength(this.value)" required></asp:TextBox>
                            </div>

                            <div class="mt-1">
                                <span id="password_strength"></span>
                                </div>
                            <div class="mt-1" id="pswd_info">
                                <h4>Password must meet the following requirements:</h4>
                                    <ul>
                                         <li id="length" class="invalid">Be at least <strong>8 characters</strong></li>
                                         <li id="capital" class="invalid">At least <strong>one uppercase letter</strong></li>
                                         <li id="letter" class="invalid">At least <strong>one lowercase letter</strong></li>                                      
                                         <li id="number" class="invalid">At least <strong>one number</strong></li>  
                                         <li id="alphanum" class="invalid">At least <strong>one non-alphanumeric character</strong></li>     
                                    </ul>
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
                                    Hello,You're going to be timed out due to inactivity in <span id="minutes"></span> minutes and <span id="seconds"></span>&nbsp;seconds.<br />
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

                                <div class="modal" tabindex="-1" role="dialog" id="accountCreationFail" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Account Created Failed</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                   Account Creation Fail. Please Try Again.
                                </p>
                            </div>
                            <div class="modal-footer">
                                 <button type="button" class="btn btn-primary"  data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>


            </div>


        </div>

                 <script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script> 
        <script src="js/popper.min.js"></script>
        <script src="js/jquery-3.2.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.simulate.js"></script>

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
                        document.getElementById("<%=ConfirmPasswordTB.ClientID%>").style.borderColor = "Green";
                        document.getElementById("<%=passwordTB.ClientID%>").style.borderColor = "Green";
                        document.getElementById("<%=ConfirmPasswordTB.ClientID%>").style.borderWidth = "2px";
                        document.getElementById("<%=passwordTB.ClientID%>").style.borderWidth = "2px";
                    } else
                        document.getElementById("<%=ConfirmPasswordTB.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ConfirmPasswordTB.ClientID%>").style.borderWidth = "2px";
                    document.getElementById("<%=passwordTB.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=passwordTB.ClientID%>").style.borderWidth = "2px";

                });

            });


            $('#<%=inputNRICTB.ClientID%>').keyup(function () {
                var nric_num = $(this).val();
                nric_num = nric_num.replace(/[^0-9 a-z A-Z]+/g, "").replace(/(^\s||\s$)+/, "").toUpperCase();
                $(this).val(nric_num);
                if (nric_num.length == 9 && validateNRIC(nric_num)) {
                    document.getElementById("<%=inputNRICTB.ClientID%>").style.borderColor = "Green";
                        document.getElementById("<%=inputNRICTB.ClientID%>").style.borderWidth = "2px";
                        document.getElementById("<%=RegisterBtn.ClientID%>").disabled = false;
                    } else {
                        document.getElementById("<%=inputNRICTB.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=inputNRICTB.ClientID%>").style.borderWidth = "2px";
                        document.getElementById("<%=RegisterBtn.ClientID%>").disabled = true;
                    }

                }).click(function () {
                    $(this).select();
                }).blur(function () {

                });

            $('#<%=inputNameTB.ClientID%>').keyup(function () {
                var requriedPattern = /^[a-zA-Z\s]*$/;
                var value = $(this).val();
                if (requriedPattern.test(value)) {
                    //pass
                    document.getElementById("<%=inputNameTB.ClientID%>").style.borderColor = "Green";
                    document.getElementById("<%=inputNameTB.ClientID%>").style.borderWidth = "2px";
                } else {
                    //fail
                    document.getElementById("<%=inputNameTB.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=inputNameTB.ClientID%>").style.borderWidth = "2px";

                }

            }).click(function () {
                $(this).select();
            }).blur(function () {

            });

            $('#<%=emailTB.ClientID%>').keyup(function () {
                var requriedPattern = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
                var value = $(this).val();
                if (requriedPattern.test(value)) {
                    //pass
                    document.getElementById("<%=emailTB.ClientID%>").style.borderColor = "Green";
                    document.getElementById("<%=emailTB.ClientID%>").style.borderWidth = "2px";
                } else {
                    //fail
                    document.getElementById("<%=emailTB.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=emailTB.ClientID%>").style.borderWidth = "2px";
                }

            }).click(function () {
                $(this).select();
            }).blur(function () {

            });

                // Password complexity
                $('input[type=password]').keyup(function () {
                  
                    var pswd = $(this).val();

                    //validate the length
                    if (pswd.length < 8) {
                        $('#length').removeClass('valid').addClass('invalid');
                    } else {
                        $('#length').removeClass('invalid').addClass('valid');
                    }

                    //validate letter
                    if (pswd.match(/[A-z]/)) {
                        $('#letter').removeClass('invalid').addClass('valid');
                    } else {
                        $('#letter').removeClass('valid').addClass('invalid');
                    }

                    //validate capital letter
                    if (pswd.match(/[A-Z]/)) {
                        $('#capital').removeClass('invalid').addClass('valid');
                    } else {
                        $('#capital').removeClass('valid').addClass('invalid');
                    }

                    //validate number
                    if (pswd.match(/\d/)) {
                        $('#number').removeClass('invalid').addClass('valid');
                    } else {
                        $('#number').removeClass('valid').addClass('invalid');
                    }

                    //validate non-alphanumeric character
                    if (pswd.match(/[$@$!%*#?&]/)) {
                        $('#alphanum').removeClass('invalid').addClass('valid');
                    } else {
                        $('#alphanum').removeClass('valid').addClass('invalid');
                    }
                 
                }).focus(function () {
                    $('#pswd_info').show();
                }).blur(function () {
                    $('#pswd_info').hide();
                });

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
                $('#userExistModal').modal('show');
            }

            function openRedirectModal() {
                $('#accountCreatedModal').modal('show');
            }

            function openAccFModal() {
                $('#accountCreationFail').modal('show');
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

        </script>

    </form>



</body>

