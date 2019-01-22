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
        public String insertUser(String User_ID, String password, String name, String email, String confirmEmail, String role,String activationCode, DateTime codeEDate)
        {
            string result = "";
            if (result == "")
            {
                string salt;
                Crypto_BO crypto = new Crypto_BO();
                crypto.password_crypto(User_ID, password);
                password = crypto.hashedPassword;
                salt = crypto.salt;
                objRegister.UserRegistration(User_ID, password, salt, name, email, confirmEmail, role, activationCode, codeEDate);
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

        //check for existing username
        //prevent user to rejoining the event they have joined
        public bool checkIfUserExist(string User_ID, string email)
        {
            bool result;
            result = objRegister.checkIfUserExist(User_ID, email);

            return result; //true = user no exist. false = user exist
        }

        //UPDATE SQ
        //update
        public String updateSQ(String User_ID, Byte[] firstSecurityQ, String firstSecurityQA, Byte[] secondSecurityQ, String secondSecurityQA, Byte[] thirdSecurityQ, String thirdSecurityQA)
        {
            string result = "";
            if (result == "")
            {
                objRegister.updateSQ(User_ID, firstSecurityQ, firstSecurityQA, secondSecurityQ, secondSecurityQA, thirdSecurityQ, thirdSecurityQA);
            }
            else
            {
                result = "Error";
            }

            return "";
        }

        //check for existing email

        //get activationCode 
        public activationCode getACBasedOnID(string userId)
        {
            activationCode result = null;
            result = objRegister.getActivationCodeBasedOnNRIC(userId);
            return result;

        }

        public string resendCode(String User_ID, String activationCode, DateTime codeEDate)
        {
            string result = "";
            if (result == "")
            {
                objRegister.getNewActivationCode(User_ID, activationCode, codeEDate);
            }
            else
            {
                result = "Error";
            }


            return ""; //successful
        }

        //activate account
        public string activateAccount(String User_ID, String confirmEmail)
        {
            string result = "";
            if (result == "")
            {
                objRegister.ValidateActivationCode(User_ID, confirmEmail);
            }
            else
            {
                result = "Error";
            }


            return ""; //successful
        }

    }
}