using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Message
    {
        public long MSG_ID { set; get; }
        public string MSG_Message { set; get; }
        public string MSG_File { set; get; }
        public long MSG_FDB_ID { set; get; }
    }
}