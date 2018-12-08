using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EADP_Project.Entities;
using System.Web;

namespace EADP_Project.DataLayer
{
    public class sessionDAO
    {
        //FOR STUDENT THAT IS A TUTOR
        //createSession
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
       
        public int createTeachingSession(String sessionDetails, String sessionDate, String sessionSTime, String sessionETime, String status, String tutorId)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;

            sqlStr.AppendLine("INSERT INTO tutorSessionDB (sessionDetails,sessionDate,sessionSTime,sessionETime,status,tutorId)");
            //sqlStr.AppendLine("sessionDate)");
            sqlStr.AppendLine("VALUES (@paraSessionDetails, @paraSessionDate, @paraSessionSTime, @paraSessionETime,@parastatus, @paratutorId)");
            //sqlStr.AppendLine("@paraSessionDate,@paraCCAPoints,@paraSessionRating");
            //@paraEventLocation,@paraParticipationAmount,");@paraParticipatorId
            

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);


            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
           
            objCmd.Parameters.AddWithValue("@paraSessionDetails", sessionDetails);
            objCmd.Parameters.AddWithValue("@paraSessionDate", sessionDate);
            objCmd.Parameters.AddWithValue("@paraSessionSTime", sessionSTime);
            objCmd.Parameters.AddWithValue("@paraSessionETime", sessionETime);
            objCmd.Parameters.AddWithValue("@parastatus", status);
            objCmd.Parameters.AddWithValue("@paratutorId", tutorId);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        //load teaching session for tutors
        public List<tutionEntities> getTeachSessionList(String tutorId)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<tutionEntities> TeachTutionList = new List<tutionEntities>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select sessionId, sessionDetails, sessionDate, sessionSTime, sessionETime,status");

            sqlCommand.AppendLine("from tutorSessionDB where tutorId = @paratutorId");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@paratutorId", tutorId);
            //fill dataset to table
            da.Fill(ds, "tuitionGrid");

