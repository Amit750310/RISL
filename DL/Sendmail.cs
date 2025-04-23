using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace DL
{
    public class Sendmail
    {
        public bool Sendemail(string mailid, string subjectline, string body, string cc)
        {
            try
            {
                System.Net.Mail.MailMessage Mail = new System.Net.Mail.MailMessage();
                Mail.Subject = subjectline.ToString();
                Mail.From = new MailAddress("flex-u@uflexltd.com");

                Mail.To.Add(mailid.ToString());
                if (cc != "")
                {
                    Mail.CC.Add(cc);
                }
                Mail.IsBodyHtml = true;
                Mail.Body = body.ToString();
                System.Net.Mail.SmtpClient smtp = new SmtpClient();
                smtp.Port = 25;
               // smtp.Host = "smtp.gmail.com";
                smtp.Host = "smtp.mail.uflexltd.com";
                smtp.Credentials = new System.Net.NetworkCredential("flex-u@uflexltd.com", "flex2145");

                smtp.EnableSsl = false;
                smtp.Send(Mail);
                return true;
            }

            catch
            {
                return false;
            }

        }
        public bool Receivemailcar(string mailid, string subjectline, string body)
        {
            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress(mailid.ToString());
                msg.To.Add("flex-u@uflexltd.com");
                msg.IsBodyHtml = true;
                msg.Body = body.ToString();
                System.Net.Mail.SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                msg.Priority = MailPriority.High;
                smtp.Credentials = new System.Net.NetworkCredential("flex-u@uflexltd.com", "flex2145");
                smtp.EnableSsl = true;
                smtp.Send(msg);
                return true;
            }

            catch
            {
                return false;
            }

        }
       
    }
}
