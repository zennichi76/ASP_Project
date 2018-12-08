using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{
    public class tutionEntities
    {
        public int sessionId { get; set; }
       
        public String sessionDate { get; set; }

        public String sessionSTime { get; set; }
        public String sessionETime { get; set; }
        
        public string SessionDetails { get; set; }
       public string status { get; set; }
        public int sessionRating { get; set; }
        public string tutorId { get; set; }
        public string tuteeId { get; set; }
        public int CcaPoints { get; set; }
        
    }
}