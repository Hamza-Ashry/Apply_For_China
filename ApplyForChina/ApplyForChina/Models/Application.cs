using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Application
    {
        public long APP_ID { set; get; }
        public string APP_Code { set; get; }
        public long APP_PRG_ID { set; get; }
        public long APP_ORD_ID { set; get; }
        public string PFS_FeeStructure { set; get; }
        public float PFS_Price { set; get; }

        public bool ShouldSerializePFS_FeeStructure()
        {
            return PFS_FeeStructure != null;
        }
        public bool ShouldSerializePFS_Price()
        {
            return PFS_Price != 0;
        }
    }
}