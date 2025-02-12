﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UpworkTask.Helpers;
using UpworkTask.Infrastructure;

namespace UpworkTask
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // register DI
            DIBuilder.RegisterAutofac();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            EfConfiguration.Configure();
        }
    }
}
