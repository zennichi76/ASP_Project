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
                <div class="card">
                    <div class="card-header">
                        <h4>Registration</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:TextBox ID="inputNameTB" runat="server" CssClass="form-control" placeholder="Full Name" required pattern="[a-zA-Z ]*"></asp:TextBox>
                               <span id="spnError" style="color: Red; display: none">*Valid characters: Alphabets and space.</span>
                                <asp:Label ID="errLblForName" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </div> 
                          
                            <div class="form-group col-md-6">
                                <asp:TextBox ID="inputNRICTB" runat="server" CssClass="form-control" placeholder="NRIC, This will be used as your user id" ></asp:TextBox>
                            </div>
                        </div>
 
                        <div class="form-group">
                            <div class="mt-1">
                                <asp:TextBox ID="emailTB" runat="server" CssClass="form-control" placeholder="email: @example.com" TextMode="Email" ></asp:TextBox>
                            </div>
                            <hr />
                            <div class="mt-1">
                                <asp:TextBox ID="passwordTB" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" ></asp:TextBox>
                            </div>
                            <div class="mt-1">
                                <asp:TextBox ID="ConfirmPasswordTB" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password" ></asp:TextBox>
                            </div>
                            <hr>
                            <p class="text-center">Security Questions</p>
                            <div class="mt-2">
                                <asp:FileUpload ID="imageUpload" runat="server" CssClass="form-control-file" /> <%--onchange="ShowPreview(this)"--%>
                                <asp:Image ID="firstImagePreview" runat="server" />
                                <div class="mt-1">
                                    <asp:TextBox ID="firstImageAnsTB" runat="server" CssClass="form-control" placeholder="Answer to the first image"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mt-2">
                                <asp:FileUpload ID="image2Upload" runat="server" CssClass="form-control-file" />  <%--onchange="ShowSecPreview(this)"--%>
                                <asp:Image ID="secondImagePreview" runat="server" />
                                <div class="mt-1">
                                    <asp:TextBox ID="secondImageAnsTB" runat="server" CssClass="form-control" placeholder="Answer to the Second image"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mt-2">
                                <asp:FileUpload ID="image3Upload" runat="server" CssClass="form-control-file" />
                                <asp:Image ID="ThirdImagePreview" runat="server" />
                                <div class="mt-1">
                                    <asp:TextBox ID="thirdImageAnsTB" runat="server" CssClass="form-control" placeholder="Answer to the third image"></asp:TextBox>
                                </div>
                            </div>
                            <asp:Label ID="errLblForSQ" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <p class="text-center font-weight-light">These questions will be used to verify your identity and recover your password if you ever forget it.</p>
                            <hr />
                            captcha
                                <div class="text-center">
                                    <asp:Button ID="RegisterBtn" runat="server" Text="Register" class="btn btn-primary" OnClick="RegisterBtn_Click" />
                                </div>

                        </div>
                        <%-- OnClick="RegisterBtn_Click"--%>
                    </div>
                </div>
            </div>
        </div>


    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <script type="text/javascript">

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
                    $('#firstImagePreview').css('height', '300px').show();	//	just that simple
                    $('#firstImagePreview').css('width', '400px').show();	//	just that simple

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



        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>


    
</body>

