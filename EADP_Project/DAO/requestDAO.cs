using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace EADP_Project.DataLayer
{
    public class requestDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();

        //to send a reuqest to a tutor
        public int sendRequest(String requestDetails, String requestTo, String requestBy,String status)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter da;
            int result;

            sqlStr.AppendLine("INSERT INTO requestDB (requestDetails, requestTo, requestBy, status)");
            //sqlStr.AppendLine("sessionDate)");
            sqlStr.AppendLine("VALUES (@pararequestDetails, @pararequestTo, @pararequestBy, @parastatus)");
            //sqlStr.AppendLine("@paraSessionDate,@paraCCAPoints,@paraSessionRating");
            //@paraEventLocation,@paraParticipationAmount,");@paraParticipatorId


            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);

            da = new SqlDataAdapter(sqlStr.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            

            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
          //  obj.SelectCommand.Parameters.AddWithValue("@pararequestDetails", requestDetails);
            objCmd.Parameters.AddWithValue("@pararequestDetails", requestDetails);
            da.SelectCommand.Parameters.AddWithValue("@pararequestTo", requestTo);
            objCmd.Parameters.AddWithValue("@pararequestTo", requestTo);
            objCmd.Parameters.AddWithValue("@pararequestBy", requestBy);
            objCmd.Parameters.AddWithValue("@parastatus", status);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        //get requestToMe session details
        public requestEntity RequestToMeByIdDetails(int requestId, String requestTo)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand objCmd = new SqlCommand();
            //declare list to hold collection of events objs
            requestEntity theRequest = new requestEntity();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * ");
            sqlCommand.AppendLine("from requestDB where requestId= '" + requestId + "' and requestTo =  '" + requestTo + "' ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlCommand.ToString(), objsqlconn);
            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            objCmd.Parameters.AddWithValue("@pararequestTo", requestTo);
            //fill dataset to table
            da.Fill(ds, "RequestToMeGV");

            //if no record, set list to null
            int count = ds.Tables["RequestToMeGV"].Rows.Count;
            if (count == 0)
            {
                theRequest = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["RequestToMeGV"].Rows)
                {

                    theRequest.requestId = Convert.ToInt32(row["requestId"]);
                    theRequest.requestDetails = Convert.ToString(row["requestDetails"]);
                    theRequest.requestTo = Convert.ToString(row["requestTo"]);
                    theRequest.requestBy = Convert.ToString(row["requestBy"]);
                    theRequest.status = Convert.ToString(row["status"]);
                }

            }

            return theRequest;


        }

        //get requestByMe session details
        public requestEntity RequestByMeByIdDetails(int requestId, String requestBy)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand objCmd = new SqlCommand();
            //declare list to hold collection of events objs
            requestEntity theRequest = new requestEntity();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * ");
            sqlCommand.AppendLine("from requestDB where requestId= '" + requestId + "' and requestBy =  '" + requestBy + "' ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlCommand.ToString(), objsqlconn);
            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            objCmd.Parameters.AddWithValue("@pararequestBy", requestBy);
            //fill dataset to table
            da.Fill(ds, "requestByMeGV");

            //if no record, set list to null
            int count = ds.Tables["requestByMeGV"].Rows.Count;
            if (count == 0)
            {
                theRequest = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["requestByMeGV"].Rows)
                {

                    theRequest.requestId = Convert.ToInt32(row["requestId"]);
                    theRequest.requestDetails = Convert.ToString(row["requestDetails"]);
                    theRequest.requestTo = Convert.ToString(row["requestTo"]);
                    theRequest.requestBy = Convert.ToString(row["requestBy"]);
                    theRequest.status = Convert.ToString(row["status"]);
                }

            }

            return theRequest;


        }

        public int acceptRequest(int requestId, String status)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int results;
            SqlDataAdapter da;

            sqlStr.AppendLine("update requestDB set status= @parastatus");

            sqlStr.AppendLine(" where requestId = @pararequestId");/* and tutorId = @paratutorId */
            string x = sqlStr.ToString();
            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;

            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            //   objCmd.Parameters.AddWithValue("@paraEventName", eventName);
            objCmd.Parameters.AddWithValue("@pararequestId", requestId);
            objCmd.Parameters.AddWithValue("@parastatus", status);

            objsqlconn.Open();
            results = objCmd.ExecuteNonQuery();
            objsqlconn.Close();
            return results;



        }


        //filter request based on requestTo(current User is the tutor)
        public List<requestEntity> getTeachSessionList(String requestTo)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<requestEntity> requestList = new List<requestEntity>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("select * from requestDB where requestTo = @pararequestTo");

            //sqlCommand.AppendLine("from tutorSessionDB where tutorId = @paratutorId");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@pararequestTo", requestTo);
            //fill dataset to table
            da.Fill(ds, "myRequestGV");

            //if no record, set list to null
            int count = ds.Tables["myRequestGV"].Rows.Count;
            if (count == 0)
            {
                requestList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["myRequestGV"].Rows)
                {
                    requestEntity objRequest = new requestEntity();

                    objRequest.requestId = Convert.ToInt32(row["requestId"]);
                    objRequest.requestDetails = Convert.ToString(row["requestDetails"]);
                    objRequest.requestTo = Convert.ToString(row["requestTo"]);
                    objRequest.requestBy = Convert.ToString(row["requestBy"]);
                    objRequest.status = Convert.ToString(row["status"]);

                    requestList.Add(objRequest);
                }

            }

            return requestList;

        }

        //filter request by requestBy(current user is requestee/current user send request to other people)
        public List<requestEntity> getRequestByMeSessionList(String requestBy)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<requestEntity> requestByList = new List<requestEntity>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("select * from requestDB where requestBy = @pararequestBy");

            //sqlCommand.AppendLine("from tutorSessionDB where tutorId = @paratutorId");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@pararequestBy", requestBy);
            //fill dataset to table
            da.Fill(ds, "requestByMeGV");

            //if no record, set list to null
            int count = ds.Tables["requestByMeGV"].Rows.Count;
            if (count == 0)
            {
                requestByList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["requestByMeGV"].Rows)
                {
                    requestEntity objRequest = new requestEntity();

                    objRequest.requestId = Convert.ToInt32(row["requestId"]);
                    objRequest.requestDetails = Convert.ToString(row["requestDetails"]);
                    objRequest.requestTo = Convert.ToString(row["requestTo"]);
                    objRequest.requestBy = Convert.ToString(row["requestBy"]);
                    objRequest.status = Convert.ToString(row["status"]);
                    requestByList.Add(objRequest);
                }

            }

            return requestByList;

        }

        //populate gridview based on edulevel(Pri Sch)
        public List<user> PriSchList()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<user> PriSchList = new List<user>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select User_ID ,Education_Level from [User] where Education_Level is not null and Role='Student'");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            //da.SelectCommand.Parameters.AddWithValue("@parauserId", User_ID);
            //fill dataset to table
            da.Fill(ds, "studentGV");

            //if no record, set list to null
            int count = ds.Tables["studentGV"].Rows.Count;
            if (count == 0)
            {
                PriSchList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["studentGV"].Rows)
                {
                    user objRequest = new user();
                    objRequest.User_ID = Convert.ToString(row["user_Id"]);
                    objRequest.education_level = Convert.ToString(row["education_level"]);
                    PriSchList.Add(objRequest);
                    //  objRequest.education_level = Convert.ToString(row["ELevel"]);
                }

            }

            return PriSchList;

        }

        

        //select the list of student to give points for students who accept request
        public List<requestEntity> getNumberOfRequestTeach()
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<requestEntity> requestTutionList = new List<requestEntity>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select requestTo ");
            sqlCommand.AppendLine("from requestDB where status LIKE '%Completed%' GROUP BY requestTo HAVING COUNT(requestTo) > 2");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;

            //fill dataset to table
            da.Fill(ds, "requestPointsGV");

            //if no record, set list to null
            int count = ds.Tables["requestPointsGV"].Rows.Count;
            if (count == 0)
            {
                requestTutionList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["requestPointsGV"].Rows)
                {
                    requestEntity objTuition = new requestEntity();

                    objTuition.requestTo = Convert.ToString(row["requestTo"]);
                    // objTuition.tutorId = Convert.ToString(row["tutorId"]);

                    requestTutionList.Add(objTuition);
                }

            }

            return requestTutionList;

        }

        //give points
        public int givePoints(String requestTo, int CCAPoints, int Orion_Points)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;
            SqlDataAdapter da;

            sqlStr.AppendLine("Update UserTable set User_ID= @pararequestTo, CCAPoints =  @paraCCAPoints + CCAPoints , Orion_Points = @paraOrion_Points + Orion_Points  ");
            sqlStr.AppendLine("where User_ID = @pararequestTo");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;

            objCmd.Parameters.AddWithValue("@pararequestTo", requestTo);
            objCmd.Parameters.AddWithValue("@paraCCAPoints", CCAPoints);
            objCmd.Parameters.AddWithValue("@paraOrion_Points", Orion_Points);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

    }

  

}