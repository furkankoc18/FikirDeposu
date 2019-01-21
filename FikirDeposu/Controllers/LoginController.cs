using FikirDeposu.Models;
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
            string testEmail = "furkan@gmail.com";
            string testPass = "1";
            if(email==testEmail && testPass == password)
            {
                return "successLogin";
            }
            else
            {
                return "hata";
                //Yanlış Şifre
            }

        }

        public string UserRegister(UserDetails user)
        {
            user.registerDate = DateTime.Now;
            user.isActive = false;
            db.UserDetails.Add(user);
            db.SaveChanges();
            return "";
        }

    }
}