using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

                string gonderenEposta = "info@abdullahfurkankoc.com";// "abdullahfurkan.koc@gmail.com"; //
                string gonderenSifre = "Furkan1996"; //"19961903";//;

              //  smtp.Credentials = new System.Net.NetworkCredential(gonderenEposta, gonderenSifre);
                smtp.Port = 587;// 587;
                smtp.Host = "smtp.abdullahfurkankoc.com";//"smtp.gmail.com";//;
                //smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(gonderenEposta, gonderenSifre);

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