using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class FeedBack
    {
        public long FDB_ID { set; get; }
        public string FDB_Feed { set; get; }
        public string FDB_File { set; get; }
        public bool FDB_IsViewed { set; get; }
        public int FDB_USR_ID { set; get; }
    }
}