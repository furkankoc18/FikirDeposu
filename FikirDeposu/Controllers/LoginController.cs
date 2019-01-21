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

    }
}