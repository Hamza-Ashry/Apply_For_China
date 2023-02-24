using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Program
    {
		public long PRG_ID { get; set; }
		public string PRG_Image { get; set; }
		public string PRG_Name { get; set; }
		public string PRG_Program_Code { get; set; }
		public short PRG_SST_ID { get; set; }
		public float PRG_Old_Price { get; set; }
		public float PRG_New_Price { get; set; }
		public string PRG_Intake { get; set; }
		public int PRG_Year { set; get; }
		public string PRG_Degree { get; set; }
		public string PRG_Teaching_Languages { get; set; }
		public string PRG_Field { get; set; }
		public DateTime PRG_Expired_date { get; set; }
		public float PRG_Duration { get; set; }
		public string PRG_Policy { get; set; }
		public string PRG_Requerments { get; set; }
		public string PRG_Special_Notes{ get; set; }
		public bool PRG_IsExpired  { get; set; }
		public long PRG_UNV_ID { get; set; }
	}
}