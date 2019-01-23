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
    public partial class PendingConsentForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!IsPostBack)
            {
                /*Session Fixation*/
                // check if the 2 sessions n cookie is not null
                if (Session["LoginUserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null && Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    if ((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))  /*End of Session Fixation*/
                    {//pass
                        formalert.Visible = false;
                        UserBO userbo = new UserBO();
                        ConsentFormBO consentformbo = new ConsentFormBO();
                        String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                        user currentuser = userbo.getUserById(currentLoggedInUser);
                        if (currentuser.role == "Student")
                        {
                            List<ConsentForm> consentFormRecords = consentformbo.selectUnsignedFormsByUser(currentuser.User_ID, currentuser.school, currentuser.education_class);
                            if (consentFormRecords != null && consentFormRecords.Count != 0)
                            {
                                consentFormRecords.Reverse(); //sorts by latest at the top
                            }
                            else
                            {
                                formalert.Visible = true;
                            }
                            pendingForms.DataSource = consentFormRecords;
                            pendingForms.DataBind();
                        }
                        else if (currentuser.role == "Parent")
                        {
                            user childuser = userbo.getUserById(currentuser.child_ID);
                            List<ConsentForm> consentFormRecords = consentformbo.selectUnsignedFormsByUser(childuser.User_ID, childuser.school, childuser.education_class);
                            if (consentFormRecords != null && consentFormRecords.Count != 0)
                            {
                                consentFormRecords.Reverse(); //sorts by latest at the top
                            }
                            else
                            {
                                formalert.Visible = true;
                            }
                            pendingForms.DataSource = consentFormRecords;
                            pendingForms.DataBind();
                        }
                        else
                        {
                            formalert.Visible = true;
                        }

                    }//end of second check
                    else
                    {
                        //unauthorised user access
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem('browid');", true);
                        Response.Redirect("LoginPage.aspx");
                    }

                }//end of first check
                else
                {
                    //unauthorised user access
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem('browid');", true);
                    Response.Redirect("LoginPage.aspx");
                }

            }

        }

        protected void pendingForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = pendingForms.SelectedRow;
       
            Response.Redirect("FormSign.aspx?id=" + row.Cells[0].Text);
        }
    }
}