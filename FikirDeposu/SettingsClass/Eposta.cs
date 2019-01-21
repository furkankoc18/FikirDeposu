using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FikirDeposu.SettingsClass
{
    public class Eposta
    {
        public static bool Gonder(string konu, string mesaj, string gidecekEposta)
        {
            try
            {
                MailMessage eposta = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                string gonderenEposta = "info@abdullahfurkankoc.com";
                string gonderenSifre = "Furkan1996";

                smtp.Credentials = new System.Net.NetworkCredential(gonderenEposta, gonderenSifre);
                smtp.Port = 587;
                smtp.Host = "mail.abdullahfurkankoc.com";
                smtp.EnableSsl = false;

                eposta.IsBodyHtml = true;
                eposta.From = new MailAddress(gonderenEposta);
                eposta.To.Add(gidecekEposta);
                eposta.Subject = konu;
                eposta.Body = mesaj;

                smtp.Send(eposta);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}