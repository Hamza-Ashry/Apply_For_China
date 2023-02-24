using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Order
    {
		public long ORD_ID { get; set; }
		public string ORD_Code { get; set; }
		public DateTime ORD_Date { get; set; }
		public string ORD_State { get; set; }
		public long ORD_STD_ID { get; set; }
		public int ORD_USR_ID { get; set; }
	}
}