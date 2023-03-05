﻿using ApplyForChina.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ApplyForChina
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.Converters.Add(new CustomDateConverter());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
