using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{
    public class ConsentForm
    {
        public int ConsentFormID { get; set; }
        public String SenderID { get; set; }
        public String RecievingClasses { get; set; }
        public String School { get; set; }
        public String FormStatus { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String FoodPreferrence { get; set; }
        public ConsentForm()
        {

        }
    }
}