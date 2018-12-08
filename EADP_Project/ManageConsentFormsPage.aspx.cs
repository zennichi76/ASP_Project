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
    public partial class ManageConsentFormsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Current_screen_LB.Text = "Manage/Check Consent Forms";
                //CreateFormBtn.Visible = true;
                //ManageFormBtn.Visible = false;
                classListDiv.Visible = false;
                FormInfoDiv.Visible = false;
                confirmationOverlay.Visible = false;
                foodprefcard.Visible = false;
                foodprefcardupdate.Visible = false;
                updateFormDiv.Visible = false;
                modalOverlay.Visible = false;
                FoodRadioButton.SelectedIndex = 0;
                CreateConsentFormDiv.Visible = false;
                DraftList.Visible = false;
                UserBO userbo = new UserBO();
                ConsentFormBO consentformbo = new ConsentFormBO();
                String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                List<String> TeachingClasses = userbo.getTeachersTeachingClasses(currentLoggedInUser);
                
                List<ConsentForm> consentFormRecordsDrafts = consentformbo.getDraftConsentFormsBySenderID(currentLoggedInUser);

                if(consentFormRecordsDrafts == null || consentFormRecordsDrafts.Count == 0)
                {
                    DraftFormErrorMsg.Text = "There are no drafts created.";
                }          
                DraftFormErrorMsg.Visible = false;
                List<ConsentForm> consentFormRecords = consentformbo.getConsentFormsBySenderID(currentLoggedInUser);
                if (consentFormRecords == null || consentFormRecords.Count == 0)
                {
                    formErrorMsg.Text = "There are no forms created.";
                }
                else
                {
                    consentFormRecords.Reverse(); //sorts by latest at the top
                }
                classesDropDownList.DataSource = TeachingClasses;
                classesDropDownList.DataBind();

                string currentSchool = userbo.getUserById(Request.Cookies["CurrentLoggedInUser"].Value).school;
                classesDropDownList.SelectedIndex = 0;
                string selectedClass = classesDropDownList.SelectedValue;
                List<user> studentClassList = userbo.retrieveClassListBySchoolAndClass(currentSchool, selectedClass);
                classListGridView.DataSource = studentClassList;
                classListGridView.DataBind();

                SelectedClassesListBox.DataSource = TeachingClasses;
                SelectedClassesListBox.DataBind(); //binds the data of classes that the user teaches
                updateSelectedClassesListBox.DataSource = TeachingClasses;
                updateSelectedClassesListBox.DataBind();
                DraftList.DataSource = consentFormRecordsDrafts;
                DraftList.DataBind();
                ConsentFormList.DataSource = consentFormRecords;
                ConsentFormList.DataBind(); //bind entries
            }

        }

        protected void CreateFormBtn_Click(object sender, EventArgs e)
        {
            Current_screen_LB.Text = "Create Consent Form";
            //CreateFormBtn.Visible = false;
            //ManageFormBtn.Visible = true;
            DraftList.Visible = false;
            CreateConsentFormDiv.Visible = true;
            ConsentFormList.Visible = false;
            updateFormDiv.Visible = false;
            DraftFormErrorMsg.Visible = false;
            //ManageFormDraftsBtn.Visible = true;
            formErrorMsg.Visible = false;
            FormInfoDiv.Visible = false;
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (SelectedClassesListBox.SelectedItem == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert(\"Please select an item\")</script>"); //js function to call alert when no item is selected
            }
            else
            {
                SelectedClassesListBox_Selected.ClearSelection(); //clear selection to prevent multiple selection exception
                SelectedClassesListBox_Selected.Items.Add(SelectedClassesListBox.SelectedItem);
                SelectedClassesListBox.Items.Remove(SelectedClassesListBox.SelectedItem);
                SelectedClassesListBox_Selected.ClearSelection();//clear selection to prevent multiple selection exception
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (SelectedClassesListBox_Selected.SelectedItem == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert(\"Please select an item\")</script>"); //js function to call alert when no item is selected
            }
            else
            {
                SelectedClassesListBox.ClearSelection(); //clear selection to prevent multiple selection exception
                SelectedClassesListBox.Items.Add(SelectedClassesListBox_Selected.SelectedItem);
                SelectedClassesListBox_Selected.Items.Remove(SelectedClassesListBox_Selected.SelectedItem);
                SelectedClassesListBox.ClearSelection();//clear selection to prevent multiple selection exception
            }
        }

        protected void FoodRadioButton_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            foodprefcard.Visible = false;
            TitleTB.Text = "";
            DescriptionTB.Text = "";
            FoodPreferrences.Checked = false;
            FoodRadioButton.SelectedIndex = 0; //sets all to default
        }

        protected void SendFormBtn_Click(object sender, EventArgs e)
        {
            String RecievingClasses = "";
            String senderID = Request.Cookies["CurrentLoggedInUser"].Value;
            String school;
            UserBO userbo = new UserBO();
            school = userbo.getUserById(senderID).school;
            String Title;
            String Description;
            String FoodPreferrence;
            //this for loop will store the selected classes into a single string that can be split to retrive them later
            if (SelectedClassesListBox_Selected.Items.Count == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert(\"There are no classes selected, please select a class.\")</script>");
            }
            else
            {
                for (int i = 0; i < SelectedClassesListBox_Selected.Items.Count; i++)
                {
                    if (i == SelectedClassesListBox_Selected.Items.Count - 1)
                    {
                        RecievingClasses += SelectedClassesListBox_Selected.Items[i];
                    }
                    else
                    {
                        RecievingClasses += SelectedClassesListBox_Selected.Items[i] + ",";
                    }

                }
                //getting the other informations 
                Title = TitleTB.Text;
                Description = DescriptionTB.Text;
                FoodPreferrence = FoodPreferrences.Checked.ToString();
                //send it to business object
                ConsentFormBO consentformbo = new ConsentFormBO();
                consentformbo.createConsentForm(senderID, RecievingClasses, school, Title, Description, FoodPreferrence); //insert a new record into db through Business Logic
                System.Diagnostics.Debug.WriteLine(RecievingClasses + " " + school); //console write
                MessageLabel.Text = "Consent form is successfully created and sent";
                modalOverlay.Visible = true;
            }

        }

        protected void ManageFormBtn_Click(object sender, EventArgs e)
        {
            Current_screen_LB.Text = "Manage/Check Consent Forms";
            //CreateFormBtn.Visible = true;
            //ManageFormBtn.Visible = false;
            CreateConsentFormDiv.Visible = false;
            //ManageFormDraftsBtn.Visible = true;
            updateFormDiv.Visible = false;
            ConsentFormList.Visible = true;
            DraftList.Visible = false;
            DraftFormErrorMsg.Visible = false;
            formErrorMsg.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageConsentFormsPage.aspx");
        }

        protected void ConsentFormList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row = ConsentFormList.SelectedRow;
            //updateFormDiv.Visible = true;
            //ConsentFormBO consentformbo = new ConsentFormBO();
            //ConsentForm obj = new ConsentForm();
            //obj = consentformbo.getConsentFormByFormID(row.Cells[0].Text);
            //hiddenFieldID.Text = obj.ConsentFormID.ToString();
            //UpdateTitleTB.Text = obj.Title;
            //UpdateDescriptionTB.Text = obj.Description;
            //UpdateFoodPreferrences.Checked = Boolean.Parse(obj.FoodPreferrence.ToString());
            //if (UpdateFoodPreferrences.Checked)
            //{
            //    foodprefcardupdate.Visible = true;
            //}
            //else
            //{
            //    foodprefcardupdate.Visible = false;
            //}

        }

        protected void updateClearBtn_Click(object sender, EventArgs e)
        {
            foodprefcardupdate.Visible = false;
            UpdateTitleTB.Text = "";
            UpdateDescriptionTB.Text = "";
            UpdateFoodPreferrences.Checked = false;
            UpdateFoodRadioButton.SelectedIndex = 0; //sets all to default
        }

        protected void ConsentFormList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ConsentFormBO consentformbo = new ConsentFormBO();
            String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
            List<ConsentForm> consentFormRecords = consentformbo.getConsentFormsBySenderID(currentLoggedInUser);
            consentFormRecords.Reverse();
            ConsentFormList.DataSource = consentFormRecords;
            ConsentFormList.PageIndex = e.NewPageIndex;
            ConsentFormList.DataBind();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String FormID;
            String Title;
            String Description;
            String FoodPreferrence;
            String RecievingClasses = "";
            String senderID = Request.Cookies["CurrentLoggedInUser"].Value;
            String school;
            UserBO userbo = new UserBO();
            school = userbo.getUserById(senderID).school;
            //this for loop will store the selected classes into a single string that can be split to retrive them later
            if (updateSelectedClassesListBox_Selected.Items.Count == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert(\"There are no classes selected, please select a class.\")</script>");
            }
            else
            {
                for (int i = 0; i < updateSelectedClassesListBox_Selected.Items.Count; i++)
                {
                    if (i == updateSelectedClassesListBox_Selected.Items.Count - 1)
                    {
                        RecievingClasses += updateSelectedClassesListBox_Selected.Items[i];
                    }
                    else
                    {
                        RecievingClasses += updateSelectedClassesListBox_Selected.Items[i] + ",";
                    }

                }
                //getting the other informations 
                FormID = hiddenFieldID.Text;
                Title = UpdateTitleTB.Text;
                Description = UpdateDescriptionTB.Text;
                FoodPreferrence = UpdateFoodPreferrences.Checked.ToString();
                //send it to business object
                ConsentFormBO consentformbo = new ConsentFormBO();
                consentformbo.updateDraftConsentFormByFormID(FormID, RecievingClasses, Title, Description, FoodPreferrence);
                MessageLabel.Text = "Consent form draft is successfully updated";
                modalOverlay.Visible = true;
            }
            //this for loop will store the selected classes into a single string that can be split to retrive them later
            
        }

        protected void FoodPreferrences_CheckedChanged(object sender, EventArgs e)
        {
            if (FoodPreferrences.Checked)
            {
                foodprefcard.Visible = true;
            }
            else if (FoodPreferrences.Checked == false)
            {
                foodprefcard.Visible = false;
            }
        }

        protected void UpdateFoodPreferrences_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdateFoodPreferrences.Checked)
            {
                foodprefcardupdate.Visible = true;
            }
            else if (UpdateFoodPreferrences.Checked == false)
            {
                foodprefcardupdate.Visible = false;
            }
        }

        protected void ConsentFormList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ConsentFormList.Rows[index];
                ConsentFormBO consentformbo = new ConsentFormBO();
                ConsentForm obj = new ConsentForm();
                obj = consentformbo.getConsentFormByFormID(row.Cells[0].Text);
                ViewFormTitleLB.Text = obj.Title;
                ViewFormDescriptionTB.Text = obj.Description;
                FormInfoDiv.Visible = true;
                if (Boolean.Parse(obj.FoodPreferrence.ToString()))
                {
                    ViewFormFoodPrefCard.Visible = true;
                }
                else
                {
                    ViewFormFoodPrefCard.Visible = false;
                }
            }else if(e.CommandName == "viewParticipants")
            {
                //insert page to view participants
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ConsentFormList.Rows[index];
                Response.Redirect("ConsentFormStatus.aspx?FormId=" +row.Cells[0].Text+"&FoodPref="+row.Cells[5].Text);
            }
            
        }

        protected void ManageFormDraftsBtn_Click(object sender, EventArgs e)
        {
            Current_screen_LB.Text = "Manage/Check Consent Forms Drafts";
            //CreateFormBtn.Visible = true;
            //ManageFormBtn.Visible = true;
            //ManageFormDraftsBtn.Visible = false;
            CreateConsentFormDiv.Visible = false;
            ConsentFormList.Visible = false;
            DraftList.Visible = true;
            DraftFormErrorMsg.Visible = true;
            formErrorMsg.Visible = false;
            FormInfoDiv.Visible = false;
        }

        protected void SaveDraftBtn_Click(object sender, EventArgs e)
        {
            String RecievingClasses = "";
            String senderID = Request.Cookies["CurrentLoggedInUser"].Value;
            String school;
            UserBO userbo = new UserBO();
            school = userbo.getUserById(senderID).school;
            String Title;
            String Description;
            String FoodPreferrence;
            //this for loop will store the selected classes into a single string that can be split to retrive them later
            if (SelectedClassesListBox_Selected.Items.Count == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert(\"There are no classes selected, please select a class.\")</script>");
            }
            else
            {
                for (int i = 0; i < SelectedClassesListBox_Selected.Items.Count; i++)
                {
                    if (i == SelectedClassesListBox_Selected.Items.Count - 1)
                    {
                        RecievingClasses += SelectedClassesListBox_Selected.Items[i];
                    }
                    else
                    {
                        RecievingClasses += SelectedClassesListBox_Selected.Items[i] + ",";
                    }

                }
                //getting the other informations 
                Title = TitleTB.Text;
                Description = DescriptionTB.Text;
                FoodPreferrence = FoodPreferrences.Checked.ToString();
                //send it to business object
                ConsentFormBO consentformbo = new ConsentFormBO();
                consentformbo.createConsentFormDraft(senderID, RecievingClasses, school, Title, Description, FoodPreferrence); //insert a new record into db through Business Logic
                System.Diagnostics.Debug.WriteLine(RecievingClasses + " " + school); //console write
                MessageLabel.Text = "Consent form is successfully saved as draft";
                modalOverlay.Visible = true;
            }

        }

        protected void updateRemoveBtn_Click(object sender, EventArgs e)
        {

        }

        protected void updateAddBtn_Click(object sender, EventArgs e)
        {

        }

        protected void DraftList_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DraftList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ConsentFormBO consentformbo = new ConsentFormBO();
            String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
            List<ConsentForm> consentFormRecords = consentformbo.getDraftConsentFormsBySenderID(currentLoggedInUser);
            consentFormRecords.Reverse();
            DraftList.DataSource = consentFormRecords;
            DraftList.PageIndex = e.NewPageIndex;
            DraftList.DataBind();
        }

        protected void DraftList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = DraftList.SelectedRow;
            updateFormDiv.Visible = true;
            ConsentFormBO consentformbo = new ConsentFormBO();
            ConsentForm obj = new ConsentForm();
            UserBO userbo = new UserBO();
            obj = consentformbo.getDraftConsentFormByFormID(row.Cells[0].Text);
            List<String> RecievingClasses = obj.RecievingClasses.Split(',').ToList<String>();
            List<String> TeachingClasses = userbo.getTeachersTeachingClasses(Request.Cookies["CurrentLoggedInUser"].Value);
            List<String> newTeachClasses = new List<string>();
            foreach(String i in TeachingClasses)
            {
                if (RecievingClasses.Contains(i))
                {
                    //dont add anything
                }
                else
                {
                    newTeachClasses.Add(i);
                }
            }
            updateSelectedClassesListBox.DataSource = newTeachClasses;
            updateSelectedClassesListBox.DataBind();
            updateSelectedClassesListBox_Selected.DataSource = RecievingClasses;
            updateSelectedClassesListBox_Selected.DataBind();
            hiddenFieldID.Text = obj.ConsentFormID.ToString();
            UpdateTitleTB.Text = obj.Title;
            UpdateDescriptionTB.Text = obj.Description;
            UpdateFoodPreferrences.Checked = Boolean.Parse(obj.FoodPreferrence.ToString());
            if (UpdateFoodPreferrences.Checked)
            {
                foodprefcardupdate.Visible = true;
            }
            else
            {
                foodprefcardupdate.Visible = false;
            }
        }

        protected void sendDraftBtn_Click(object sender, EventArgs e)
        {
            String RecievingClasses = "";
            String senderID = Request.Cookies["CurrentLoggedInUser"].Value;
            String school;
            UserBO userbo = new UserBO();
            school = userbo.getUserById(senderID).school;
            String Title;
            String Description;
            String FoodPreferrence;
            String DraftID;
            //this for loop will store the selected classes into a single string that can be split to retrive them later
            if (updateSelectedClassesListBox_Selected.Items.Count == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert(\"There are no classes selected, please select a class.\")</script>");
            }
            else
            {
                for (int i = 0; i < updateSelectedClassesListBox_Selected.Items.Count; i++)
                {
                    if (i == updateSelectedClassesListBox_Selected.Items.Count - 1)
                    {
                        RecievingClasses += updateSelectedClassesListBox_Selected.Items[i];
                    }
                    else
                    {
                        RecievingClasses += updateSelectedClassesListBox_Selected.Items[i] + ",";
                    }

                }
                //getting the other informations 
                DraftID = hiddenFieldID.Text;
                Title = UpdateTitleTB.Text;
                Description = UpdateDescriptionTB.Text;
                FoodPreferrence = UpdateFoodPreferrences.Checked.ToString();
                //send it to business object
                ConsentFormBO consentformbo = new ConsentFormBO();
                consentformbo.createConsentForm(senderID, RecievingClasses, school, Title, Description, FoodPreferrence); //insert a new record into db through Business Logic
                consentformbo.removeDraft(DraftID);
                System.Diagnostics.Debug.WriteLine(RecievingClasses + " " + school); //console write
                MessageLabel.Text = "Consent form is successfully created and sent";
                modalOverlay.Visible = true;
            }
        }

        protected void updateAddBtn_Click1(object sender, EventArgs e)
        {
            if (updateSelectedClassesListBox.SelectedItem == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert(\"Please select an item\")</script>"); //js function to call alert when no item is selected
            }
            else
            {
                updateSelectedClassesListBox_Selected.ClearSelection(); //clear selection to prevent multiple selection exception
                updateSelectedClassesListBox_Selected.Items.Add(updateSelectedClassesListBox.SelectedItem);
                updateSelectedClassesListBox.Items.Remove(updateSelectedClassesListBox.SelectedItem);
                updateSelectedClassesListBox_Selected.ClearSelection();//clear selection to prevent multiple selection exception
            }
        }

        protected void updateRemoveBtn_Click1(object sender, EventArgs e)
        {
            if (updateSelectedClassesListBox_Selected.SelectedItem == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert(\"Please select an item\")</script>"); //js function to call alert when no item is selected
            }
            else
            {
                updateSelectedClassesListBox.ClearSelection(); //clear selection to prevent multiple selection exception
                updateSelectedClassesListBox.Items.Add(updateSelectedClassesListBox_Selected.SelectedItem);
                updateSelectedClassesListBox_Selected.Items.Remove(updateSelectedClassesListBox_Selected.SelectedItem);
                updateSelectedClassesListBox.ClearSelection();//clear selection to prevent multiple selection exception
            }
        }

        protected void NoBtn_Click(object sender, EventArgs e)
        {
            confirmationOverlay.Visible = false;
        }

        protected void removeDraftBtn_Click(object sender, EventArgs e)
        {
            confirmationOverlay.Visible = true;
        }

        protected void YesBtn_Click(object sender, EventArgs e)
        {
            String DraftID = hiddenFieldID.Text;
            ConsentFormBO consentformbo = new ConsentFormBO();
            consentformbo.removeDraft(DraftID);
            confirmationOverlay.Visible = false;
            MessageLabel.Text = "Consent form draft is successfully deleted.";
            modalOverlay.Visible = true;
        }

        protected void classesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserBO userbo = new UserBO();
            string currentSchool = userbo.getUserById(Request.Cookies["CurrentLoggedInUser"].Value).school;
            string selectedClass = classesDropDownList.SelectedValue;
            List<user> studentClassList = userbo.retrieveClassListBySchoolAndClass(currentSchool,selectedClass);
            classListGridView.DataSource = studentClassList;
            classListGridView.DataBind();
        }

        protected void classListHyperLink_ServerClick(object sender, EventArgs e)
        {
            classListDiv.Visible = true;
        }

        protected void closeClassListBtn_Click(object sender, EventArgs e)
        {
            classListDiv.Visible = false;
        }
    }
}