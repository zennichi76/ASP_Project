using EADP_Project.BO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class WebForm1 : System.Web.UI.Page
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
                    {
                        //pass
                        UserBO userbo = new UserBO();
                        ConsentFormBO consentformbo = new ConsentFormBO();
                        String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                        user userobj = userbo.getUserById(currentLoggedInUser);
                        List<String> TeachingClasses = userbo.getTeachersTeachingClasses(currentLoggedInUser);
                        String FormID = Request.QueryString["FormId"];
                        String FoodPrefEnabled = Request.QueryString["FoodPref"];
                        ClassesDropDownList.DataSource = consentformbo.getSentClassesByFormID(FormID);
                        ClassesDropDownList.DataBind();
                        ClassesDropDownList.SelectedIndex = 0;
                        if (consentformbo.retrieveClassList(FormID, ClassesDropDownList.SelectedItem.Text, userobj.school) == null || consentformbo.retrieveClassList(FormID, ClassesDropDownList.SelectedItem.Text, userobj.school).Count == 0)
                        {
                            noStudentsMsg.Visible = true;
                        }
                        else
                        {
                            noStudentsMsg.Visible = false;
                        }
                        StudentTables.DataSource = consentformbo.retrieveClassList(FormID, ClassesDropDownList.SelectedItem.Text, userobj.school);
                        StudentTables.DataBind();
                        if (FoodPrefEnabled == "True")
                        {
                            StudentTables.Columns[2].Visible = true;
                        }
                        else if (FoodPrefEnabled == "False")
                        {
                            StudentTables.Columns[2].Visible = false;
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
                    Response.Redirect("LoginPage.aspx");
                }
              

                //List<ConsentForm> consentFormRecords = consentformbo.getConsentFormsBySenderID(currentLoggedInUser);
                //consentFormRecords.Reverse(); //sorts by latest at the top
                //SelectedClassesListBox.DataSource = TeachingClasses;
                //SelectedClassesListBox.DataBind(); //binds the data of classes that the user teaches
                //ConsentFormList.DataSource = consentFormRecords;
                //ConsentFormList.DataBind(); //bind entries
            }
        }

        protected void ClassesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserBO userbo = new UserBO();
            ConsentFormBO consentformbo = new ConsentFormBO();
            String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
            user userobj = userbo.getUserById(currentLoggedInUser);
            List<String> TeachingClasses = userbo.getTeachersTeachingClasses(currentLoggedInUser);
            String FormID = Request.QueryString["FormId"];
            String FoodPrefEnabled = Request.QueryString["FoodPref"];
            if(consentformbo.retrieveClassList(FormID, ClassesDropDownList.SelectedItem.Text, userobj.school) == null || consentformbo.retrieveClassList(FormID, ClassesDropDownList.SelectedItem.Text, userobj.school).Count == 0)
            {
                noStudentsMsg.Visible = true;
            }
            else
            {
                noStudentsMsg.Visible = false;
            }
            StudentTables.DataSource = consentformbo.retrieveClassList(FormID, ClassesDropDownList.SelectedItem.Text, userobj.school);
            StudentTables.DataBind();
            if (FoodPrefEnabled == "True")
            {
                StudentTables.Columns[2].Visible = true;
            }
            else if(FoodPrefEnabled == "False")
            {
                StudentTables.Columns[2].Visible = false;
            }
            
        }


        protected void ExportBtn_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ConsentForm_Report.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                StudentTables.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in StudentTables.HeaderRow.Cells)
                {
                    cell.BackColor = StudentTables.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in StudentTables.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = StudentTables.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = StudentTables.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                StudentTables.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);

            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openFModal();", true);

            }

        }

    }
}