using EADP_Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project.StudentTutorPage
{
    public partial class updateTuitionPage : System.Web.UI.Page
    {
        sessionBO updateFunction;

        String tuitionDesc;
        String tuitionDate;
        String tuitionETime;
        String tuitionSTime;
        String user_Id;
        int sessionId;
        int currentSessionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if(!IsPostBack){
                loadData();
            }

        }
     

            public void loadData()
        {
            if (Session["sessionId"] != null)
            {
                currentSessionId = Convert.ToInt32(Session["sessionId"].ToString());
                sessionDetailsTB.Text = Session["tutionDesc"].ToString();
                sessionSDateTB.Text = Session["sessionDate"].ToString();
                sessionSTimeTB.Text = Session["sessionSTime"].ToString();
                sessionETimeTB.Text = Session["sessionETime"].ToString();
                statusDDL.SelectedValue = Session["ddlSelectedValue"].ToString();
                user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            }
        }

        public void updateTuition()
        {

            updateFunction = new sessionBO();

            sessionId = Convert.ToInt32(Session["sessionId"].ToString());
            tuitionDesc = sessionDetailsTB.Text.ToString();
            tuitionDate = sessionSDateTB.Text.ToString();
            tuitionETime = sessionETimeTB.Text.ToString();
            tuitionSTime = sessionSTimeTB.Text.ToString();
            user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            string status = statusDDL.SelectedValue.ToString();

            updateFunction.updateSession(sessionId, tuitionDesc, tuitionDate,tuitionSTime,tuitionETime ,status,user_Id);

            successpanel.Visible = true;
            
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {

            updateTuition();

            successpanel.Visible = true;

            Response.AddHeader("REFRESH", "5;URL=viewMyTuitionPage.aspx");
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Response.Redirect("viewMyTuitionPage.aspx");
            }
            else
            {
                
            }
           
        }
    }
}