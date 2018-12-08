using EADP_Project.DataLayer;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EADP_Project.Business_Layer
{
    public class requestBO
    {
        public requestDAO objRequest = new requestDAO();

        //load request when user is the requester
        public List<requestEntity> loadRequestToMe(String requestTo)
        {

            List<requestEntity> tempRequestList = new List<requestEntity>();

            tempRequestList = objRequest.getTeachSessionList(requestTo);

            return tempRequestList;

        }
        //load request when user is the requestee
        public List<requestEntity> loadRequestByMe(String requestBy)
        {

            List<requestEntity> tempRequestByMeList = new List<requestEntity>();

            tempRequestByMeList = objRequest.getRequestByMeSessionList(requestBy);

            return tempRequestByMeList;

        }

        //send request
        public String sendRequest(String requestDetails, String requestTo, String requestBy,String status)
        {
            string result = "";
            if (result == "")
            {
                objRequest.sendRequest(requestDetails, requestTo, requestBy, status);
            }
            else
            {
                result = "Error";
            }


            return ""; //successful
        }

        //get request to me
        public requestEntity getRequestToMeByIdDetails(int requestId, String requestTo)
        {
            requestEntity result = null;


            result = objRequest.RequestToMeByIdDetails(requestId, requestTo);

            return result;
        }

        //get request by me
        public requestEntity getRequestByMeByIdDetails(int requestId, String requestBy)
        {
            requestEntity result = null;


            result = objRequest.RequestByMeByIdDetails(requestId, requestBy);

            return result;
        }

        //accept/reject request
        public String acceptRequest(int requestId, String status)
        {
            string result = "";
            if (result == "")
            {
                objRequest.acceptRequest(requestId, status);
            }
            else
            {
                result = "Error";
            }
                return "";
        }


        //load gridview for all student
        public List<user> loadAllStudent()
        {

            List<user> tempRequestList = new List<user>();

            tempRequestList = objRequest.PriSchList();

            return tempRequestList;

        }

     

        //get students to allocate points for accepting and completing request
        public List<requestEntity> getNumOfSession()
        {

            List<requestEntity> tempTuitionList = new List<requestEntity>();

            tempTuitionList = objRequest.getNumberOfRequestTeach();

            return tempTuitionList;
        }

        public String givePoints(String requestTo, int CCAPoints, int Orion_Points)
        {
            string result = "";
            if (result == "")
            {
                objRequest.givePoints(requestTo, CCAPoints, Orion_Points);
            }
            else
            {
                result = "Error";
            }
            return "";

        }

    }
}