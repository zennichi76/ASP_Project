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
    public partial class SiteMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["CurrentLoggedInUser"].Value != null)
            {
                user current_user_obj = new user();
                UserBO userbo = new UserBO();
                string userId = Request.Cookies["CurrentLoggedInUser"].Value;
                current_user_obj = userbo.getUserById(userId);
                AdminTools.Visible = false;
                if (current_user_obj.role == "Teacher")
                {
                    LinkEvent.HRef = "viewEventPage.aspx";
                    LinkTuition.Visible = false;
                }
                else if (current_user_obj.role == "Student")
                {
                    LinkEvent.HRef = "studentViewEvent.aspx";
                    LinkTuition.Visible = true;
                }
                else if (current_user_obj.role == "Parent")
                {
                    EventNavItem.Visible = false;
                    LinkTuition.Visible = false;
                }else if(current_user_obj.role == "Staff")
                {
                    LinkEvent.HRef = "viewEventPage.aspx";
                    LinkTuition.Visible = false;
                    EventNavItem.Visible = false;
                }
                else if (current_user_obj.role == "Admin")
                {
                    LinkEvent.HRef = "viewEventPage.aspx";
                    LinkTuition.Visible = false;
                    EventNavItem.Visible = false;
                    AdminTools.Visible = true;
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}