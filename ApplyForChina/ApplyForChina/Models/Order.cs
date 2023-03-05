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
		public string ORD_Passport_sized_Photo { get; set; }
		public string ORD_PassportID_Page { get; set; }
		public string ORD_Academic_Transcripts { get; set; }
		public string ORD_Highest_Degree { get; set; }
		public string ORD_Foreigner_Physical { get; set; }
		public string ORD_Non_criminal { get; set; }
		public string ORD_Chinese_Lang { get; set; }
		public string ORD_University_App { get; set; }
		public string ORD_Guarantee_Letter { get; set; }
		public string ORD_Residence_Permit { get; set; }
		public string ORD_StudyCertificateInChina { get; set; }
		public string ORD_Others { get; set; }
		public long ORD_STD_ID { get; set; }
		public int ORD_USR_ID { get; set; }
	}
}