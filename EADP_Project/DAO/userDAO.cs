using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EADP_Project.DAO
{
    public class userDAO
    {
   


        public user getUserById(string user_ID)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from [User] where");
            sqlCommand.AppendLine("User_ID = @paraUserId");

            user obj = new user();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraUserId", user_ID); 

            da.Fill(ds, "userTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["userTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                obj = null;
            } else if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["userTable"].Rows[0]; //First record
                obj.User_ID = row["User_ID"].ToString();
                obj.password = row["Password"].ToString();
                obj.salt = row["Salt"].ToString();
                obj.name = row["Name"].ToString();
                obj.email = row["Email"].ToString();
                obj.role = row["Role"].ToString();
                obj.school = row["School"].ToString();
                obj.teaching_classes = row["Teaching_Classes"].ToString();
                obj.schedule = row["Schedule"].ToString();
                obj.staff_type = row["Staff_type"].ToString();
                obj.child_ID = row["Child_ID"].ToString();
                obj.education_class = row["Education_Class"].ToString();
                obj.education_level = row["Education_Level"].ToString();
                obj.orion_point = int.Parse(row["Orion_Points"].ToString());
                obj.cca_point = int.Parse(row["CCA_Points"].ToString());
                obj.pwd_startDate = DateTime.Parse(row["Pwd_startDate"].ToString());
                obj.pwd_endDate = DateTime.Parse(row["Pwd_endDate"].ToString());
                obj.pwd_changeBool = (row["Pwd_changeBool"] as int? == 1) ? true : false;
                obj.gAuth_Enabled = (row["gAuth_Enabled"] as int? == 1) ? true : false;
                obj.gAuth_Key = "";
                if (obj.gAuth_Enabled == true)
                {
                    obj.gAuth_Key = row["gAuth_Key"].ToString();
                }



            }
            return obj;
        }
        public List<String> getTeachersTeachingClasses(String user_ID)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from [User] where");
            sqlCommand.AppendLine("User_ID = @paraUserId");

            String obj = null;

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraUserId", user_ID); 

            da.Fill(ds, "userTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["userTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                obj = null;
            } else if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["userTable"].Rows[0]; //First record
                obj = row["Teaching_Classes"].ToString();
               
            }

            List<String> TeachingClasses = obj.Split(';').ToList<String>();
            return TeachingClasses;

        }
        public void updatePwd(String user_ID, String pwd, String salt)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Update [user] set Password=@paraPassword, Salt=@paraSalt, Pwd_startDate=@parapwdStartDate, Pwd_endDate=@parapwdEndDate, Pwd_changeBool=@parapwdChangeBool");
            sqlCommand.AppendLine("Where User_ID=@paraUserID");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraUserID", user_ID);
            cmd.Parameters.AddWithValue("@paraPassword", pwd);
            cmd.Parameters.AddWithValue("@paraSalt", salt);
            cmd.Parameters.AddWithValue("@parapwdStartDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@parapwdEndDate", DateTime.Now.AddDays(30.0));
            cmd.Parameters.AddWithValue("@paraPwdChangeBool", false);
            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();
        }
        public void updateEmail(String user_ID, String email)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Update [user] set Email=@paraEmail");
            sqlCommand.AppendLine("Where User_ID=@paraUserID");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraEmail", email);
            cmd.Parameters.AddWithValue("@paraUserID", user_ID);
            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();
        }
        public void activate2FA(string user_ID, string key)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Update [user] set gAuth_Enabled=@paragAuthEnabled, gAuth_Key=@paragAuthKey");
            sqlCommand.AppendLine("Where User_ID=@paraUserID");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraUserID", user_ID);
            cmd.Parameters.AddWithValue("@paragAuthEnabled", true);
            cmd.Parameters.AddWithValue("@paragAuthKey", key);

            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void deactivate2FA(string user_ID, string key)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Update [user] set gAuth_Enabled=@paragAuthEnabled, gAuth_Key=@paragAuthKey");
            sqlCommand.AppendLine("Where User_ID=@paraUserID");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraUserID", user_ID);
            cmd.Parameters.AddWithValue("@paragAuthEnabled", false);
            cmd.Parameters.AddWithValue("@paragAuthKey", "");

            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();
        }

        public List<user> retrieveClassListBySchoolAndClass(String school, String edu_class)
        {
            List<user> classList = new List<user>();
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select User_ID, Name from [User] where Education_Class=@paraClass and School=@paraSchool");

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraSchool", school);
            da.SelectCommand.Parameters.AddWithValue("paraClass", edu_class);

            da.Fill(ds, "formsTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["formsTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                classList = null;
            }
            else if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables["formsTable"].Rows[i];
                    user obj = new user();
                    obj.User_ID = row["User_ID"].ToString();
                    obj.name= row["Name"].ToString();
                    classList.Add(obj);
                }
            }
            return classList;
        }

    }
}