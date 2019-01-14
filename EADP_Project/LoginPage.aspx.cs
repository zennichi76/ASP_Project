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

namespace EADP_Project
{
    public partial class LoginPage : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //check for existing session
            if (!Page.IsPostBack){
                // first time, this is executed...)

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
            String input_username = username_tb.Text;
            String input_password = password_tb.Text;
            UserBO login_bo = new UserBO();
            user returnedObj = new user();
            returnedObj = login_bo.login_validation(input_username, input_password);

            //security Questions for authentication
            //////////////////////////////////////
            if (returnedObj == null)
            {
                ErrorMsg.Text = "Login failed"; //login fail 
            }
            else
            {
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
    }
}