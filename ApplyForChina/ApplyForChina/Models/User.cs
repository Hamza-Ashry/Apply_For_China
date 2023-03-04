using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class User
    {
        public int USR_ID { set; get; }
        public string USR_Image { set; get; }
        public string USR_Username { set; get; }
        public string USR_City { set; get; }
        public string USR_Email { set; get; }
        public string USR_Password { set; get; }
        public string USR_Nationality { set; get; }
        public string USR_Phone { set; get; }
        public short USR_ROL_ID { set; get; }
    }
}