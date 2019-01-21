using EADP_Project.DAO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EADP_Project.BO
{
    public class UserBO
    {
        public user login_validation(string user_ID, string password)
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
                Crypto_BO crpyto = new Crypto_BO();
                bool password_correct = crpyto.password_compare(user_ID, password, obj.salt, obj.password);
                if (password_correct)//obj.password == password)
                {
                    return obj; //user pass login
                }
                else
                {
                    return null; //user fail login
                }
            }
        }
        public user getUserById(string user_ID)
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

        public List<accessLogItem> getAccessLogById(string user_ID)
        {
            List<accessLogItem> obj = new List<accessLogItem>();
            userDAO userdao = new userDAO();
            obj = userdao.getAccessLogById(user_ID);
            return obj;
        }

        public List<string> getTeachersTeachingClasses(string user_ID)
        {
            List<string> obj = new List<string>();
            userDAO userdao = new userDAO();
            obj = userdao.getTeachersTeachingClasses(user_ID);
            return obj;
        }
        public void addNewLoginLog(string user_ID)
        {
            userDAO userdao = new userDAO();
            userdao.log_login_operation(user_ID);
        }
        public void updatePwd(string user_ID, string pwd)
        {
            string salt;
            Crypto_BO crypto = new Crypto_BO();
            crypto.password_crypto(user_ID, pwd);
            pwd = crypto.hashedPassword;
            salt = crypto.salt;
            userDAO userdao = new userDAO();
            userdao.updatePwd(user_ID, pwd, salt);
        }
        public void activate2FA(string user_ID, string key)
        {
            userDAO userdao = new userDAO();
            userdao.activate2FA(user_ID, key);
        }
        public void deactivate2FA(string user_ID)
        {
            userDAO userdao = new userDAO();
            userdao.deactivate2FA(user_ID);
        }
        public void updateEmail(string user_ID, string email)
        {
            userDAO userdao = new userDAO();
            userdao.updateEmail(user_ID, email);
        }
        public List<user> retrieveClassListBySchoolAndClass(string school, string edu_class)
        {
            userDAO userdao = new userDAO();
            return userdao.retrieveClassListBySchoolAndClass(school, edu_class);
        }

        public DataTable getUserInfo(string selectedUser)
        {
            userDAO userinfodao = new userDAO();
            return userinfodao.getUserInfo(selectedUser);
        }
    }
}