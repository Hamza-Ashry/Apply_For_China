using ApplyForChina.Attributes;
using ApplyForChina.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplyForChina.Controllers
{
    public class ApplicationFileController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_Application_Files([FromUri] long APPF_APP_ID)
        {
            List<Application_File> appf = new List<Application_File>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APPF_APP_ID BIGINT', @APPF_APP_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Application_Files @APPF_APP_ID");
            comm.Parameters.AddWithValue("@APPF_APP_ID", APPF_APP_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    appf.Add(new Application_File()
                    {
                        APPF_ID = long.Parse(reader[0].ToString()),
                        APPF_Decoument = reader[1].ToString(),
                        APPF_File = reader[2].ToString(),
                        APPF_APP_ID = long.Parse(reader[3].ToString())
                    });
                }

                if (appf.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, appf);
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
        public HttpResponseMessage Get_Application_File([FromUri] long APPF_ID)
        {
            Application_File appf = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APPF_ID BIGINT', @APPF_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Application_File @APPF_ID");
            comm.Parameters.AddWithValue("@APPF_ID", APPF_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    appf = new Application_File()
                    {
                        APPF_ID = long.Parse(reader[0].ToString()),
                        APPF_Decoument = reader[1].ToString(),
                        APPF_File = reader[2].ToString(),
                        APPF_APP_ID = long.Parse(reader[3].ToString())
                    };
                }

                if (appf == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, appf);
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
        public HttpResponseMessage Insert_Application_File([FromBody] Application_File appf)
        {
            int a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APPF_Decoument NVARCHAR(MAX), @APPF_File NVARCHAR(MAX),  @APPF_APP_ID BIGINT', @APPF_Decoument, @APPF_File , @APPF_APP_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Application_File @APPF_Decoument, @APPF_File , @APPF_APP_ID");
            comm.Parameters.AddWithValue("@APPF_Decoument", appf.APPF_Decoument);
            comm.Parameters.AddWithValue("@APPF_File", appf.APPF_File);
            comm.Parameters.AddWithValue("@APPF_APP_ID", appf.APPF_APP_ID);

            conn.Open();
            try
            {
                a = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Application Files"));
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
        public HttpResponseMessage Update_Application_File([FromUri] long APPF_ID, [FromBody] Application_File appf)
        {
            int a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APPF_ID BIGINT, @APPF_Decoument NVARCHAR(MAX), @APPF_File NVARCHAR(MAX),  @APPF_APP_ID BIGINT', @APPF_ID, @APPF_Decoument, @APPF_File , @APPF_APP_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Application_File @APPF_ID, @APPF_Decoument, @APPF_File , @APPF_APP_ID");
            comm.Parameters.AddWithValue("@APPF_ID", APPF_ID);
            comm.Parameters.AddWithValue("@APPF_Decoument", appf.APPF_Decoument);
            comm.Parameters.AddWithValue("@APPF_File", appf.APPF_File);
            comm.Parameters.AddWithValue("@APPF_APP_ID", appf.APPF_APP_ID);

            conn.Open();
            try
            {
                a = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Application Files"));
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
        public HttpResponseMessage Delete_Application_File([FromUri] long APPF_ID)
        {
            int a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@APPF_ID BIGINT', @APPF_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_Application_File @APPF_ID");
            comm.Parameters.AddWithValue("@APPF_ID", APPF_ID);

            conn.Open();
            try
            {
                a = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Application Files"));
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