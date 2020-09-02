using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Common
{
    public class Helper
    {
        public static bool SendMail(string to, string subject, string body)
        {
            string From = "dailyexpressnews2018@gmail.com";
            string Password = "den@2018";
          
            MailMessage mm = new MailMessage(From, to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            
            NetworkCredential nc = new NetworkCredential(From, Password);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            try
            {
                smtp.Send(mm);
                return true;
            }
            catch
            {
                return false;
                throw;
            }


        }
    }
}
