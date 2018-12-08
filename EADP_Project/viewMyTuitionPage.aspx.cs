using EADP_Project.Business_Layer;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project.StudentTutorPage
{
    public partial class viewMyTuitionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadData();
                loadRequestByMeData();
                loadRequestToMeData();
                loadSessionIJoined();

                //set visibility of session I created
                sessionDetailsPanel.Visible = false;
                SessionByMePanel.Visible = true;
                SessionCreatedByMeBtn.Visible = false;

                //set visibiliy of request to Me
                viewRequestToMePanel.Visible = false;
                requestToMeDetailsPanel.Visible = false;

                //set visibility of Reqeust By Me
                viewRequestByMePanel.Visible = false;
                requestByMeDetailsPanel.Visible = false;
                //SessionCreatedByMe.Visible = false;


            }
            
            //S9651833B --tutor
            //S9876543A-- tutee
        }

        sessionBO deleteFunction = new sessionBO();
 
        public void loadData()
        {
            sessionBO getTuition = new sessionBO();
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            tuitionGrid.DataSource = getTuition.loadTuition(user_Id);
            tuitionGrid.DataBind();

        }

        public void loadSessionIJoined()
        {
            sessionBO getTuition = new sessionBO();
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            JoinedSessionGV.DataSource = getTuition.loadJoinedTuition(user_Id);
            JoinedSessionGV.DataBind();
        }

        public void loadRequestToMeData()
        {
            requestBO getRequest = new requestBO();
            String requestTo = Request.Cookies["CurrentLoggedInUser"].Value;
            RequestToMeGV.DataSource = getRequest.loadRequestToMe(requestTo);
            RequestToMeGV.DataBind();
        }

        public void loadRequestByMeData()
        {
            requestBO getReqeuestByMe = new requestBO();
            String requestBy = Request.Cookies["CurrentLoggedInUser"].Value;
            requestByMeGV.DataSource = getReqeuestByMe.loadRequestByMe(requestBy);
            requestByMeGV.DataBind();
        }


        protected void requestToMeBtn_Click(object sender, EventArgs e)
        {
            viewRequestToMePanel.Visible = true;
            requestToMeDetailsPanel.Visible = false;
            //request by me panel 
            viewRequestByMePanel.Visible = false;
            requestByMeDetailsPanel.Visible = false;
            //session created by me
            sessionDetailsPanel.Visible = false;
            SessionByMePanel.Visible = false;
            SessionCreatedByMeBtn.Visible = true;
            //
            sessionIjoinedPanel.Visible = false;
            sessionIjoinedDetailsPanel.Visible = false;

        }

        protected void RequestByMeBtn_Click(object sender, EventArgs e)
        {
            viewRequestByMePanel.Visible = true;
            requestByMeDetailsPanel.Visible = false;
            //session created by me
            sessionDetailsPanel.Visible = false;
            SessionByMePanel.Visible = false;
            SessionCreatedByMeBtn.Visible = true;
            //request to me
            viewRequestToMePanel.Visible = false;
            requestToMeDetailsPanel.Visible = false;
            //
            sessionIjoinedPanel.Visible = false;
            sessionIjoinedDetailsPanel.Visible = false;
        }

        protected void SessionCreatedByMe_Click(object sender, EventArgs e) //session by me
        {
            viewRequestToMePanel.Visible = false;
            requestToMeDetailsPanel.Visible = false;
            //request by me panel 
            viewRequestByMePanel.Visible = false;
            requestByMeDetailsPanel.Visible = false;
            //session created by me
            sessionDetailsPanel.Visible = false;
            SessionByMePanel.Visible = true;
            SessionCreatedByMeBtn.Visible = false;
            //
            sessionIjoinedPanel.Visible = false;
            sessionIjoinedDetailsPanel.Visible = false;

        }

        protected void tuitionGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            sessionBO getDetails = new sessionBO();

            viewRequestToMePanel.Visible = false;
            requestToMeDetailsPanel.Visible = false;
            //request by me panel 
            viewRequestByMePanel.Visible = false;
            requestByMeDetailsPanel.Visible = false;
            //session created by me
            sessionDetailsPanel.Visible = true;
            SessionByMePanel.Visible = false;
            SessionCreatedByMeBtn.Visible = false;
            GridViewRow row = tuitionGrid.SelectedRow;
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;

            int sessionId = Convert.ToInt32(tuitionGrid.SelectedRow.Cells[0].Text);

            tutionEntities tuitionObj = getDetails.GetTuitionById(sessionId);
            tutionDescriptionLbl.Text = tuitionObj.SessionDetails.ToString();
            tutorIdLbl.Text = user_Id;
            tuteeIdLbl.Text = tuitionObj.tuteeId.ToString();
            dateLbl.Text = tuitionObj.sessionDate.ToString();
            stimeLbl.Text = tuitionObj.sessionSTime.ToString();
            etimeLbl.Text = tuitionObj.sessionETime.ToString();

        }

        protected void RequestToMeGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            requestBO getRequest = new requestBO();

            viewRequestToMePanel.Visible = false;
            requestToMeDetailsPanel.Visible = true;
            //request by me panel 
            viewRequestByMePanel.Visible = false;
            requestByMeDetailsPanel.Visible = false;
            //session created by me
            sessionDetailsPanel.Visible = false;
            SessionByMePanel.Visible = false;
            SessionCreatedByMeBtn.Visible = true;

            GridViewRow row = RequestToMeGV.SelectedRow;
            String requestTo = Request.Cookies["CurrentLoggedInUser"].Value;
            int requestId = Convert.ToInt32(RequestToMeGV.SelectedRow.Cells[0].Text);
            requestEntity requestObj = getRequest.getRequestToMeByIdDetails(requestId, requestTo);

            requestEntity current_status = new requestEntity();
            string tempStatus = requestObj.status;
            if (tempStatus == "canceled")
            {
                cancelLbl.Visible = true;
                cancelLbl.Text = "This request was canceled by the requestee";
                statusDDL.Visible = false;
                updateBtn.Enabled = false;
                requestIdLbl.Text = requestObj.requestId.ToString();
                requestDetailsLbl.Text = requestObj.requestDetails.ToString();
                requestToLbl.Text = requestObj.requestTo.ToString();
                requestByLbl.Text = requestObj.requestBy.ToString();
                //statusDDL.SelectedValue = requestObj.status.ToString();

            }
            else
            {
                cancelLbl.Visible = false;
                statusDDL.Visible = true;
                updateBtn.Enabled = true;
                requestIdLbl.Text = requestObj.requestId.ToString();
                requestDetailsLbl.Text = requestObj.requestDetails.ToString();
                requestToLbl.Text = requestObj.requestTo.ToString();
                requestByLbl.Text = requestObj.requestBy.ToString();
                
            }

        }

        protected void requestByMeGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            requestBO getRequest = new requestBO();
            viewRequestByMePanel.Visible = false;
            requestByMeDetailsPanel.Visible = true;

            //request to me
            viewRequestToMePanel.Visible = false;
            requestToMeDetailsPanel.Visible = false;
            //session by me
            sessionDetailsPanel.Visible = false;
            SessionByMePanel.Visible = false;
            SessionCreatedByMeBtn.Visible = true;

            GridViewRow row = requestByMeGV.SelectedRow;
            String requestBy = Request.Cookies["CurrentLoggedInUser"].Value;
            int requestId = Convert.ToInt32(requestByMeGV.SelectedRow.Cells[0].Text);
            requestEntity requestObj = getRequest.getRequestByMeByIdDetails(requestId, requestBy);


            myRequestId.Text = requestObj.requestId.ToString();
            myRequestDetails.Text = requestObj.requestDetails.ToString();
            myRequestTo.Text = requestObj.requestTo.ToString();
            myRequestBy.Text = requestObj.requestBy.ToString();
            myStatusLbl.Text = requestObj.status.ToString();

        }

 

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            if (tuitionGrid.SelectedIndex < 0)
            {
              
            }
            else
            {

                sessionBO getDetails = new sessionBO();
                int sessionId = Convert.ToInt32(tuitionGrid.SelectedRow.Cells[0].Text);
                tutionEntities tutionObj = getDetails.GetTuitionById(sessionId);
                String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;

                Session["sessionId"] = Convert.ToInt32(tuitionGrid.SelectedRow.Cells[0].Text);
                Session["tutionDesc"] = tutionDescriptionLbl.Text;
                Session["sessionDate"] = dateLbl.Text.ToString();
                Session["sessionSTime"] = stimeLbl.Text.ToString();
                Session["sessionETime"] = etimeLbl.Text.ToString();
                Session["ddlSelectedValue"] = myStatusLbl.Text.ToString();
                Session["userIdSession"] = user_Id;


                Response.Redirect("updateTuitionPage.aspx");
            }
        }

        protected void createTuition_Click(object sender, EventArgs e)
        {
            Response.Redirect("createTuitionPage.aspx");
        }

       

        protected void viewAllTutorSession_Click(object sender, EventArgs e)
        {
            //response.redirect
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            Session["userIdSession"] = user_Id;
            Response.Redirect("viewAllTuition.aspx");
        }

        protected void RequestToMeGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RequestToMeGV.PageIndex = e.NewPageIndex;
            loadRequestToMeData();
        }

        protected void tuitionGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            tuitionGrid.PageIndex = e.NewPageIndex;
            loadData();

        }

        protected void requestByMeGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            requestByMeGV.PageIndex = e.NewPageIndex;
            loadRequestByMeData();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            //statusDDL.SelectedValue = RequestToMeGV.SelectedRow.Cells[4].Text;
            requestBO setStatus = new requestBO();
            requestEntity current_status = new requestEntity();
            string status = statusDDL.SelectedValue;
            string tempStatus = current_status.status;
            if (tempStatus == "canceled")
            {
                cancelLbl.Visible = true;
                cancelLbl.Text = "This request was canceled by the requestee";
                statusDDL.Visible = false;
                updateBtn.Enabled = false;
            }
            else
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    //clear all input
                    
                int requestId = Convert.ToInt32(RequestToMeGV.SelectedRow.Cells[0].Text);
                setStatus.acceptRequest(requestId, status);
                    string display = "Request is Updated";
                    ClientScript.RegisterStartupScript(this.GetType(), "Request is updated successfully!", "alert('" + display + "');", true);
                    loadRequestToMeData();
                    viewRequestToMePanel.Visible = true;
                    requestToMeDetailsPanel.Visible = false;
                    //request by me panel 
                    viewRequestByMePanel.Visible = false;
                    requestByMeDetailsPanel.Visible = false;
                    //session created by me
                    sessionDetailsPanel.Visible = false;
                    SessionByMePanel.Visible = false;
                    SessionCreatedByMeBtn.Visible = true;
                }
                else
                {
                    string display = "Request not Updated!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Request is not Updated!", "alert('" + display + "');", true);
                    loadRequestToMeData();
                    viewRequestToMePanel.Visible = true;
                    requestToMeDetailsPanel.Visible = false;
                    //request by me panel 
                    viewRequestByMePanel.Visible = false;
                    requestByMeDetailsPanel.Visible = false;
                    //session created by me
                    sessionDetailsPanel.Visible = false;
                    SessionByMePanel.Visible = false;
                    SessionCreatedByMeBtn.Visible = true;
                }
                
            }

        }

        protected void cancelRequestBtn_Click(object sender, EventArgs e)
        {
            requestBO setStatus = new requestBO();
            

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //clear all input
                string status = "canceled";
                int requestId = Convert.ToInt32(requestByMeGV.SelectedRow.Cells[0].Text);
                setStatus.acceptRequest(requestId, status);
                requestByMeDetailsPanel.Visible = true;
                loadRequestByMeData();
                string display = "Request is Canceled";
                ClientScript.RegisterStartupScript(this.GetType(), "Request is Canceled successfully!", "alert('" + display + "');", true);

                viewRequestToMePanel.Visible = false;
                requestToMeDetailsPanel.Visible = false;
                //request by me panel 
                viewRequestByMePanel.Visible = true;
                requestByMeDetailsPanel.Visible = false;
                //session created by me
                sessionDetailsPanel.Visible = false;
                SessionByMePanel.Visible = false;
                SessionCreatedByMeBtn.Visible = true;

                loadRequestToMeData();
            }
            else
            {
                string display = "Request is not Canceled!";
                ClientScript.RegisterStartupScript(this.GetType(), "Request is not Canceled!", "alert('" + display + "');", true);
                viewRequestToMePanel.Visible = false;
                requestToMeDetailsPanel.Visible = false;
                //request by me panel 
                viewRequestByMePanel.Visible = true;
                requestByMeDetailsPanel.Visible = false;
                //session created by me
                sessionDetailsPanel.Visible = false;
                SessionByMePanel.Visible = false;
                SessionCreatedByMeBtn.Visible = true;

                loadRequestToMeData();

            }

            
        }

        protected void SessionJoinedBtn_Click(object sender, EventArgs e)
        {
            sessionIjoinedPanel.Visible = true;
            viewRequestToMePanel.Visible = false;
            requestToMeDetailsPanel.Visible = false;
            //request by me panel 
            viewRequestByMePanel.Visible = false;
            requestByMeDetailsPanel.Visible = false;
            //session created by me
            sessionDetailsPanel.Visible = false;
            SessionByMePanel.Visible = false;
            SessionCreatedByMeBtn.Visible = true;


        }

        protected void JoinedSessionGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            sessionIjoinedPanel.Visible = true;
            sessionIjoinedDetailsPanel.Visible = true;
            viewRequestToMePanel.Visible = false;
            requestToMeDetailsPanel.Visible = false;
            //request by me panel 
            viewRequestByMePanel.Visible = false;
            requestByMeDetailsPanel.Visible = false;
            //session created by me
            sessionDetailsPanel.Visible = false;
            SessionByMePanel.Visible = false;
            SessionCreatedByMeBtn.Visible = true;

            sessionBO getDetails = new sessionBO();
           
            GridViewRow row = JoinedSessionGV.SelectedRow;
            String tuteeId = Request.Cookies["CurrentLoggedInUser"].Value;
            int sessionId = Convert.ToInt32(JoinedSessionGV.SelectedRow.Cells[0].Text);
            tutionEntities tutionObj = getDetails.GetSessionJoinedById(sessionId, tuteeId);


            SJDeatilsLbl.Text = tutionObj.SessionDetails.ToString();
            SJDateLbl.Text = tutionObj.sessionDate.ToString();
            SJSTimeLbl.Text = tutionObj.sessionSTime.ToString();
            SJETimeLbl.Text = tutionObj.sessionETime.ToString();
            SJTutorId.Text = tutionObj.tutorId.ToString();
            SJTuteeId.Text = tutionObj.tuteeId.ToString();



        }

        protected void JoinedSessionGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            JoinedSessionGV.PageIndex = e.NewPageIndex;
            loadSessionIJoined();
        }

        protected void unjoinSessionButton_Click(object sender, EventArgs e)
        {
            sessionBO getDetails = new sessionBO();

            GridViewRow row = JoinedSessionGV.SelectedRow;
            String tuteeId = Request.Cookies["CurrentLoggedInUser"].Value;
            int sessionId = Convert.ToInt32(JoinedSessionGV.SelectedRow.Cells[0].Text);

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getDetails.unjoin(tuteeId, sessionId);
                string display = "You successfully quit the session!";
                ClientScript.RegisterStartupScript(this.GetType(), "You successfully quit the  session!", "alert('" + display + "');", true);
              
                loadSessionIJoined();

                sessionIjoinedPanel.Visible = true;
                sessionIjoinedDetailsPanel.Visible = false;
                viewRequestToMePanel.Visible = false;
                requestToMeDetailsPanel.Visible = false;
                //request by me panel 
                viewRequestByMePanel.Visible = false;
                requestByMeDetailsPanel.Visible = false;
                //session created by me
                sessionDetailsPanel.Visible = false;
                SessionByMePanel.Visible = false;
                SessionCreatedByMeBtn.Visible = true;

            }
            else
            {
                string display = "You did not quit the  session!";
                ClientScript.RegisterStartupScript(this.GetType(), "You did not quit the  session!", "alert('" + display + "');", true);
                loadSessionIJoined();

                sessionIjoinedPanel.Visible = true;
                sessionIjoinedDetailsPanel.Visible = false;
                viewRequestToMePanel.Visible = false;
                requestToMeDetailsPanel.Visible = false;
                //request by me panel 
                viewRequestByMePanel.Visible = false;
                requestByMeDetailsPanel.Visible = false;
                //session created by me
                sessionDetailsPanel.Visible = false;
                SessionByMePanel.Visible = false;
                SessionCreatedByMeBtn.Visible = true;

            }

           
            
        }
    }
    }
