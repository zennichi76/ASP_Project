using EADP_Project.BO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class ConfirmAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                try
                {
                    string loginPage = Request.UrlReferrer.ToString();
                    string registerPage = Request.UrlReferrer.ToString();
                    if (loginPage.Contains("LoginPage"))
                    {
                        if (Session["LoginUserName"] == null && Session["AuthToken"] == null && Request.Cookies["AuthToken"] == null)
                        {
                            Response.Redirect("LoginPage.aspx");
                        }
                        else
                        {
                            if (Session["LoginUserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
                            {
                                //come from login page
                                if ((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))
                                {

                                }
                                else
                                {
                                    Response.Redirect("LoginPage.aspx");
                                }
                            }
                        }
                    }
                    else
                    {

                    }

                    if (registerPage.Contains("Registration"))
                    {
                        if (Session["userName"] == null)
                        {
                            Response.Redirect("LoginPage.aspx");
                        }
                        else
                        {
                            //load page
                        }
                    }
                    else
                    {

                    }
                }
                catch
                {
                    Response.Redirect("LoginPage.aspx");
                }

            }
            else
            {

            }

        }

        protected void resendBtn_Click(object sender, EventArgs e)
        {
            RegistrationBO addUser = new RegistrationBO();
            try
            {   //from login page. execute this code if loginuserName exist
                if (Session["LoginUserName"] != null)
                {
                    string userId = Session["LoginUserName"].ToString();
                    activationCode validateCodeBasedOnID = addUser.getACBasedOnID(userId);
                    ////////////////////////////////For activation Email//////////////////////////////////////////////////
                    //generate random code for activation
                    Random random = new Random();
                    string activationCode = random.Next(1001, 9999).ToString();

                    string msgSub = "Registration Confirmation";

                    string breakTag = "\n";
                    string msgBod = "Hi " + validateCodeBasedOnID.Name + ",";

                    msgBod += breakTag + "Thank you for signing up with Orion. You are only one step away from using your newly created account. ";
                    msgBod += breakTag + "Please enter the following code to verify your account: " + activationCode;
                    msgBod += breakTag + "Please note that the code will expired in 3 hours";
                    msgBod += breakTag + "Yours Faithfully," + breakTag + "Orion Team";

                    //add to activationCode
                    DateTime currDT = DateTime.Now;
                    DateTime futureDT = currDT.AddHours(3.0);
                    string emailTo = validateCodeBasedOnID.email;
                    mailService sendMail = new mailService();
                    sendMail.sendmail(emailTo, msgSub, msgBod);
                    addUser.resendCode(userId, activationCode, futureDT); //update the new code in
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else
                {
                    //do nothing
                }

                //from register page. execute this code if registerEmail exist
                if (Session["userName"] != null)
                {
                    string userId = Session["userName"].ToString();
                    activationCode validateCodeBasedOnID = addUser.getACBasedOnID(userId);
                    ////////////////////////////////For activation Email//////////////////////////////////////////////////
                    //generate random code for activation
                    Random random = new Random();
                    string activationCode = random.Next(1001, 9999).ToString();

                    string msgSub = "Registration Confirmation";

                    string breakTag = "\n";
                    string msgBod = "Hi " + validateCodeBasedOnID.Name + ",";

                    msgBod += breakTag + "Thank you for signing up with Orion. You are only one step away from using your newly created account. ";
                    msgBod += breakTag + "Please enter the following code to verify your account: " + activationCode;
                    msgBod += breakTag + "Please note that the code will expired in 3 hours";
                    msgBod += breakTag + "Yours Faithfully," + breakTag + "Orion Team";

                    //add to activationCode
                    DateTime currDT = DateTime.Now;
                    DateTime futureDT = currDT.AddHours(3.0);
                    string emailTo = validateCodeBasedOnID.email;
                    mailService sendMail = new mailService();
                    sendMail.sendmail(emailTo, msgSub, msgBod);
                    addUser.resendCode(userId, activationCode, futureDT); //update the new code in
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

                }
                else
                {
                    //do nothing
                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openWModal();", true);
            }

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            RegistrationBO addUser = new RegistrationBO();

            //from login page. execute this code if loginuserName exist
            if (Session["LoginUserName"] != null)
            {
                string userId = Session["LoginUserName"].ToString();
                activationCode validateCodeBasedOnID = addUser.getACBasedOnID(userId);
                string fromLoginCode = validateCodeBasedOnID.ActivationCode;
                DateTime eDateFromLogin = validateCodeBasedOnID.codeEDate;
                string enteredCode = confirmCodeTB.Text.ToString();
                string userEmail = validateCodeBasedOnID.email.ToString();
                if (enteredCode == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openToggle();", true);
                }
                else
                {
                    if (enteredCode.Equals(fromLoginCode))
                    {
                        //check for expiray
                        DateTime currDT = DateTime.Now;
                        if (currDT > eDateFromLogin)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEModal();", true);
                        }
                        else
                        {
                            //activate the account
                            if (enteredCode.Equals(fromLoginCode))
                            {
                                try
                                {
                                    string confirmEmail = "True";
                                    addUser.activateAccount(userId, confirmEmail);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAModal();", true);
                                }
                                catch
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFModal();", true);
                                }

                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openWModal();", true);
                    }
                }

            }
            else
            {

            }

            //from register page. execute this code if registerEmail exist
            if (Session["userName"] != null)
            {
                string userId = Session["userName"].ToString();
                activationCode validateCodeBasedOnID = addUser.getACBasedOnID(userId); //get account details based on userId
                string code = validateCodeBasedOnID.ActivationCode;
                DateTime eDate = validateCodeBasedOnID.codeEDate;
                string enteredCode = confirmCodeTB.Text.ToString();
                string userEmail = validateCodeBasedOnID.email.ToString();
                if (string.IsNullOrEmpty(enteredCode))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openToggle();", true);
                }
                else
                {
                    if (enteredCode.Equals(code))
                    {
                        //check for expiray
                        DateTime currDT = DateTime.Now;
                        if (currDT > eDate)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEModal();", true);
                        }
                        else
                        {
                            //activate the account
                            if (enteredCode.Equals(code))
                            {
                                try
                                {
                                    string confirmEmail = "True";
                                    addUser.activateAccount(userId, confirmEmail);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAModal();", true);
                                }
                                catch
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openFModal();", true);
                                }

                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openWModal();", true);
                    }
                }
               
            }
            else
            {

            }

        }
    }
}