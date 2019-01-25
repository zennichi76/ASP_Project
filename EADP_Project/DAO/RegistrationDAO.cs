using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using EADP_Project.Entities;

namespace EADP_Project.DAO
{
    public class RegistrationDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();

        ////for Actual Registration of users
        //public int UserRegistration(String User_ID, String password, String name, String email, String confirmEmail, String role, String school_ID, String education_level, String education_class)
        //{
        //    DataSet ds = new DataSet();
        //    StringBuilder sqlStr = new StringBuilder();
        //    SqlCommand objCmd = new SqlCommand();
        //    int result;

        //    sqlStr.AppendLine("INSERT INTO User (User_ID, Password, Name, Email, ConfirmEmail, Role, School, Education_Level;, Eduaction_Class)");
        //    sqlStr.AppendLine("VALUES (@paraUser_ID, @paraPassword, @paraName, @paraEmail,@paraConfirmEmail, @paraRole, @paraSchool, @paraEducation_Level,@paraEducation_Class)");

        //    SqlConnection objsqlconn = new SqlConnection(DBConnect);
        //    objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);


        //    //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);

        //    objCmd.Parameters.AddWithValue("@paraUser_ID", User_ID);
        //    objCmd.Parameters.AddWithValue("@paraPassword", password);
        //    objCmd.Parameters.AddWithValue("@paraName", name);
        //    objCmd.Parameters.AddWithValue("@paraEmail", email);
        //    objCmd.Parameters.AddWithValue("@paraConfirmEmail", confirmEmail);
        //    objCmd.Parameters.AddWithValue("@paraRole", role);
        //    objCmd.Parameters.AddWithValue("@paraSchool", school_ID);
        //    objCmd.Parameters.AddWithValue("@parastatus", education_level);
        //    objCmd.Parameters.AddWithValue("@paratutorId", education_class);

        //    objsqlconn.Open();
        //    result = objCmd.ExecuteNonQuery();
        //    objsqlconn.Close();

        //    return result;

        //}

        //test for Registration of users

        public int UserRegistration(string User_ID, string password, string salt, string name, string email, string confirmEmail, string role)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;

