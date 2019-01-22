using FikirDeposu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikirDeposu.Controllers
{
    public class IdeaController : Controller
    {
        Context db = new Context();
        public ActionResult IdeaAdd()
        {
            return View();
        }

        public string AddIdea(Ideas idea)
        {
            UserDetails user;
            if (Session["firstLoggedInUser"] != null)
            {
                user =(UserDetails) Session["firstLoggedInUser"];
            }else
            {
                user = (UserDetails)Session["loggedInUser"];
            }
            UserDetails dbUser = db.UserDetails.Where(x => x.email == user.email).SingleOrDefault();
            idea.ideaDate = DateTime.Now;
            idea.number = new Random().Next(0, 100);
            idea.isActive = true;
            dbUser.Ideas.Add(idea);
            db.Ideas.Add(idea);
            db.SaveChanges();

            return "success";
        }

    }
}