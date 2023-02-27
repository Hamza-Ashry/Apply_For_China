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
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> User_Login([FromUri] string USR_Username, [FromUri]  string USR_Password)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@USR_Username", USR_Username);
                Parameters.Add("@USR_Password", USR_Password);

                IEnumerable<User> usr = await SingletonSqlConnection.Instance.Connection.QueryAsync<User>("User_Login", Parameters, commandType: CommandType.StoredProcedure);

                if (usr.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, usr);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_User([FromBody] User usr)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@USR_Username", usr.USR_Username);
                Parameters.Add("@USR_City", usr.USR_City);
                Parameters.Add("@USR_Email", usr.USR_Email);
                Parameters.Add("@USR_Password", usr.USR_Password);
                Parameters.Add("@USR_Nationality", usr.USR_Nationality);
                Parameters.Add("@USR_Phone", usr.USR_Phone);
                Parameters.Add("@USR_ROL_ID", usr.USR_ROL_ID);

                IEnumerable<int> u = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_User", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("User"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_User([FromUri] int USR_ID, [FromBody] User usr)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@USR_ID", USR_ID);
                Parameters.Add("@USR_Username", usr.USR_Username);
                Parameters.Add("@USR_City", usr.USR_City);
                Parameters.Add("@USR_Email", usr.USR_Email);
                Parameters.Add("@USR_Password", usr.USR_Password);
                Parameters.Add("@USR_Nationality", usr.USR_Nationality);
                Parameters.Add("@USR_Phone", usr.USR_Phone);
                Parameters.Add("@USR_ROL_ID", usr.USR_ROL_ID);

                IEnumerable<int> u = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_User", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("User"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_User([FromUri] int USR_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@USR_ID", USR_ID);

                IEnumerable<int> u = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_User", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("User"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}