            //if no record, set list to null
            int count = ds.Tables["tuitionGrid"].Rows.Count;
            if (count == 0)
            {
                TeachTutionList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["tuitionGrid"].Rows)
                {
                    tutionEntities objTuition = new tutionEntities();

                    objTuition.sessionId = Convert.ToInt32(row["SessionID"]);
                    objTuition.SessionDetails = Convert.ToString(row["sessionDetails"]);
                    objTuition.sessionDate = Convert.ToString(row["sessionDate"]);
                    objTuition.sessionSTime = Convert.ToString(row["sessionSTime"]);
                    objTuition.sessionETime = Convert.ToString(row["sessionETime"]);
                    objTuition.status = Convert.ToString(row["status"]);
                    TeachTutionList.Add(objTuition);
                }

            }

            return TeachTutionList;

        }

        //load teaching session joined
        public List<tutionEntities> getJoinedSessionList(String tuteeId)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<tutionEntities> TeachTutionList = new List<tutionEntities>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select sessionId, sessionDetails, sessionDate, sessionSTime, sessionETime,status");

            sqlCommand.AppendLine("from tutorSessionDB where tuteeId = @paratuteeId");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@paratuteeId", tuteeId);
            //fill dataset to table
            da.Fill(ds, "JoinedSessionGV");

            //if no record, set list to null
            int count = ds.Tables["JoinedSessionGV"].Rows.Count;
            if (count == 0)
            {
                TeachTutionList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["JoinedSessionGV"].Rows)
                {
                    tutionEntities objTuition = new tutionEntities();

                    objTuition.sessionId = Convert.ToInt32(row["SessionID"]);
                    objTuition.SessionDetails = Convert.ToString(row["sessionDetails"]);
                    objTuition.sessionDate = Convert.ToString(row["sessionDate"]);
                    objTuition.sessionSTime = Convert.ToString(row["sessionSTime"]);
                    objTuition.sessionETime = Convert.ToString(row["sessionETime"]);
                    objTuition.status = Convert.ToString(row["status"]);
                    TeachTutionList.Add(objTuition);
                }

            }

            return TeachTutionList;

        }

        //RETRIEVE THE Session DATA
        public tutionEntities GetTuitionById(int SessionID)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            tutionEntities getTuition = new tutionEntities();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select * ");
            sqlCommand.AppendLine("from tutorSessionDB where sessionId= '" + SessionID + "' ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);

            //fill dataset to table
            da.Fill(ds, "tuitionGrid");

            //if no record, set list to null
            int count = ds.Tables["tuitionGrid"].Rows.Count;
            if (count == 0)
            {
                getTuition = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["tuitionGrid"].Rows)
                {


                    getTuition.sessionId = Convert.ToInt32(row["SessionID"]);
                    getTuition.SessionDetails = Convert.ToString(row["sessionDetails"]);
                    getTuition.sessionDate = Convert.ToString(row["sessionDate"]);
                    getTuition.sessionSTime = Convert.ToString(row["sessionSTime"]);
                    getTuition.sessionETime = Convert.ToString(row["sessionETime"]);
                    getTuition.status = Convert.ToString(row["status"]);
                    getTuition.tutorId = Convert.ToString(row["tutorId"]);
                    getTuition.tuteeId = Convert.ToString(row["tuteeId"]);
                }

            }

            return getTuition;


        }



        //RETRIEVE THE TUITION DATA
        public tutionEntities GetSesionJoinedById(int SessionID,String tuteeId)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            tutionEntities getTuition = new tutionEntities();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select * ");
            sqlCommand.AppendLine("from tutorSessionDB where sessionId= '" + SessionID + "' and tuteeId = @paratuteeId");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@paratuteeId", tuteeId);

            //fill dataset to table
            da.Fill(ds, "JoinedSessionGV");

            //if no record, set list to null
            int count = ds.Tables["JoinedSessionGV"].Rows.Count;
            if (count == 0)
            {
                getTuition = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["JoinedSessionGV"].Rows)
                {


                    getTuition.sessionId = Convert.ToInt32(row["SessionID"]);
                    getTuition.SessionDetails = Convert.ToString(row["sessionDetails"]);
                    getTuition.sessionDate = Convert.ToString(row["sessionDate"]);
                    getTuition.sessionSTime = Convert.ToString(row["sessionSTime"]);
                    getTuition.sessionETime = Convert.ToString(row["sessionETime"]);
                    getTuition.status = Convert.ToString(row["status"]);
                    getTuition.tutorId = Convert.ToString(row["tutorId"]);
                    getTuition.tuteeId = Convert.ToString(row["tuteeId"]);
                }

            }

            return getTuition;


        }

        //update session

        public int updateSession(int sessionId, String sessionDetails, String sessionDate, String sessionSTime, String sessionETime,String status, String tutorId)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int results;
            SqlDataAdapter da;

            sqlStr.AppendLine("Update tutorSessionDB set sessionDetails= @parasessionDetails ,  sessionDate= @parasessionDate , sessionSTime= @parsessionSTime , sessionETime = @parasessionETime , status = @parastatus");
           
            sqlStr.AppendLine(" where sessionId = @parasessionId and tutorId = @paratutorId ");
            string x = sqlStr.ToString();
            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;

            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            //   objCmd.Parameters.AddWithValue("@paraEventName", eventName);
            objCmd.Parameters.AddWithValue("@parasessionId", sessionId);
            objCmd.Parameters.AddWithValue("@parasessionDetails", sessionDetails);
            objCmd.Parameters.AddWithValue("@parasessionDate", sessionDate);
            objCmd.Parameters.AddWithValue("@parsessionSTime", sessionSTime);
            objCmd.Parameters.AddWithValue("@parasessionETime", sessionETime);
            objCmd.Parameters.AddWithValue("@parastatus", status);
            objCmd.Parameters.AddWithValue("@paratutorId", tutorId);

            objsqlconn.Open();
            results = objCmd.ExecuteNonQuery();
            objsqlconn.Close();
            return results;



        }


        //------------------------------------------------------------------------------------------------------------------------------------//
        //load all tuition session
        public List<tutionEntities> LoadAllTutionSession()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<tutionEntities> loadAllTuitionSession = new List<tutionEntities>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select sessionId, sessionDetails, sessionDate,sessionSTime, sessionETime,  tutorId");

            sqlCommand.AppendLine("from tutorSessionDB where tuteeId IS NULL");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            //da.SelectCommand.Parameters.AddWithValue("@paratutorId", tutorId);
            //fill dataset to table
            da.Fill(ds, "viewAllTuition");

            //if no record, set list to null
            int count = ds.Tables["viewAllTuition"].Rows.Count;
            if (count == 0)
            {
                loadAllTuitionSession = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["viewAllTuition"].Rows)
                {
                    tutionEntities objTuition = new tutionEntities();

                    objTuition.sessionId = Convert.ToInt32(row["SessionID"]);
                    objTuition.SessionDetails = Convert.ToString(row["sessionDetails"]);
                    objTuition.sessionDate = Convert.ToString(row["sessionDate"]);
                    objTuition.sessionSTime = Convert.ToString(row["sessionSTime"]);
                    objTuition.sessionETime = Convert.ToString(row["sessionETime"]);
                    objTuition.tutorId = Convert.ToString(row["tutorId"]);

                    loadAllTuitionSession.Add(objTuition);
                }

            }

            return loadAllTuitionSession;

        }

        //TO JOIN A TUITION
        public int signUpTuition(String tuteeId, String tutorId ,int sessionId)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;
            SqlDataAdapter da;

            sqlStr.AppendLine("update tutorSessionDB set tuteeId = @paratuteeId");
            sqlStr.AppendLine("where sessionId = @parasessionId and tutorId = @paratutorId");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;

            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            objCmd.Parameters.AddWithValue("@paratuteeId", tuteeId);
            objCmd.Parameters.AddWithValue("@paratutorId", tutorId);
            objCmd.Parameters.AddWithValue("@parasessionId", sessionId);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }


        

        //select students who have tutorSession to give points
        public List<tutionEntities> getNumberOfTutionTeach()
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<tutionEntities> TeachTutionList = new List<tutionEntities>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select tutorId ");
            sqlCommand.AppendLine("from tutorSessionDB where status LIKE 'Completed' GROUP BY tutorId HAVING COUNT(tutorId) > 3");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;

            //fill dataset to table
            da.Fill(ds, "tutionPointsGV");

            //if no record, set list to null
            int count = ds.Tables["tutionPointsGV"].Rows.Count;
            if (count == 0)
            {
                TeachTutionList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["tutionPointsGV"].Rows)
                {
                    tutionEntities objTuition = new tutionEntities();

                    objTuition.tutorId = Convert.ToString(row["tutorId"]);
                   // objTuition.tutorId = Convert.ToString(row["tutorId"]);

                    TeachTutionList.Add(objTuition);
                }

            }

            return TeachTutionList;

        }

        //give points
        public int givePoints(String tutorId, int CCAPoints, int Orion_Points)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;
            SqlDataAdapter da;

            sqlStr.AppendLine("Update UserTable set User_ID= @paratutorId, CCAPoints =  @paraCCAPoints + CCAPoints , Orion_Points = @paraOrion_Points + Orion_Points  ");
            sqlStr.AppendLine("where User_ID = @paratutorId");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;

            objCmd.Parameters.AddWithValue("@paratutorId", tutorId);
            objCmd.Parameters.AddWithValue("@paraCCAPoints", CCAPoints);
            objCmd.Parameters.AddWithValue("@paraOrion_Points", Orion_Points);
            
            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        public int unjoinSession(String tuteeId,int sessionId)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int results;


            sqlStr.AppendLine("update tutorSessionDB set tuteeId = Null where sessionId = @parasessionId and tuteeId = @paratuteeId ");


            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);



            objCmd.Parameters.AddWithValue("@parasessionId", sessionId);
            objCmd.Parameters.AddWithValue("@paratuteeId", tuteeId);


            objsqlconn.Open();
            results = objCmd.ExecuteNonQuery();
            objsqlconn.Close();
            return results;



        }


    }
}