using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
//currently not working
namespace EADP_Project.Entities
{

    public class mailService
    {
        private const string SMTP_EMAIL = "username";
        private const string SMTP_PASSWORD = "password";


        public void sendmail()
        {
                MailMessage mailmessage = new MailMessage("zzenzen2461@gmail.com", "zzenzen2461@gmail.com");
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                mailmessage.Subject = "Exception";
                smtpClient.Credentials = new System.Net.NetworkCredential("zzenzen2461@gmail.com", "zenzen24^!");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailmessage);
            
        }
    }
}