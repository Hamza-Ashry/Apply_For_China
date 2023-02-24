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
    public class MessageController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_All_Agent_Messages([FromUri] int USR_ID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConStr()))
            {
                await conn.OpenAsync();

                try
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@USR_ID", USR_ID);

                    IEnumerable<Message> msg = await conn.QueryAsync<Message>("Get_All_Agent_Messages", Parameters, commandType: CommandType.StoredProcedure);

                    if (msg.Count() == 0)
                        return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                    return Request.CreateResponse(HttpStatusCode.OK, msg);
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

        [HttpPost]
        public HttpResponseMessage Insert_Message([FromBody] Message msg)
        {
            int m = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@MSG_Message NVARCHAR(MAX), @MSG_File NVARCHAR(MAX), @MSG_FDB_ID BIGINT', @MSG_Message, @MSG_File, @MSG_FDB_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Message @MSG_Message, @MSG_File, @MSG_FDB_ID");
            comm.Parameters.AddWithValue("@MSG_Message", msg.MSG_Message);
            comm.Parameters.AddWithValue("@MSG_File", msg.MSG_File);
            comm.Parameters.AddWithValue("@MSG_FDB_ID", msg.MSG_FDB_ID);

            conn.Open();
            try
            {
                m = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Message"));
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
        public HttpResponseMessage Update_Message([FromUri] long MSG_ID, [FromBody] Message msg)
        {
            int m = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@MSG_ID BIGINT, @MSG_Message NVARCHAR(MAX), @MSG_File NVARCHAR(MAX), @MSG_FDB_ID BIGINT', @MSG_ID, @MSG_Message, @MSG_File, @MSG_FDB_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Message @MSG_ID, @MSG_Message, @MSG_File, @MSG_FDB_ID");
            comm.Parameters.AddWithValue("@MSG_ID", MSG_ID);
            comm.Parameters.AddWithValue("@MSG_Message", msg.MSG_Message);
            comm.Parameters.AddWithValue("@MSG_File", msg.MSG_File);
            comm.Parameters.AddWithValue("@MSG_FDB_ID", msg.MSG_FDB_ID);

            conn.Open();
            try
            {
                m = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Message"));
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
        public HttpResponseMessage Delete_Message([FromUri] long MSG_ID)
        {
            int m = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@MSG_ID BIGINT', @MSG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_Message @MSG_ID");
            comm.Parameters.AddWithValue("@MSG_ID", MSG_ID);

            conn.Open();
            try
            {
                m = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Message"));
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