using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Hot_Program
    {
        public int PHOT_ID { set; get; }
        public int PHOT_PRG_ID { set; get; }
        public List<int> PHOT_PRG_IDs { set; get; }

        public bool ShouldSerializePHOT_ID()
        {
            return PHOT_ID != 0;
        }

        public bool ShouldSerializePHOT_PRG_ID()
        {
            return PHOT_PRG_ID != 0;
        }

        public bool ShouldSerializePHOT_PRG_IDs()
        {
            return PHOT_PRG_IDs != null;
        }
    }
}