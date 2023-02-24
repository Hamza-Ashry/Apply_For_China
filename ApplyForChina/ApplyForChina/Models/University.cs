using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class University
    {
		public long UNV_ID { get; set; }
		public string UNV_Image { get; set; }
		public string UNV_BG_Image { get; set; }
		public string UNV_Overview { get; set; }
		public string UNV_Name { get; set; }
		public string UNV_City { get; set; }
		public int UNV_Found_in { get; set; }
		public short UNV_UNVT_ID { get; set; }
		public int UNV_NoOfTotalStudents { get; set; }
		public int UNV_NoOfInternationalStudents { get; set; }
		public int UNV_NoOfFaculty { get; set; }
		public string UNV_About { get; set; }
		public int UNV_ScholarShip_Rank { get; set; }
		public int UNV_World_Rank { get; set; }
		public int UNV_ARWU_Rank { get; set; }
		public string UNV_Advantages { get; set; }
		public int UNV_NoofPrograms { get; set; }
	}
}