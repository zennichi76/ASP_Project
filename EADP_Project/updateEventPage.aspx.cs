using EADP_Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project.EventPage
{
    public partial class updateEventPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadSession();
            }
        }

        eventBO updateFunction;
        String eventName;
        String eventSDate;
        String eventEDate;
        String eventSTime;
        String eventETime;
        String eventDescription;
        String maxCap;
        String CcaPoints;
        String OrionPoints;
        int eventId;
        String user_Id;

        public void loadSession()
        {

            if (Session["eventIdSession"] != null )
            {
                eventId =  int.Parse(Session["eventIdSession"].ToString());
                //eventIdTB.Text = Session["eventIdSession"].ToString();
                eventNameTB.Text = Session["nameSession"].ToString();
                txtStartDate.Text = DateTime.Parse(Session["sDateSession"].ToString()).ToString("dd-MMM-yyyy");
                txtEndDate.Text = DateTime.Parse(Session["eDateSession"].ToString()).ToString("dd-MMM-yyyy");
                STimeTB.Text = Session["sTimeSession"].ToString();
                ETimeTB.Text = Session["eTimeSession"].ToString();
                eventDescTB.Text = Session["descriptionSession"].ToString();
                maxCapTB.Text = Session["maxCapSession"].ToString();
                ccaPointsTB.Text = Session["ccaPointsSession"].ToString();
                orionPointsTB.Text = Session["orionPointsSession"].ToString();
                user_Id = Session["userIdSession"].ToString();
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
            String eventDescription = eventDescTB.Text;
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

        protected void updateBtn_Click(object sender, EventArgs e)
        {

            //updateEvent();

            updateFunction = new eventBO();

            eventId = int.Parse(Session["eventIdSession"].ToString());
            eventName = eventNameTB.Text;
            DateTime sd = DateTime.Parse(txtStartDate.Text.ToString());
            DateTime ed = DateTime.Parse(txtEndDate.Text.ToString());
            eventSDate = sd.ToString("dd-MMMM-yy");
            eventEDate = ed.ToString("dd-MMMM-yy");
            user_Id = Session["userIdSession"].ToString();

            DateTime st = DateTime.Parse(STimeTB.Text.ToString());
            DateTime et = DateTime.Parse(ETimeTB.Text.ToString());
            eventSTime = st.ToString("hh:mm tt");
            eventETime = et.ToString("hh:mm tt");

            eventDescription = eventDescTB.Text;
            maxCap = maxCapTB.Text.ToString();
            CcaPoints = ccaPointsTB.Text.ToString();
            OrionPoints = orionPointsTB.Text.ToString();

            updateFunction.updateEvent(eventName,eventSDate, eventEDate, eventSTime , eventETime, eventDescription, int.Parse(maxCap), int.Parse(CcaPoints), int.Parse(OrionPoints), eventId, user_Id);


            successPanel.Visible = true;

            Response.AddHeader("REFRESH", "5;URL=viewEventPage.aspx");

            //Thread.Sleep(3000);
            //Response.Redirect("viewEventPage.aspx");
            
        }



        protected void backBtn_Click(object sender, EventArgs e)
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
                eventDescTB.Text = "";
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
    }
}