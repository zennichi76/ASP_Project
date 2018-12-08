using EADP_Project.Business_Layer;
using EADP_Project.Controller;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;

namespace EADP_Project.EventPage
{
    public partial class viewEventPage : System.Web.UI.Page
    {
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



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //wacked the mygv(gridview name
                loadData();
 
            }

        }

        //eventDAO fillTable = new eventDAO();   
        eventDAO eventObj = new eventDAO();
        List<eventBO> retrieveAllList = new List<eventBO>();



        //correct one
        // eventBO getEventDetails = new eventBO();

        public void loadData()
        {
            eventBO filltable = new eventBO();
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            taskGridView.DataSource = filltable.loadEvent(user_Id);

            taskGridView.DataBind();

           


            //  taskGridView.UseAccessibleHeader = true;
            //  taskGridView.HeaderRow.TableSection = TableRowSection.TableHeader;


        }

        public void test()
        {
            eventBO filltable = new eventBO();
            String creator_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            eventId = Convert.ToInt32(taskGridView.SelectedRow.Cells[0].Text);
            
            printParticipatorGV.DataSource = filltable.getAttendanceList(eventId, creator_Id);
            printParticipatorGV.DataBind();
        }


        protected void taskGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            eventBO getDetails = new eventBO();

            GridViewRow row = taskGridView.SelectedRow;

            eventId = Convert.ToInt32(taskGridView.SelectedRow.Cells[0].Text);
            eventDetails.Visible = true;
            eventPanel.Visible = false;
            events eventobj = getDetails.GetEventById(eventId);
            selectedEventLbl.Text = eventobj.eventName.ToString();
            selectedSDateLbl.Text = eventobj.eventSDate.ToString();
            selectedEDateLbl.Text = eventobj.eventEDate.ToString();
            selectedSTimeLbl.Text = eventobj.eventSTime.ToString();
            selectedETimeLbl.Text = eventobj.eventETime.ToString();
            selectedDescripLbl.Text = eventobj.eventDescription.ToString();
            selectedMaxCapLbl.Text = eventobj.maxCapacity.ToString();
            selectedCcaPointsLbl.Text = eventobj.CcaPoints.ToString();
            selectedOrionPointsLbl.Text = eventobj.Orion_Points.ToString();

            test();


            //&nbsp;


        }

        protected void taskGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        //protected void taskGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    deleteFunction = new eventBO();

        //    int eventId = Convert.ToInt16(taskGridView.DataKeys[e.RowIndex].Values["eventId"].ToString());


        //    deleteFunction.deleteEvent(eventId);

        //    selectedEventLbl.Text = "";
        //    selectedSDateLbl.Text = "";
        //    selectedEDateLbl.Text = "";
        //    selectedSTimeLbl.Text = "";
        //    selectedETimeLbl.Text = "";
        //    selectedDescripLbl.Text = "";
        //    selectedMaxCapLbl.Text = "";
        //    selectedCcaPointsLbl.Text = "";
        //    selectedOrionPointsLbl.Text = "";

        //    loadData();
        //}

        protected void getParticipantList_Click(object sender, EventArgs e)
        {
            eventPanel.Visible = false;
            eventDetails.Visible = false;
            attendancePanel.Visible = true;
            printBtn.Visible = true;
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            if (taskGridView.SelectedIndex < 0)
            {
                ///Label1.Text = "Please select a event";

            }
            else
            {
                eventBO getDetails = new eventBO();
                events eventobj = getDetails.GetEventById(eventId);
                String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
                eventId = int.Parse(taskGridView.SelectedRow.Cells[0].Text);

                Session["eventIdSession"] = eventId;
                Session["nameSession"] = selectedEventLbl.Text;
                Session["sDateSession"] = selectedSDateLbl.Text;
                Session["eDateSession"] = selectedEDateLbl.Text;
                Session["sTimeSession"] = selectedSTimeLbl.Text;
                Session["eTimeSession"] = selectedETimeLbl.Text;
                Session["descriptionSession"] = selectedDescripLbl.Text;
                Session["maxCapSession"] = selectedMaxCapLbl.Text;
                Session["ccaPointsSession"] = selectedCcaPointsLbl.Text;
                Session["orionPointsSession"] = selectedOrionPointsLbl.Text;
                Session["userIdSession"] = user_Id;


                Response.Redirect("updateEventPage.aspx");
            }
        }

        protected void AllocatePointsBtn_Click(object sender, EventArgs e)
        {
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            //eventId = int.Parse(taskGridView.SelectedRow.Cells[0].Text);
            Session["userIdSession"] = user_Id;
            //Session["eventIdSession"] = eventId;

            Response.Redirect("viewParticipators.aspx");

        }


        protected void createBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("CreateEventPage.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            eventPanel.Visible = true;
            eventDetails.Visible = false;
        }

        

        protected void printParticipatorGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void taskGridView_PageIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void taskGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            eventBO filltable = new eventBO();
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            taskGridView.DataSource = filltable.loadEvent(user_Id);
            taskGridView.PageIndex = e.NewPageIndex;
            taskGridView.DataBind();
            
        }
    }
}




        