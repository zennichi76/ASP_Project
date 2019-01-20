using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{
    public class accessLogItem
    {
        public string ip { get; set; }
        public DateTime accessTime { get; set; }
        
        public accessLogItem()
        {

        }
        public accessLogItem(string ip, DateTime accessTime)
        {
            this.ip = ip;
            this.accessTime = accessTime;
        }
    }
}