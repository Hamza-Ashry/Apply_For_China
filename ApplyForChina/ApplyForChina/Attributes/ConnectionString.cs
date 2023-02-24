using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ApplyForChina.Attributes
{
    public class ConnectionString
    {
        public static string ConStr()
        {
            return ConfigurationManager.ConnectionStrings["ApplyForChina"].ConnectionString;
        }
    }
}