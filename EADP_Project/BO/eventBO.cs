using EADP_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EADP_Project.Entities;

namespace EADP_Project.Business_Layer
{
    public class eventBO
    {
        public eventDAO objevent = new eventDAO();

        //get num of participants
        public events getNumParticipants(int eventId)
        {

            events result = null;


            result = objevent.getNumberOfParticipant(eventId);

            return result;
         
        }
        
        //prevent user to rejoining the event they have joined
        public bool checkIfParticipantExist(int eventId, String participatorId)
        {



            return  objevent.checkIfParticipantHasSignUp(eventId, participatorId);

        }

        //get event details
        public events GetEventById(int eventId)
        {
            events result = null;


            result = objevent.GetEventById(eventId);
            
            return result;
        }

        //add event
        public String insertEvent(String eventName, String eventSDate, String eventEDate, String eventSTime, String eventETime,
            String eventDescription, int maxCapacity, int CcaPoints, int Orion_Points, String user_Id)
        {
            string result = "";
            if(result == "")
            {
                objevent.insertEvent(eventName, eventSDate, eventEDate, eventSTime, eventETime, eventDescription, maxCapacity, CcaPoints, Orion_Points, user_Id);
            }
            else
            {
                result = "Error";
            }
            

            return ""; //successful
        }

        //update
        public String updateEvent(String eventName, String eventSDate, String eventEDate, String eventSTime, String eventETime,
            String eventDescription, int maxCapacity, int CcaPoints, int Orion_Points, int eventId, String user_Id)
        {
            string result = "";
            if(result == "")
            {
                objevent.updateEvent(eventName, eventSDate, eventEDate, eventSTime, eventETime, eventDescription, maxCapacity, CcaPoints, Orion_Points, eventId,user_Id);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        //load event based on user id(creator)
        public List<events>loadEvent(String User_Id)
        {

            List<events> tempeventList = new List<events>();

            tempeventList = objevent.getEventList(User_Id);

            return tempeventList;

        }

        //load all event into the viewAll event page
        public List<events> loadAllEvent()
        {

            List<events> tempAlleventList = new List<events>();

            tempAlleventList = objevent.LoadAllEventList();

            return tempAlleventList;

        }
        

        //to details of student to assign points to(can remove)
        public events ListOfStudentToAddPoints(int eventId, String creatorId)
        {
            events result = null;


            result = objevent.DetailsToAllocatePoints(eventId, creatorId);

            return result;
        }

 

        public List<events> getAttendanceList(int eventId, String creatorId)
        {
            List<events> getAttendanceList = new List<events>();


            getAttendanceList = objevent.getAttendanceList(eventId, creatorId);
            return getAttendanceList;
        }

        //load participatorlist  in gv 
        public List<events> loadParticipatorList(String creatorId)
        {

            List<events> tempParticipatorList = new List<events>();

            tempParticipatorList = objevent.getParticipatorList(creatorId);

            return tempParticipatorList;

        }


        //student sign up
        public String signUpEvent(int eventId, String eventName, String eventSDate, String eventEDate, String eventSTime, String eventETime,
            String eventDescription, string participatorId,int CCAPoints, int Orion_Points, String creatorId)
        {
            string result = "";
            if (result == "")
            {
                objevent.signUpEvent(eventId, eventName, eventSDate, eventEDate, eventSTime, eventETime, eventDescription, participatorId,CCAPoints,Orion_Points,creatorId);
            }
            else
            {
                result = "Error";
            }


            return ""; //successful
        }

        //student sign up grid
        public List<events> loadSignUpEvent(String participatorId)
        {

            List<events> tempSignUpeventList = new List<events>();

            tempSignUpeventList = objevent.getsignUpEventList(participatorId);

            return tempSignUpeventList;

        }

        //for event details
        public events GetEventByParticipatorId(int eventId , String participatorId)
        {
            events result = null;


            result = objevent.GetEventJoinedById(eventId, participatorId);

            return result;
        }

        //give points to student
        public void givePoints(String participatorId, int CCAPoints, int Orion_Points)
        {
            string result = "";
            if (result == "")
            {
                objevent.givePoints(participatorId, CCAPoints, Orion_Points);
            }
            else
            {
                result = "Error";
            }

            
        }

        // un join event
        public String unjoinEvent(String participatorId, int eventId)
        {
            string result = "";
            if (result == "")
            {
                objevent.unjoinEvent(participatorId,eventId);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        //set status as assigned
        public String showPointedAreAllocated(String status, String participatorId, String creatorId)
        {
            string result = "";
            if (result == "")
            {
                objevent.setStatus(status, participatorId, creatorId);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

      
        }

    }
