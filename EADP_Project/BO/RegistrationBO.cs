using EADP_Project.DAO;
using EADP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project.BO
{
    public class RegistrationBO
    {
        public RegistrationDAO objRegister = new RegistrationDAO();
        /*school_ID, education_level, education_class*/
        public String insertUser(String User_ID, String password, String name, String email, String confirmEmail, String role)
        {
            string result = "";
            if (result == "")
            {
                string salt;
                Crypto_BO crypto = new Crypto_BO();
                crypto.password_crypto(User_ID, password);
                password = crypto.hashedPassword;
                salt = crypto.salt;
                objRegister.UserRegistration(User_ID, password, salt, name, email, confirmEmail, role);
            }
            else
            {
                result = "Error";
            }


            return ""; //successful
        }

        public String insertSQ(String User_ID, Byte[] firstSecurityQ, String firstSecurityQA, Byte[] secondSecurityQ, String secondSecurityQA, Byte[] thirdSecurityQ, String thirdSecurityQA)
        {
            string result = "";
            if (result == "")
            {
                objRegister.insertSecurityQuestions(User_ID, firstSecurityQ, firstSecurityQA, secondSecurityQ, secondSecurityQA, thirdSecurityQ , thirdSecurityQA);
            }
            else
            {
                result = "Error";
            }


            return ""; //successful
        }

        //retrieve sq
        public SecurityQuestions GetSQById(String user_Id)
        {
            SecurityQuestions result = null;
            result = objRegister.getSecurityQuestion(user_Id);
            return result;

        }


    }
}