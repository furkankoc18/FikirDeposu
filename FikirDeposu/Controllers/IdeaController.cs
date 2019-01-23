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

        public string UpdateIdea(int ideaID,string name,string description,string status)
        {
            Ideas idea = db.Ideas.Where(x => x.ideaID == ideaID && x.isActive==true).SingleOrDefault();
            idea.name = name;
            idea.description = description;
            idea.status = status;
            db.SaveChanges();
            return "success";
        }
        public string CloseIdea(int ideaID)
        {
            Ideas idea = db.Ideas.Where(x => x.ideaID == ideaID).SingleOrDefault();
            idea.isActive = false;
            db.SaveChanges();

            return "success";
        }

    }
}