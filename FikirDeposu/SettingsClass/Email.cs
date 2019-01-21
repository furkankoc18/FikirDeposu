using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FikirDeposu.SettingsClass
{
    public class Email
    {
        public static bool EmailSender(string subject, string message, string sendEmail)
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                string gonderenEposta = "info@abdullahfurkankoc.com";
                string gonderenSifre = "Furkan1996";

                smtp.Credentials = new System.Net.NetworkCredential(gonderenEposta, gonderenSifre);
                smtp.Port = 587;
                smtp.Host = "mail.abdullahfurkankoc.com";
                smtp.EnableSsl = true;

               email.IsBodyHtml = true;
               email.From = new MailAddress(gonderenEposta);
               email.To.Add(sendEmail);
               email.Subject = subject;
                email.Body = message;

                smtp.Send(email);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}