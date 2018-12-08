using EADP_Project.BO;
using EADP_Project.Business_Layer;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project.StudentTutorPage
{
    public partial class viewAllTuition : System.Web.UI.Page
    {
        //S9651833B --tutor
        //S9876543A-- tutee
        String user_Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserBO userbo = new UserBO();
                String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                loadData();

                loadRequest();
            }

        }

        public void loadData()
        {
            sessionBO getTuition = new sessionBO();
            // String user_Id = Request.Cookies["Current_user"].Value;
            viewAllTuitionGV.DataSource = getTuition.loadAllTuition();

            viewAllTuitionGV.DataBind();

        }

        public void loadRequest()
        {
            requestBO load = new requestBO();
            studentGV.DataSource = load.loadAllStudent();
            studentGV.DataBind();
        }


        protected void viewRequestBtn_Click(object sender, EventArgs e)
        {
            //available session panels
            tutionPanel.Visible = false;
            detailsPanel.Visible = false;
            //request panels
            tutorListPanel.Visible = true;
            requestPanel.Visible = true;
            detailsTable.Visible = false;


        }

        protected void backToTution_Click(object sender, EventArgs e)
        {
            //available session panels
            tutionPanel.Visible = true;
            detailsPanel.Visible = false;
            //request panels
            requestPanel.Visible = false;
            detailsTable.Visible = false;
            tutorListPanel.Visible = false;

        }

        protected void backToSessionBtn_Click(object sender, EventArgs e)
        {
            //available session panels
            tutionPanel.Visible = true;
            detailsPanel.Visible = false;
            //request panels
            requestPanel.Visible = false;
            detailsTable.Visible = false;
            tutorListPanel.Visible = false;

        }

        protected void JoinTuition_Click(object sender, EventArgs e)
        {
            sessionBO joinTution = new sessionBO();

            String tuteeId = Request.Cookies["CurrentLoggedInUser"].Value;
            int sessionId = int.Parse(tutionIdLbl.Text.ToString());
            String tutorId = tutorIdTB.Text.ToString();
            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                joinTution.signUpTution(tuteeId, tutorId, sessionId);
                string display = "Tution Joined!";
                ClientScript.RegisterStartupScript(this.GetType(), "Tution Joined successfully ", "alert('" + display + "');", true);

                //available session panels
                tutionPanel.Visible = true;
                detailsPanel.Visible = false;
                //request panels
                requestPanel.Visible = false;
                detailsTable.Visible = false;
                tutorListPanel.Visible = false;


            }
            else
            {
                string display = "You did not join this tution!";
                ClientScript.RegisterStartupScript(this.GetType(), "You did not join this tution!", "alert('" + display + "');", true);
                //available session panels
                tutionPanel.Visible = true;
                detailsPanel.Visible = false;
                //request panels
                requestPanel.Visible = false;
                detailsTable.Visible = false;

            }



        }

        protected void viewAllTuitionGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            viewAllTuitionGV.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void viewAllTuitionGV_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            GridViewRow row = viewAllTuitionGV.SelectedRow;
            detailsPanel.Visible = true;
            tutionPanel.Visible = false;
            sessionBO getDetails = new sessionBO();

            String tuteeId = Request.Cookies["CurrentLoggedInUser"].Value;

            int sessionId = Convert.ToInt32(viewAllTuitionGV.SelectedRow.Cells[0].Text);
            string tutorId = Convert.ToString(viewAllTuitionGV.SelectedRow.Cells[5].Text);

            tutionEntities tuitionObj = getDetails.GetTuitionById(sessionId);
            tutionIdLbl.Text = tuitionObj.sessionId.ToString();
            sessionDetailsLbl.Text = tuitionObj.SessionDetails.ToString();
            dateLbl.Text = tuitionObj.sessionDate.ToString();
            stimeLbl.Text = tuitionObj.sessionSTime.ToString();
            etimeLbl.Text = tuitionObj.sessionETime.ToString();
            tutorIdTB.Text = tuitionObj.tutorId.ToString();
            tuteeIdTB.Text = tuteeId.ToString();


        }


        protected void priSchDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void studentGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = studentGV.SelectedRow;
            requestBO getDetails = new requestBO();

            //available session panels
            tutionPanel.Visible = false;
            detailsPanel.Visible = false;
            //request panels
            requestPanel.Visible = true;
            detailsTable.Visible = true;
            tutorListPanel.Visible = false;

            String requestBy = Request.Cookies["CurrentLoggedInUser"].Value;

            requestByLbl.Text = requestBy;
            requestToLbl.Text = studentGV.SelectedRow.Cells[0].Text;
            String checkRequestBy = requestToLbl.Text.ToString();
            

        }

     

        protected void sendRequestBtn_Click(object sender, EventArgs e)
        {
            String temprequestBy = requestByLbl.Text;
            String temprequestTo = requestToLbl.Text;
            if (temprequestBy.Equals(temprequestTo))
            {
                sendRequestBtn.Enabled = false;
            }

            Boolean valid = true;
            if(valid == true)
            {

                String requestBy = Request.Cookies["CurrentLoggedInUser"].Value;


                requestByLbl.Text = requestBy;
                String requestTo = studentGV.SelectedRow.Cells[0].Text;
                requestToLbl.Text = requestTo;
                requestBO getDetails = new requestBO();

                requestBy = requestByLbl.Text;
                requestTo = requestToLbl.Text;
                String status = "Pending";
                String requestDetails = Request.Form["requestDetails"].ToString();
                String currentEduLevel = Request.Cookies["Current_Edu_Level"].Value;
                String eduLevelGV = studentGV.SelectedRow.Cells[1].Text;
                getDetails.sendRequest(requestDetails, requestTo, requestBy, status);
                
                string display = "Request Sent!";
                ClientScript.RegisterStartupScript(this.GetType(), "Request Is successfully sent!", "alert('" + display + "');", true);

                //available session panels
                tutionPanel.Visible = false;
                detailsPanel.Visible = false;
                //request panels
                tutorListPanel.Visible = true;
                requestPanel.Visible = true;
                detailsTable.Visible = false;


            }
            else if(valid == false)
            {
                String currentEduLevel = Request.Cookies["Current_Edu_Level"].Value;
                String eduLevelGV = studentGV.SelectedRow.Cells[1].Text;
                String requestByUser = requestByLbl.Text;
                String requestToUser = requestToLbl.Text;
               

                if (currentEduLevel == "Secondary")
                {
                    if (eduLevelGV.Contains("Primary") == true)
                    {
                        string displayErr = "You cannot request to User that has lower education level than you!!";
                        ClientScript.RegisterStartupScript(this.GetType(), "You cannot request to User that has lower education level than you!", "alert('" + displayErr + "');", true);
                        valid = false;
                    }

                }

                else if (currentEduLevel == "JC")
                {
                    if (eduLevelGV.Contains("Primary") == true)
                    {
                        string displayErr = "You cannot request to User that has lower education level than you!!";
                        ClientScript.RegisterStartupScript(this.GetType(), "You cannot request to User that has lower education level than you!", "alert('" + displayErr + "');", true);
                        valid = false;
                    }
                    else if (eduLevelGV.Contains("Secondary") == true)
                    {
                        string displayErr = "You cannot request to User that has lower education level than you!!";
                        ClientScript.RegisterStartupScript(this.GetType(), "You cannot request to User that has lower education level than you!", "alert('" + displayErr + "');", true);
                        valid = false;
                    }
                }
            }
            else
            {
                string display = "Request Fail to Send!";
                ClientScript.RegisterStartupScript(this.GetType(), "Request Fail to Send!", "alert('" + display + "');", true);
                viewAllTutionPanel.Visible = false;
                requestPanel.Visible = true;
            }

            
          
              
            }
            

         

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            //available session panels
            tutionPanel.Visible = false;
            detailsPanel.Visible = false;
            //request panels
            requestPanel.Visible = true;
            tutorListPanel.Visible = true;
            detailsTable.Visible = false;
         
        }

        protected void backToMySessionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewMyTuitionPage.aspx");
        }

        protected void studentGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            studentGV.PageIndex = e.NewPageIndex;
            loadRequest();
        }
    }




}