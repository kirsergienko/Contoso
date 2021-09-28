﻿using Contoso.Models;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Contoso
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            Database.SetInitializer(new MyDbInitializer());
            using MyDbContext db = new MyDbContext();
            db.Database.Initialize(true);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
