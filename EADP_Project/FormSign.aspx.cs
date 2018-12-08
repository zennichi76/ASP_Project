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
    public partial class FormSign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                modalOverlay.Visible = false;
                OthersAlert.Visible = false;
                UserBO userbo = new UserBO();
                String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                user currentuser = userbo.getUserById(currentLoggedInUser);
                string id = Request.QueryString["id"];
                ConsentFormBO consentformbo = new ConsentFormBO();
                ConsentForm consentFormData = consentformbo.getConsentFormByFormID(id);
                TitleLB.Text = consentFormData.Title;
                DescriptionTB.Text = consentFormData.Description;
                if(consentFormData.FoodPreferrence == "True")
                {
                    foodprefcard.Visible = true;
                }
                else
                {
                    foodprefcard.Visible = false;
                }

                if(currentuser.role == "Student")
                {
                    alertLB.Visible = true;
                    signgroup.Visible = false;
                }else if(currentuser.role == "Parent")
                {
                    alertLB.Visible = false;
                    signgroup.Visible = true;
                }
            }

        }

        protected void signBtn_Click(object sender, EventArgs e)
        {
            UserBO userbo = new UserBO();
            String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
            user currentuser = userbo.getUserById(currentLoggedInUser);
            user childuser = userbo.getUserById(currentuser.child_ID);
            string id = Request.QueryString["id"];
            ConsentFormBO formbo = new ConsentFormBO();
            String foodpreferrence = "";
            if(foodprefcard.Visible == false)
            {
                foodpreferrence = "";
            }
            else
            {
                if (FoodRadioButton.SelectedIndex == 3)
                {
                    if (OthersTB.Text.Trim() == "" || OthersTB.Text.Trim() == null)
                    {
                        //insert javascript alert
                        OthersAlert.Visible = true ;
                    }
                    else
                    {
                        foodpreferrence = OthersTB.Text;
                        OthersAlert.Visible = false;
                    }
                }
                else
                {
                    foodpreferrence = FoodRadioButton.SelectedValue;
                    OthersAlert.Visible = false;
                }
                
            }
            //finish setting, validation check
            if (!OthersAlert.Visible)
            {
                formbo.createFormEntry(childuser.User_ID, id, foodpreferrence);
                modalOverlay.Visible = true;
            }
        }

        protected void ProceedBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendingConsentForms.aspx");
        }
    }
}