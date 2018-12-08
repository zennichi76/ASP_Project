using EADP_Project.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EADP_Project.BO
{
    public class DietTrackingBO
    {
        public void addSelectedFood(int foodID, string foodname, int calories, int protein, int fat, int carbohydrate)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            diettrackingdao.addSelectedFood(foodID, foodname, calories, protein, fat, carbohydrate);
        }

        public void deleteSelectedFood(int foodID, string foodname, int calories, int protein, int fat, int carbohydrate)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            diettrackingdao.deleteSelectedFood(foodID, foodname, calories, protein, fat, carbohydrate);
        }
        public DataTable getFoodData(string selectedFood)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            return diettrackingdao.getFoodData(selectedFood);
        }
        public DataTable getDietTracker(string User_ID)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            return diettrackingdao.getDietTracker(User_ID);
        }
        public void deleteDietTracker(string User_ID, int id)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            diettrackingdao.deleteDietTracker(User_ID, id);

        }
        public void addDietTrackerItem(string User_ID, string Food, int Calories, int Protein, int Fat, int Carbohydrate)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            diettrackingdao.addDietTrackerItem(User_ID, Food, Calories, Protein, Fat, Carbohydrate);
        }
        public void addFood(string food, string calories, string protein, string fat, string carbohydrates)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            diettrackingdao.addFood(food, calories, protein, fat, carbohydrates);

        }
        public void deleteFoodFromFoodDB(int id)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            diettrackingdao.deleteFoodFromFoodDB(id);
        }
        public void updateFood(string food, string calories, string protein, string fat, string carbohydrate, int id)
        {
            DietTrackingDAO diettrackingdao = new DietTrackingDAO();
            diettrackingdao.updateFood(food, calories, protein, fat, carbohydrate, id);
        }
    }
}