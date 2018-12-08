using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EADP_Project.DAO
{
    public class DietTrackingDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public void addSelectedFood(int foodID, string foodname, int calories, int protein, int fat, int carbohydrate)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                int result;
                sqlCon.Open();
                string query = "INSERT INTO DietTracker (Food, Calories, Protein, Fat, Carbohydrate) VALUES (@Food,@Calories,@Protein,@Fat,@Carbohydrate)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Food", foodname);
                sqlCmd.Parameters.AddWithValue("@Calories", calories);
                sqlCmd.Parameters.AddWithValue("@Protein", protein);
                sqlCmd.Parameters.AddWithValue("@Fat", fat);
                sqlCmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
                result = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void addFood(string food, string calories, string protein, string fat, string carbohydrates)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Food (Food,Calories, Protein, Fat, Carbohydrate) VALUES (@Food,@Calories,@Protein,@Fat,@Carbohydrate)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Food", food);
                sqlCmd.Parameters.AddWithValue("@Calories", calories);
                sqlCmd.Parameters.AddWithValue("@Protein", protein);
                sqlCmd.Parameters.AddWithValue("@Fat", fat);
                sqlCmd.Parameters.AddWithValue("@Carbohydrate", carbohydrates);
                sqlCmd.ExecuteNonQuery();
            }

        }
        public void updateFood(string food, string calories, string protein, string fat, string carbohydrate, int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Food SET Food=@Food,Calories=@Calories,Protein=@Protein,Fat=@Fat,Carbohydrate=@Carbohydrate WHERE foodID = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Food", food);
                sqlCmd.Parameters.AddWithValue("@Calories", calories);
                sqlCmd.Parameters.AddWithValue("@Protein", protein);
                sqlCmd.Parameters.AddWithValue("@Fat", fat);
                sqlCmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.ExecuteNonQuery();
            }
        }
        public void deleteFoodFromFoodDB(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Food WHERE foodID = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.ExecuteNonQuery();

            }
        }
        public void deleteSelectedFood(int foodID, string foodname, int calories, int protein, int fat, int carbohydrate)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                int result;
                sqlCon.Open();
                string query = "DELETE FROM DietTracker WHERE foodID = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(foodID.ToString()));
                result = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
        }
        public DataTable getFoodData(string selectedFood)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Food WHERE Food LIKE '%' + @Food + '%'";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Food", selectedFood.Trim());
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public DataTable getDietTracker(string User_ID)
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From DietTracker where User_ID=@paraUserID", sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@paraUserID", User_ID);
                sqlDa.Fill(dtbl);
                return dtbl;
            }
        }
        public void deleteDietTracker(string User_ID, int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM DietTracker WHERE foodID = @paraid and User_ID = @paraUserID;";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@paraid", id);
                sqlCmd.Parameters.AddWithValue("@paraUserID", User_ID);
                sqlCmd.ExecuteNonQuery();

            }
        }
        public void addDietTrackerItem(string User_ID, string Food, int Calories, int Protein, int Fat, int Carbohydrate)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO DietTracker (Food, Calories, Protein, Fat, Carbohydrate, User_ID) VALUES (@Food,@Calories,@Protein,@Fat,@Carbohydrate, @paraUserID)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Food", Food);
                sqlCmd.Parameters.AddWithValue("@Calories", Calories);
                sqlCmd.Parameters.AddWithValue("@Protein", Protein);
                sqlCmd.Parameters.AddWithValue("@Fat", Fat);
                sqlCmd.Parameters.AddWithValue("@Carbohydrate", Carbohydrate);
                sqlCmd.Parameters.AddWithValue("@paraUserID", User_ID);
                sqlCmd.ExecuteNonQuery();

            }
        }
    }
}