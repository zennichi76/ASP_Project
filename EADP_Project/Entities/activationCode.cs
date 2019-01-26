using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{
    public class activationCode
    {

        public string email { get; set; }
        public string confirmEmail { get; set; }
        public string ActivationCode { get; set; }
        public DateTime codeSDate { get; set; }
        public DateTime codeEDate { get; set; }
        public string Name { get; set; }
        public string userId { get; set; }
    }
}