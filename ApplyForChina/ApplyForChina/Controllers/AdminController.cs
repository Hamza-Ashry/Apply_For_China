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
    public class AdminController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Admin_Login([FromUri] string ADM_Username, [FromUri] string ADM_Password)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ADM_Username", ADM_Username);
                Parameters.Add("@ADM_Password", ADM_Password);

                IEnumerable<Admin> adm =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Admin>("Admin_Login", Parameters, commandType: CommandType.StoredProcedure);

                if (adm.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, adm.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Admin([FromBody] Admin adm)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ADM_Username", adm.ADM_Username);
                Parameters.Add("@ADM_Password", adm.ADM_Password);
                Parameters.Add("@ADM_Role", adm.ADM_Role);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Admin", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Admin"));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_Admin([FromUri] int ADM_ID, [FromBody] Admin adm)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ADM_ID", ADM_ID);
                Parameters.Add("@ADM_Username", adm.ADM_Username);
                Parameters.Add("@ADM_Password", adm.ADM_Password);
                Parameters.Add("@ADM_Role", adm.ADM_Role);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Admin", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Admin"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Admin([FromUri] int ADM_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ADM_ID", ADM_ID);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Admin", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Admin"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}