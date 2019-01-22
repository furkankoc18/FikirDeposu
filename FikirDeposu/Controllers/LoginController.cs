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

        

       
        

    }
}