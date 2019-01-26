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


        public string sendmail(string email_to, string msg_subject, string msg_body)
        {
            try
            {
                MailMessage mailmessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                mailmessage.Subject = msg_subject;
                mailmessage.Body = msg_body;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("zzen2461@gmail.com", "fqrppqguauyjwlis");
                
                mailmessage.From = new MailAddress("zzen2461@gmail.com");
                mailmessage.To.Add(email_to);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailmessage);
                return "true";
            }catch(Exception e)
            {
                return e.Message;
            }
            
        }
    }
}