using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Payed_Image
    {
        public long PIMG_ID { get; set; }
        public string PIMG_Image { get; set; }
        public bool PIMG_IsApproved { get; set; }
        public short PIMG_PNL_ID { get; set; }
        public long PIMG_ORD_ID { get; set; }
        public bool PIMG_IsViewed { get; set; }
    }
}