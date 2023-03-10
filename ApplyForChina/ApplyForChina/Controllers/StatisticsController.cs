using ApplyForChina.Attributes;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StatisticsController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Agent_Statistics([FromUri] int USR_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@USR_ID", USR_ID);

                var results =
                    await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("Agent_Statistics", Parameters, commandType: CommandType.StoredProcedure);

                Dictionary<string, dynamic> stats = new Dictionary<string, dynamic>()
                {
                    { "TotalStudents", results.Read<int>().Single()},
                    { "TotalOrders", results.Read<int>().Single()},
                    { "TotalSuccessOrders", results.Read<int>().Single()},
                    { "TotalFaildOrders", results.Read<int>().Single()},
                    { "TotalSuccessRate", results.Read<float>().Single()}
                };

                return Request.CreateResponse(HttpStatusCode.OK, stats) ;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}