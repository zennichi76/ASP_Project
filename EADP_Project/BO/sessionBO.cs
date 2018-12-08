using EADP_Project.DataLayer;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Business_Layer
{
    public class sessionBO
    {

        public sessionDAO objSession = new sessionDAO();

        //load All tution session
        public List<tutionEntities> loadAllTuition()
        {
            List<tutionEntities> tempTuitionList = new List<tutionEntities>();

            tempTuitionList = objSession.LoadAllTutionSession();

            return tempTuitionList;
        }

        //Tutor CRUD
        //insert into tutor Db (mean student as tutor)
        public String insertSession(String sessionDetails, String sessionDate, String sessionSTime, String sessionETime, String status, String tutorId)
        {
            string result = "";
            if (result == "")
            {
                objSession.createTeachingSession(sessionDetails, sessionDate, sessionSTime, sessionETime, status ,tutorId);
            }
            else
            {
                result = "Error";
            }


            return ""; //successful
        }

        //retrieve session that user is tutor
        public List<tutionEntities> loadTuition(String tutorId)
        {
            List<tutionEntities> tempTuitionList = new List<tutionEntities>();

            tempTuitionList = objSession.getTeachSessionList(tutorId);

            return tempTuitionList;
        }

        public List<tutionEntities> loadJoinedTuition(String tuteeId)
        {
            List<tutionEntities> tempTuitionList = new List<tutionEntities>();

            tempTuitionList = objSession.getJoinedSessionList(tuteeId);

            return tempTuitionList;
        }

        public tutionEntities GetTuitionById(int sessionId)
        {
            tutionEntities result = null;


            result = objSession.GetTuitionById(sessionId);

            return result;
        }

        public tutionEntities GetSessionJoinedById(int SessionID, String tuteeId)
        {
            tutionEntities result = null;


            result = objSession.GetSesionJoinedById( SessionID, tuteeId);

            return result;
        }

        public string unjoin(String tuteeId, int sessionId)
        {
            string result = "";
            if (result == "")
            {
                objSession.unjoinSession(tuteeId,sessionId);
            }
            else
            {
                result = "Error";
            }

            return "";
        }


        public String updateSession(int sessionId, String sessionDetails, String sessionDate, String sessionSTime, String sessionETime, String status, String tutorId)
        {
            string result = "";
            if (result == "")
            {
                objSession.updateSession(sessionId,sessionDetails,sessionDate,sessionSTime,sessionETime, status ,tutorId);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        //TUTEE

        //sign up tution
        public String signUpTution(String tuteeId, String tutorId, int sessionId)
        {
            string result = "";
            if (result == "")
            {
                objSession.signUpTuition(tuteeId, tutorId,sessionId);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        public List<tutionEntities> getNumOfSession()
        {

            List<tutionEntities> tempTuitionList = new List<tutionEntities>();

            tempTuitionList = objSession.getNumberOfTutionTeach();

            return tempTuitionList;

        }

        public String givePoints(String tutorId, int CCAPoints, int Orion_Points)
        {
            string result = "";
            if (result == "")
            {
                objSession.givePoints(tutorId, CCAPoints, Orion_Points);
            }
            else
            {
                result = "Error";
            }
            return "";

        }

    }
}