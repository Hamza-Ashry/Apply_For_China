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

		public bool ShouldSerializeUNV_Image()
        {
			return UNV_Image != null;
		}
		public bool ShouldSerializeUNV_BG_Image()
		{
			return UNV_BG_Image != null;
		}
		public bool ShouldSerializeUNV_Overview()
		{
			return UNV_Overview != null;
		}
		public bool ShouldSerializeUNV_City()
		{
			return UNV_City != null;
		}
		public bool ShouldSerializeUNV_Found_in()
		{
			return UNV_Found_in != 0;
		}
		public bool ShouldSerializeUNV_UNVT_ID()
		{
			return UNV_UNVT_ID != 0;
		}
		public bool ShouldSerializeUNV_NoOfTotalStudents()
		{
			return UNV_NoOfTotalStudents != 0;
		}
		public bool ShouldSerializeUNV_NoOfInternationalStudents()
		{
			return UNV_NoOfInternationalStudents != 0;
		}
		public bool ShouldSerializeUNV_NoOfFaculty()
		{
			return UNV_NoOfFaculty != 0;
		}
		public bool ShouldSerializeUNV_About()
		{
			return UNV_About != null;
		}
		public bool ShouldSerializeUNV_ScholarShip_Rank()
		{
			return UNV_ScholarShip_Rank != 0;
		}
		public bool ShouldSerializeUNV_World_Rank()
		{
			return UNV_World_Rank != 0;
		}
		public bool ShouldSerializeUNV_ARWU_Rank()
		{
			return UNV_ARWU_Rank != 0;
		}
		public bool ShouldSerializeUNV_Advantages()
		{
			return UNV_Advantages != null;
		}
		public bool ShouldSerializeUNV_NoofPrograms()
		{
			return UNV_NoofPrograms != 0;
		}

	}
}