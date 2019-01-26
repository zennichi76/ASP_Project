using EADP_Project.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Food : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }

        protected void gvFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        // RETRIEVE
        void PopulateGridView()
        {
            string selectedFood = tbSearch.Text.Trim();
            DietTrackingBO diettrackingbo = new DietTrackingBO();
            DataTable dt = new DataTable();
            dt = diettrackingbo.getFoodData(selectedFood);
            gvFood.DataSource = dt;
            gvFood.DataBind();
        }

        protected void gvFood_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFood.PageIndex = e.NewPageIndex;
            PopulateGridView();
        }

        protected void gvFood_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string food = (gvFood.FooterRow.FindControl("txtFoodFooter") as TextBox).Text.Trim();
                string calories = (gvFood.FooterRow.FindControl("txtCaloriesFooter") as TextBox).Text.Trim();
                string protein = (gvFood.FooterRow.FindControl("txtProteinFooter") as TextBox).Text.Trim();
                string fat = (gvFood.FooterRow.FindControl("txtFatFooter") as TextBox).Text.Trim();
                string carbohydrates = (gvFood.FooterRow.FindControl("txtCarbohydrateFooter") as TextBox).Text.Trim();
                DietTrackingBO diettrackingbo = new DietTrackingBO();
                if (e.CommandName.Equals("Add"))
                {
                    diettrackingbo.addFood(food, calories, protein, fat, carbohydrates);
                    PopulateGridView();
                    LblSuccessMessage.Text = "Thank you for adding your food recommendation!";
                    LblErrorMessage.Text = "";

                }
            }
            catch (Exception ex)
            {
                LblSuccessMessage.Text = "";
                LblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvFood_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvFood.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void gvFood_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvFood.DataKeys[e.RowIndex].Value.ToString());
            DietTrackingBO diettrackingbo = new DietTrackingBO();
            diettrackingbo.deleteFoodFromFoodDB(id);
            PopulateGridView();
            //using (SqlConnection sqlCon = new SqlConnection(connectionString))
            //{
            //    sqlCon.Open();
            //    string query = "DELETE FROM Food WHERE foodID = @id";
            //    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            //    sqlCmd.Parameters.AddWithValue("@id", id);
            //    sqlCmd.ExecuteNonQuery();       

            //}
        }

        protected void gvFood_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                DietTrackingBO diettrackingbo = new DietTrackingBO();
                string food = (gvFood.Rows[e.RowIndex].FindControl("txtFood") as TextBox).Text.Trim();
                string calories = (gvFood.Rows[e.RowIndex].FindControl("txtCalories") as TextBox).Text.Trim();
                string protein = (gvFood.Rows[e.RowIndex].FindControl("txtProtein") as TextBox).Text.Trim();
                string fat = (gvFood.Rows[e.RowIndex].FindControl("txtFat") as TextBox).Text.Trim();
                string carbohydrate = (gvFood.Rows[e.RowIndex].FindControl("txtCarbohydrate") as TextBox).Text.Trim();
                int id = Convert.ToInt32(gvFood.DataKeys[e.RowIndex].Value.ToString());
                diettrackingbo.updateFood(food, calories, protein, fat, carbohydrate, id);
                gvFood.EditIndex = -1;
                PopulateGridView();
                LblSuccessMessage.Text = "Selected Food Updated";
                LblErrorMessage.Text = "";
                //using (SqlConnection sqlCon = new SqlConnection(connectionString))
                //{
                //    sqlCon.Open();
                //    string query = "UPDATE Food SET Food=@Food,Calories=@Calories,Protein=@Protein,Fat=@Fat,Carbohydrate=@Carbohydrate WHERE foodID = @id";
                //    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //    sqlCmd.Parameters.AddWithValue("@Food", food);
                //    sqlCmd.Parameters.AddWithValue("@Calories", calories);
                //    sqlCmd.Parameters.AddWithValue("@Protein", protein);
                //    sqlCmd.Parameters.AddWithValue("@Fat", fat);
                //    sqlCmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
                //    sqlCmd.Parameters.AddWithValue("@id", id);
                //    sqlCmd.ExecuteNonQuery();
                //    gvFood.EditIndex = -1;
                //    PopulateGridView();
                //    LblSuccessMessage.Text = "Selected Food Updated";
                //    LblErrorMessage.Text = "";
                //}

            }
            catch (Exception ex)
            {
                LblSuccessMessage.Text = "";
                LblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvFood_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFood.EditIndex = -1;
            PopulateGridView();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }
    }
}