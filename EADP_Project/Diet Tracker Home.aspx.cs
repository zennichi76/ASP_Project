using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using EADP_Project.BO;
using System.IO;
using System.Drawing;
using System.Configuration;
using System.Web.Configuration;

namespace WebApplication3
{
    public partial class Diet_Tracker_Home : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;

                ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
                  /*Session Fixation*/
                    // check if the 2 sessions n cookie is not null
                    if (Session["LoginUserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null && Request.Cookies["CurrentLoggedInUser"] != null)
                    {
                        if ((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))  /*End of Session Fixation*/
                        {
                            //pass
                            PopulateGVFood();
                            PopulateGVDietTracker();
                        }//end of second check
                        else
                        {


                        }

                    }//end of first check
                    else
                    {
                        //unauthorised user access
                        Response.Redirect("LoginPage.aspx");
                    }
            }
            catch
            {

            }
       }

        protected void gvFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //session fixation for timeout
        protected void RemoveSessionBtn_OnClick(object Source, EventArgs e)
        {
            try
            {
                //  clear session
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["AuthToken"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["AuthToken"].Value = string.Empty;
                    Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["CurrentLoggedInUser"].Value = string.Empty;
                    Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddMonths(-20);
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem(browid);", true);
                Response.Redirect("LoginPage.aspx");
            }
            catch
            {

            }


        }

        //session reset
        protected void ResetSessionBtn_OnClick(object Source, EventArgs e)
        {
            try
            {
                HttpContext.Current.Session["Reset"] = true;
                //Session["Reset"] = true;
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);

            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openFModal();", true);

            }

        }



        // RETRIEVE
        void PopulateGVFood()
        {
            string selectedFood = tbSearch.Text.Trim();
            DietTrackingBO diettrackingbo = new DietTrackingBO();
            DataTable dt = new DataTable();
            dt = diettrackingbo.getFoodData(selectedFood);
            gvFood.DataSource = dt;
            gvFood.DataBind();
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.CommandText = "SELECT * FROM Food WHERE Food LIKE '%' + @Food + '%'";
            //        cmd.Connection = con;
            //        cmd.Parameters.AddWithValue("@Food", tbSearch.Text.Trim());
            //        DataTable dt = new DataTable();
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {
            //            sda.Fill(dt);
            //            gvFood.DataSource = dt;
            //            gvFood.DataBind();
            //        }
            //    }
            //}
        }

        protected void gvFood_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFood.PageIndex = e.NewPageIndex;
            PopulateGVFood();
            PopulateGVDietTracker();
        }

        protected void btnRedirectFood_Click(object sender, EventArgs e)
        {
            Response.Redirect("Food.aspx");

        }

        protected void gvFood_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string userID = Request.Cookies["CurrentLoggedInUser"].Value; //mock current user
            DietTrackingBO diettrackingbo = new DietTrackingBO();

            //try
            //{
            if (e.CommandName.Equals("Select"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvFood.Rows[index];
                String foodname;
                int calories, protein, fat, carbohydrate;
                foodname = row.Cells[0].Text;
                calories = Convert.ToInt32(row.Cells[1].Text);
                protein = Convert.ToInt32(row.Cells[2].Text);
                fat = Convert.ToInt32(row.Cells[3].Text);
                carbohydrate = Convert.ToInt32(row.Cells[4].Text);
                diettrackingbo.addDietTrackerItem(userID, foodname, calories, protein, fat, carbohydrate);
                PopulateGVDietTracker();

                //        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                //        {
                //            sqlCon.Open();
                //            string query = "INSERT INTO DietTracker (Food, Calories, Protein, Fat, Carbohydrate) VALUES (@Food,@Calories,@Protein,@Fat,@Carbohydrate)";
                //            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //            sqlCmd.Parameters.AddWithValue("@Food", foodname);
                //            sqlCmd.Parameters.AddWithValue("@Calories", calories);
                //            sqlCmd.Parameters.AddWithValue("@Protein", protein);
                //            sqlCmd.Parameters.AddWithValue("@Fat", fat);
                //            sqlCmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
                //            sqlCmd.ExecuteNonQuery();
                //            PopulateGVDietTracker();




                //}
            }
            //catch (Exception ex)
            //{
            //    LblSuccessMessage.Text = "";
            //    LblErrorMessage.Text = ex.Message;
            //}

        }

