using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EADP_Project.Entities
{
    //getters and setters
    public class events
    {
        public int eventId { get; set; }
        public string eventName { get; set; }
        public string eventSDate { get; set; }
        public string eventEDate { get; set; }
        public string eventSTime { get; set; }
        public string eventETime { get; set; }
        public string eventDescription { get; set; }
        public string eventLocation { get; set; }
        public int maxCapacity { get; set; }
        public int participationAmount { get; set; }
        public string participatorId { get; set; }
        public int CcaPoints { get; set; }
        public int Orion_Points { get; set; }
        public string image { get; set; }
        public string userId { get; set; }
        public string creatorId { get; set; }
        public string status { get; set; }

        ////add event 
        //string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();

       

        //public object ExecuteSqlString(string sqlstring)
        //{
        //    SqlConnection objsqlconn = new SqlConnection(DBConnect);
        //    objsqlconn.Open();
        //    DataSet ds = new DataSet();
        //    SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
        //    SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
        //    objAdp.Fill(ds);
        //    return ds;
        //}

        //public int insertEvent(String eventName, DateTime eventSDate, DateTime eventEDate, DateTime eventSTime, DateTime eventETime,
        //    String eventDescription, int maxCapacity, String eventLocation, int CcaPoints, int Orion_Points)
        //{
        //    DataSet ds = new DataSet();
        //    StringBuilder sqlStr = new StringBuilder();
        //    SqlCommand objCmd = new SqlCommand();
        //    int result;

        //    sqlStr.AppendLine("INSERT INTO eventDB (eventName,eventSDate,eventEDate,eventSTime ,eventETime,eventDescription, ");
        //    sqlStr.AppendLine("maxCapacity,eventLocation,CCAPoints,Orion_Points)");
        //    sqlStr.AppendLine("VALUES (@paraEventName,@paraEventSDate, @paraEventEDate, @paraEventSTime,");
        //    sqlStr.AppendLine("@paraEventETime,@paraEventDescription,@paraMaxCapacity,@paraEventLocation,");
        //    //@paraEventLocation,@paraParticipationAmount,");@paraParticipatorId
        //    sqlStr.AppendLine("@paraCCAPoints, @paraOrion_Points)");
  
        //    SqlConnection objsqlconn = new SqlConnection(DBConnect);
        //    objCmd = new SqlCommand(sqlStr.ToString(), objsqlconn);
    
            
        //    //SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
        //    objCmd.Parameters.AddWithValue("@paraEventName", eventName);
        //    objCmd.Parameters.AddWithValue("@paraEventSDate", eventSDate);
        //    objCmd.Parameters.AddWithValue("@paraEventEDate", eventEDate);
        //    objCmd.Parameters.AddWithValue("@paraEventSTime", eventSTime);
        //    objCmd.Parameters.AddWithValue("@paraEventETime", eventETime);
        //    objCmd.Parameters.AddWithValue("@paraEventDescription", eventDescription);
        //    objCmd.Parameters.AddWithValue("@paraEventLocation", eventLocation);
        //    objCmd.Parameters.AddWithValue("@paraMaxCapacity", maxCapacity);
            
        //    //sqlCmd.Parameters.AddWithValue("@paraParticipationAmount", participationAmount);
        //    //sqlCmd.Parameters.AddWithValue("@paraParticipatorId", participatorId);
        //    objCmd.Parameters.AddWithValue("@paraCCAPoints", CcaPoints);
        //    objCmd.Parameters.AddWithValue("@paraOrion_Points", Orion_Points);

            

        //    objsqlconn.Open();
        //    result = objCmd.ExecuteNonQuery();

        //    return result;

        }

     

      




    }



