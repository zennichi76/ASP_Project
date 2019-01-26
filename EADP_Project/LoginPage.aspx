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
                    <asp:Button ID="ProceedBtn" style="margin-top:15px" runat="server" CssClass="btn btn-light" Text="Proceed" UseSubmitBehavior="False" CausesValidation="False" OnClick="ProceedBtn_Click" />
               
                            
                    <div class="content2">
                     <p>I want to use Security Question instead</p>
                     <p><asp:Button ID="sqBtn" style="margin-top:15px" runat="server" CssClass="btn btn-link" Text="Answer Security Questions" UseSubmitBehavior="False" CausesValidation="False" OnClick="sqBtn_Click"/></p>

                </div>    
                
                </div>

        </div>

        
        <div runat="server" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; z-index: 10; background-color: rgba(0,0,0,0.5);" id="SQoverLay" visible="false">
                <div class="content" style="width: 800px; height: 100% auto; position: fixed; top: 50%; left: 50%; margin-top: -350px; margin-left: -350px; background-color: white; border-radius: 5px; text-align:left; z-index: 11; padding: 50px;">
                    <p>
                        <asp:Label ID="SQlbl" runat="server"></asp:Label>
                    </p>
                     <div class="enterSecQ">
                                <h4>Answer Your Current Security Questions</h4>
                                <asp:Label ID="errLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
                           <asp:Label ID="SQAns1Lbl" runat="server" Text="" Visible="false"></asp:Label>
                         <asp:Label ID="SQAns2Lbl" runat="server" Text="" Visible="false"></asp:Label>
                           <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <div class="row">
                                    <asp:Image ID="Image1" runat="server" />
                                </div>
                                <div class="row">
                                    <asp:TextBox ID="FirstsecurityQnAnsTB" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                          <div class="row">
                                  <asp:Image ID="Image2" runat="server" />
                              </div>
                          <div class="row">
                                <asp:TextBox ID="SecondsecurityQnAnsTB" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                           <asp:Button ID="submitAnsweredSQBtn" style="margin-top:15px" runat="server" CssClass="btn btn-light" Text="Proceed" UseSubmitBehavior="False" CausesValidation="False" OnClick="submit_OnClick" />
                              
                            </div>
                </div>
        </div>

         <div runat="server" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; z-index: 10; background-color: rgba(0,0,0,0.5);" id="accountNotActivated" visible="false">
                <div class="content" style="width: 600px; height: 100% auto; position: fixed; top: 50%; left: 50%; margin-top: -250px; margin-left: -350px; background-color: white; border-radius: 5px; text-align:left; z-index: 11; padding: 50px;">
                    <p>
                        <asp:Label ID="activateAccountLbl" runat="server"></asp:Label>
                    </p>
                    <p> Hello, You have not activate your account, Please click the button below to be redirected to activate your account. </p>
                    <asp:Button ID="actBtn" runat="server" CssClass="btn btn-light" Text="Go to Activate My Account"  CausesValidation="False" UseSubmitBehavior="False" OnClick="ActiveAccountBtn_Click" />
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
                <asp:Button ID="ForgetSecQnsBtn" CssClass="btn btn-link" runat="server" Text="Forget Security Questions" CausesValidation="False" UseSubmitBehavior="False" ForeColor="Black" OnClick="ForgetSecQnsBtn_Click" />
            </div>

             <div class="row" id="captchaRow" runat="server" style="display:none">
                   <div id="ReCaptchContainer" runat="server"></div> 
                   <asp:Label ID="errCaptcha" runat="server" Visible="false" Font-Bold="True" ForeColor="Red" clientidmode="static"></asp:Label> 
            </div>

        </div>
         <script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script> 
        <script src="js/popper.min.js"></script>
        <script src="js/jquery-3.2.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
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
