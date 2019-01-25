using EADP_Project.Business_Layer;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project.studentEventPage
{
    public partial class studentViewEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //wacked the mygv(gridview name)
                loadAllData();

            }
 
        }

        int eventId;

        public void loadAllData()
        {
            eventBO filltable = new eventBO();
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            myEventsGV.DataSource = filltable.loadSignUpEvent(user_Id);

            myEventsGV.DataBind();
            //  taskGridView.UseAccessibleHeader = true;
            //  taskGridView.HeaderRow.TableSection = TableRowSection.TableHeader;


        }

        protected void myEventsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            eventBO getDetails = new eventBO();

            GridViewRow row = myEventsGV.SelectedRow;

            eventId = Convert.ToInt32(myEventsGV.SelectedRow.Cells[0].Text);
            String participatorId = Request.Cookies["CurrentLoggedInUser"].Value;
            eventDetails.Visible = true;
            myEventsGV.Visible = false;
            //eventPanel.Visible = false;
            events eventobj = getDetails.GetEventByParticipatorId(eventId,participatorId);
            selectedEventLbl.Text = eventobj.eventName.ToString();
            selectedSDateLbl.Text = eventobj.eventSDate.ToString();
            selectedEDateLbl.Text = eventobj.eventEDate.ToString();
            selectedSTimeLbl.Text = eventobj.eventSTime.ToString();
            selectedETimeLbl.Text = eventobj.eventETime.ToString();
            selectedDescripLbl.Text = eventobj.eventDescription.ToString();
           // selectedMaxCapLbl.Text = eventobj.maxCapacity.ToString();
            selectedCcaPointsLbl.Text = eventobj.CcaPoints.ToString();
            selectedOrionPointsLbl.Text = eventobj.Orion_Points.ToString();

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            eventDetails.Visible = false;
            myEventsGV.Visible = true;
        }

        protected void unjoinBtn_Click(object sender, EventArgs e)
        {

            DateTime endDate = Convert.ToDateTime(selectedEDateLbl.Text.Trim());
            DateTime currentDate = DateTime.Today;
            string confirmValue = Request.Form["confirm_value"];

            if (currentDate > endDate)
            {
                string display = "Event is already over! There is no reason to unjoin the event";
                ClientScript.RegisterStartupScript(this.GetType(), "Event is already over! There is no reason to unjoin the event", "alert('" + display + "');", true);
                loadAllData();

            }

            else if (confirmValue == "Yes")
            {
                eventBO unjoin = new eventBO();
                int eventId = Convert.ToInt32(myEventsGV.SelectedRow.Cells[0].Text);
                String participatorId = Request.Cookies["CurrentLoggedInUser"].Value;
                unjoin.unjoinEvent(participatorId,eventId);
                string display = "You successfully quit the event!";
                ClientScript.RegisterStartupScript(this.GetType(), "You successfully quit the event!", "alert('" + display + "');", true);
                eventDetails.Visible = false;
                loadAllData();
            }
            else
            {
                string display = "You did not quit the event!";
                ClientScript.RegisterStartupScript(this.GetType(), "You did not quit the event!", "alert('" + display + "');", true);
                loadAllData();
            }

            
           

        }

        protected void viewAllEventBtn_Click(object sender, EventArgs e)
        {
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            Response.Redirect("AllEventPage.aspx");
        }
    }
}