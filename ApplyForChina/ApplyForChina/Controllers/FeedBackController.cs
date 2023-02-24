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

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeedBackController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_All_FeedBacks()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConStr()))
            {
                await conn.OpenAsync();

                try
                {
                    IEnumerable<FeedBack> fdb = await conn.QueryAsync<FeedBack>("Get_All_FeedBacks", commandType: CommandType.StoredProcedure);

                    if (fdb.Count() == 0)
                        return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                    return Request.CreateResponse(HttpStatusCode.OK, fdb);
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
        public HttpResponseMessage Insert_FeedBack([FromBody] FeedBack fdb)
        {
            int f = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@FDB_Feed NVARCHAR(MAX), @FDB_File NVARCHAR(MAX), @FDB_USR_ID INT', @FDB_Feed, @FDB_File, @FDB_USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_FeedBack @FDB_Feed, @FDB_File, @FDB_USR_ID");
            comm.Parameters.AddWithValue("@FDB_Feed", fdb.FDB_Feed);
            comm.Parameters.AddWithValue("@FDB_File", fdb.FDB_File);
            comm.Parameters.AddWithValue("@FDB_USR_ID", fdb.FDB_USR_ID);

            conn.Open();
            try
            {
                f = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("FeedBack"));
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
        public HttpResponseMessage Update_FeedBack([FromUri] long FDB_ID, [FromBody] FeedBack fdb)
        {
            int f = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@FDB_ID BIGINT, @FDB_Feed NVARCHAR(MAX), @FDB_File NVARCHAR(MAX), @FDB_USR_ID INT', @FDB_ID, @FDB_Feed, @FDB_File, @FDB_USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_FeedBack @FDB_ID, @FDB_Feed, @FDB_File, @FDB_USR_ID");
            comm.Parameters.AddWithValue("@FDB_ID", FDB_ID);
            comm.Parameters.AddWithValue("@FDB_Feed", fdb.FDB_Feed);
            comm.Parameters.AddWithValue("@FDB_File", fdb.FDB_File);
            comm.Parameters.AddWithValue("@FDB_USR_ID", fdb.FDB_USR_ID);

            conn.Open();
            try
            {
                f = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("FeedBack"));
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
        public HttpResponseMessage Delete_FeedBack([FromUri] long FDB_ID)
        {
            int f = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@FDB_ID BIGINT', @FDB_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_FeedBack @FDB_ID");
            comm.Parameters.AddWithValue("@FDB_ID", FDB_ID);

            conn.Open();
            try
            {
                f = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("FeedBack"));
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