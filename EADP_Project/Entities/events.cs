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


        }

     

      




    }



