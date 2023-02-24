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
    public class ApplicationController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_Order_Applications([FromUri] long APP_ORD_ID)
        {
            List<Application> app = new List<Application>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APP_ORD_ID BIGINT', @APP_ORD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Order_Applications @APP_ORD_ID");
            comm.Parameters.AddWithValue("@APP_ORD_ID", APP_ORD_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    app.Add(new Application()
                    {
                        APP_ID = long.Parse(reader[0].ToString()),
                        APP_Code = reader[1].ToString(),
                        APP_PRG_ID = long.Parse(reader[2].ToString()),
                        APP_ORD_ID = long.Parse(reader[3].ToString())
                    });
                }

                if (app.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, app);
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
        public HttpResponseMessage Get_Application([FromUri] long APP_ID)
        {
            Application app = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APP_ID BIGINT', @APP_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Application @APP_ID");
            comm.Parameters.AddWithValue("@APP_ID", APP_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    app = new Application()
                    {
                        APP_ID = long.Parse(reader[0].ToString()),
                        APP_Code = reader[1].ToString(),
                        APP_PRG_ID = long.Parse(reader[2].ToString()),
                        APP_ORD_ID = long.Parse(reader[3].ToString())
                    };
                }

                if (app == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, app);
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
        public HttpResponseMessage Insert_Application([FromBody] Application app)
        {
            long a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APP_PRG_ID BIGINT, @APP_ORD_ID BIGINT', @APP_PRG_ID, @APP_ORD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Application @APP_PRG_ID, @APP_ORD_ID");
            comm.Parameters.AddWithValue("@APP_PRG_ID", app.APP_PRG_ID);
            comm.Parameters.AddWithValue("@APP_ORD_ID", app.APP_ORD_ID);

            conn.Open();
            try
            {
                a = long.Parse(comm.ExecuteScalar().ToString());

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Application", a));
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
        public HttpResponseMessage Update_Application([FromUri] long APP_ID, [FromBody] Application app)
        {
            int a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APP_ID BIGINT, @APP_PRG_ID BIGINT, @APP_ORD_ID BIGINT', @APP_ID, @APP_PRG_ID, @APP_ORD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Application @APP_ID, @APP_PRG_ID, @APP_ORD_ID");
            comm.Parameters.AddWithValue("@APP_ID", APP_ID);
            comm.Parameters.AddWithValue("@APP_PRG_ID", app.APP_PRG_ID);
            comm.Parameters.AddWithValue("@APP_ORD_ID", app.APP_ORD_ID);

            conn.Open();
            try
            {
                a = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Application"));
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
        public HttpResponseMessage Delete_Application([FromUri] long APP_ID)
        {
            int a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APP_ID BIGINT', @APP_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_Application @APP_ID");
            comm.Parameters.AddWithValue("@APP_ID", APP_ID);

            conn.Open();
            try
            {
                a = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Application"));
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