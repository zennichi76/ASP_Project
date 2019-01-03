using EADP_Project.BO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {      
                        
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            String input_username = username_tb.Text;
            String input_password = password_tb.Text;
            UserBO login_bo = new UserBO();
            user returnedObj = new user();
            returnedObj = login_bo.login_validation(input_username, input_password);

            //security Questions for authentication


            if (returnedObj == null)
            {
                ErrorMsg.Text = "Login failed"; //login fail 
            }
            else
            {
                //to create session for user
                Session["LoginUserName"] = returnedObj.User_ID.ToString();
                string guid = Guid.NewGuid().ToString();
                //create second session for user and assigning a random GUID
                Session["AuthToken"] = guid;
                //Create cokie and store the same value of second session in cookie
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                Response.Cookies.Add(new HttpCookie("CurrentLoggedInUser", returnedObj.User_ID.ToString()));

              // Response.Cookies["CurrentLoggedInUser"].Value = returnedObj.User_ID;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);
                Response.Redirect("Dashboard.aspx"); //login pass

            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void ForgetSecQnsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetSecurityQuestion.aspx");
        }
    }
}