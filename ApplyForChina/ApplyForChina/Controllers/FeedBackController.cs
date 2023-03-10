using ApplyForChina.Attributes;
using ApplyForChina.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Dapper;
using System.Data;
using System.Web;

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeedBackController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_All_FeedBacks([FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                var results = 
                    await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("Get_All_FeedBacks", Parameters, commandType: CommandType.StoredProcedure);

                HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Type, FeedBacks-total-count");

                var fdb = results.Read<FeedBack>().ToList();

                if (fdb.Count() == 0)
                {
                    HttpContext.Current.Response.Headers.Add("FeedBacks-total-count", results.Read<int>().FirstOrDefault().ToString());
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                }

                HttpContext.Current.Response.Headers.Add("FeedBacks-total-count", results.Read<int>().FirstOrDefault().ToString());
                return Request.CreateResponse(HttpStatusCode.OK, fdb);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_FeedBack([FromBody] FeedBack fdb)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@FDB_Feed", fdb.FDB_Feed);
                Parameters.Add("@FDB_File", fdb.FDB_File);
                Parameters.Add("@FDB_USR_ID", fdb.FDB_USR_ID);

                IEnumerable<int> f =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_FeedBack", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Feed Back"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_FeedBack([FromUri] long FDB_ID, [FromBody] FeedBack fdb)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@FDB_ID", FDB_ID);
                Parameters.Add("@FDB_Feed", fdb.FDB_Feed);
                Parameters.Add("@FDB_File", fdb.FDB_File);
                Parameters.Add("@FDB_USR_ID", fdb.FDB_USR_ID);

                IEnumerable<int> f =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_FeedBack", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Feed Back"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_FeedBack([FromUri] long FDB_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@FDB_ID", FDB_ID);

                IEnumerable<int> f =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_FeedBack", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Feed Back"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}