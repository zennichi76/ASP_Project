using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{
    public class securityQn
    {
        public byte[] qn { get; set; }
        public string answ { get; set; }

        public securityQn()
        {

        }
        public securityQn(byte[] qn, string answ)
        {
            this.qn = qn;
            this.answ = answ;
        }
    }
}