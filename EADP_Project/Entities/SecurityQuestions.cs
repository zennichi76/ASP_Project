using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{


    public class SecurityQuestions
    {
        public String User_ID { get; set; }
        public Byte[] firstSecurityQ { get; set; }
        public String firstSecurityQA { get; set; }
        public Byte[] secondSecurityQ { get; set; }
        public String secondSecurityQA { get; set; }
        public Byte[] thirdSecurityQ { get; set; }
        public String thirdSecurityQA { get; set; }

        
        

    }
}