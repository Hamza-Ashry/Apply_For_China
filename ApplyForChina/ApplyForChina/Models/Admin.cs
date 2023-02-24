using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Admin
    {
        public int ADM_ID { get; set; }
        public string ADM_Username { get; set; }
        public string ADM_Password { get; set; }
        public short ADM_Role { get; set; }
    }
}