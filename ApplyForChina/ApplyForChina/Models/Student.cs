using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplyForChina.Models
{
    public class Student
    {
        public long STD_ID { set; get; }
        public string STD_SurName { set; get; }
        public string STD_GivenName { set; get; }
        public string STD_Nationality { set; get; }
        public DateTime STD_DOB { set; get; }
        public bool STD_Gender { set; get; }
        public string STD_PassportNo { set; get; }
        public bool STD_SocialState { set; get; }
        public DateTime STD_PassportExDate { set; get; }
        public string STD_Religion { set; get; }
        public string STD_Language { set; get; }
        public string STD_Eduction { set; get; }
        public string STD_Email  { set; get; }
        public string STD_Phone  { set; get; }
        public string STD_WhatsAppNo { set; get; }
        public string STD_PlaceOfBirth { set; get; }
        public string STD_Occupation { set; get; }
        public string STD_Address { set; get; }
        public bool STD_InChinaNow { set; get; }
        public bool STD_StudyInChine { set; get; }
        public int STD_USR_ID { set; get; }
    }
}