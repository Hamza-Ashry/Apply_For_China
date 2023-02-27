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
    public class ApplicationController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Order_Applications([FromUri] long APP_ORD_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APP_ORD_ID", APP_ORD_ID);

                IEnumerable<Application> app =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Application>("Get_Order_Applications", Parameters, commandType: CommandType.StoredProcedure);

                if (app.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, app);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Application([FromUri] long APP_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APP_ID", APP_ID);

                IEnumerable<Application> app =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Application>("Get_Application", Parameters, commandType: CommandType.StoredProcedure);

                if (app.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, app.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Application([FromBody] Application app)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APP_PRG_ID", app.APP_PRG_ID);
                Parameters.Add("@APP_ORD_ID", app.APP_ORD_ID);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Application", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Application", a.First()));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_Application([FromUri] long APP_ID, [FromBody] Application app)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APP_ID", APP_ID);
                Parameters.Add("@APP_PRG_ID", app.APP_PRG_ID);
                Parameters.Add("@APP_ORD_ID", app.APP_ORD_ID);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Application", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Application"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Application([FromUri] long APP_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APP_ID", APP_ID);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Application", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Application"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}