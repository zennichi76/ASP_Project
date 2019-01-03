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
    public partial class SiteMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Session Fixation*/
            //check if the 2 sessions n 2 cookie is not null
            if (Session["LoginUserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null && Request.Cookies["CurrentLoggedInUser"] != null)
            {
                //second check for cookie has the same value as the second session
                if ((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))  /*End of Session Fixation*/
                {
                    user current_user_obj = new user();
                    UserBO userbo = new UserBO();
                    string userId = Request.Cookies["CurrentLoggedInUser"].Value;
                    current_user_obj = userbo.getUserById(userId);
                    AdminTools.Visible = false;
                    if (current_user_obj.role == "Teacher")
                    {
                        LinkEvent.HRef = "viewEventPage.aspx";
                        LinkTuition.Visible = false;
                    }
                    else if (current_user_obj.role == "Student")
                    {
                        LinkEvent.HRef = "studentViewEvent.aspx";
                        LinkTuition.Visible = true;
                    }
                    else if (current_user_obj.role == "Parent")
                    {
                        EventNavItem.Visible = false;
                        LinkTuition.Visible = false;
                    }
                    else if (current_user_obj.role == "Staff")
                    {
                        LinkEvent.HRef = "viewEventPage.aspx";
                        LinkTuition.Visible = false;
                        EventNavItem.Visible = false;
                    }
                    else if (current_user_obj.role == "Admin")
                    {
                        LinkEvent.HRef = "viewEventPage.aspx";
                        LinkTuition.Visible = false;
                        EventNavItem.Visible = false;
                        AdminTools.Visible = true;
                    }
                }
                else
                {
                   Response.Redirect("LoginPage.aspx");
                }
            }


            //check if session exist?


            }

    

            //currently not working properly
        public void TestLogout()
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
           Response.Redirect("LoginPage.aspx");
            //String cookie = Request.Cookies["ASP.NET_SessionId"].Value;
            //String TokenCookie = Request.Cookies["AuthToken"].Value;
        }


        }
    
    }
  

   
    
