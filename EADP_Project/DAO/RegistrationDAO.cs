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
        //Registration of users

        public int UserRegistration(string User_ID, string password, string salt, string name, string email, string confirmEmail, string role, String activationCode, DateTime codeEDate)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;

            sqlStr.AppendLine("Insert into [User] (User_ID,Password,Salt,Name,Email,ConfirmEmail,Role, Pwd_startDate, Pwd_endDate, Pwd_changeBool,ActivationCode,codeEDate)");
            sqlStr.AppendLine("VALUES (@paraUser_Id, @parapassword, @paraSalt, @paraname, @paraemail, @paraconfirmEmail, @pararole, @parapwdStartDate, @parapwdEndDate, @parapwdChangeBool,@paraActivationCode, @paraedate)");

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
            objCmd.Parameters.AddWithValue("@parapwdEndDate", DateTime.Now.AddDays(30.0));
            objCmd.Parameters.AddWithValue("@paraPwdChangeBool", false);
            objCmd.Parameters.AddWithValue("@paraActivationCode", activationCode);
            objCmd.Parameters.AddWithValue("@paraedate", codeEDate);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        //check for existing username
        public bool checkIfUserExist(string User_ID, string email)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            user theUser = new user();

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select User_ID , Email from [User] ");
            sqlCommand.AppendLine("where User_ID = @paraUser_Id and Email = @paraemail");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@paraUser_Id", User_ID);
            da.SelectCommand.Parameters.AddWithValue("@paraemail", email);

            //fill dataset to table
            da.Fill(ds, "userTable");

            //if no record, set list to null
            int count = ds.Tables["userTable"].Rows.Count;
            if (count == 0)
            {
                return true; //user no exist

            }
            else
            {
                return false; // this means the user exist

            }

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

        //update security Q
        public int updateSQ(String User_ID, Byte[] firstSecurityQ, String firstSecurityQA, Byte[] secondSecurityQ, String secondSecurityQA, Byte[] thirdSecurityQ, String thirdSecurityQA)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int results;
            SqlDataAdapter da;

            sqlStr.AppendLine("Update SecurityQuestions set User_ID = @paraUserID, FirstSecurityQuestion = @paraFirstSecurityQuestion ,FirstSecurityQuestionAns = @paraFirstSecurityQuestionAns,");
            sqlStr.AppendLine("SecondSecurityQuestion= @paraSecondSecurityQuestion , SecondSecurityQuestionAns= @paraSecondSecurityQuestionAns , ThirdSecurityQuestion= @paraThirdSecurityQuestion ,ThirdSecurityQuestionAns = @paraThirdSecurityQuestionAns");
            sqlStr.AppendLine(" where User_ID = @paraUserID");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            string x = da.ToString();


            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            objCmd.Parameters.AddWithValue("@paraUserID", User_ID);
            objCmd.Parameters.AddWithValue("@paraFirstSecurityQuestion", firstSecurityQ);
            objCmd.Parameters.AddWithValue("@paraFirstSecurityQuestionAns", firstSecurityQA);
            objCmd.Parameters.AddWithValue("@paraSecondSecurityQuestion", secondSecurityQ);
            objCmd.Parameters.AddWithValue("@paraSecondSecurityQuestionAns", secondSecurityQA);
            objCmd.Parameters.AddWithValue("@paraThirdSecurityQuestion", thirdSecurityQ);
            objCmd.Parameters.AddWithValue("@paraThirdSecurityQuestionAns", thirdSecurityQA);

            objsqlconn.Open();
            results = objCmd.ExecuteNonQuery();
            objsqlconn.Close();
            return results;



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

        //for getting the code to activate account if user didnt activate acc
        public activationCode getActivationCodeBasedOnNRIC(String User_ID)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            activationCode activationCodeList = new activationCode();

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select User_ID, ActivationCode, codeEDate, Name, Email, ConfirmEmail");

            sqlCommand.AppendLine("from [User] where User_ID = @parauser_Id ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@parauser_Id", User_ID);
            //fill dataset to table
            da.Fill(ds, "userTable");

            //if no record, set list to null
            int count = ds.Tables["userTable"].Rows.Count;
            if (count == 0)
            {
                activationCodeList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["userTable"].Rows)
                {
                    //SecurityQuestions objSQ = new SecurityQuestions();
                    activationCodeList.userId = Convert.ToString(row["User_ID"]);
                    activationCodeList.ActivationCode = Convert.ToString(row["ActivationCode"]);
                    activationCodeList.codeEDate = Convert.ToDateTime(row["codeEDate"]);
                    activationCodeList.Name = Convert.ToString(row["Name"]);
                    activationCodeList.confirmEmail = Convert.ToString(row["ConfirmEmail"]);
                    activationCodeList.email = Convert.ToString(row["Email"]);
                }

            }

            return activationCodeList;

        }



        //for asking new Activaation Code
        public int getNewActivationCode(String User_ID, String activationCode, DateTime codeEDate)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;
            SqlDataAdapter da;

            sqlStr.AppendLine("update [User] set ActivationCode = @paraActivationCode , codeEDate = @paraedate");
            sqlStr.AppendLine("where User_ID = @parauser_Id");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;


            objCmd.Parameters.AddWithValue("@parauser_Id", User_ID);
            objCmd.Parameters.AddWithValue("@paraActivationCode", activationCode);
            objCmd.Parameters.AddWithValue("@paraedate", codeEDate);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        //for updating the user table to activate the account
        public int ValidateActivationCode(String User_ID, String confirmEmail)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;
            SqlDataAdapter da;

            sqlStr.AppendLine("update [User] set ActivationCode = NULL , ConfirmEmail = @paraConfirmEmail");
            sqlStr.AppendLine("where User_ID = @parauser_Id");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            objCmd.Parameters.AddWithValue("@parauser_Id", User_ID);
            objCmd.Parameters.AddWithValue("@paraConfirmEmail", confirmEmail);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

    }
}