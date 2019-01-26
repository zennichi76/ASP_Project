using EADP_Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project.StudentTutorPage
{
    public partial class viewTuitionPage : System.Web.UI.Page
    {

        sessionBO addSessionObj = new sessionBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
            }
        }

        public void createSession()
        {
            sessionBO add = new sessionBO();

            String sessionDetails = sessionDetailsTB.Text.ToString();
            String sessionSTime = (sessionSTimeTB.Text.ToString());
            String sessionETime = sessionETimeTB.Text.ToString();
            String sessionDate = (sessionSDateTB.Text.ToString());
            String user_Id = Request.Cookies["CurrentLoggedInUser"].Value;
            String status = "Ongoing";


            add.insertSession(sessionDetails, sessionDate,sessionSTime, sessionETime, status ,user_Id);


            }

        public bool isValid()
        {
            bool pass = true;
            DateTime startDate = Convert.ToDateTime(sessionSDateTB.Text.Trim());
            DateTime currentDate = DateTime.Today;
            DateTime startTime = Convert.ToDateTime(sessionSTimeTB.Text.Trim());
            DateTime endTime = Convert.ToDateTime(sessionETimeTB.Text.Trim());

            System.TimeSpan diff = endTime.Subtract(startTime);
            int minHour = (int)diff.TotalMinutes;

            if (currentDate > startDate)
            {
                sdateErrLbl.Text = "Start Date should not be over already!";
                successpanel.Visible = false;
                //errorPanel.Visible = true;
                sdateErrLbl.Visible = true;
                pass = false;
            }
            else if (startTime >= endTime)
            {
                timeErrLbl.Text = "Please ensure that end time is not earlier than start time!";
                successpanel.Visible = false;
                // errorPanel.Visible = true;
                timeErrLbl.Visible = true;
                pass = false;
            }
            else if (minHour < 90)
            {
                timeErrLbl.Text = "Session should be at least 1h and 30min";
                successpanel.Visible = false;

                timeErrLbl.Visible = true;
                pass = false;
            }
            else
            {
                pass = true;
            }

            return pass;
        }




        protected void createBtn_Click(object sender, EventArgs e)
        {
            bool success = isValid();
            if(success == false)
            {
                sdateErrLbl.Visible = true;
                timeErrLbl.Visible = true;
            }
            else
            {
                createSession();
                successpanel.Visible = true;

                Response.AddHeader("REFRESH", "3;URL=viewMyTuitionPage.aspx");
            }

        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewMyTuitionPage.aspx");
        }
    }
}