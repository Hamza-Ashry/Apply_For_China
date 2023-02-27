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

namespace ApplyForChina.Controllers
{
    public class ApplicationFileController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Application_Files([FromUri] long APPF_APP_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APPF_APP_ID", APPF_APP_ID);

                IEnumerable<Application_File> appf =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Application_File>("Get_Application_Files", Parameters, commandType: CommandType.StoredProcedure);

                if (appf.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, appf);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Application_File([FromUri] long APPF_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APPF_ID", APPF_ID);

                IEnumerable<Application_File> appf =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Application_File>("Get_Application_File", Parameters, commandType: CommandType.StoredProcedure);

                if (appf.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, appf.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Application_File([FromBody] Application_File appf)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APPF_Decoument", appf.APPF_Decoument);
                Parameters.Add("@APPF_File", appf.APPF_File);
                Parameters.Add("@APPF_APP_ID", appf.APPF_APP_ID);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Application_File", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Application File"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_Application_File([FromUri] long APPF_ID, [FromBody] Application_File appf)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APPF_ID", APPF_ID);
                Parameters.Add("@APPF_Decoument", appf.APPF_Decoument);
                Parameters.Add("@APPF_File", appf.APPF_File);
                Parameters.Add("@APPF_APP_ID", appf.APPF_APP_ID);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Application_File", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Application File"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Application_File([FromUri] long APPF_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@APPF_ID", APPF_ID);

                IEnumerable<int> a =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Application_File", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Application File"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}