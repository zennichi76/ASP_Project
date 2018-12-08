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
    public class ConsentFormDAO
    {
        public void createConsentForm(String senderID, String RecievingClasses, String School, String Title, String Description, String FoodPreferrence)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Insert into ConsentForms (SenderID, RecievingClasses, School, Title, Description, FoodPreferrence, Status)");
            sqlCommand.AppendLine("Values (@paraSenderID, @paraRecievingClasses, @paraSchool, @paraTitle, @paraDescription, @paraFoodPreferrence, 'Open')");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraSenderID", senderID);
            cmd.Parameters.AddWithValue("@paraRecievingClasses", RecievingClasses);
            cmd.Parameters.AddWithValue("@paraSchool", School);
            cmd.Parameters.AddWithValue("@paraTitle", Title);
            cmd.Parameters.AddWithValue("@paraDescription", Description);
            cmd.Parameters.AddWithValue("@paraFoodPreferrence", FoodPreferrence);

            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();

        }
        public void createConsentFormDraft(String senderID, String RecievingClasses, String School, String Title, String Description, String FoodPreferrence)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Insert into ConsentFormsDrafts (SenderID, RecievingClasses, School, Title, Description, FoodPreferrence, Status)");
            sqlCommand.AppendLine("Values (@paraSenderID, @paraRecievingClasses, @paraSchool, @paraTitle, @paraDescription, @paraFoodPreferrence, 'Open')");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraSenderID", senderID);
            cmd.Parameters.AddWithValue("@paraRecievingClasses", RecievingClasses);
            cmd.Parameters.AddWithValue("@paraSchool", School);
            cmd.Parameters.AddWithValue("@paraTitle", Title);
            cmd.Parameters.AddWithValue("@paraDescription", Description);
            cmd.Parameters.AddWithValue("@paraFoodPreferrence", FoodPreferrence);

            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();

        }
        public void removeDraft(String draftID)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("DELETE ConsentFormsDrafts");
            sqlCommand.AppendLine("WHERE ConsentFormID = @paraDraftID");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraDraftID", draftID);

            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();
        }
        public List<ConsentForm> getConsentFormsBySenderID(String senderID)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from [ConsentForms] where");
            sqlCommand.AppendLine("SenderID = @paraUserId");
          
            List<ConsentForm> objList = new List<ConsentForm>();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraUserId", senderID);

            da.Fill(ds, "formsTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["formsTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                objList = null;
            }
            else if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables["formsTable"].Rows[i];
                    ConsentForm obj = new ConsentForm();
                    obj.ConsentFormID = int.Parse(row["ConsentFormID"].ToString());
                    obj.SenderID = row["SenderID"].ToString();
                    obj.RecievingClasses = row["RecievingClasses"].ToString();
                    obj.School = row["School"].ToString();
                    obj.FormStatus = row["Status"].ToString();
                    obj.Title = row["Title"].ToString();
                    obj.Description = row["Description"].ToString();
                    obj.FoodPreferrence = row["FoodPreferrence"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;

        }
        public List<ConsentForm> getDraftConsentFormsBySenderID(String senderID)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from [ConsentFormsDrafts] where");
            sqlCommand.AppendLine("SenderID = @paraUserId");

            List<ConsentForm> objList = new List<ConsentForm>();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraUserId", senderID);

            da.Fill(ds, "formsTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["formsTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                objList = null;
            }
            else if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables["formsTable"].Rows[i];
                    ConsentForm obj = new ConsentForm();
                    obj.ConsentFormID = int.Parse(row["ConsentFormID"].ToString());
                    obj.SenderID = row["SenderID"].ToString();
                    obj.RecievingClasses = row["RecievingClasses"].ToString();
                    obj.School = row["School"].ToString();
                    obj.FormStatus = row["Status"].ToString();
                    obj.Title = row["Title"].ToString();
                    obj.Description = row["Description"].ToString();
                    obj.FoodPreferrence = row["FoodPreferrence"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;

        }
        public ConsentForm getConsentFormByFormID(String FormID)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from [ConsentForms] where");
            sqlCommand.AppendLine("ConsentFormID = @paraConsentFormID");

            ConsentForm obj = new ConsentForm();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraConsentFormID", FormID);

            da.Fill(ds, "formsTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["formsTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                obj = null;
            }
            else if (rec_cnt > 0)
            {
                    DataRow row = ds.Tables["formsTable"].Rows[0];
                    obj.ConsentFormID = int.Parse(row["ConsentFormID"].ToString());
                    obj.SenderID = row["SenderID"].ToString();
                    obj.RecievingClasses = row["RecievingClasses"].ToString();
                    obj.School = row["School"].ToString();
                    obj.FormStatus = row["Status"].ToString();
                    obj.Title = row["Title"].ToString();
                    obj.Description = row["Description"].ToString();
                    obj.FoodPreferrence = row["FoodPreferrence"].ToString();
            }
            return obj;

        }
        public ConsentForm getDraftConsentFormByFormID(String FormID)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from [ConsentFormsDrafts] where");
            sqlCommand.AppendLine("ConsentFormID = @paraConsentFormID");

            ConsentForm obj = new ConsentForm();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraConsentFormID", FormID);

            da.Fill(ds, "formsTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["formsTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                obj = null;
            }
            else if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["formsTable"].Rows[0];
                obj.ConsentFormID = int.Parse(row["ConsentFormID"].ToString());
                obj.SenderID = row["SenderID"].ToString();
                obj.RecievingClasses = row["RecievingClasses"].ToString();
                obj.School = row["School"].ToString();
                obj.FormStatus = row["Status"].ToString();
                obj.Title = row["Title"].ToString();
                obj.Description = row["Description"].ToString();
                obj.FoodPreferrence = row["FoodPreferrence"].ToString();
            }
            return obj;

        }
        public void updateDraftConsentFormByFormID(String FormID, String ReceivingClasses, String Title, String Description, String FoodPreferrence)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Update ConsentFormsDrafts set Title=@paraTitle, RecievingClasses=@paraClasses, Description=@paraDescription, FoodPreferrence=@paraFoodPreferrence");
            sqlCommand.AppendLine("Where ConsentFormID=@paraFormID");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraTitle", Title);
            cmd.Parameters.AddWithValue("@paraClasses", ReceivingClasses);
            cmd.Parameters.AddWithValue("@paraDescription", Description);
            cmd.Parameters.AddWithValue("@paraFoodPreferrence", FoodPreferrence);
            cmd.Parameters.AddWithValue("@paraFormID", FormID);
            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();
        }

        public List<ConsentForm> selectUnsignedFormsByUser(String UserID, String School, String Class)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from ConsentForms where RecievingClasses Like @paraClass and School=@paraSchool and ConsentFormID NOT IN (Select FormID from FormEntries where SignerID =@paraUserID)");

            List<ConsentForm> objList = new List<ConsentForm>();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraUserId", UserID);
            da.SelectCommand.Parameters.AddWithValue("paraClass", "%"+Class+"%");
            da.SelectCommand.Parameters.AddWithValue("paraSchool", School);

            da.Fill(ds, "formsTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["formsTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                objList = null;
            }
            else if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables["formsTable"].Rows[i];
                    ConsentForm obj = new ConsentForm();
                    obj.ConsentFormID = int.Parse(row["ConsentFormID"].ToString());
                    obj.SenderID = row["SenderID"].ToString();
                    obj.RecievingClasses = row["RecievingClasses"].ToString();
                    obj.School = row["School"].ToString();
                    obj.FormStatus = row["Status"].ToString();
                    obj.Title = row["Title"].ToString();
                    obj.Description = row["Description"].ToString();
                    obj.FoodPreferrence = row["FoodPreferrence"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public void createFormEntry(String senderID, String FormID, String FoodPreferrence)
        {
            int result;
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Insert into FormEntries (FormID, SignerID, FoodPref)");
            sqlCommand.AppendLine("Values (@paraFormID, @paraSignerID, @paraFoodPref)");

            SqlConnection myConn = new SqlConnection(DBConnect); //conn in java, make connection
            SqlCommand cmd = new SqlCommand(sqlCommand.ToString()); //attach command to connection
            cmd.Connection = myConn;
            cmd.Parameters.AddWithValue("@paraSignerID", senderID);
            cmd.Parameters.AddWithValue("@paraFormID", FormID);
            cmd.Parameters.AddWithValue("@paraFoodPref", FoodPreferrence);

            myConn.Open();
            result = cmd.ExecuteNonQuery();
            myConn.Close();

        }

        public List<FormStatus> retrieveClassList(String FormID, String Education_Class, String Education_School)
        {

            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select [User].User_ID, Name, FoodPref, FormEntries.FormID from [User] left join FormEntries on FormEntries.SignerID=[User].User_ID and (FormID=@paraFormId or FormID is null) where [User].Role='Student' and [User].School=@paraSchool and [User].Education_Class=@paraClass");

            List<FormStatus> objList = new List<FormStatus>();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraSchool", Education_School);
            da.SelectCommand.Parameters.AddWithValue("paraClass", Education_Class);
            da.SelectCommand.Parameters.AddWithValue("paraFormId", FormID);

            da.Fill(ds, "formsTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["formsTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                objList = null;
            }
            else if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables["formsTable"].Rows[i];
                    FormStatus obj = new FormStatus();
                    obj.UserID = row["User_ID"].ToString();
                    obj.Name = row["Name"].ToString();
                    obj.FoodPreferrence = row["FoodPref"].ToString();
                    if(row["FormID"].ToString() == "")
                    {
                        obj.Status = "";
                    }
                    else
                    {
                        obj.Status = "Signed";
                    }
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public List<String> getSentClassesByFormID(String FormID)
        {
            //get conn string
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //make adapter
            SqlDataAdapter da;
            //make dataset to store results (ResultSet equivalent in Java) 
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select RecievingClasses from [ConsentForms] where");
            sqlCommand.AppendLine("ConsentFormID = @paraFormID");

            String obj = null;

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraFormID", FormID);

            da.Fill(ds, "FormTable"); //Executes command and fills data set with the results
            int rec_cnt = ds.Tables["FormTable"].Rows.Count; //recordcount
            if (rec_cnt == 0) //no record has been found
            {
                //return a null object 
                obj = null;
            }
            else if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["FormTable"].Rows[0]; //First record
                obj = row["RecievingClasses"].ToString();

            }

            List<String> TeachingClasses = obj.Split(',').ToList<String>();
            return TeachingClasses;

        }
    }
}