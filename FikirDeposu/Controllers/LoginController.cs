using FikirDeposu.Models;
using FikirDeposu.SettingsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikirDeposu.Controllers
{
    public class LoginController : Controller
    {
        Context db = new Context();
        public string UserLogin(string email,string password)
        {
            string testEmail = "f";
            string testPass = "1";
            if(email==testEmail && testPass == password)
            {
                return "successLogin";
            }
            else
            {
                return "hata";
            }

        }

        public string UserRegister(UserDetails user)
        {


            string confirmationGuid = Guid.NewGuid().ToString();
            string verifyUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                               "/Account/Verify?Id=" +
                               confirmationGuid;

            string bodyMessage = string.Format("üyeliğiniz başarıyla oluşturulmuştur. Aşağıdaki linke tıkladığınızda hesabınızın aktif olacaktır.\n");
            bodyMessage += verifyUrl;


            user.registerDate = DateTime.Now;
            user.isActive = false;
            db.UserDetails.Add(user);
            db.SaveChanges();
            Email.EmailSender("FikirDeposu Register Subject",bodyMessage, user.email);
            return "success";
        }

    }
}