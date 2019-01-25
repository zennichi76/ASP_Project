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
    public partial class ViewParticipators : System.Web.UI.Page
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
                        if((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))  /*End of Session Fixation*/
                        { //pass

                            loadAllData();
                        }//end of second check
                        else
                        {
                           
                        }

                    }//end of first check
                    else
                    {
                        Response.Redirect("LoginPage.aspx");
                    }

                }

        }

        String participatorId;
        int eventId;
        String creatorId;

        public void loadAllData()
        {
            if (Request.Cookies["CurrentLoggedInUser"].Value != null)
            {
                //creatorId = Session["userIdSession"].ToString();
                //eventId = int.Parse(Session["eventIdSession"].ToString());
                eventBO filltable = new eventBO();
                sessionBO loadTable = new sessionBO();
                requestBO fillGV = new requestBO();
                String creatorId = Request.Cookies["CurrentLoggedInUser"].Value;
                viewParticipatorsGV.DataSource = filltable.loadParticipatorList( creatorId);
                viewParticipatorsGV.DataBind();

                tutionPointsGV.DataSource = loadTable.getNumOfSession();
                tutionPointsGV.DataBind();

                requestPointsGV.DataSource = fillGV.getNumOfSession();
                requestPointsGV.DataBind();

            }
        }



        protected void viewParticipatorsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            eventBO getDetails = new eventBO();
            eventBO test = new eventBO();

            AllocationToTutionPointsPanel.Visible = false;
            AllocationToRequestPointsPanel.Visible = false;
            allocatePanel.Visible = true;

            GridViewRow row = viewParticipatorsGV.SelectedRow;
            string status;
            eventId = Convert.ToInt32(viewParticipatorsGV.SelectedRow.Cells[0].Text);
            status = Convert.ToString(viewParticipatorsGV.SelectedRow.Cells[4].Text);
            participatorIdLbl.Text = Convert.ToString(viewParticipatorsGV.SelectedRow.Cells[1].Text);
            CCAPointsLbl.Text = Convert.ToString(viewParticipatorsGV.SelectedRow.Cells[2].Text);
            OrionPointsLbl.Text = Convert.ToString(viewParticipatorsGV.SelectedRow.Cells[3].Text);

            String creatorId = Request.Cookies["CurrentLoggedInUser"].Value;

        }

        protected void addPoints_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                eventBO assignPoints = new eventBO();
                String participatorId = participatorIdLbl.Text;
                int ccaPoints = int.Parse(CCAPointsLbl.Text.ToString());
                int orionPoints = int.Parse(OrionPointsLbl.Text.ToString());
                String creatorId = Request.Cookies["CurrentLoggedInUser"].Value;
                string status = "Assigned Successfully";
              
                bool success = true;

                if (success == true)
                {
                    success = true;

                    string display = "Allocation Pass! Points get allocated successfully";
                    ClientScript.RegisterStartupScript(this.GetType(), "Points get allocated successfully!", "alert('" + display + "');", true);
                    assignPoints.givePoints(participatorId, ccaPoints, orionPoints);
                    assignPoints.showPointedAreAllocated(status, participatorId, creatorId);
                    loadAllData();
                    allocatePanel.Visible = false;

                    

                }
                else
                {

                    string display = "Allocation Fail! Points did not get allocated successfully!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Points did not get allocated successfully!", "alert('" + display + "');", true);
                }

            }
            else
            {
                string display = "Allocation Fail! You did not update the points";
                ClientScript.RegisterStartupScript(this.GetType(), "You did not update the points!", "alert('" + display + "');", true);
            }


        }


        protected void RaddPointsBtn_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                requestBO getDetails = new requestBO();
                string requestTo = TuserIdLbl.Text;
                // status = Convert.ToString(viewParticipatorsGV.SelectedRow.Cells[5].Text);
                int ccaPoints = int.Parse(TCCAPointsLbl.Text.ToString());
                int orion_points = int.Parse(TOrionPointsLbl.Text.ToString());

                getDetails.givePoints(requestTo, ccaPoints, orion_points);
            }
            else
            {

            }
        }

        protected void requestPointsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            requestBO getDetails = new requestBO();
            eventBO test = new eventBO();
            AllocationToRequestPointsPanel.Visible = true;
            AllocationToTutionPointsPanel.Visible = false;
            allocatePanel.Visible = false;
            GridViewRow row = requestPointsGV.SelectedRow;
            string status;
            String requestTo = "";
            requestTo = Convert.ToString(requestPointsGV.SelectedRow.Cells[0].Text);
            
            // status = Convert.ToString(viewParticipatorsGV.SelectedRow.Cells[5].Text);





        }

        protected void tutionPointsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            sessionBO getDetails = new sessionBO();
            AllocationToTutionPointsPanel.Visible = true;
            GridViewRow row = tutionPointsGV.SelectedRow;
            string status;
           
            TuserIdLbl.Text = Convert.ToString(tutionPointsGV.SelectedRow.Cells[0].Text);
           
            AllocationToRequestPointsPanel.Visible = false;
            allocatePanel.Visible = false;


        }

        protected void TaddPointsBtn_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                sessionBO getDetails = new sessionBO();
                string tutorId = TuserIdLbl.Text;
                // status = Convert.ToString(viewParticipatorsGV.SelectedRow.Cells[5].Text);
                int ccaPoints = int.Parse(TCCAPointsLbl.Text.ToString());
                int orion_points = int.Parse(TOrionPointsLbl.Text.ToString());

                getDetails.givePoints(tutorId, ccaPoints, orion_points);
            }
            else
            {

            }
        }

        protected void RcancelBtn_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                AllocationToRequestPointsPanel.Visible = false;
            }
                else
                {

                  
                }

              
        }

        protected void TCancelBtn_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                AllocationToTutionPointsPanel.Visible = false;
            }
            else
            {


            }

           
        }

        protected void EcancelBtn_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                allocatePanel.Visible = false;
            }
            else
            {


            }
          
        }
    }
}