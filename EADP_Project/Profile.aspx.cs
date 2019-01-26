using EADP_Project.BO;
using EADP_Project.Entities;
using Google.Authenticator;
using OtpSharp;
using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

namespace EADP_Project
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;

                ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
                if (Session["LoginUserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null && Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    if ((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))  /*End of Session Fixation*/
                    { //pass
                        if (!Page.IsPostBack)
                        {
                            UserBO userbo = new UserBO();
                            String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                            user userobj = new user();
                            userobj = userbo.getUserById(currentLoggedInUser);
                            if (DateTime.Compare(DateTime.Now, userobj.pwd_endDate) > 0)
                            {
                                Response.Write("<script>alert('Your Password has expired. Please change your password');</script>");
                                DaysToChangeLbl.Text = "Password expired " + Math.Abs((userobj.pwd_endDate - DateTime.Now).Days).ToString() + " days ago";
                            }
                            else
                            {
                                DaysToChangeLbl.Text = (userobj.pwd_endDate - DateTime.Now).Days.ToString() + " days";
                            }
                            UsernameTB.Text = userobj.User_ID;
                            NameTB.Text = userobj.name;
                            EmailTB.Text = userobj.email;
                            LastPwdChangeLbl.Text = userobj.pwd_startDate.ToShortDateString().ToString();

                            accessLogView.DataSource = userbo.getAccessLogById(currentLoggedInUser);
                            accessLogView.DataBind();
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
                }
                else
                {
                    //  clear session
                    Session.Clear();
                    Session.Abandon();
                    Session.RemoveAll();
                    if (Request.Cookies["ASP.NET_SessionId"] != null)
                    {
                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                    }
                    if (Request.Cookies["AuthToken"] != null)
                    {
                        //Empty Cookie
                        Response.Cookies["AuthToken"].Value = string.Empty;
                        Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                    }
                    if (Request.Cookies["CurrentLoggedInUser"] != null)
                    {
                        //Empty Cookie
                        Response.Cookies["CurrentLoggedInUser"].Value = string.Empty;
                        Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddMonths(-20);
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem(browid);", true);
                    Response.Redirect("LoginPage.aspx");
                }
            }
            catch
            {
                //  clear session
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["AuthToken"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["AuthToken"].Value = string.Empty;
                    Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["CurrentLoggedInUser"].Value = string.Empty;
                    Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddMonths(-20);
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem(browid);", true);
                Response.Redirect("LoginPage.aspx");
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
                String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                user userobj = new user();
                userobj = userbo.getUserById(currentLoggedInUser);
                LastPwdChangeLbl.Text = userobj.pwd_startDate.ToShortDateString().ToString();
                DaysToChangeLbl.Text = (userobj.pwd_endDate - DateTime.Now).Days.ToString() + " days";
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

        //session fixation for timeout
        protected void RemoveSessionBtn_OnClick(object Source, EventArgs e)
        {
            try
            {
                //  clear session
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["AuthToken"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["AuthToken"].Value = string.Empty;
                    Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["CurrentLoggedInUser"].Value = string.Empty;
                    Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddMonths(-20);
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem(browid);", true);
                Response.Redirect("LoginPage.aspx");
            }
            catch
            {

            }


        }

        //session reset
        protected void ResetSessionBtn_OnClick(object Source, EventArgs e)
        {
            try
            {
                HttpContext.Current.Session["Reset"] = true;
                //Session["Reset"] = true;
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);

            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openFModal();", true);

            }

        }

    }
}