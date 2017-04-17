using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wop.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Data.Entity;
using System.Web.Routing;

namespace Wop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new StikDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
