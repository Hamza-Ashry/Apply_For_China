using ApplyForChina.Attributes;
using ApplyForChina.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_Agent_Students([FromUri] int STD_USR_ID)
        {
            List<Student> stu = new List<Student>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@STD_USR_ID INT', @STD_USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Agent_Students @STD_USR_ID");
            comm.Parameters.AddWithValue("@STD_USR_ID", STD_USR_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    stu.Add(new Student()
                    {
                        STD_ID = long.Parse(reader[0].ToString()),
                        STD_SurName = reader[1].ToString(),
                        STD_GivenName = reader[2].ToString(),
                        STD_Nationality = reader[3].ToString(),
                        STD_DOB = DateTime.Parse(reader[4].ToString()),
                        STD_Gender = bool.Parse(reader[5].ToString()),
                        STD_PassportNo = reader[6].ToString(),
                        STD_SocialState = bool.Parse(reader[7].ToString()),
                        STD_PassportExDate = DateTime.Parse(reader[8].ToString()),
                        STD_Religion = reader[9].ToString(),
                        STD_Language = reader[10].ToString(),
                        STD_Eduction = reader[11].ToString(),
                        STD_Email = reader[12].ToString(),
                        STD_Phone = reader[13].ToString(),
                        STD_WhatsAppNo = reader[14].ToString(),
                        STD_PlaceOfBirth = reader[15].ToString(),
                        STD_Occupation = reader[16].ToString(),
                        STD_Address = reader[17].ToString(),
                        STD_InChinaNow = bool.Parse(reader[18].ToString()),
                        STD_StudyInChine = bool.Parse(reader[19].ToString()),
                        STD_PassportPhoto = reader[20].ToString(),
                        STD_PassportIDPhoto = reader[21].ToString(),
                        STD_AcadimicTransctiptPhoto = reader[22].ToString(),
                        STD_HieghestEduPhoto = reader[23].ToString(),
                        STD_BankStatmentPhoto = reader[24].ToString(),
                        STD_ForeignerExam = reader[25].ToString(),
                        STD_NoCrimimalRecord = reader[26].ToString(),
                        STD_AppForm = reader[27].ToString(),
                        STD_UniversityAppForm = reader[28].ToString(),
                        STD_USR_ID = int.Parse(reader[29].ToString())
                    });
                }

                if (stu.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, stu);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpGet]
        public HttpResponseMessage Get_Student([FromUri] int STD_ID)
        {
            Student stu = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@STD_ID BIGINT', @STD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Student @STD_ID");
            comm.Parameters.AddWithValue("@STD_ID", STD_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while(reader.Read())
                {
                    stu = new Student()
                    {
                        STD_ID = long.Parse(reader[0].ToString()),
                        STD_SurName = reader[1].ToString(),
                        STD_GivenName = reader[2].ToString(),
                        STD_Nationality = reader[3].ToString(),
                        STD_DOB = DateTime.Parse(reader[4].ToString()),
                        STD_Gender = bool.Parse(reader[5].ToString()),
                        STD_PassportNo = reader[6].ToString(),
                        STD_SocialState = bool.Parse(reader[7].ToString()),
                        STD_PassportExDate = DateTime.Parse(reader[8].ToString()),
                        STD_Religion = reader[9].ToString(),
                        STD_Language = reader[10].ToString(),
                        STD_Eduction = reader[11].ToString(),
                        STD_Email = reader[12].ToString(),
                        STD_Phone = reader[13].ToString(),
                        STD_WhatsAppNo = reader[14].ToString(),
                        STD_PlaceOfBirth = reader[15].ToString(),
                        STD_Occupation = reader[16].ToString(),
                        STD_Address = reader[17].ToString(),
                        STD_InChinaNow = bool.Parse(reader[18].ToString()),
                        STD_StudyInChine = bool.Parse(reader[19].ToString()),
                        STD_PassportPhoto = reader[20].ToString(),
                        STD_PassportIDPhoto = reader[21].ToString(),
                        STD_AcadimicTransctiptPhoto = reader[22].ToString(),
                        STD_HieghestEduPhoto = reader[23].ToString(),
                        STD_BankStatmentPhoto = reader[24].ToString(),
                        STD_ForeignerExam = reader[25].ToString(),
                        STD_NoCrimimalRecord = reader[26].ToString(),
                        STD_AppForm = reader[27].ToString(),
                        STD_UniversityAppForm = reader[28].ToString(),
                        STD_USR_ID = int.Parse(reader[29].ToString())
                    };
                }

                if (stu == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, stu);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpPost]
        public HttpResponseMessage Insert_Student([FromBody] Student stu)
        {
            int s = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql," +
                " N'@STD_SurName NVARCHAR(50), @STD_GivenName NVARCHAR(50), @STD_Nationality NVARCHAR(50), @STD_DOB DATE, @STD_Gender BIT, @STD_PassportNo NVARCHAR(10), @STD_SocialState BIT, @STD_PassportExDate DATE, @STD_Religion NVARCHAR(20), @STD_Language NVARCHAR(20), @STD_Eduction NVARCHAR(30), @STD_Email NVARCHAR(50), @STD_Phone NVARCHAR(15), @STD_WhatsAppNo NVARCHAR(15), @STD_PlaceOfBirth NVARCHAR(50), @STD_Occupation NVARCHAR(30), @STD_Address NVARCHAR(50),  @STD_InChinaNow BIT, @STD_StudyInChine BIT, @STD_PassportPhoto NVARCHAR(MAX), @STD_PassportIDPhoto NVARCHAR(MAX), @STD_AcadimicTransctiptPhoto NVARCHAR(MAX), @STD_HieghestEduPhoto NVARCHAR(MAX), @STD_BankStatmentPhoto NVARCHAR(MAX), @STD_ForeignerExam NVARCHAR(MAX), @STD_NoCrimimalRecord NVARCHAR(MAX), @STD_AppForm NVARCHAR(MAX), @STD_UniversityAppForm NVARCHAR(MAX), @STD_USR_ID INT'," +
                " @STD_SurName, @STD_GivenName, @STD_Nationality, @STD_DOB, @STD_Gender, @STD_PassportNo, @STD_SocialState, @STD_PassportExDate, @STD_Religion, @STD_Language, @STD_Eduction, @STD_Email, @STD_Phone, @STD_WhatsAppNo, @STD_PlaceOfBirth, @STD_Occupation, @STD_Address, @STD_InChinaNow, @STD_StudyInChine, @STD_PassportPhoto, @STD_PassportIDPhoto, @STD_AcadimicTransctiptPhoto, @STD_HieghestEduPhoto, @STD_BankStatmentPhoto, @STD_ForeignerExam, @STD_NoCrimimalRecord, @STD_AppForm, @STD_UniversityAppForm, @STD_USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Student @STD_SurName, @STD_GivenName, @STD_Nationality, @STD_DOB, @STD_Gender, @STD_PassportNo, @STD_SocialState, @STD_PassportExDate, @STD_Religion, @STD_Language, @STD_Eduction, @STD_Email, @STD_Phone, @STD_WhatsAppNo, @STD_PlaceOfBirth, @STD_Occupation, @STD_Address, @STD_InChinaNow, @STD_StudyInChine, @STD_PassportPhoto, @STD_PassportIDPhoto, @STD_AcadimicTransctiptPhoto, @STD_HieghestEduPhoto, @STD_BankStatmentPhoto, @STD_ForeignerExam, @STD_NoCrimimalRecord, @STD_AppForm, @STD_UniversityAppForm, @STD_USR_ID");
            comm.Parameters.AddWithValue("@STD_SurName", stu.STD_SurName);
            comm.Parameters.AddWithValue("@STD_GivenName", stu.STD_GivenName);
            comm.Parameters.AddWithValue("@STD_Nationality", stu.STD_Nationality);
            comm.Parameters.AddWithValue("@STD_DOB", stu.STD_DOB);
            comm.Parameters.AddWithValue("@STD_Gender", stu.STD_Gender);
            comm.Parameters.AddWithValue("@STD_PassportNo", stu.STD_PassportNo);
            comm.Parameters.AddWithValue("@STD_SocialState", stu.STD_SocialState);
            comm.Parameters.AddWithValue("@STD_PassportExDate", stu.STD_PassportExDate);
            comm.Parameters.AddWithValue("@STD_Religion", stu.STD_Religion);
            comm.Parameters.AddWithValue("@STD_Language", stu.STD_Language);
            comm.Parameters.AddWithValue("@STD_Eduction", stu.STD_Eduction);
            comm.Parameters.AddWithValue("@STD_Email", stu.STD_Email);
            comm.Parameters.AddWithValue("@STD_Phone", stu.STD_Phone);
            comm.Parameters.AddWithValue("@STD_WhatsAppNo", stu.STD_WhatsAppNo);
            comm.Parameters.AddWithValue("@STD_PlaceOfBirth", stu.STD_PlaceOfBirth);
            comm.Parameters.AddWithValue("@STD_Occupation", stu.STD_Occupation);
            comm.Parameters.AddWithValue("@STD_Address", stu.STD_Address);
            comm.Parameters.AddWithValue("@STD_InChinaNow", stu.STD_InChinaNow);
            comm.Parameters.AddWithValue("@STD_StudyInChine", stu.STD_StudyInChine);
            comm.Parameters.AddWithValue("@STD_PassportPhoto", stu.STD_PassportPhoto);
            comm.Parameters.AddWithValue("@STD_PassportIDPhoto", stu.STD_PassportIDPhoto);
            comm.Parameters.AddWithValue("@STD_AcadimicTransctiptPhoto", stu.STD_AcadimicTransctiptPhoto);
            comm.Parameters.AddWithValue("@STD_HieghestEduPhoto", stu.STD_HieghestEduPhoto);
            comm.Parameters.AddWithValue("@STD_BankStatmentPhoto", stu.STD_BankStatmentPhoto);
            comm.Parameters.AddWithValue("@STD_ForeignerExam", stu.STD_ForeignerExam);
            comm.Parameters.AddWithValue("@STD_NoCrimimalRecord", stu.STD_NoCrimimalRecord);
            comm.Parameters.AddWithValue("@STD_AppForm", stu.STD_AppForm);
            comm.Parameters.AddWithValue("@STD_UniversityAppForm", stu.STD_UniversityAppForm);
            comm.Parameters.AddWithValue("@STD_USR_ID", stu.STD_USR_ID);

            conn.Open();
            try
            {
                s = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Student"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpPut]
        public HttpResponseMessage Update_Student([FromUri] long STD_ID, [FromBody] Student stu)
        {
            int s = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql," +
                " N'@STD_ID BIGINT, @STD_SurName NVARCHAR(50), @STD_GivenName NVARCHAR(50), @STD_Nationality NVARCHAR(50), @STD_DOB DATE, @STD_Gender BIT, @STD_PassportNo NVARCHAR(10), @STD_SocialState BIT, @STD_PassportExDate DATE, @STD_Religion NVARCHAR(20), @STD_Language NVARCHAR(20), @STD_Eduction NVARCHAR(30), @STD_Email NVARCHAR(50), @STD_Phone NVARCHAR(15), @STD_WhatsAppNo NVARCHAR(15), @STD_PlaceOfBirth NVARCHAR(50), @STD_Occupation NVARCHAR(30), @STD_Address NVARCHAR(50),  @STD_InChinaNow BIT, @STD_StudyInChine BIT, @STD_PassportPhoto NVARCHAR(MAX), @STD_PassportIDPhoto NVARCHAR(MAX), @STD_AcadimicTransctiptPhoto NVARCHAR(MAX), @STD_HieghestEduPhoto NVARCHAR(MAX), @STD_BankStatmentPhoto NVARCHAR(MAX), @STD_ForeignerExam NVARCHAR(MAX), @STD_NoCrimimalRecord NVARCHAR(MAX), @STD_AppForm NVARCHAR(MAX), @STD_UniversityAppForm NVARCHAR(MAX), @STD_USR_ID INT'," +
                " @STD_ID, @STD_SurName, @STD_GivenName, @STD_Nationality, @STD_DOB, @STD_Gender, @STD_PassportNo, @STD_SocialState, @STD_PassportExDate, @STD_Religion, @STD_Language, @STD_Eduction, @STD_Email, @STD_Phone, @STD_WhatsAppNo, @STD_PlaceOfBirth, @STD_Occupation, @STD_Address, @STD_InChinaNow, @STD_StudyInChine, @STD_PassportPhoto, @STD_PassportIDPhoto, @STD_AcadimicTransctiptPhoto, @STD_HieghestEduPhoto, @STD_BankStatmentPhoto, @STD_ForeignerExam, @STD_NoCrimimalRecord, @STD_AppForm, @STD_UniversityAppForm, @STD_USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Student @STD_ID, @STD_SurName, @STD_GivenName, @STD_Nationality, @STD_DOB, @STD_Gender, @STD_PassportNo, @STD_SocialState, @STD_PassportExDate, @STD_Religion, @STD_Language, @STD_Eduction, @STD_Email, @STD_Phone, @STD_WhatsAppNo, @STD_PlaceOfBirth, @STD_Occupation, @STD_Address, @STD_InChinaNow, @STD_StudyInChine, @STD_PassportPhoto, @STD_PassportIDPhoto, @STD_AcadimicTransctiptPhoto, @STD_HieghestEduPhoto, @STD_BankStatmentPhoto, @STD_ForeignerExam, @STD_NoCrimimalRecord, @STD_AppForm, @STD_UniversityAppForm, @STD_USR_ID");
            comm.Parameters.AddWithValue("@STD_ID", STD_ID);
            comm.Parameters.AddWithValue("@STD_SurName", stu.STD_SurName);
            comm.Parameters.AddWithValue("@STD_GivenName", stu.STD_GivenName);
            comm.Parameters.AddWithValue("@STD_Nationality", stu.STD_Nationality);
            comm.Parameters.AddWithValue("@STD_DOB", stu.STD_DOB);
            comm.Parameters.AddWithValue("@STD_Gender", stu.STD_Gender);
            comm.Parameters.AddWithValue("@STD_PassportNo", stu.STD_PassportNo);
            comm.Parameters.AddWithValue("@STD_SocialState", stu.STD_SocialState);
            comm.Parameters.AddWithValue("@STD_PassportExDate", stu.STD_PassportExDate);
            comm.Parameters.AddWithValue("@STD_Religion", stu.STD_Religion);
            comm.Parameters.AddWithValue("@STD_Language", stu.STD_Language);
            comm.Parameters.AddWithValue("@STD_Eduction", stu.STD_Eduction);
            comm.Parameters.AddWithValue("@STD_Email", stu.STD_Email);
            comm.Parameters.AddWithValue("@STD_Phone", stu.STD_Phone);
            comm.Parameters.AddWithValue("@STD_WhatsAppNo", stu.STD_WhatsAppNo);
            comm.Parameters.AddWithValue("@STD_PlaceOfBirth", stu.STD_PlaceOfBirth);
            comm.Parameters.AddWithValue("@STD_Occupation", stu.STD_Occupation);
            comm.Parameters.AddWithValue("@STD_Address", stu.STD_Address);
            comm.Parameters.AddWithValue("@STD_InChinaNow", stu.STD_InChinaNow);
            comm.Parameters.AddWithValue("@STD_StudyInChine", stu.STD_StudyInChine);
            comm.Parameters.AddWithValue("@STD_PassportPhoto", stu.STD_PassportPhoto);
            comm.Parameters.AddWithValue("@STD_PassportIDPhoto", stu.STD_PassportIDPhoto);
            comm.Parameters.AddWithValue("@STD_AcadimicTransctiptPhoto", stu.STD_AcadimicTransctiptPhoto);
            comm.Parameters.AddWithValue("@STD_HieghestEduPhoto", stu.STD_HieghestEduPhoto);
            comm.Parameters.AddWithValue("@STD_BankStatmentPhoto", stu.STD_BankStatmentPhoto);
            comm.Parameters.AddWithValue("@STD_ForeignerExam", stu.STD_ForeignerExam);
            comm.Parameters.AddWithValue("@STD_NoCrimimalRecord", stu.STD_NoCrimimalRecord);
            comm.Parameters.AddWithValue("@STD_AppForm", stu.STD_AppForm);
            comm.Parameters.AddWithValue("@STD_UniversityAppForm", stu.STD_UniversityAppForm);
            comm.Parameters.AddWithValue("@STD_USR_ID", stu.STD_USR_ID);

            conn.Open();
            try
            {
                s = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Student"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete_Student([FromUri] long STD_ID)
        {
            int s = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@STD_ID BIGINT', @STD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_Student @STD_ID");
            comm.Parameters.AddWithValue("@STD_ID", STD_ID);

            conn.Open();
            try
            {
                s = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Student"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
            finally
            {
                conn.Close();
            }
        }
    }
}