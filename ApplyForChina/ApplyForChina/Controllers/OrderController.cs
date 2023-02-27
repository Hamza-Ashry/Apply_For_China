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
    public class OrderController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Agent_Orders([FromUri] int ORD_USR_ID, [FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ORD_USR_ID", ORD_USR_ID);
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                IEnumerable<Order> ord =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Order>("Get_Agent_Orders", Parameters, commandType: CommandType.StoredProcedure);

                if (ord.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, ord);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Order([FromUri] long ORD_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ORD_ID", ORD_ID);

                IEnumerable<Order> ord =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Order>("Get_Order", Parameters, commandType: CommandType.StoredProcedure);

                if (ord.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, ord.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Agent_Orders_Total([FromUri] int ORD_USR_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ORD_USR_ID", ORD_USR_ID);

                IEnumerable<int> ord =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Get_Agent_Orders_Total", Parameters, commandType: CommandType.StoredProcedure);

                if (ord.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, ord.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Order([FromBody] Order ord)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ORD_STD_ID", ord.ORD_STD_ID);
                Parameters.Add("@ORD_USR_ID", ord.ORD_USR_ID);

                IEnumerable<int> o =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Order", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Order", o.First()));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_Order([FromUri] long ORD_ID, [FromBody] Order ord)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ORD_ID", ORD_ID);
                Parameters.Add("@ORD_STD_ID", ord.ORD_STD_ID);
                Parameters.Add("@ORD_USR_ID", ord.ORD_USR_ID);

                IEnumerable<int> o =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Order", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Order"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Order([FromUri] long ORD_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ORD_ID", ORD_ID);

                IEnumerable<int> o =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Order", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Order"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }   
}
