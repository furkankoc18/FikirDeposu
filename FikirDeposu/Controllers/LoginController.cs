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
            UserDetails user = db.UserDetails.Where(x => x.email == email && x.password == password).SingleOrDefault();
            if (user != null)
            {
                if (user.isActive == true)
                {
                    Session["loggedInUser"] = user;
                    Session["firstLoggedInUser"] = null;
                    return "successLogin";
                }
                else
                {
                    return "hata";

                }
            }
            else
            {
                return "hata";
            }
        }

        public string UserRegister(UserDetails user)
        {
            UserDetails userDb = db.UserDetails.Where(x => x.email == user.email).SingleOrDefault();
            if (userDb != null)
            {
                //bu mail adresinde kullanıcı var
                return "error";
            }else
            {
                string confirmationGuid = Guid.NewGuid().ToString();
                string verifyUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                                   "/Account/Verify?Id=" +
                                   confirmationGuid + "?email=" + user.email;

                string bodyMessage = string.Format("Üyeliğiniz başarıyla oluşturulmuştur. Aşağıdaki linke tıkladığınızda hesabınızın aktif olacaktır.\n");
                bodyMessage += verifyUrl;


                user.registerDate = DateTime.Now;
                user.isActive = false;
                db.UserDetails.Add(user);
                db.SaveChanges();
                Email.EmailSender("FikirDeposu Register Subject", bodyMessage, user.email);
                return "success";
            }

        }

       
        

    }
}