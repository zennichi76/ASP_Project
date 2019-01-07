using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.Entities
{
    public class user
    {
        public String User_ID { get; set; }
        public String salt { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String role { get; set; }
        public String school { get; set; }
        public String teaching_classes { get; set; }
        public String schedule { get; set; }
        public String staff_type { get; set; }
        public String child_ID { get; set; }
        public String education_level { get; set; }
        public String education_class { get; set; }
        public int orion_point { get; set; }
        public int cca_point { get; set; }
        public user() { }
        public user(String User_ID, String password, String salt, String name, String email, String role, String school_ID, String teaching_classes, String schedule, String staff_type, String child_ID, String education_level, String education_class, int orion_point, int cca_point)
        {
            this.User_ID = User_ID;
            this.salt = salt;
            this.password = password;
            this.name = name;
            this.email = role;
            this.school = school_ID;
            this.teaching_classes = teaching_classes;
            this.schedule = schedule;
            this.staff_type = staff_type;
            this.child_ID = child_ID;
            this.education_level = education_level;
            this.education_class = education_class;
            this.orion_point = orion_point;
            this.cca_point = cca_point;
        }
    }
}