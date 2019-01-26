using EADP_Project.Business_Layer;
using EADP_Project.Controller;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace EADP_Project.EventPage
{
    public partial class CreateEventPage : System.Web.UI.Page
    {
        eventBO addEventObj = new eventBO();
        int tempMaxCap;
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
                        successPanel.Visible = false;
                        createPanel.Visible = true;
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


        public bool isValidated()
        {
            bool pass = true;

            DateTime startDate = Convert.ToDateTime(txtStartDate.Text.Trim());
            DateTime endDate = Convert.ToDateTime(txtEndDate.Text.Trim());
            DateTime currentDate = DateTime.Today;
            DateTime startTime = Convert.ToDateTime(STimeTB.Text.Trim());
            DateTime endTime = Convert.ToDateTime(ETimeTB.Text.Trim());

            System.TimeSpan diff = endTime.Subtract(startTime);
            int temp = (int)diff.TotalMinutes;
            String eventName = eventNameTB.Text.ToString();
            String eventSDate = txtStartDate.Text.ToString();
            String eventEDate = txtEndDate.Text.ToString();
            String eventSTime = STimeTB.Text.ToString();
            String eventETime = ETimeTB.Text.ToString();
            String eventDescription = Request.Form["eventDesc"];
            int CcaPoints = int.Parse(ccaPointsTB.Text.ToString());
            int Orion_Points = int.Parse(orionPointsTB.Text.ToString());
            int maxCapacity = int.Parse(maxCapTB.Text.ToString());
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;

            if (startDate > endDate)
            {
                errLbl.Text = "End date should not be earlier than start date";
                successPanel.Visible = false;
                createPanel.Visible = true;
                errorPanel.Visible = true;
                dateErr.Visible = true;
                pass = false;

            }
            else if (currentDate > startDate)
            {
                errLbl.Text = "Start Date should not be over already!";
                successPanel.Visible = false;
                createPanel.Visible = true;
                errorPanel.Visible = true;
                dateErr.Visible = true;
                pass = false;
            }
            else if (startTime >= endTime)
            {
                errTLbl.Text = "Please ensure that end time is not earlier than start time!";
                successPanel.Visible = false;
                createPanel.Visible = true;
                errorPanel.Visible = true;
                timeErr.Visible = true;
                pass = false;
            }
            else if (temp < 120)
            {
                errTLbl.Text = "Input more than 2 hour please!";
                successPanel.Visible = false;
                createPanel.Visible = true;
                errorPanel.Visible = true;
                timeErr.Visible = true;
                pass = false;
            }
            else if (maxCapacity < 10)
            {
                errLblMax.Text = "Minimum capacity is 10!";
                successPanel.Visible = false;
                createPanel.Visible = true;
                errorPanel.Visible = true;
                mcErr.Visible = true;
                pass = false;
            }
            else if (CcaPoints <= 0)
            {
                cpErrLbl.Text = "Input positive Number for CCaPoints!";
                successPanel.Visible = false;
                createPanel.Visible = true;
                errorPanel.Visible = true;
                errCpLbl.Visible = true;
                pass = false;

            }
            else if (Orion_Points <= 0)
            {
                OpErrLbl.Text = "Input positive Number for Orion Points!";
                successPanel.Visible = false;
                createPanel.Visible = true;
                errorPanel.Visible = true;
                opErr.Visible = true;
                pass = false;
            }
            else
            {
                pass = true;
            }

            return pass;
        }

        //protected void cancelBtn_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("viewEventPage.aspx");
        //}

        protected void createBtn_Click1(object sender, EventArgs e)
        {
            //DateTime tempSTime = DateTime.Parse(STimeTB.Text.ToString());
            //DateTime tempETime = DateTime.Parse(ETimeTB.Text.ToString());

            String eventName = eventNameTB.Text.ToString();
            DateTime sd = DateTime.Parse(txtStartDate.Text.ToString());
            DateTime ed = DateTime.Parse(txtEndDate.Text.ToString());
            String eventSDate = sd.ToString("dd-MMMM-yy");
            String eventEDate = ed.ToString("dd-MMMM-yy");
            //String eventSDate = txtStartDate.Text.ToString();
            //String eventEDate = txtEndDate.Text.ToString();
            DateTime st = DateTime.Parse(STimeTB.Text.ToString());
            DateTime et = DateTime.Parse(ETimeTB.Text.ToString());
            String eventSTime = st.ToString("hh:mm tt");
            String eventETime = et.ToString("hh:mm tt");
            //String eventSTime = STimeTB.Text.ToString();
            //String eventETime = ETimeTB.Text.ToString();
            String eventDescription = Request.Form["eventDesc"];
            int CcaPoints = int.Parse(ccaPointsTB.Text.ToString());
            int Orion_Points = int.Parse(orionPointsTB.Text.ToString());
            int maxCapacity = int.Parse(maxCapTB.Text.ToString());
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            bool success = isValidated();

            if((success == false))
            {
                errorPanel.Visible = true;
                successPanel.Visible = false;
                createPanel.Visible = true;
            }
            else
            {
                errLbl.Text = "";
                errTLbl.Text = "";
                errLblMax.Text = "";
                cpErrLbl.Text = "";
                OpErrLbl.Text = "";
                opErr.Visible = false;
                errCpLbl.Visible = false;
                mcErr.Visible = false;
                timeErr.Visible = false;
                dateErr.Visible = false;
                errorPanel.Visible = false;
                successPanel.Visible = true;
                eventBO add = new eventBO();
                add.insertEvent(eventName, eventSDate, eventEDate, eventSTime, eventETime, eventDescription, maxCapacity, CcaPoints, Orion_Points, user_Id);
                Response.AddHeader("REFRESH", "5;URL=viewEventPage.aspx");
            }




        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
               //clear all input
            eventNameTB.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            STimeTB.Text = "";
            ETimeTB.Text = "";
            String eventDescription = Request.Form["eventDesc"];
            eventDescription = "";
            maxCapTB.Text = "";
            orionPointsTB.Text = "";
            ccaPointsTB.Text = "";
                errLbl.Text = "";
                errTLbl.Text = "";
                errLblMax.Text = "";
                cpErrLbl.Text = "";
                OpErrLbl.Text = "";
                opErr.Visible = false;
                errCpLbl.Visible = false;
                mcErr.Visible = false;
                timeErr.Visible = false;
                dateErr.Visible = false;
                errorPanel.Visible = false;
            }
            else
            {
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
         
        }


        protected void BackBtn_Click1(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Response.Redirect("viewEventPage.aspx");
            }
            else
            {
               // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
           
        }
    }
}