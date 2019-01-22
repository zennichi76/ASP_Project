using EADP_Project.Business_Layer;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project.EventPage
{
    public partial class AllEventPage : System.Web.UI.Page
    {

        String participatorId;
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
                        participatorId = Request.Cookies["CurrentLoggedInUser"].Value;
                        loadAllData();
                        eventDetailsPanel.Visible = false;
                        EventPanel.Visible = true;
                    }//end of second check

                }//end of first check
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem('browid');", true);
                    Response.Redirect("LoginPage.aspx");
                }
            }
        }
        int eventId;


        public void loadAllData()
        {
            eventBO filltable = new eventBO();

            AllEventGridView.DataSource = filltable.loadAllEvent();
            AllEventGridView.DataBind();

        }


        protected void AllEventGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //eventDetails.Visible = true;

            eventBO getDetails = new eventBO();

            GridViewRow row = AllEventGridView.SelectedRow;

            eventId = Convert.ToInt32(AllEventGridView.SelectedRow.Cells[0].Text);

            events eventobj = getDetails.GetEventById(eventId);
            events test = getDetails.getNumParticipants(eventId);



            selectedEventIdLbl.Text = eventobj.eventId.ToString();
            selectedEventLbl.Text = eventobj.eventName.ToString();
            selectedSDateLbl.Text = eventobj.eventSDate.ToString();
            selectedEDateLbl.Text = eventobj.eventEDate.ToString();
            selectedMaxCapLbl.Text = eventobj.maxCapacity.ToString();
            selectedSTimeLbl.Text = eventobj.eventSTime.ToString();
            selectedETimeLbl.Text = eventobj.eventETime.ToString();
            selectedDescripLbl.Text = eventobj.eventDescription.ToString();
            ccaPointLbl.Text = eventobj.CcaPoints.ToString();
            orionPointLbl.Text = eventobj.Orion_Points.ToString();
            currentCapacLbl.Text = test.maxCapacity.ToString();
            ccaPointLbl.Text = eventobj.CcaPoints.ToString();
            orionPointLbl.Text = eventobj.Orion_Points.ToString();
            participatorId = Request.Cookies["CurrentLoggedInUser"].Value;
            idLbl.Text = participatorId.ToString();
            creatorIdLbl.Text = eventobj.creatorId;
            eventDetailsPanel.Visible = true;
            EventPanel.Visible = false;





        }

        public void signUpEvent()
        {
            eventBO signUp = new eventBO();


            int eventId = int.Parse(selectedEventIdLbl.Text.ToString());
            String eventName = selectedEventLbl.Text.ToString();
            String eventSDate = selectedSDateLbl.Text.ToString();
            String eventEDate = selectedEDateLbl.Text.ToString();
            String eventSTime = selectedSTimeLbl.Text.ToString();
            String eventETime = selectedETimeLbl.Text.ToString();
            String eventDescription = selectedDescripLbl.Text.ToString();
            int CCAPoints = int.Parse(ccaPointLbl.Text.ToString());
            int Orion_Points = int.Parse(orionPointLbl.Text.ToString());
            String participatorId = Request.Cookies["CurrentLoggedInUser"].Value;
            idLbl.Text = participatorId.ToString();
            String currentParticipator = idLbl.Text.ToString();

            events test = signUp.getNumParticipants(eventId);
            events eventobj = signUp.GetEventById(eventId);

            String creatorId = creatorIdLbl.Text;

            selectedMaxCapLbl.Text = eventobj.maxCapacity.ToString();

            String maxCap = selectedMaxCapLbl.Text.ToString();

            String currentNum = test.maxCapacity.ToString();

            if (currentNum == maxCap)
            {
                string display = "Sorry, There is no more available slots!";
                ClientScript.RegisterStartupScript(this.GetType(), "Sorry, There is no more available slots!", "alert('" + display + "');", true);
            }
            else if (signUp.checkIfParticipantExist(eventId, participatorId) == false)
            {
                // joinBtn.Visible = false;
                string display = "You have already sign up for this event!";
                ClientScript.RegisterStartupScript(this.GetType(), "You have already sign up for this event!", "alert('" + display + "');", true);
            }

            else
            {
                signUp.signUpEvent(eventId, eventName, eventSDate, eventEDate, eventSTime, eventETime, eventDescription, currentParticipator, CCAPoints, Orion_Points, creatorId);
                string display = "Congrats for signing up! See you on the day of the event!";
                ClientScript.RegisterStartupScript(this.GetType(), "Congrats for signing up! See you on the day of the event!", "alert('" + display + "');", true);
                eventDetailsPanel.Visible = false;
                EventPanel.Visible = true;
            }
        }


        protected void joinBtn_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                signUpEvent();
            }
            else
            {
                string display = "You did not sign up for the event!";
                ClientScript.RegisterStartupScript(this.GetType(), "You did not sign up for the event!", "alert('" + display + "');", true);
            }

        }

        protected void openEventPanelBtn_Click(object sender, EventArgs e)
        {
            eventDetailsPanel.Visible = false;
            EventPanel.Visible = true;
        }

        protected void AllEventGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AllEventGridView.PageIndex = e.NewPageIndex;
            loadAllData();
        }

        protected void viewMyEventBtn_Click(object sender, EventArgs e)
        {
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            Request.Cookies["CurrentLoggedInUser"].Value = user_Id;
            Response.Redirect("studentViewEvent.aspx");
        }
    }
}

