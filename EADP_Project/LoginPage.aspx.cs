using EADP_Project.BO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using Google.Authenticator;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace EADP_Project
{
    public partial class LoginPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            modalOverlay.Visible = false;
            if (Session["LoginUserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null && Request.Cookies["CurrentLoggedInUser"] != null && Request.Cookies["ASP.NET_SessionId"] != null)
            {
                //  clear session
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                //invalidate all existing session
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
                ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem('browid');", true);
            }


        }

        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = ConfigurationManager.AppSettings["SecretKey"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
        //for checking purpose
        public bool getSQ(string userId, string ansQ1, string ansQ2)
        {
            bool isvalid;
            RegistrationBO getQuestions = new RegistrationBO();
            SecurityQuestions sqObj = getQuestions.GetSQById(userId);
            securityQn qn1obj = new securityQn(sqObj.firstSecurityQ, sqObj.firstSecurityQA);
            securityQn qn2obj = new securityQn(sqObj.secondSecurityQ, sqObj.secondSecurityQA);
            securityQn qn3obj = new securityQn(sqObj.thirdSecurityQ, sqObj.thirdSecurityQA);

            List<securityQn> securityQnList = new List<securityQn>();
            securityQnList.Add(qn1obj);
            securityQnList.Add(qn2obj);
            securityQnList.Add(qn3obj);

            Shuffle(securityQnList);
            byte[] questionOne;
            string questionOneAns;
            byte[] questionTwo;
            string questionTwoAns;

            questionOne = securityQnList[0].qn;
            questionOneAns = securityQnList[0].answ;
            questionTwo = securityQnList[1].qn;
            questionTwoAns = securityQnList[1].answ;

            Image1.ImageUrl = "data:Image/;base64," + Convert.ToBase64String(questionOne);
            Image2.ImageUrl = "data:Image/;base64," + Convert.ToBase64String(questionTwo);
            if (ansQ1.Equals(questionOneAns) == true && ansQ2.Equals(questionTwoAns) == true)
            {
                //pass
                errLbl.Text = "";
                isvalid = true;

            }
            else
            {
                //fail
               // errLbl.Text = "Please Ensure you answered your security question correctly";
                isvalid = false;
            }

            return isvalid;
        }

        //just plain retrieval
        public void retrieveSQAsAlternateMethod(string userId)
        {
            try
            {
                RegistrationBO getQuestions = new RegistrationBO();
                SecurityQuestions sqObj = getQuestions.GetSQById(userId);
                securityQn qn1obj = new securityQn(sqObj.firstSecurityQ, sqObj.firstSecurityQA);
                securityQn qn2obj = new securityQn(sqObj.secondSecurityQ, sqObj.secondSecurityQA);
                securityQn qn3obj = new securityQn(sqObj.thirdSecurityQ, sqObj.thirdSecurityQA);

                List<securityQn> securityQnList = new List<securityQn>();
                securityQnList.Add(qn1obj);
                securityQnList.Add(qn2obj);
                securityQnList.Add(qn3obj);

                Shuffle(securityQnList);
                byte[] questionOne;
                string questionOneAns;
                byte[] questionTwo;
                string questionTwoAns;

                questionOne = securityQnList[0].qn;
                questionOneAns = securityQnList[0].answ;
                questionTwo = securityQnList[1].qn;
                questionTwoAns = securityQnList[1].answ;

                Image1.ImageUrl = "data:Image/;base64," + Convert.ToBase64String(questionOne);
                Image2.ImageUrl = "data:Image/;base64," + Convert.ToBase64String(questionTwo);
            }
            catch
            {

            }

        }



        protected void sqBtn_Click(object sender, EventArgs e)
        {
            SQoverLay.Visible = true;
            modalOverlay.Visible = false;
            accountNotActivated.Visible = false;
            String input_username = username_tb.Text;
            retrieveSQAsAlternateMethod(input_username);

        }

        protected void submit_OnClick(object sender, EventArgs e)
        {
            SQoverLay.Visible = true;
            modalOverlay.Visible = false;
            accountNotActivated.Visible = false;
            String input_username = username_tb.Text;
          //  retrieveSQAsAlternateMethod(input_username);

            string FirstAns = FirstsecurityQnAnsTB.Text.ToString();
            string SecAns = SecondsecurityQnAnsTB.Text.ToString();
            bool pass = getSQ(input_username, FirstAns, SecAns);

            try
            {
                if (pass == true)
                {
                    //login
                    ////to create session for user
                    Session["LoginUserName"] = input_username;
                    string guid = Guid.NewGuid().ToString();
                    //create second session for user and assigning a random GUID
                    Session["AuthToken"] = guid;
                    //Create cokie and store the same value of second session in cookie
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    Response.Cookies.Add(new HttpCookie("CurrentLoggedInUser", input_username));
                    Response.Redirect("Dashboard.aspx"); //login pass
                }
                else
                {
                    //fail
                    errLbl.Text = "Please Ensure you answered your security question correctly";
                }

            }
            catch
            {
                //fail
                errLbl.Text = "Please Ensure you answered your security question correctly";
            }


        }


        private static Random rng = new Random();
        public static void Shuffle<T>(IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

        }


        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            user returnedObj = new user();
            returnedObj = null;
            String input_username = username_tb.Text;
            if (modalOverlay.Visible == true)
            {
                UserBO login_bo = new UserBO();
                returnedObj = new user();
                returnedObj = login_bo.getUserById(input_username);
            }
            else
            {
                String input_password = password_tb.Text;
                UserBO login_bo = new UserBO();
                returnedObj = new user();
                returnedObj = login_bo.login_validation(input_username, input_password);
            }
            //security Questions for authentication
            //////////////////////////////////////
            if (returnedObj == null && modalOverlay.Visible == false) //login fail
            {
                ErrorMsg.Text = "Login failed"; //login fail 
                                                //captcha
                captchaRow.Style.Remove("display");

              if(captchaRow.Style["display"] != "none") //captcha is shown
                {
                    bool captchaPass = IsReCaptchValid();
                    errCaptcha.Visible = false;
                    if (captchaPass == true)
                    {
                        RegistrationBO getCode = new RegistrationBO();
                        activationCode validateCode = getCode.getACBasedOnID(input_username);

                        string code = validateCode.ActivationCode;
                        DateTime eDate = validateCode.codeEDate;
                        string hasConfirmEmail = validateCode.confirmEmail;
                        if (hasConfirmEmail == "False")
                        {
                            modalOverlay.Visible = false;
                            accountNotActivated.Visible = true;
                            SQoverLay.Visible = false;
                        }
                        else //user account is validated
                        {
                            if (returnedObj.gAuth_Enabled && modalOverlay.Visible == false)
                            {
                                modalOverlay.Visible = true;
                                ViewState["key"] = returnedObj.gAuth_Key;
                            }
                            else if ((modalOverlay.Visible && new TwoFactorAuthenticator().ValidateTwoFactorPIN(ViewState["key"].ToString(), gAuthTb.Text)) || (returnedObj.gAuth_Enabled == false && modalOverlay.Visible == false))
                            {
                                //IF user didnt activate google
                                retrieveSQAsAlternateMethod(input_username);
                                SQoverLay.Visible = true;
                                modalOverlay.Visible = false;
                                accountNotActivated.Visible = false;

                            }
                            else if (modalOverlay.Visible && new TwoFactorAuthenticator().ValidateTwoFactorPIN(ViewState["key"].ToString(), gAuthTb.Text) == false)
                            {
                                ErrorMsg.Text = "Google Authenticator Code entered was incorrect";
                                modalOverlay.Visible = false;
                                ViewState["key"] = null;
                                gAuthTb.Text = "";

                            }

                        }
                    }
                    else
                    {
                        errCaptcha.Visible = true;
                        errCaptcha.Text = "Please Redo Captcha";
                    }
                }
            }
            else
            {//2nd try login
                if (captchaRow.Style["display"] != "none")
                {
                    //check if captcha is filled
                    bool captchaPass = IsReCaptchValid();
                    if (captchaPass == true)
                    {
                        RegistrationBO getCode = new RegistrationBO();
                        activationCode validateCode = getCode.getACBasedOnID(input_username);
                    UserBO userbo = new UserBO();
                    userbo.addNewLoginLog(returnedObj.User_ID.ToString());
                    //to create session for user
                    Session["LoginUserName"] = returnedObj.User_ID.ToString();
                    string guid = Guid.NewGuid().ToString();
                    //create second session for user and assigning a random GUID
                    Session["AuthToken"] = guid;

                        string code = validateCode.ActivationCode;
                        DateTime eDate = validateCode.codeEDate;
                        string hasConfirmEmail = validateCode.confirmEmail;
                        if (hasConfirmEmail == "False")
                        {
                            modalOverlay.Visible = false;
                            accountNotActivated.Visible = true;
                        }
                        else
                        {
                            if (returnedObj.gAuth_Enabled && modalOverlay.Visible == false)
                            {
                                modalOverlay.Visible = true;
                                ViewState["key"] = returnedObj.gAuth_Key;
                            }
                            else if ((modalOverlay.Visible && new TwoFactorAuthenticator().ValidateTwoFactorPIN(ViewState["key"].ToString(), gAuthTb.Text)) || (returnedObj.gAuth_Enabled == false && modalOverlay.Visible == false))
                            {
                                //IF user didnt activate google
                                retrieveSQAsAlternateMethod(input_username);
                                SQoverLay.Visible = true;
                                modalOverlay.Visible = false;
                                accountNotActivated.Visible = false;
                            }
                            else if (modalOverlay.Visible && new TwoFactorAuthenticator().ValidateTwoFactorPIN(ViewState["key"].ToString(), gAuthTb.Text) == false)
                            {
                                ErrorMsg.Text = "Google Authenticator Code entered was incorrect";
                                modalOverlay.Visible = false;
                                ViewState["key"] = null;
                                gAuthTb.Text = "";

                            }
                        }
                    }
                    else
                    {
                        errCaptcha.Visible = true;
                        errCaptcha.Text = "Captcha Fail, Please Redo Captcha";
                    }
                }
                else //normal login
                {
                    RegistrationBO getCode = new RegistrationBO();
                    activationCode validateCode = getCode.getACBasedOnID(input_username);

                    string code = validateCode.ActivationCode;
                    DateTime eDate = validateCode.codeEDate;
                    string hasConfirmEmail = validateCode.confirmEmail;
                    if (hasConfirmEmail == "False")
                    {
                        modalOverlay.Visible = false;
                        accountNotActivated.Visible = true;
                        SQoverLay.Visible = false;
                    }
                    else
                    {
                        if (returnedObj.gAuth_Enabled && modalOverlay.Visible == false)
                        {
                            modalOverlay.Visible = true;
                            ViewState["key"] = returnedObj.gAuth_Key;
                        }


                        else if ((modalOverlay.Visible && new TwoFactorAuthenticator().ValidateTwoFactorPIN(ViewState["key"].ToString(), gAuthTb.Text)) || (returnedObj.gAuth_Enabled == false && modalOverlay.Visible == false))
                        {
                            //IF user didnt activate google
                            retrieveSQAsAlternateMethod(input_username);
                            SQoverLay.Visible = true;
                            modalOverlay.Visible = false;
                            accountNotActivated.Visible = false;

                        }
                        else if (modalOverlay.Visible && new TwoFactorAuthenticator().ValidateTwoFactorPIN(ViewState["key"].ToString(), gAuthTb.Text) == false)
                        {
                            ErrorMsg.Text = "Google Authenticator Code entered was incorrect";
                            modalOverlay.Visible = false;
                            ViewState["key"] = null;
                            gAuthTb.Text = "";

                        }


                    }
                }

            }

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            //create random session id 
            SessionIDManager manager = new SessionIDManager();

            string newID = manager.CreateSessionID(Context);
            bool redirected = false;
            bool isAdded = false;
            manager.SaveSessionID(Context, newID, out redirected, out isAdded);
            string currSessionID = manager.GetSessionID(Context);
            string guid = Guid.NewGuid().ToString();
            Session["AuthToken"] = guid;
            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
            //  Response.Cookies.Add(new HttpCookie("currSessionID", currSessionID));

            Response.Redirect("Registration.aspx");
        }

        protected void ForgetSecQnsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetSecurityQuestion.aspx");
        }

        protected void ActiveAccountBtn_Click(object sender, EventArgs e)
        {
            //to create session for user
            Session["LoginUserName"] = username_tb.Text;
            Session["loginPage"] = "loginPage";
            string guid = Guid.NewGuid().ToString();
            //create second session for user and assigning a random GUID
            Session["AuthToken"] = guid;
            //Create cokie and store the same value of second session in cookie
            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
            Response.Redirect("ConfirmAccount.aspx");
        }

        protected void ProceedBtn_Click(object sender, EventArgs e)
        {
            string user_enter = gAuthTb.Text;
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            bool isCorrectPIN = tfa.ValidateTwoFactorPIN(ViewState["key"].ToString(), user_enter);
            if (isCorrectPIN == true)
            {
                String input_username = username_tb.Text;
                UserBO userbo = new UserBO();
                user returnedObj = new user();
                returnedObj = userbo.getUserById(input_username);
                //to create session for user
                Session["LoginUserName"] = returnedObj.User_ID.ToString();
                string guid = Guid.NewGuid().ToString();
                //create second session for user and assigning a random GUID
                Session["AuthToken"] = guid;
                //Create cokie and store the same value of second session in cookie
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                Response.Cookies.Add(new HttpCookie("CurrentLoggedInUser", returnedObj.User_ID.ToString()));

                Response.Redirect("Dashboard.aspx"); //login pass
            }
            else
            {
                modalOverlay.Visible = false;
            }
        }


    }
}