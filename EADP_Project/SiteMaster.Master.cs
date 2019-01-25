using EADP_Project.BO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class SiteMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!this.IsPostBack)
            { // first time, this is executed...)
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

                Session["Reset"] = true;
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
           
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);

            }
            else //postback else
            {

            }

        }

        //session fixation for logout
        protected void logOut_OnClick(object Source, EventArgs e)
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
            ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem('browid');", true);
            Response.Redirect("LoginPage.aspx");
            //String cookie = Request.Cookies["ASP.NET_SessionId"].Value;
            //String TokenCookie = Request.Cookies["AuthToken"].Value;
        }

        protected void invalidateSessionBtn_OnClick(object Source, EventArgs e)
        {
            //different window is open
            //check for existing user session. 
            //check if user already sign in

            //  clear session
            if ((Request.Cookies["CurrentLoggedInUser"].Value.Equals(Session["LoginUserName"].ToString())) && Request.Cookies["ASP.NET_SessionId"].Value.Equals(Request.Cookies["ASP.NET_SessionId"].Value))
            {
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
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('fail');", true);
            }
        }

        //session fixation for timeout
        protected void RemoveSessionBtn_OnClick(object Source, EventArgs e)
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

}




