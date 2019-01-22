using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
namespace FikirDeposu
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //GlobalConfiguration.Configuration.Formatters
            //        .JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling
            //        = ReferenceLoopHandling.Ignore;
        }
    }
}
