using ApplyForChina.Attributes;
using ApplyForChina.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_Agent_Orders([FromUri] int ORD_USR_ID)
        {
            List<Order> ord = new List<Order>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ORD_USR_ID INT', @ORD_USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Agent_Orders @ORD_USR_ID");
            comm.Parameters.AddWithValue("@ORD_USR_ID", ORD_USR_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ord.Add(new Order()
                    {
                         ORD_ID = long.Parse(reader[0].ToString()),
                         ORD_Code = reader[1].ToString(),
                         ORD_Date = DateTime.Parse(reader[2].ToString()),
                         ORD_State = reader[3].ToString(),
                         ORD_STD_ID = long.Parse(reader[4].ToString()),
                         ORD_USR_ID = int.Parse(reader[5].ToString())
                    });
                }

                if (ord.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, ord);
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

        [HttpGet]
        public HttpResponseMessage Get_Order([FromUri] long ORD_ID)
        {
            Order ord = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ORD_ID BIGINT', @ORD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Order @ORD_ID");
            comm.Parameters.AddWithValue("@ORD_ID", ORD_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ord = new Order()
                    {
                        ORD_ID = long.Parse(reader[0].ToString()),
                        ORD_Code = reader[1].ToString(),
                        ORD_Date = DateTime.Parse(reader[2].ToString()),
                        ORD_State = reader[3].ToString(),
                        ORD_STD_ID = long.Parse(reader[4].ToString()),
                        ORD_USR_ID = int.Parse(reader[5].ToString())
                    };
                }

                if (ord == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, ord);
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

        [HttpPost]
        public HttpResponseMessage Insert_Order([FromBody] Order ord)
        {
            long o = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ORD_STD_ID BIGINT, @ORD_USR_ID INT', @ORD_STD_ID, @ORD_USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Order @ORD_STD_ID, @ORD_USR_ID");
            comm.Parameters.AddWithValue("@ORD_STD_ID", ord.ORD_STD_ID);
            comm.Parameters.AddWithValue("@ORD_USR_ID", ord.ORD_USR_ID);

            conn.Open();
            try
            {
                o = long.Parse(comm.ExecuteScalar().ToString());
                
                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Order", o));
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
        public HttpResponseMessage Update_Order([FromUri] long ORD_ID, [FromBody] Order ord)
        {
            int o = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ORD_ID BIGINT, @ORD_STD_ID BIGINT, @ORD_USR_ID INT', @ORD_ID, @ORD_STD_ID, @ORD_USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Order @ORD_ID, @ORD_STD_ID, @ORD_USR_ID");
            comm.Parameters.AddWithValue("@ORD_ID", ORD_ID);
            comm.Parameters.AddWithValue("@ORD_STD_ID", ord.ORD_STD_ID);
            comm.Parameters.AddWithValue("@ORD_USR_ID", ord.ORD_USR_ID);

            conn.Open();
            try
            {
                o = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Order"));
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
        public HttpResponseMessage Delete_Order([FromUri] long ORD_ID)
        {
            int o = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ORD_ID BIGINT', @ORD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_Order @ORD_ID");
            comm.Parameters.AddWithValue("@ORD_ID", ORD_ID);

            conn.Open();
            try
            {
                o = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Order"));
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
