using FikirDeposu.Models;
using FikirDeposu.SettingsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikirDeposu.Controllers
{
    public class AccountController : Controller
    {
        Context db = new Context();


        public ActionResult Verify(string id)
        {
            string[] emailSplit = id.Split('=');
            string email = emailSplit[1];

            UserDetails user = db.UserDetails.Where(x => x.email == email).SingleOrDefault();
            if (user != null)
            {
                user.isActive = true;
                db.SaveChanges();
                Session["loggedInUser"] = user;
                return RedirectToAction("Home","User");
            }
            else
            {
                return null;
            }
        }
        public JsonResult FirstVerify()
        {
            UserDetails user = (UserDetails)Session["loggedInUser"];
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public string UserResetPassword(string forgotEmail)
        {
            UserDetails user = db.UserDetails.Where(x => x.email == forgotEmail).SingleOrDefault();
            if (user != null)
            {
                string confirmationGuid = Guid.NewGuid().ToString();
                string forgotUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                                   "/Account/Forgot?Id=" +
                                   confirmationGuid + "?email=" + user.email;

                string bodyMessage = string.Format("Şifreyi sıfırlarmak için aşağıdaki linke tıklayınız\n");
                bodyMessage += forgotUrl;


                Email.EmailSender("FikirDeposu forgot Subject", bodyMessage, forgotEmail);
                return "success";
            }
            else
            {
                return "error";

            }
        }
        string forgotEmail;
        public ActionResult Forgot(string id)
        {
            string[] emailSplit = id.Split('=');
            string email = emailSplit[1];
            forgotEmail = email;
            UserDetails user = db.UserDetails.Where(x => x.email == email).SingleOrDefault();
            if (user != null)
            {
                Session["updateUserPassword"] = user;
                return RedirectToAction("ResetPassword","User");
            }
            else
            {
                return null;
            }
        }
        public string UpdatePassword(string newPassword)
        {
            UserDetails ob = (UserDetails)Session["updateUserPassword"];
            UserDetails user = db.UserDetails.Where(x => x.email == ob.email).SingleOrDefault();
            if (user != null)
            {
                user.password = newPassword;
                db.SaveChanges();
                return "success";
            }else
            {
                return "error";
            }
        }


    }
}