            sqlStr.AppendLine("Insert into [User] (User_ID,Password,Salt,Name,Email,ConfirmEmail,Role, Pwd_startDate, Pwd_endDate, Pwd_changeBool)");
            sqlStr.AppendLine("VALUES (@paraUser_Id, @parapassword, @paraSalt, @paraname, @paraemail, @paraconfirmEmail, @pararole, @parapwdStartDate, @parapwdEndDate, @parapwdChangeBool)");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);

            objCmd.Parameters.AddWithValue("@paraUser_Id", User_ID);
            objCmd.Parameters.AddWithValue("@parapassword", password);
            objCmd.Parameters.AddWithValue("@paraSalt", salt);
            objCmd.Parameters.AddWithValue("@paraname", name);
            objCmd.Parameters.AddWithValue("@paraemail", email);
            objCmd.Parameters.AddWithValue("@paraconfirmEmail", confirmEmail);
            objCmd.Parameters.AddWithValue("@pararole", role);
            objCmd.Parameters.AddWithValue("@parapwdStartDate", DateTime.Now);
            objCmd.Parameters.AddWithValue("@parapwdEndDate", DateTime.Now.AddDays(90.0));
            objCmd.Parameters.AddWithValue("@paraPwdChangeBool", false);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        //for inserting security questions
        public int insertSecurityQuestions(String User_ID, Byte[] firstSecurityQ, String firstSecurityQA, Byte[] secondSecurityQ, String secondSecurityQA, Byte[] thirdSecurityQ, String thirdSecurityQA)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;

            sqlStr.AppendLine("Insert into SecurityQuestions (User_ID,FirstSecurityQuestion,FirstSecurityQuestionAns,SecondSecurityQuestion,SecondSecurityQuestionAns,ThirdSecurityQuestion,ThirdSecurityQuestionAns)");
            sqlStr.AppendLine("VALUES (@paraUser_Id, @paraFirstSecurityQuestion, @paraFirstSecurityQuestionAns, @paraSecondSecurityQuestion, @paraSecondSecurityQuestionAns, @paraThirdSecurityQuestion, @paraThirdSecurityQuestionAns)");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);

            objCmd.Parameters.AddWithValue("@paraUser_Id", User_ID);
            objCmd.Parameters.AddWithValue("@paraFirstSecurityQuestion", firstSecurityQ);
            objCmd.Parameters.AddWithValue("@paraFirstSecurityQuestionAns", firstSecurityQA);
            objCmd.Parameters.AddWithValue("@paraSecondSecurityQuestion", secondSecurityQ);
            objCmd.Parameters.AddWithValue("@paraSecondSecurityQuestionAns", secondSecurityQA);
            objCmd.Parameters.AddWithValue("@paraThirdSecurityQuestion", thirdSecurityQ);
            objCmd.Parameters.AddWithValue("@paraThirdSecurityQuestionAns", thirdSecurityQA);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }


        //for loading the security questions for authentication
        //public List<SecurityQuestions> getSecurityQuestion(String user_Id)
        //{
        //    SqlDataAdapter da;
        //    DataSet ds = new DataSet();

        //    //declare list to hold collection of events objs
        //    List<SecurityQuestions> securityList = new List<SecurityQuestions>();

        //    //sql commant to select data from table 
        //    StringBuilder sqlCommand = new StringBuilder();
        //    sqlCommand.AppendLine("Select *");

        //    sqlCommand.AppendLine("from SecurityQuestions where User_ID = @parauser_Id ");

        //    //Instantiate sqlcommnd instance
        //    SqlConnection objsqlconn = new SqlConnection(DBConnect);

        //    //RETRIEVE RECORD USING DATAADAPTER
        //    da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
        //    da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //    da.SelectCommand.CommandType = CommandType.Text;
        //    da.SelectCommand.Parameters.AddWithValue("@parauser_Id", user_Id);
        //    //fill dataset to table
        //    da.Fill(ds, "table");

        //    //if no record, set list to null
        //    int count = ds.Tables["table"].Rows.Count;
        //    if (count == 0)
        //    {
        //        securityList = null;

        //    }
        //    else
        //    {
        //        // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
        //        //          create interestRte instance and add the instance to a List collection
        //        foreach (DataRow row in ds.Tables["table"].Rows)
        //        {
        //            SecurityQuestions objSQ = new SecurityQuestions();
        //            objSQ.User_ID = Convert.ToString(row["user_Id"]);
        //            objSQ.firstSecurityQ = (byte[])row["FirstSecurityQuestion"];
        //            objSQ.firstSecurityQA = Convert.ToString(row["FirstSecurityQA"]);
        //            objSQ.secondSecurityQ = (byte[])row["SecondSecurityQ"];
        //            // objSQ.secondSecurityQ = Convert.ToByte(row["SecondSecurityQ"]);
        //            objSQ.secondSecurityQA = Convert.ToString(row["SecondSecurityQA"]);
        //            //objSQ.thirdSecurityQ = Convert.ToByte(row["thirdSecurityQ"]);
        //            objSQ.thirdSecurityQ = (byte[])row["thirdSecurityQA"];
        //            objSQ.thirdSecurityQA = Convert.ToString(row["thirdSecurityQA"]);

        //          //  securityList.Add(objSQ);

        //        }

        //    }

        //    return securityList;

        //}
        public SecurityQuestions getSecurityQuestion(String user_Id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            SecurityQuestions securityList = new SecurityQuestions();

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select *");

            sqlCommand.AppendLine("from SecurityQuestions where User_ID = @parauser_Id ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@parauser_Id", user_Id);
            //fill dataset to table
            da.Fill(ds, "SQTable");

            //if no record, set list to null
            int count = ds.Tables["SQTable"].Rows.Count;
            if (count == 0)
            {
                securityList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["SQTable"].Rows)
                {
                    //SecurityQuestions objSQ = new SecurityQuestions();
                    securityList.User_ID = Convert.ToString(row["user_Id"]);
                    securityList.firstSecurityQ = (byte[])row["FirstSecurityQuestion"];
                    securityList.firstSecurityQA = Convert.ToString(row["FirstSecurityQuestionAns"]);
                    securityList.secondSecurityQ = (byte[])row["SecondSecurityQuestion"];
                    // objSQ.secondSecurityQ = Convert.ToByte(row["SecondSecurityQ"]);
                    securityList.secondSecurityQA = Convert.ToString(row["SecondSecurityQuestionAns"]);
                    //objSQ.thirdSecurityQ = Convert.ToByte(row["thirdSecurityQ"]);
                    securityList.thirdSecurityQ = (byte[])row["ThirdSecurityQuestion"];
                    securityList.thirdSecurityQA = Convert.ToString(row["ThirdSecurityQuestionAns"]);

                }

            }

            return securityList;

        }

    }
}