using EADP_Project.BO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class PendingConsentForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                formalert.Visible = false;
                UserBO userbo = new UserBO();
                ConsentFormBO consentformbo = new ConsentFormBO();
                String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                user currentuser = userbo.getUserById(currentLoggedInUser);
                if (currentuser.role == "Student")
                {
                    List<ConsentForm> consentFormRecords = consentformbo.selectUnsignedFormsByUser(currentuser.User_ID, currentuser.school, currentuser.education_class);
                    if (consentFormRecords != null && consentFormRecords.Count != 0)
                    {
                        consentFormRecords.Reverse(); //sorts by latest at the top
                    }
                    else
                    {
                        formalert.Visible = true;
                    }
                    pendingForms.DataSource = consentFormRecords;
                    pendingForms.DataBind(); 
                }else if (currentuser.role == "Parent")
                {
                    user childuser = userbo.getUserById(currentuser.child_ID);
                    List<ConsentForm> consentFormRecords = consentformbo.selectUnsignedFormsByUser(childuser.User_ID, childuser.school, childuser.education_class);
                    if(consentFormRecords != null && consentFormRecords.Count != 0) { 
                    consentFormRecords.Reverse(); //sorts by latest at the top
                    }
                    else
                    {
                        formalert.Visible = true;
                    }
                    pendingForms.DataSource = consentFormRecords;
                    pendingForms.DataBind();
                }
                else
                {
                    formalert.Visible = true;
                }



            }
        }

        protected void pendingForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = pendingForms.SelectedRow;
       
            Response.Redirect("FormSign.aspx?id=" + row.Cells[0].Text);
        }
    }
}