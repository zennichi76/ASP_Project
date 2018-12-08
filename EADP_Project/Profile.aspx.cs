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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserBO userbo = new UserBO();
            String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
            user userobj = new user();
            userobj = userbo.getUserById(currentLoggedInUser);
            UsernameTB.Text = userobj.User_ID;
            NameTB.Text = userobj.name;
            EmailTB.Text = userobj.email;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(ChangePwdTB.Text.Trim() == "" || ChangePwdTB.Text.Trim() == null || ChangePwdConfirmTB.Text.Trim() == "" || ChangePwdConfirmTB.Text.Trim() == null)
            {
                ErrorMsgLabel.Text = "One of the password fields is empty, Password is not changed.";
            }
            else if (ChangePwdConfirmTB.Text == ChangePwdTB.Text)
            {
                UserBO userbo = new UserBO();
                userbo.updatePwd(Request.Cookies["CurrentLoggedInUser"].Value, ChangePwdTB.Text);
                ErrorMsgLabel.Text = "Password is changed successfully!";
            }
            else
            {
                ErrorMsgLabel.Text = "Passwords are not the same. Password is not changed";
            }
        }

        protected void newEmailTB_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (newEmailTB.Text.Trim() == "" || newEmailTB.Text.Trim() == null)
            {
                ErrorMsgLabelEmail.Text = "Please input a valid email address";
            }
            else
            {
                UserBO userbo = new UserBO();
                userbo.updateEmail(Request.Cookies["CurrentLoggedInUser"].Value, newEmailTB.Text);
                ErrorMsgLabelEmail.Text = "Email is changed successfully!";
                EmailTB.Text = newEmailTB.Text;
            }
        }
    }
}