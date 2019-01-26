<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmAccount.aspx.cs" Inherits="EADP_Project.ConfirmAccount" %>

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
                    <div class="card-header text-center">
                        <h4>Confirm Your Email </h4>
                    </div>
                    <div class="card-body">
                        <div class="row justify-content-center">
                               <label class="text-center">Please Check Your Email for a confirmation Email. </label> 
                        </div>
                         <div class="row justify-content-center">
                              <label class="text-center">Enter the code sent in your email to confirm your account. After You enter the code, click Ok</label>
                        </div>
                        <div class="row justify-content-center">
                            <asp:TextBox ID="confirmCodeTB" runat="server" CssClass="form-control text-center" TextMode="Number"></asp:TextBox>
                            <a href="#" data-toggle="popover" title="Please Fill up your code" data-content="Code cannot be empty"></a>
                        </div>
                        
                        <div class="row justify-content-center">
                             <label class="text-center">If you didn't receive the email, click the resend button below</label>
                        </div>
                   
                         <div class="row justify-content-center">
                              <asp:Button ID="resendBtn" runat="server" Text="Resend Email Confirmation" CssClass="btn btn-link" OnClick="resendBtn_Click"/>
                                <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn btn-link" OnClick="submitBtn_Click"/>
                        </div>
                        
                       

                    </div>
                </div>


            </div>


            <div class="modal" tabindex="-1" role="dialog" id="successModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Email Sent!</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Hello, A new account activation email is sent to your email. Please enter the new code and activate your account.
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" id="closeModalBtn" data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of successModal modal-->

             <div class="modal" tabindex="-1" role="dialog" id="codeExpireModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Verifcation Code is Expired!</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Activation Code is expired, Please get a new email verification and re-enter the code.
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" id="closeEModalBtn" data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of codeExpireModal modal-->

             <div class="modal" tabindex="-1" role="dialog" id="wrongCodeModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Verifcation Code is wrong!</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Invalid Activation Code, Please enter the code sent to your registered email.
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" id="closewrongCodeModalBtn" data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of wrongCodeModal modal-->

            <div class="modal" tabindex="-1" role="dialog" id="activateModal" data-keyboard="false" data-backdrop="static">>
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Account Activated!</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Your Account has been activated! You will be redirected to the Login Page
                                </p>
                            </div>
                          
                        </div>
                    </div>
                </div>
                <!--end of wrongCodeModal modal-->

             <div class="modal" tabindex="-1" role="dialog" id="activateFailModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Account Activation Fail!</h5>
                            </div>
                            <div class="modal-body">
                                <p>
                                    Your Account is not activated! Please resend the code and try again!
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" id="activateFailModalBtn" data-dismiss="modal">Okay</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of wrongCodeModal modal-->

        </div>

        <script src="js/popper.min.js"></script>
        <script src="js/jquery-3.2.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
         <script type="text/javascript">
             function openModal() {
                 $('#successModal').modal('show');
             }
             function openEModal() {
                 $('#codeExpireModal').modal('show');
                 
             }
             function openWModal() {
                 $('#wrongCodeModal').modal('show');
             }

             function openAModal() {
                 $('#activateModal').modal('show');
             }

             function openFModal() {
                 $('#activateFailModal').modal('show');
             }

             function openToggle() {
                 $('[data-toggle="popover"]').popover('show'); 
             }
             
           </script>

    </form>
</body>
</html>
