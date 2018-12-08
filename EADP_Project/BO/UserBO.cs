using EADP_Project.DAO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.BO
{
    public class UserBO
    {
        public user login_validation(String user_ID, String password)
        {
            user obj = new user();
            userDAO userdao = new userDAO();
            obj = userdao.getUserById(user_ID);
            if(obj == null)
            {
                return null; //user does not exist
            }
            else
            {
                if (obj.password == password)
                {
                    return obj; //user pass login
                }
                else
                {
                    return null; //user fail login
                }
            }
        }
        public user getUserById(String user_ID)
        {
            user obj = new user();
            userDAO userdao = new userDAO();
            obj = userdao.getUserById(user_ID);
            if (obj == null)
            {
                return null; //user does not exist
            }
            else
            {
                return obj;
            }
        }
        public List<String> getTeachersTeachingClasses(String user_ID)
        {
            List<String> obj = new List<String>();
            userDAO userdao = new userDAO();
            obj = userdao.getTeachersTeachingClasses(user_ID);
            return obj;
        }

        public void updatePwd(String user_ID, String pwd)
        {
            userDAO userdao = new userDAO();
            userdao.updatePwd(user_ID, pwd);
        }
        public void updateEmail(String user_ID, String email)
        {
            userDAO userdao = new userDAO();
            userdao.updateEmail(user_ID, email);
        }
        public List<user> retrieveClassListBySchoolAndClass(String school, String edu_class)
        {
            userDAO userdao = new userDAO();
            return userdao.retrieveClassListBySchoolAndClass(school, edu_class);
        }
    }
}