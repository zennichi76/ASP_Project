using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EADP_Project.BO
{
    public class Crypto_BO
    {
        public string password_crypto(string username, string password)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[8];

            rng.GetBytes(saltByte);
            string salt = Convert.ToBase64String(saltByte);

            SHA512Managed hashing = new SHA512Managed();

            string pwdWithSalt = username + password + salt;
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

            return Convert.ToBase64String(hashWithSalt);

        }

        public bool password_compare(string hashedPassword, string databasePassword)
        {
            if (hashedPassword == databasePassword)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}