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
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessageController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_All_Agent_Messages([FromUri] int USR_ID, [FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@USR_ID", USR_ID);
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                var results = await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("Get_All_Agent_Messages", Parameters, commandType: CommandType.StoredProcedure);

                var msg = results.Read<Message>().ToList();

                HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Type, Messages-total-count");

                if (msg.Count() == 0)
                {
                    HttpContext.Current.Response.Headers.Add("Messages-total-count", results.Read<int>().FirstOrDefault().ToString());
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                }

                HttpContext.Current.Response.Headers.Add("Messages-total-count", results.Read<int>().FirstOrDefault().ToString());
                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Message([FromBody] Message msg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@MSG_Message", msg.MSG_Message);
                Parameters.Add("@MSG_File", msg.MSG_File);
                Parameters.Add("@MSG_FDB_ID", msg.MSG_FDB_ID);

                IEnumerable<int> m =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Message", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Message"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_Message([FromUri] long MSG_ID, [FromBody] Message msg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@MSG_ID", MSG_ID);
                Parameters.Add("@MSG_Message", msg.MSG_Message);
                Parameters.Add("@MSG_File", msg.MSG_File);
                Parameters.Add("@MSG_FDB_ID", msg.MSG_FDB_ID);

                IEnumerable<int> m =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Message", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Message"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Message([FromUri] long MSG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@MSG_ID", MSG_ID);

                IEnumerable<int> m =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Message", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Message"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}