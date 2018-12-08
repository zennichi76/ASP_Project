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

namespace EADP_Project.Controller
{
    public class eventDAO
    {


        //add event 
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        public int insertEvent(String eventName, String eventSDate, String eventEDate, String eventSTime, String eventETime,
            String eventDescription, int maxCapacity, int CcaPoints, int Orion_Points, string user_Id)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;

            sqlStr.AppendLine("INSERT INTO eventDB (eventName,eventSDate,eventEDate,eventSTime ,eventETime,eventDescription, ");
            sqlStr.AppendLine("maxCapacity,CCAPoints,Orion_Points,user_Id)");
            sqlStr.AppendLine("VALUES (@paraEventName,@paraEventSDate, @paraEventEDate, @paraEventSTime,");
            sqlStr.AppendLine("@paraEventETime,@paraEventDescription,@paraMaxCapacity,");
            //@paraEventLocation,@paraParticipationAmount,");@paraParticipatorId
            sqlStr.AppendLine("@paraCCAPoints, @paraOrion_Points,@parauser_Id)");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);


            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            objCmd.Parameters.AddWithValue("@paraEventName", eventName);
            objCmd.Parameters.AddWithValue("@paraEventSDate", eventSDate);
            objCmd.Parameters.AddWithValue("@paraEventEDate", eventEDate);
            objCmd.Parameters.AddWithValue("@paraEventSTime", eventSTime);
            objCmd.Parameters.AddWithValue("@paraEventETime", eventETime);
            objCmd.Parameters.AddWithValue("@paraEventDescription", eventDescription);

            objCmd.Parameters.AddWithValue("@paraMaxCapacity", maxCapacity);

            //sqlCmd.Parameters.AddWithValue("@paraParticipationAmount", participationAmount);
            //sqlCmd.Parameters.AddWithValue("@paraParticipatorId", participatorId);
            objCmd.Parameters.AddWithValue("@paraCCAPoints", CcaPoints);
            objCmd.Parameters.AddWithValue("@paraOrion_Points", Orion_Points);
            objCmd.Parameters.AddWithValue("@parauser_Id", user_Id);
            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        //load data in datagrid based on user(working)
        public List<events> getEventList(String user_Id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<events> eventList = new List<events>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select eventId, eventName, eventSDate , eventEDate,eventSTime,  eventETime");

            sqlCommand.AppendLine("from eventDB where user_Id = @parauser_Id ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@parauser_Id", user_Id);
            //fill dataset to table
            da.Fill(ds, "taskGridView");

            //if no record, set list to null
            int count = ds.Tables["taskGridView"].Rows.Count;
            if (count == 0)
            {
                eventList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["taskGridView"].Rows)
                {
                    events objEvent = new events();
                    objEvent.eventId = Convert.ToInt32(row["eventId"]);
                    objEvent.eventName = Convert.ToString(row["eventName"]);
                    objEvent.eventSDate = Convert.ToString(row["eventSDate"]);
                    objEvent.eventEDate = Convert.ToString(row["eventEDate"]);
                    objEvent.eventSTime = Convert.ToString(row["eventSTime"]);
                    objEvent.eventETime = Convert.ToString(row["eventETime"]);
                    //objEvent.eventDescription = Convert.ToString(row["eventDescription"]);
                    //objEvent.maxCapacity = Convert.ToInt32(row["maxCapacity"]);
                    //  objEvent.eventLocation = Convert.ToString(row["eventLocation"]);
                    //objEvent.CcaPoints = Convert.ToInt32(row["ccaPoints"]);
                    //objEvent.Orion_Points = Convert.ToInt32(row["Orion_Points"]);

                    eventList.Add(objEvent);
                }

            }

