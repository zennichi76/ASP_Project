using EADP_Project.BO;
using EADP_Project.Entities;
using Google.Authenticator;
using OtpSharp;
using System;

namespace EADP_Project
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack) {
                UserBO userbo = new UserBO();
                String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                user userobj = new user();
                userobj = userbo.getUserById(currentLoggedInUser);
                UsernameTB.Text = userobj.User_ID;
                NameTB.Text = userobj.name;
                EmailTB.Text = userobj.email;
                LastPwdChangeLbl.Text = userobj.pwd_startDate.ToShortDateString().ToString();
                DaysToChangeLbl.Text = (userobj.pwd_endDate - userobj.pwd_startDate).Days.ToString() + " days";
                ////GAuth Test////
                if (userobj.gAuth_Enabled == true)
                {
                    gAuthEnableLink.Visible = false;
                    gAuthDisableLink.Visible = true;
                }
                else
                {
                    gAuthEnableLink.Visible = true;
                    gAuthDisableLink.Visible = false;
                }
                gAuthCard.Visible = false;

                }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(ChangePwdTB.Text.Trim() == "" || ChangePwdTB.Text.Trim() == null || ChangePwdConfirmTB.Text.Trim() == "" || ChangePwdConfirmTB.Text.Trim() == null)
            {
                ErrorMsgLabel.Text = "One of the password fields is empty, Password is not changed.";
            }
            else if (ChangePwdConfirmTB.Text == ChangePwdTB.Text)
            {
                UserBO userbo = new UserBO();
                userbo.updatePwd(Request.Cookies["CurrentLoggedInUser"].Value, ChangePwdTB.Text);
                ErrorMsgLabel.Text = "Password is changed successfully!";
            }
            else
            {
                ErrorMsgLabel.Text = "Passwords are not the same. Password is not changed";
            }
        }

        protected void newEmailTB_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (newEmailTB.Text.Trim() == "" || newEmailTB.Text.Trim() == null)
            {
                ErrorMsgLabelEmail.Text = "Please input a valid email address";
            }
            else
            {
                UserBO userbo = new UserBO();
                userbo.updateEmail(Request.Cookies["CurrentLoggedInUser"].Value, newEmailTB.Text);
                ErrorMsgLabelEmail.Text = "Email is changed successfully!";
                EmailTB.Text = newEmailTB.Text;
            }
        }
        protected void google_auth_init()
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            string key = Base32.Base32Encoder.Encode(KeyGeneration.GenerateRandomKey(20));
            ViewState["key"] = key;
            var setupInfo = tfa.GenerateSetupCode("EADP", UsernameTB.Text, key, 250, 250);

            string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl; //  assigning the Qr code information + URL to string
            string manualEntrySetupCode = setupInfo.ManualEntryKey; // show the Manual Entry Key for the users that don't have app or phone
            gAuthImage.ImageUrl = qrCodeImageUrl;// showing the qr code on the page "linking the string to image element"
            gAuthManualKeyLbl.Text = manualEntrySetupCode; // showing the manual Entry setup code for the users that can not use their phone
        }

        protected void activateBtn_Click(object sender, EventArgs e)
        {
                string key = ViewState["key"].ToString();
                string user_enter = gAuthPassTb.Text;
                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                bool isCorrectPIN = tfa.ValidateTwoFactorPIN(key, user_enter);
                if (isCorrectPIN == true)
                {
                UserBO userbo = new UserBO();
                userbo.activate2FA(Request.Cookies["CurrentLoggedInUser"].Value, key);


                GoogleAuthErrorMsgLabel.Text = "";
                gAuthCard.Visible = false;
                mainPanel.Visible = true;
                gAuthEnableLink.Visible = false;
                gAuthDisableLink.Visible = true;
                gAuthSuccessMessage.Text = "Google Authenticator Activated";
            }
                else
                {

                GoogleAuthErrorMsgLabel.Text = "Incorrect PIN entered";
                }
        }

        protected void gAuthEnableLink_Click(object sender, EventArgs e)
        {

            gAuthCard.Visible = true;
            google_auth_init();
            mainPanel.Visible = false;
        }

        protected void gAuthDisableLink_Click(object sender, EventArgs e)
        {
            UserBO userbo = new UserBO();
            userbo.deactivate2FA(Request.Cookies["CurrentLoggedInUser"].Value);
            gAuthDisableLink.Visible = false;
            gAuthEnableLink.Visible = true;
            gAuthSuccessMessage.Text = "Google Authenticator Activated";
        }
    }
}