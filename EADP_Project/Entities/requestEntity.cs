using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{
    public class requestEntity
    {
        public int requestId { get; set; }
        public string requestDetails { get; set; }
        public string requestTo { get; set; }
        public string requestBy { get; set; }
        public string status { get; set; }
    }
}