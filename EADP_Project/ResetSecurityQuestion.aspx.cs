using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class ResetSecurityQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void cancelButton()
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void submitEmailBtn_Click(object sender, EventArgs e)
        {
            passwordPanel.Visible = true;
            emailPanel.Visible = false;
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            //revert back to original
            Response.Redirect("LoginPage.aspx");
        }

        protected void submitPasswordBtn_Click(object sender, EventArgs e)
        {
            //move to reset sec q 
            answerSecurityQ.Visible = true;
            passwordPanel.Visible = false;
            emailPanel.Visible = false;

        }

        protected void submitAnsweredSQBtn_Click(object sender, EventArgs e)
        {
            resetSeurityPanel.Visible = true;
            answerSecurityQ.Visible = false;
            passwordPanel.Visible = false;
            emailPanel.Visible = false;
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            cancelButton();
        }

        protected void submitSQBtn_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Your Security Questions have been updated!');window.location ='LoginPage.aspx';", true);
            //string display = "Your Security Questions have been updated!";
            //ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('" + display + "');", true);

            //Response.Redirect("LoginPage.aspx");
        }
    }
}