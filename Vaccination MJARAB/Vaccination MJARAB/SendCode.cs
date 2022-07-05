using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class SendCode : ISendMessageEmail
    {
        public void SendMessage(string to, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("your email address", "Vaccination");
            mail.To.Add(to);
            mail.Subject = "کد تایید";
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 25;
            client.Credentials = new NetworkCredential("your email address", "your email password");
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}
