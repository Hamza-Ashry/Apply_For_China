using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Order
    {
		public long ORD_ID { set; get; }
		public string ORD_Code { set; get; }
		public DateTime ORD_Date { set; get; }
		public string ORD_State { set; get; }
		public string ORD_Passport_sized_Photo { set; get; }
		public string ORD_PassportID_Page { set; get; }
		public string ORD_Academic_Transcripts { set; get; }
		public string ORD_Highest_Degree { set; get; }
		public string ORD_Foreigner_Physical { set; get; }
		public string ORD_Non_criminal { set; get; }
		public string ORD_Chinese_Lang { set; get; }
		public string ORD_University_App { set; get; }
		public string ORD_Guarantee_Letter { set; get; }
		public string ORD_Residence_Permit { set; get; }
		public string ORD_StudyCertificateInChina { set; get; }
		public string ORD_Others { set; get; }
		public long ORD_STD_ID { set; get; }
		public int ORD_USR_ID { set; get; }
		public string STD_Name { set; get; }
		public string USR_Username { set; get; }
		public float ORD_Total { set; get; }
		public IEnumerable<Application> ORD_Apps { set; get; }
		
		public bool ShouldSerializeSTD_Name()
		{
			return STD_Name != null;
		}
		public bool ShouldSerializeUSR_Username()
		{
			return USR_Username != null;
		}
		public bool ShouldSerializeORD_Total()
		{
			return ORD_Total != 0;
		}
		public bool ShouldSerializeORD_Apps()
		{
			return ORD_Apps != null;
		}
	}
}