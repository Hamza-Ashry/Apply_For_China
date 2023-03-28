using ApplyForChina.Attributes;
using ApplyForChina.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Agent_Students([FromUri] int STD_USR_ID, [FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@STD_USR_ID", STD_USR_ID);
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                IEnumerable<Student> stu =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Student>("Get_Agent_Students", Parameters, commandType: CommandType.StoredProcedure);
            
                if (stu.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, stu);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Student([FromUri] int STD_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@STD_ID", STD_ID);

                IEnumerable<Student> stu =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Student>("Get_Student", Parameters, commandType: CommandType.StoredProcedure);

                if (stu.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, stu.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Student([FromBody] Student stu)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@STD_SurName", stu.STD_SurName);
                Parameters.Add("@STD_GivenName", stu.STD_GivenName);
                Parameters.Add("@STD_Nationality", stu.STD_Nationality);
                Parameters.Add("@STD_DOB", stu.STD_DOB);
                Parameters.Add("@STD_Gender", stu.STD_Gender);
                Parameters.Add("@STD_PassportNo", stu.STD_PassportNo);
                Parameters.Add("@STD_SocialState", stu.STD_SocialState);
                Parameters.Add("@STD_PassportExDate", stu.STD_PassportExDate);
                Parameters.Add("@STD_Religion", stu.STD_Religion);
                Parameters.Add("@STD_Language", stu.STD_Language);
                Parameters.Add("@STD_Eduction", stu.STD_Eduction);
                Parameters.Add("@STD_Email", stu.STD_Email);
                Parameters.Add("@STD_Phone", stu.STD_Phone);
                Parameters.Add("@STD_WhatsAppNo", stu.STD_WhatsAppNo);
                Parameters.Add("@STD_PlaceOfBirth", stu.STD_PlaceOfBirth);
                Parameters.Add("@STD_Occupation", stu.STD_Occupation);
                Parameters.Add("@STD_Address", stu.STD_Address);
                Parameters.Add("@STD_InChinaNow", stu.STD_InChinaNow);
                Parameters.Add("@STD_StudyInChine", stu.STD_StudyInChine);
                Parameters.Add("@STD_USR_ID", stu.STD_USR_ID);

                IEnumerable<int> s =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Student", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Student"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_Student([FromUri] long STD_ID, [FromBody] Student stu)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@STD_ID", STD_ID);
                Parameters.Add("@STD_SurName", stu.STD_SurName);
                Parameters.Add("@STD_GivenName", stu.STD_GivenName);
                Parameters.Add("@STD_Nationality", stu.STD_Nationality);
                Parameters.Add("@STD_DOB", stu.STD_DOB);
                Parameters.Add("@STD_Gender", stu.STD_Gender);
                Parameters.Add("@STD_PassportNo", stu.STD_PassportNo);
                Parameters.Add("@STD_SocialState", stu.STD_SocialState);
                Parameters.Add("@STD_PassportExDate", stu.STD_PassportExDate);
                Parameters.Add("@STD_Religion", stu.STD_Religion);
                Parameters.Add("@STD_Language", stu.STD_Language);
                Parameters.Add("@STD_Eduction", stu.STD_Eduction);
                Parameters.Add("@STD_Email", stu.STD_Email);
                Parameters.Add("@STD_Phone", stu.STD_Phone);
                Parameters.Add("@STD_WhatsAppNo", stu.STD_WhatsAppNo);
                Parameters.Add("@STD_PlaceOfBirth", stu.STD_PlaceOfBirth);
                Parameters.Add("@STD_Occupation", stu.STD_Occupation);
                Parameters.Add("@STD_Address", stu.STD_Address);
                Parameters.Add("@STD_InChinaNow", stu.STD_InChinaNow);
                Parameters.Add("@STD_StudyInChine", stu.STD_StudyInChine);
                Parameters.Add("@STD_USR_ID", stu.STD_USR_ID);

                IEnumerable<int> s =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Student", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Student"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Student([FromUri] long STD_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@STD_ID", STD_ID);

                IEnumerable<int> s =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Student", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Student"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}