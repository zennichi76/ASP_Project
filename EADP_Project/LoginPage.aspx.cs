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

namespace EADP_Project
{
    public partial class LoginPage : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //check for existing session
            if (!Page.IsPostBack){
                // first time, this is executed...)
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
                    }
                }

            else
            {
                //// this code will execute after the page postbacks.......(first time this will not be executed...)

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
            if (returnedObj == null && modalOverlay.Visible == false)
            {
                ErrorMsg.Text = "Login failed"; //login fail 
            }
            else
            {
                if (returnedObj.gAuth_Enabled && modalOverlay.Visible == false)
                {
                    modalOverlay.Visible = true;
                    ViewState["key"] = returnedObj.gAuth_Key;
                }
                else if((modalOverlay.Visible && new TwoFactorAuthenticator().ValidateTwoFactorPIN(ViewState["key"].ToString(), gAuthTb.Text)) || (returnedObj.gAuth_Enabled == false && modalOverlay.Visible == false))
                {
                    UserBO userbo = new UserBO();
                    userbo.addNewLoginLog(returnedObj.User_ID.ToString());
                    //to create session for user
                    Session["LoginUserName"] = returnedObj.User_ID.ToString();
                    string guid = Guid.NewGuid().ToString();
                    //create second session for user and assigning a random GUID
                    Session["AuthToken"] = guid;

                    //Session["authWin"] = guidWN;
                    //Create cokie and store the same value of second session in cookie
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    Response.Cookies.Add(new HttpCookie("CurrentLoggedInUser", returnedObj.User_ID.ToString()));
                    Response.Cookies["AuthToken"].Expires = DateTime.Now.AddDays(1); //so the cookie will be expired if user didn't log out properly
                    Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddDays(1); //so the cookie will be expired if user didn't log out properly
                    Response.Redirect("Dashboard.aspx"); //login pass
                }
                else if(modalOverlay.Visible && new TwoFactorAuthenticator().ValidateTwoFactorPIN(ViewState["key"].ToString(), gAuthTb.Text) == false)
                {
                    ErrorMsg.Text = "Google Authenticator Code entered was incorrect";
                    modalOverlay.Visible = false;
                    ViewState["key"] = null;
                    gAuthTb.Text = "";
                    
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

                //Session["authWin"] = guidWN;
                //Create cokie and store the same value of second session in cookie
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                Response.Cookies.Add(new HttpCookie("CurrentLoggedInUser", returnedObj.User_ID.ToString()));
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddDays(1); //so the cookie will be expired if user didn't log out properly
                Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddDays(1); //so the cookie will be expired if user didn't log out properly
                Response.Redirect("Dashboard.aspx"); //login pass
            }
            else
            {
                modalOverlay.Visible = false;
            }
        }
    }
}