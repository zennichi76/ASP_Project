using EADP_Project_Education.BO;
using EADP_Project_Education.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project_Education
{
    public partial class StudyGuide : System.Web.UI.Page
    {

        Bookstore_BO bookstorebo = new Bookstore_BO();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_Generate_Click(object sender, EventArgs e)
        {
            lbl_Error1.Visible = false;
            lbl_Error2.Visible = false;
            StringBuilder sb = new StringBuilder();
            ArrayList scheduleList = new ArrayList();
            double sumHours = 0.0;
            int count = 0;
            int count1 = 0;
            int countVisible = 0;
            //subjects 1 - 4
            if (ddl_Score1.SelectedValue == "-1")
            {
                count++;
            }
            if (TB_Subject1.Text == "")
            {
                count1++;
            }
            else
            {
                string grade = ddl_Score1.SelectedItem.ToString();
                lbl_Subject1.Text = TB_Subject1.Text + " --> " + calculateStudyHours(grade).ToString();
                scheduleList.Add(TB_Subject1.Text);
                sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                countVisible++;
            }

            if (ddl_Score2.SelectedValue == "-1")
            {
                count++;
            }
            if (TB_Subject2.Text == "")
            {
                count1++;
            }
            else
            {
                string grade = ddl_Score2.SelectedItem.ToString();
                lbl_Subject2.Text = TB_Subject2.Text + " --> " + calculateStudyHours(grade).ToString();
                scheduleList.Add(TB_Subject2.Text);
                sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                countVisible++;
            }

            if (ddl_Score3.SelectedValue == "-1")
            {
                count++;
            }
            if (TB_Subject3.Text == "")
            {
                count1++;
            }
            else
            {
                string grade = ddl_Score3.SelectedItem.ToString();
                lbl_Subject3.Text = TB_Subject3.Text + " --> " + calculateStudyHours(grade).ToString();
                scheduleList.Add(TB_Subject3.Text);
                sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                countVisible++;
            }

            if (ddl_Score4.SelectedValue == "-1")
            {
                count++;
            }
            if (TB_Subject4.Text == "")
            {
                count1++;
            }
            else
            {
                string grade = ddl_Score4.SelectedItem.ToString();
                lbl_Subject4.Text = TB_Subject4.Text + " --> " + calculateStudyHours(grade).ToString();
                scheduleList.Add(TB_Subject4.Text);
                sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                countVisible++;
            }

            //subjects 5 - 10
            //Subject 5
            if (TB_Subject5.Visible == true && ddl_Score5.Visible == true)
            {
                if (TB_Subject5.Text == "")
                {
                    count1++;
                }
                if (ddl_Score5.SelectedValue == "-1")
                {
                    count++;
                }
                else
                {
                    string grade = ddl_Score5.SelectedItem.ToString();
                    lbl_Subject5.Text = TB_Subject5.Text + " --> " + calculateStudyHours(grade).ToString();
                    scheduleList.Add(TB_Subject5.Text);
                    sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                    countVisible++;
                }
            }

            //Subject 6
            if (TB_Subject6.Visible == true && ddl_Score6.Visible == true)
            {
                if (TB_Subject6.Text == "")
                {
                    count1++;
                }
                if (ddl_Score6.SelectedValue == "-1")
                {
                    count++;
                }
                else
                {
                    string grade = ddl_Score6.SelectedItem.ToString();
                    lbl_Subject6.Text = TB_Subject6.Text + " --> " + calculateStudyHours(grade).ToString();
                    scheduleList.Add(TB_Subject6.Text);
                    sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                    countVisible++;
                }
            }

            //Subject 7
            if (TB_Subject7.Visible == true && ddl_Score7.Visible == true)
            {
                if (TB_Subject7.Text == "")
                {
                    count1++;
                }
                if (ddl_Score7.SelectedValue == "-1")
                {
                    count++;
                }
                else
                {
                    string grade = ddl_Score7.SelectedItem.ToString();
                    lbl_Subject7.Text = TB_Subject7.Text + " --> " + calculateStudyHours(grade).ToString();
                    scheduleList.Add(TB_Subject7.Text);
                    sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                    countVisible++;
                }
            }

            //Subject 8
            if (TB_Subject8.Visible == true && ddl_Score8.Visible == true)
            {
                if (TB_Subject8.Text == "")
                {
                    count1++;
                }
                if (ddl_Score8.SelectedValue == "-1")
                {
                    count++;
                }
                else
                {
                    string grade = ddl_Score8.SelectedItem.ToString();
                    lbl_Subject8.Text = TB_Subject8.Text + " --> " + calculateStudyHours(grade).ToString();
                    scheduleList.Add(TB_Subject8.Text);
                    sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                    countVisible++;
                }
            }
            //Subject 9
            if (TB_Subject9.Visible == true && ddl_Score9.Visible == true)
            {
                if (TB_Subject9.Text == "")
                {
                    count1++;
                }
                if (ddl_Score9.SelectedValue == "-1")
                {
                    count++;
                }
                else
                {
                    string grade = ddl_Score9.SelectedItem.ToString();
                    lbl_Subject9.Text = TB_Subject9.Text + " --> " + calculateStudyHours(grade).ToString();
                    scheduleList.Add(TB_Subject9.Text);
                    sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                    countVisible++;
                }
            }

            //Subject 10
            if (TB_Subject10.Visible == true && ddl_Score10.Visible == true)
            {
                if (TB_Subject10.Text == "")
                {
                    count1++;
                }
                if (ddl_Score10.SelectedValue == "-1")
                {
                    count++;
                }
                else
                {
                    string grade = ddl_Score10.SelectedItem.ToString();
                    lbl_Subject10.Text = TB_Subject10.Text + " --> " + calculateStudyHours(grade).ToString();
                    scheduleList.Add(TB_Subject10.Text);
                    sumHours += Convert.ToDouble(calculateStudyHours(grade).Substring(0, 3));
                    countVisible++;
                }
            }

            //validation for textboxes and DropDownLists
            if (count > 0)
            {
                lbl_Error1.Visible = true;
                lbl_Error1.Text = "Ensure that all subjects have a selected grade";
            }

            if (count1 > 0)
            {
                lbl_Error2.Visible = true;
                lbl_Error2.Text = "Ensure that all visible subject boxes are filled";
            }

            if (count == 0 && count1 == 0)
            {
                PanelEntry.Visible = false;
                PanelSchedule.Visible = true;

                lbl_TotalHours.Text = "You have to study a total of " + sumHours + " hours a week";

                //Assign Checkbox
                CheckBox1.Text = TB_Subject1.Text;
                CheckBox2.Text = TB_Subject2.Text;
                CheckBox3.Text = TB_Subject3.Text;
                CheckBox4.Text = TB_Subject4.Text;
                CheckBox5.Text = TB_Subject5.Text;
                CheckBox6.Text = TB_Subject6.Text;
                CheckBox7.Text = TB_Subject7.Text;
                CheckBox8.Text = TB_Subject8.Text;
                CheckBox9.Text = TB_Subject9.Text;
                CheckBox10.Text = TB_Subject10.Text;

                if (countVisible == 4)
                {
                    CheckBox1.Visible = true;
                    CheckBox2.Visible = true;
                    CheckBox3.Visible = true;
                    CheckBox4.Visible = true;
                }
                else if (countVisible == 5)
                {
                    CheckBox1.Visible = true;
                    CheckBox2.Visible = true;
                    CheckBox3.Visible = true;
                    CheckBox4.Visible = true;
                    CheckBox5.Visible = true;
                }
                else if (countVisible == 6)
                {
                    CheckBox1.Visible = true;
                    CheckBox2.Visible = true;
                    CheckBox3.Visible = true;
                    CheckBox4.Visible = true;
                    CheckBox5.Visible = true;
                    CheckBox6.Visible = true;
                }
                else if (countVisible == 7)
                {
                    CheckBox1.Visible = true;
                    CheckBox2.Visible = true;
                    CheckBox3.Visible = true;
                    CheckBox4.Visible = true;
                    CheckBox5.Visible = true;
                    CheckBox6.Visible = true;
                    CheckBox7.Visible = true;
                }
                else if (countVisible == 8)
                {
                    CheckBox1.Visible = true;
                    CheckBox2.Visible = true;
                    CheckBox3.Visible = true;
                    CheckBox4.Visible = true;
                    CheckBox5.Visible = true;
                    CheckBox6.Visible = true;
                    CheckBox7.Visible = true;
                    CheckBox8.Visible = true;
                }
                else if (countVisible == 9)
                {
                    CheckBox1.Visible = true;
                    CheckBox2.Visible = true;
                    CheckBox3.Visible = true;
                    CheckBox4.Visible = true;
                    CheckBox5.Visible = true;
                    CheckBox6.Visible = true;
                    CheckBox7.Visible = true;
                    CheckBox8.Visible = true;
                    CheckBox9.Visible = true;
                }
                else
                {
                    CheckBox1.Visible = true;
                    CheckBox2.Visible = true;
                    CheckBox3.Visible = true;
                    CheckBox4.Visible = true;
                    CheckBox5.Visible = true;
                    CheckBox6.Visible = true;
                    CheckBox7.Visible = true;
                    CheckBox8.Visible = true;
                    CheckBox9.Visible = true;
                    CheckBox10.Visible = true;
                }

            }


        }

        public string calculateStudyHours(string grade)
        {
            string studyPeriod;
            if(grade == "A")
            {
                studyPeriod = "1.0 hour";
            }
            else if(grade == "B+")
            {
                studyPeriod = "1.5 hours";
            }
            else if (grade == "B")
            {
                studyPeriod = "2.0 hours";
            }
            else if (grade == "C+")
            {
                studyPeriod = "2.5 hours";
            }
            else if (grade == "C")
            {
                studyPeriod = "3.0 hours";
            }
            else if (grade == "D+")
            {
                studyPeriod = "3.5 hours";
            }
            else if (grade == "D")
            {
                studyPeriod = "4.0 hours";
            }
            else if (grade == "E")
            {
                studyPeriod = "4.5 hours";
            }
            else
            {
                studyPeriod = "5.0 hours";
            }

            return studyPeriod;
        }

        protected void ButtonAddSubject0_Click(object sender, EventArgs e)
        {
            ButtonAddSubject0.Visible = false;
            TB_Subject5.Visible = true;
            ddl_Score5.Visible = true;
            ButtonAddSubject1.Visible = true;
            ButtonRemoveSubject1.Visible = true;
        }

        protected void ButtonAddSubject1_Click(object sender, EventArgs e)
        {
            ButtonAddSubject1.Visible = false;
            ButtonRemoveSubject1.Visible = false;
            TB_Subject6.Visible = true;
            ddl_Score6.Visible = true;
            ButtonAddSubject2.Visible = true;
            ButtonRemoveSubject2.Visible = true;
        }

        protected void ButtonAddSubject2_Click(object sender, EventArgs e)
        {
            ButtonAddSubject2.Visible = false;
            ButtonRemoveSubject2.Visible = false;
            TB_Subject7.Visible = true;
            ddl_Score7.Visible = true;
            ButtonAddSubject3.Visible = true;
            ButtonRemoveSubject3.Visible = true;
        }

        protected void ButtonAddSubject3_Click(object sender, EventArgs e)
        {
            ButtonAddSubject3.Visible = false;
            ButtonRemoveSubject3.Visible = false;
            TB_Subject8.Visible = true;
            ddl_Score8.Visible = true;
            ButtonAddSubject4.Visible = true;
            ButtonRemoveSubject4.Visible = true;
        }

        protected void ButtonAddSubject4_Click(object sender, EventArgs e)
        {
            ButtonAddSubject4.Visible = false;
            ButtonRemoveSubject4.Visible = false;
            TB_Subject9.Visible = true;
            ddl_Score9.Visible = true;
            ButtonAddSubject5.Visible = true;
            ButtonRemoveSubject5.Visible = true;
        }

        protected void ButtonAddSubject5_Click(object sender, EventArgs e)
        {
            ButtonAddSubject5.Visible = false;
            ButtonRemoveSubject5.Visible = false;
            TB_Subject10.Visible = true;
            ddl_Score10.Visible = true;
            ButtonRemoveSubject6.Visible = true;
        }

        protected void ButtonRemoveSubject6_Click(object sender, EventArgs e)
        {
            ButtonAddSubject5.Visible = true;
            ButtonRemoveSubject5.Visible = true;
            TB_Subject10.Visible = false;
            ddl_Score10.Visible = false;
            ButtonRemoveSubject6.Visible = false;
        }

        protected void ButtonRemoveSubject5_Click(object sender, EventArgs e)
        {
            ButtonAddSubject4.Visible = true;
            ButtonRemoveSubject4.Visible = true;
            TB_Subject9.Visible = false;
            ddl_Score9.Visible = false;
            ButtonAddSubject5.Visible = false;
            ButtonRemoveSubject5.Visible = false;
        }

        protected void ButtonRemoveSubject4_Click(object sender, EventArgs e)
        {
            ButtonAddSubject3.Visible = true;
            ButtonRemoveSubject3.Visible = true;
            TB_Subject8.Visible = false;
            ddl_Score8.Visible = false;
            ButtonAddSubject4.Visible = false;
            ButtonRemoveSubject4.Visible = false;
        }

        protected void ButtonRemoveSubject3_Click(object sender, EventArgs e)
        {
            ButtonAddSubject2.Visible = true;
            ButtonRemoveSubject2.Visible = true;
            TB_Subject7.Visible = false;
            ddl_Score7.Visible = false;
            ButtonAddSubject3.Visible = false;
            ButtonRemoveSubject3.Visible = false;
        }

        protected void ButtonRemoveSubject2_Click(object sender, EventArgs e)
        {
            ButtonAddSubject1.Visible = true;
            ButtonRemoveSubject1.Visible = true;
            TB_Subject6.Visible = false;
            ddl_Score6.Visible = false;
            ButtonAddSubject2.Visible = false;
            ButtonRemoveSubject2.Visible = false;
        }

        protected void ButtonRemoveSubject1_Click(object sender, EventArgs e)
        {
            ButtonAddSubject0.Visible = true;
            TB_Subject5.Visible = false;
            ddl_Score5.Visible = false;
            ButtonAddSubject1.Visible = false;
            ButtonRemoveSubject1.Visible = false;
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            ButtonAddSubject0.Visible = true;

            TB_Subject5.Text = "";
            ddl_Score5.SelectedValue = "-1";
            TB_Subject5.Visible = false;
            ddl_Score5.Visible = false;
            ButtonAddSubject1.Visible = false;
            ButtonRemoveSubject1.Visible = false;

            TB_Subject6.Text = "";
            ddl_Score6.SelectedValue = "-1";
            TB_Subject6.Visible = false;
            ddl_Score6.Visible = false;
            ButtonAddSubject2.Visible = false;
            ButtonRemoveSubject2.Visible = false;

            TB_Subject7.Text = "";
            ddl_Score7.SelectedValue = "-1";
            TB_Subject7.Visible = false;
            ddl_Score7.Visible = false;
            ButtonAddSubject3.Visible = false;
            ButtonRemoveSubject3.Visible = false;

            TB_Subject8.Text = "";
            ddl_Score8.SelectedValue = "-1";
            TB_Subject8.Visible = false;
            ddl_Score8.Visible = false;
            ButtonAddSubject4.Visible = false;
            ButtonRemoveSubject4.Visible = false;

            TB_Subject9.Text = "";
            ddl_Score9.SelectedValue = "-1";
            TB_Subject9.Visible = false;
            ddl_Score9.Visible = false;
            ButtonAddSubject5.Visible = false;
            ButtonRemoveSubject5.Visible = false;

            TB_Subject10.Text = "";
            ddl_Score10.SelectedValue = "-1";
            TB_Subject10.Visible = false;
            ddl_Score10.Visible = false;
            ButtonAddSubject5.Visible = false;
            ButtonRemoveSubject5.Visible = false;

            ButtonRemoveSubject6.Visible = false;
        }

        protected void redoEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudyGuide.aspx");
        }

        protected void btn_weekDone_Click(object sender, EventArgs e)
        {
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
            CheckBox6.Checked = false;
            CheckBox7.Checked = false;
            CheckBox8.Checked = false;
            CheckBox9.Checked = false;
            CheckBox10.Checked = false;
        }

        protected void GridViewGuides_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GridViewGuides.SelectedIndex == 0)
            {
                Response.Redirect("https://www.helpguide.org/articles/stress/stress-management.htm");
            }
            else if(GridViewGuides.SelectedIndex == 1)
            {
                Response.Redirect("https://www.mindtools.com/pages/main/newMN_HTE.htm");
            }
            else if(GridViewGuides.SelectedIndex == 2)
            {
                Response.Redirect("https://www.topuniversities.com/student-info/health-and-support/exam-preparation-ten-study-tips");
            }
            
        }
    }
}