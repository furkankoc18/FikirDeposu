﻿using FikirDeposu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikirDeposu.Controllers
{
    public class UserController : Controller
    {
        Context db = new Context();

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            UserDetails user = (UserDetails)Session["updateUserPassword"];
            if (user == null)
                return RedirectToAction("Login", "User");
            return View();
        }

        public JsonResult GetIdeas(UserDetails user)
        {
            List<IdeaPojo> ideasPojo = new List<IdeaPojo>();
            List<Ideas> ideas = db.Ideas.Where(x=>x.status=="public" && x.isActive==true).ToList();
            UserDetails dbUser = db.UserDetails.Where(x => x.userID == user.userID).SingleOrDefault();
            foreach(var idea in dbUser.Ideas.ToList())
            {
                if(idea.isActive==true && idea.status=="private")
                    ideas.Add(idea);
            }
            foreach(var idea in ideas)
            {
                IdeaPojo obj = new IdeaPojo();
                obj.ideaID = idea.ideaID;
                obj.name = idea.name;
                obj.isActive = idea.isActive;
                obj.ideaDate = idea.ideaDate;
                obj.description = idea.description;
                obj.clasureDate = idea.clasureDate;
                obj.number = idea.number;
                obj.userID = idea.userID;
                obj.status = idea.status;
                obj._event = idea._event;
                ideasPojo.Add(obj);
                
            }
            var json = JsonConvert.SerializeObject(ideasPojo);
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserIdeas(string type,UserDetails user)
        {
            if (type == "all")
            {
                return GetIdeas(user);
            }else
            {
                List<IdeaPojo> ideasPojo = new List<IdeaPojo>();
                List<Ideas> ideas = db.Ideas.Where(x => x.userID==user.userID).ToList();
                foreach (var idea in ideas)
                {
                    IdeaPojo obj = new IdeaPojo();
                    obj.ideaID = idea.ideaID;
                    obj.name = idea.name;
                    obj.isActive = idea.isActive;
                    obj.ideaDate = idea.ideaDate;
                    obj.description = idea.description;
                    obj.clasureDate = idea.clasureDate;
                    obj.number = idea.number;
                    obj.userID = idea.userID;
                    obj.status = idea.status;
                    obj._event = idea._event;
                    ideasPojo.Add(obj);
                }
                var json = JsonConvert.SerializeObject(ideasPojo);
                return Json(json,JsonRequestBehavior.AllowGet);
            }
        }
    }
}