        void PopulateGVDietTracker()
        {
            string userID = Request.Cookies["CurrentLoggedInUser"].Value;  //mock current user
            DataTable dtbl = new DataTable();
            DietTrackingBO diettrackerbo = new DietTrackingBO();
            dtbl = diettrackerbo.getDietTracker(userID);
            //using (SqlConnection sqlCon = new SqlConnection(connectionString))
            //{
            //    sqlCon.Open();
            //    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From DietTracker where User_ID=@paraUserID", sqlCon);
            //    sqlDa.SelectCommand.Parameters.AddWithValue("@paraUserID", userID);
            //    sqlDa.Fill(dtbl);
            //}
            if (dtbl.Rows.Count > 0)
            {
                excelSheetBtn.Visible = true;
                calculateDiv.Visible = true;
                gvDietTracker.DataSource = dtbl;
                gvDietTracker.DataBind();
                gvDietTracker.FooterRow.Visible = true;
                gvDietTracker.FooterRow.Cells[0].Text = "TOTAL";

                gvDietTracker.FooterRow.Cells[1].Text = dtbl.Compute("Sum(Calories)", "").ToString();
                gvDietTracker.FooterRow.Cells[2].Text = dtbl.Compute("Sum(Protein)", "").ToString();
                gvDietTracker.FooterRow.Cells[3].Text = dtbl.Compute("Sum(Fat)", "").ToString();
                gvDietTracker.FooterRow.Cells[4].Text = dtbl.Compute("Sum(Carbohydrate)", "").ToString();

            }

            else
            {
                excelSheetBtn.Visible = false;
                calculateDiv.Visible = false;
                dtbl.Rows.Add(dtbl.NewRow());
                gvDietTracker.DataSource = dtbl;
                gvDietTracker.DataBind();
                gvDietTracker.FooterRow.Visible = false;
                gvDietTracker.Rows[0].Cells.Clear();
                gvDietTracker.Rows[0].Cells.Add(new TableCell());
                gvDietTracker.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvDietTracker.Rows[0].Cells[0].Text = "No Food :(";
                gvDietTracker.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateGVFood();
        }



        protected void gvDietTracker_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userID = Request.Cookies["CurrentLoggedInUser"].Value; //mock current user
            int id = Convert.ToInt32(gvDietTracker.DataKeys[e.RowIndex].Value.ToString());
            DietTrackingBO diettrackingbo = new DietTrackingBO();
            diettrackingbo.deleteDietTracker(userID, id);
            PopulateGVDietTracker();
            //using (SqlConnection sqlCon = new SqlConnection(connectionString))
            //{
            //    sqlCon.Open();
            //    string query = "DELETE FROM DietTracker WHERE foodID = @id";
            //    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            //    sqlCmd.Parameters.AddWithValue("@id", id);
            //    sqlCmd.ExecuteNonQuery();
            //    PopulateGVDietTracker();

            //}
        }

        protected void excelSheetBtn_Click(object sender, EventArgs e)
        {
            gvDietTracker.Columns[5].Visible = false;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=FoodReport_"+DateTime.Now.ToString("d")+".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gvDietTracker.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvDietTracker.HeaderRow.Cells)
                {
                    cell.BackColor = gvDietTracker.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvDietTracker.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvDietTracker.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvDietTracker.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvDietTracker.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            gvDietTracker.Columns[5].Visible = true;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void calculateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int targetcalories = int.Parse(targetCaloriesTB.Text);
                int caloriesCalculated = int.Parse(gvDietTracker.FooterRow.Cells[1].Text);
                if(targetcalories > caloriesCalculated)
                {
                    //lose weight
                    WeightStatusLB.Text = "You will lose weight.";
                }
                else if (targetcalories < caloriesCalculated)
                {
                    //gain weight
                    WeightStatusLB.Text = "You will gain weight.";
                }
                else if (targetcalories == caloriesCalculated)
                {
                    //maintain weight
                    WeightStatusLB.Text = "You will maintain weight.";
                }
            }
            catch (Exception ex)
            {
                WeightStatusLB.Text = "Please enter a valid calories value.";
            }
        }
    }
}