            return eventList;

        }


        //load all events(student) viewAllEventPage
        public List<events> LoadAllEventList()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<events> allEventList = new List<events>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select eventId, eventName, eventSDate,eventEDate, eventSTime,  eventETime");

            sqlCommand.AppendLine("from eventDB where GETDATE() <  CONVERT(DATETIME, CONVERT(VARCHAR,eventEDate))");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            //fill dataset to table
            da.Fill(ds, "AllEventGridView");

            //if no record, set list to null
            int count = ds.Tables["AllEventGridView"].Rows.Count;
            if (count == 0)
            {
                allEventList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["AllEventGridView"].Rows)
                {
                    events objEvent = new events();
                    objEvent.eventId = Convert.ToInt32(row["eventId"]);
                    objEvent.eventName = Convert.ToString(row["eventName"]);
                    objEvent.eventSDate = Convert.ToString(row["eventSDATE"]);
                    objEvent.eventEDate = Convert.ToString(row["eventEDATE"]);
                    objEvent.eventSTime = Convert.ToString(row["eventSTime"]);
                    objEvent.eventETime = Convert.ToString(row["eventETime"]);


                    allEventList.Add(objEvent);
                }

            }

            return allEventList;

        }



        public int updateEvent(String eventName, String eventSDate, String eventEDate, String eventSTime, String eventETime,
            String eventDescription, int maxCapacity, int CcaPoints, int Orion_Points, int eventId, string user_Id)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int results;
            SqlDataAdapter da;

            sqlStr.AppendLine("Update eventDB set eventName= @paraEventName , eventSDate= @paraEventSDate , eventEDate= @paraEventEDate , ");
            sqlStr.AppendLine("eventSTime= @paraEventSTime , eventETime= @paraEventETime , eventDescription= @paraEventDescription , ");
            sqlStr.AppendLine("maxCapacity= @paraMaxCapacity , CCAPoints= @paraCCAPoints , Orion_Points= @paraOrion_Points ");
            sqlStr.AppendLine(" where eventId = @paraeventId and user_Id = @parauser_Id");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            string x = da.ToString();


            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            objCmd.Parameters.AddWithValue("@paraEventName", eventName);
            objCmd.Parameters.AddWithValue("@paraEventSDate", eventSDate);
            objCmd.Parameters.AddWithValue("@paraEventEDate", eventEDate);
            objCmd.Parameters.AddWithValue("@paraEventSTime", eventSTime);
            objCmd.Parameters.AddWithValue("@paraEventETime", eventETime);
            objCmd.Parameters.AddWithValue("@paraEventDescription", eventDescription);

            objCmd.Parameters.AddWithValue("@paraMaxCapacity", maxCapacity);
            objCmd.Parameters.AddWithValue("@paraCCAPoints", CcaPoints);
            objCmd.Parameters.AddWithValue("@paraOrion_Points", Orion_Points);
            objCmd.Parameters.AddWithValue("@paraeventId", eventId);
            objCmd.Parameters.AddWithValue("@parauser_Id", user_Id);
            //da.SelectCommand.Parameters.AddWithValue("@parauser_Id", user_Id);



            objsqlconn.Open();
            results = objCmd.ExecuteNonQuery();
            objsqlconn.Close();
            return results;



        }

        

        //to retrieve specific event
        public events GetEventById(int eventId)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            events theevent = new events();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select * ");
            sqlCommand.AppendLine("from eventDB where eventId= '" + eventId + "' ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);

            //fill dataset to table
            da.Fill(ds, "table");

            //if no record, set list to null
            int count = ds.Tables["table"].Rows.Count;
            if (count == 0)
            {
                theevent = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["table"].Rows)
                {

                    theevent.eventId = Convert.ToInt32(row["eventId"]);
                    theevent.eventName = Convert.ToString(row["eventName"]);
                    theevent.eventSDate = Convert.ToString(row["eventSDATE"]);
                    theevent.eventEDate = Convert.ToString(row["eventEDATE"]);
                    theevent.eventSTime = Convert.ToString(row["eventSTime"]);
                    theevent.eventETime = Convert.ToString(row["eventETime"]);
                    theevent.eventDescription = Convert.ToString(row["eventDescription"]);
                    theevent.maxCapacity = Convert.ToInt32(row["maxCapacity"]);
                    theevent.CcaPoints = Convert.ToInt32(row["CCAPoints"]);
                    theevent.Orion_Points = Convert.ToInt32(row["Orion_Points"]);
                    theevent.creatorId = Convert.ToString(row["user_Id"]);

                }

            }

            return theevent;


        }

     


        //get total number of participant
        public events getNumberOfParticipant(int eventId)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            events theevent = new events();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select count(*) as thecount ");
            sqlCommand.AppendLine("from eventSignUp where eventId= '" + eventId + "' ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);

            //fill dataset to table
            da.Fill(ds, "thetable");

            //if no record, set list to null
            int count = ds.Tables["thetable"].Rows.Count;
            if (count == 0)
            {
                theevent = null;  // this is an impossible situation

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["thetable"].Rows)
                {

                    theevent.maxCapacity = Convert.ToInt32(row["thecount"]);
                }

            }


            return theevent;

        }

        //check if user has already sign up for the event. not complete yet
        public bool checkIfParticipantHasSignUp(int eventId, string participatorId)
        {
            //Select* from eventSignUp where eventId = 15 and participatorId = 'S9651833B'

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            events theevent = new events();



            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select* from eventSignUp ");
            sqlCommand.AppendLine("where eventId= '" + eventId + "' and participatorId = '" + participatorId + "' ");



            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@paraparticipatorId", participatorId);
            da.SelectCommand.Parameters.AddWithValue("@paraeventId", eventId);
            //fill dataset to table
            //    da.Fill(ds, "thetable");

            //fill dataset to table
            da.Fill(ds, "thetable");

            //if no record, set list to null
            int count = ds.Tables["thetable"].Rows.Count;
            if (count == 0)
            {
                return true;

            }
            else
            {
                return false; // this means signup already

            }



        }


      

        //allow student to sign up for event
        public int signUpEvent(int eventId, String eventName, String eventSDate, String eventEDate, String eventSTime, String eventETime,
            String eventDescription, string participatorId ,int CCAPoints, int Orion_Points, String creatorId)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;

            sqlStr.AppendLine("INSERT INTO eventSignUp(eventId,eventName,eventSDate,eventEDate,eventSTime ,eventETime,eventDescription, ");
            sqlStr.AppendLine("participatorId,CCAPoints, Orion_Points,creatorId)");
            sqlStr.AppendLine("VALUES (@paraeventId, @paraEventName,@paraEventSDate, @paraEventEDate, @paraEventSTime,");
            sqlStr.AppendLine("@paraEventETime,@paraEventDescription,@paraparticipatorId,@paraCCAPoints, @paraOrion_Points,@paracreatorId)");
            //@paraEventLocation,@paraParticipationAmount,");@paraParticipatorId
            //sqlStr.AppendLine("@paraCCAPoints, @paraOrion_Points,@parauser_Id)");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);


            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            objCmd.Parameters.AddWithValue("@paraeventId", eventId);
            objCmd.Parameters.AddWithValue("@paraEventName", eventName);
            objCmd.Parameters.AddWithValue("@paraEventSDate", eventSDate);
            objCmd.Parameters.AddWithValue("@paraEventEDate", eventEDate);
            objCmd.Parameters.AddWithValue("@paraEventSTime", eventSTime);
            objCmd.Parameters.AddWithValue("@paraEventETime", eventETime);
            objCmd.Parameters.AddWithValue("@paraEventDescription", eventDescription);
            objCmd.Parameters.AddWithValue("@paraparticipatorId", participatorId);
            objCmd.Parameters.AddWithValue("@paraCCAPoints", CCAPoints);
            objCmd.Parameters.AddWithValue("@paraOrion_Points", Orion_Points);
            objCmd.Parameters.AddWithValue("@paracreatorId", creatorId);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        //load into student sign up grid. 
        public List<events> getsignUpEventList(String participatorId)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<events> eventList = new List<events>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select eventId, eventName, eventSDate,eventEDate,eventSTime, eventETime");

            sqlCommand.AppendLine("from eventSignUp where participatorId = @paraparticipatorId");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@paraparticipatorId", participatorId);
            //fill dataset to table
            da.Fill(ds, "myEventsGV");

            //if no record, set list to null
            int count = ds.Tables["myEventsGV"].Rows.Count;
            if (count == 0)
            {
                eventList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["myEventsGV"].Rows)
                {
                    events objEvent = new events();
                    objEvent.eventId = Convert.ToInt32(row["eventId"]);
                    objEvent.eventName = Convert.ToString(row["eventName"]);
                    objEvent.eventSDate = Convert.ToString(row["eventSDATE"]);
                    objEvent.eventEDate = Convert.ToString(row["eventEDATE"]);
                    objEvent.eventSTime = Convert.ToString(row["eventSTime"]);
                    objEvent.eventETime = Convert.ToString(row["eventETime"]);

                    eventList.Add(objEvent);
                }

            }

            return eventList;

        }



        //get details of event joined
        //to retrieve specific event
        public events GetEventJoinedById(int eventId, String participatorId)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            events theevent = new events();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select * ");
            sqlCommand.AppendLine("from eventSignUp where eventId= '" + eventId + "' and participatorId = '"+ participatorId+"' ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);

            //fill dataset to table
            da.Fill(ds, "theTable");

            //if no record, set list to null
            int count = ds.Tables["theTable"].Rows.Count;
            if (count == 0)
            {
                theevent = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["theTable"].Rows)
                {

                    theevent.eventId = Convert.ToInt32(row["eventId"]);
                    theevent.eventName = Convert.ToString(row["eventName"]);
                    theevent.eventSDate = Convert.ToString(row["eventSDATE"]);
                    theevent.eventEDate = Convert.ToString(row["eventEDATE"]);
                    theevent.eventSTime = Convert.ToString(row["eventSTime"]);
                    theevent.eventETime = Convert.ToString(row["eventETime"]);
                    theevent.eventDescription = Convert.ToString(row["eventDescription"]);
                    //theevent.maxCapacity = Convert.ToInt32(row["maxCapacity"]);
                    theevent.CcaPoints = Convert.ToInt32(row["CCAPoints"]);
                    theevent.Orion_Points = Convert.ToInt32(row["Orion_Points"]);
                  //  theevent.participatorId = Convert.ToString(row["participatorId"]);

                }

            }

            return theevent;


        }

        //get the list of student that sign up for event(to load in gv)
        public List<events> getParticipatorList( String creatorId)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<events> participatorList = new List<events>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select eventId,participatorId,CCAPoints,Orion_Points,status");
            //Select * from eventSignUp where eventId= 15 and creatorId='S1613266Q' and status LIKE 'Assigned SuccessFully' and CCAPoints != 0 and Orion_Points != 0
            sqlCommand.AppendLine("from eventSignUp where creatorId = @paracreatorId  and  GETDATE() > CONVERT(DATETIME, CONVERT(VARCHAR,eventEDate)) and status LIKE '%Not Assigned%'");

            //Select eventId from eventSignUp where creatorId = 'S12345678F' group by eventId

                        //and status LIKE 'Not Assigned'
                        //GETDATE() > CONVERT(DATETIME, CONVERT(VARCHAR,eventEDate)) and 
                        //Instantiate sqlcommnd instance
                        SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@paracreatorId", creatorId);
            //fill dataset to table
            da.Fill(ds, "viewParticipatorsGV");

            //if no record, set list to null
            int count = ds.Tables["viewParticipatorsGV"].Rows.Count;
            if (count == 0)
            {
                participatorList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["viewParticipatorsGV"].Rows)
                {
                    events objEvent = new events();
                    objEvent.eventId = Convert.ToInt32(row["eventId"]);
                    // objEvent.eventName = Convert.ToString(row["eventName"]);
                    objEvent.participatorId = Convert.ToString(row["participatorID"]);
                    objEvent.CcaPoints = Convert.ToInt32(row["ccaPoints"]);
                    objEvent.Orion_Points = Convert.ToInt32(row["Orion_Points"]);
                    objEvent.status = Convert.ToString(row["status"]);
                    //objEvent.eventETime = Convert.ToString(row["eventETime"]);
                    //objEvent.eventDescription = Convert.ToString(row["eventDescription"]);
                    //objEvent.maxCapacity = Convert.ToInt32(row["maxCapacity"]);
                    //  objEvent.eventLocation = Convert.ToString(row["eventLocation"]);
                   

                    participatorList.Add(objEvent);
                }

            }

            return participatorList;

        }

        //to get the list of participator and print it out
        public List<events> getAttendanceList(int eventId, String creatorId)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            List<events> AttendanceList = new List<events>();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select participatorId");
            //Select * from eventSignUp where eventId= 15 and creatorId='S1613266Q' and status LIKE 'Assigned SuccessFully' and CCAPoints != 0 and Orion_Points != 0
            sqlCommand.AppendLine("from eventSignUp where creatorId = @paracreatorId  and eventId = @paraeventId ");
            //and status LIKE 'Not Assigned'
            //GETDATE() > CONVERT(DATETIME, CONVERT(VARCHAR,eventEDate)) and 
            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@paracreatorId", creatorId);
            da.SelectCommand.Parameters.AddWithValue("@paraeventId", eventId);
            //fill dataset to table
            da.Fill(ds, "printParticipatorGV");

            //if no record, set list to null
            int count = ds.Tables["printParticipatorGV"].Rows.Count;
            if (count == 0)
            {
                AttendanceList = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["printParticipatorGV"].Rows)
                {
                    events objEvent = new events();
                   
                    objEvent.participatorId = Convert.ToString(row["participatorId"]);


                    AttendanceList.Add(objEvent);
                }

            }

            return AttendanceList;

        }



        //get details of the list of student that sign up for event
        public events DetailsToAllocatePoints(int eventId, String creatorId)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //declare list to hold collection of events objs
            events theevent = new events();

            //retrieve conn string from web config
            //done at class level

            //sql commant to select data from table 
            StringBuilder sqlCommand = new StringBuilder();
            // sqlCommand.AppendLine("SELECT eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            //sqlCommand.AppendLine("eventETime, eventDescription, maxCapacity, eventName, eventSDate ,FORMAT(eventSTime,'hh:mm tt') AS eventSTime, eventEDate,");
            sqlCommand.AppendLine("Select * ");
            sqlCommand.AppendLine("from eventSignUp where eventId= '" + eventId + "' and creatorId = '" + creatorId + "'  ");

            //Instantiate sqlcommnd instance
            SqlConnection objsqlconn = new SqlConnection(DBConnect);

            //RETRIEVE RECORD USING DATAADAPTER
            da = new SqlDataAdapter(sqlCommand.ToString(), objsqlconn);

            //fill dataset to table
            da.Fill(ds, "table");

            //if no record, set list to null
            int count = ds.Tables["table"].Rows.Count;
            if (count == 0)
            {
                theevent = null;

            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection
                foreach (DataRow row in ds.Tables["table"].Rows)
                {

                    theevent.eventId = Convert.ToInt32(row["eventId"]);
                    theevent.eventName = Convert.ToString(row["eventName"]);
                    theevent.participatorId = Convert.ToString(row["participatorId"]);
                    theevent.CcaPoints = Convert.ToInt32(row["CCAPoints"]);
                    theevent.Orion_Points = Convert.ToInt32(row["Orion_Points"]);
                    theevent.status = Convert.ToString(row["status"]);
                    //theevent.maxCapacity = Convert.ToInt32(row["maxCapacity"]);
                    // theevent.CcaPoints = Convert.ToInt32(row["CCAPoints"]);
                    //theevent.Orion_Points = Convert.ToInt32(row["Orion_Points"]);
                    

                }

            }

            return theevent;


        }

        


        //give points
        public int givePoints(String participatorId, int CCAPoints, int Orion_Points)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;
            SqlDataAdapter da;

            sqlStr.AppendLine("Update [User] set CCA_Points =  @paraCCAPoints + CCA_Points , Orion_Points = @paraOrion_Points + Orion_Points");
            sqlStr.AppendLine("where User_ID = @paraparticipatorId");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
            da = new SqlDataAdapter(objCmd.ToString(), objsqlconn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.Text;

            objCmd.Parameters.AddWithValue("@paraparticipatorId", participatorId);
            objCmd.Parameters.AddWithValue("@paraCCAPoints", CCAPoints);
            objCmd.Parameters.AddWithValue("@paraOrion_Points", Orion_Points);

            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;


        }

        public int setStatus(String status ,String participatorId, String creatorId)
        {
            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int result;

            sqlStr.AppendLine("Update eventSignUp set status = @parastatus");
            sqlStr.AppendLine(" where participatorId = @paraparticipatorId and creatorId= @paracreatorId");

            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);


            //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            objCmd.Parameters.AddWithValue("@paraparticipatorId", participatorId);
            objCmd.Parameters.AddWithValue("@parastatus", status);
            objCmd.Parameters.AddWithValue("@paracreatorId", creatorId);


            objsqlconn.Open();
            result = objCmd.ExecuteNonQuery();
            objsqlconn.Close();

            return result;

        }

        //student unjoin event
        public int unjoinEvent(String participatorId,int eventId)
        {

            DataSet ds = new DataSet();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand objCmd = new SqlCommand();
            int results;


            sqlStr.AppendLine("Delete from eventSignUp where eventId = '" +eventId+"' and participatorId = '" + participatorId + "' ");


            SqlConnection objsqlconn = new SqlConnection(DBConnect);
            objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);



            objCmd.Parameters.AddWithValue("@paraparticipatorId", participatorId);
            objCmd.Parameters.AddWithValue("@paraeventId", eventId);


            objsqlconn.Open();
            results = objCmd.ExecuteNonQuery();
            objsqlconn.Close();
            return results;



        }

    }
}

