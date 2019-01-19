using EADP_Project.BO;
using EADP_Project.Business_Layer;
using EADP_Project.Entities;
using EADP_Project_Education.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.IO;

namespace EADP_Project
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private String current_logged_in_user;
    
        private user current_user_obj;
        string cookieName;
        string browserID;
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!this.IsPostBack)
            {
                /*Session Fixation*/
                // check if the 2 sessions n cookie is not null
               

                if (Session["LoginUserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null && Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    //second check for cookie has the same value as the second session
                    if ((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))  /*End of Session Fixation*/
                    {

                    current_logged_in_user = Request.Cookies["CurrentLoggedInUser"].Value;
                    ErrorConsentForm.Visible = false;
                    ErrorLabelPurchase.Visible = false;
                    UserBO userbo = new UserBO();
                    current_user_obj = userbo.getUserById(current_logged_in_user);
                    ProfileName_LB.Text = current_user_obj.name;
                    Role_LB.Text = current_user_obj.role;
                    UserID_LB.Text = current_user_obj.User_ID;
                    CCAPoints_LB.Text = current_user_obj.cca_point.ToString();
                    OrionPoints_LB.Text = current_user_obj.orion_point.ToString();
                    Bookstore_BO bookstorebo = new Bookstore_BO();
                    List<PurchasedItem> itemsList = new List<PurchasedItem>();
                    itemsList = bookstorebo.purchaseHistory(current_logged_in_user);

                    if (itemsList == null || itemsList.Count == 0)
                    {
                        ErrorLabelPurchase.Visible = true;

                    }
                    else if (itemsList.Count() < 3)
                    {
                        itemsList.Reverse();
                        purchaseHistoryGridView.DataSource = itemsList.GetRange(0, itemsList.Count());
                        purchaseHistoryGridView.DataBind();
                        ErrorLabelPurchase.Visible = false;

                    }
                    else if (itemsList.Count() >= 3)
                    {
                        itemsList.Reverse();
                        purchaseHistoryGridView.DataSource = itemsList.GetRange(0, 3);
                        purchaseHistoryGridView.DataBind();
                        ErrorLabelPurchase.Visible = false;
                    }

                    //hide certain panels according to user type
                    if (current_user_obj.role == "Student")
                    {
                        RegisteredActivities_Col.Visible = true;
                        ConsentForms_Col.Visible = false;
                        Response.Cookies["Current_Edu_Level"].Value = current_user_obj.education_level;
                        eventBO eventbo = new eventBO();
                        List<events> eventList = eventbo.loadSignUpEvent(current_logged_in_user);
                        //event stuff

                        if (eventList == null || eventList.Count == 0)
                        {
                            EventsErrorMsg.Visible = true;

                        }
                        else if (eventList.Count() < 3)
                        {
                            eventList.Reverse();
                            RegisteredEventGridView.DataSource = eventList.GetRange(0, eventList.Count());
                            RegisteredEventGridView.DataBind();
                            EventsErrorMsg.Visible = false;

                        }
                        else if (eventList.Count() >= 3)
                        {
                            itemsList.Reverse();
                            RegisteredEventGridView.DataSource = eventList.GetRange(0, 3);
                            RegisteredEventGridView.DataBind();
                            EventsErrorMsg.Visible = false;
                        }


                        //insert pending items [check class, check the amount of unsigned forms]
                        ConsentFormBO consentformbo = new ConsentFormBO();
                        List<ConsentForm> consentFormList = consentformbo.selectUnsignedFormsByUser(current_user_obj.User_ID, current_user_obj.school, current_user_obj.education_class);
                        if (consentFormList == null || consentFormList.Count == 0)
                        {
                            pendingItemsLabel.Text = "You have no pending items.";
                        }
                        else
                        {
                            pendingItemsLabel.Text = "You have (" + consentFormList.Count + ") pending items.";
                        }

                    }
                    else if (current_user_obj.role == "Parent")
                    {
                        RegisteredActivities_Col.Visible = true;
                        ConsentForms_Col.Visible = false;
                        RegisteredActivities_Col.Visible = false;

                        //insert pending items [check class, check the amount of unsigned forms]
                        //find child 
                        user childuser = new user();
                        UserBO childuserbo = new UserBO();
                        childuser = childuserbo.getUserById(current_user_obj.child_ID);
                        ConsentFormBO consentformbo = new ConsentFormBO();
                        List<ConsentForm> consentFormList = consentformbo.selectUnsignedFormsByUser(childuser.User_ID, childuser.school, childuser.education_class);
                        if (consentFormList == null || consentFormList.Count == 0)
                        {
                            pendingItemsLabel.Text = "You have no pending items.";
                        }
                        else
                        {
                            pendingItemsLabel.Text = "You have (" + consentFormList.Count + ") pending items.";
                        }
                    }
                    else if (current_user_obj.role == "Teacher")
                    {
                        ConsentForms_Col.Visible = true;
                        RegisteredActivities_Col.Visible = false;
                        pendingItemsLabel.Text = "You have no pending items.";//tentative

                        //insert 3 recently sent forms here 
                        ConsentFormBO consentformbo = new ConsentFormBO();
                        List<ConsentForm> consentFormList = consentformbo.getConsentFormsBySenderID(current_user_obj.User_ID);
                        if (consentFormList == null || consentFormList.Count == 0)
                        {
                            ErrorConsentForm.Visible = true;
                        }
                        else if (consentFormList.Count() < 3)
                        {
                            consentFormList.Reverse();
                            GridViewSentForms.DataSource = consentFormList.GetRange(0, consentFormList.Count());
                            GridViewSentForms.DataBind();
                            ErrorConsentForm.Visible = false;

                        }
                        else if (consentFormList.Count() >= 3)
                        {
                            consentFormList.Reverse();
                            GridViewSentForms.DataSource = consentFormList.GetRange(0, 3);
                            GridViewSentForms.DataBind();
                            ErrorConsentForm.Visible = false;
                        }


                    }
                    else if (current_user_obj.role == "Staff")
                    {
                        ConsentForms_Col.Visible = false;
                        RegisteredActivities_Col.Visible = false;
                        pendingItemsLabel.Text = "You have no pending items.";
                        RegisteredActivities_Col.Visible = false;
                    }
                    else if (current_user_obj.role == "Admin")
                    {
                        ConsentForms_Col.Visible = false;
                        RegisteredActivities_Col.Visible = false;
                        pendingItemsLabel.Text = "You have no pending items.";
                        RegisteredActivities_Col.Visible = false;
                    }
                    ToConsentFormsManagementBtn.NavigateUrl = Response.ApplyAppPathModifier("ManageConsentFormsPage.aspx");
                }
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }

               


            }

            string blacklist = File.ReadAllText(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt");
            string ip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(1).ToString();
            if (blacklist.Contains(ip))
            {
                Server.Transfer("Blacklist.aspx");
            }

        }

   


    }
}