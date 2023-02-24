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
    public class AdminController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Admin_Login([FromUri] string ADM_Username, [FromUri] string ADM_Password)
        {
            Admin adm = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ADM_Username NVARCHAR(50), @ADM_Password NVARCHAR(50)', @ADM_Username, @ADM_Password";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Admin_Login @ADM_Username, @ADM_Password");
            comm.Parameters.AddWithValue("@ADM_Username", ADM_Username);
            comm.Parameters.AddWithValue("@ADM_Password", ADM_Password);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while(reader.Read())
                {
                    adm = new Admin()
                    {
                        ADM_ID = int.Parse(reader[0].ToString()),
                        ADM_Username = reader[1].ToString(),
                        ADM_Password = reader[2].ToString(),
                        ADM_Role = short.Parse(reader[3].ToString())
                    };
                }

                if (adm == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, adm);
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
        public HttpResponseMessage Insert_Admin([FromBody] Admin adm)
        {
            int a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ADM_Username NVARCHAR(50), @ADM_Password NVARCHAR(50), @ADM_Role TINYINT', @ADM_Username, @ADM_Password, @ADM_Role";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Admin @ADM_Username, @ADM_Password, @ADM_Role");
            comm.Parameters.AddWithValue("@ADM_Username", adm.ADM_Username);
            comm.Parameters.AddWithValue("@ADM_Password", adm.ADM_Password);
            comm.Parameters.AddWithValue("@ADM_Role", adm.ADM_Role);

            conn.Open();
            try
            {
                a = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Admin"));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpPut]
        public HttpResponseMessage Update_Admin([FromUri] int ADM_ID, [FromBody] Admin adm)
        {
            int a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ADM_ID INT, @ADM_Username NVARCHAR(50), @ADM_Password NVARCHAR(50), @ADM_Role TINYINT', @ADM_ID, @ADM_Username, @ADM_Password, @ADM_Role";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Admin @ADM_ID, @ADM_Username, @ADM_Password, @ADM_Role");
            comm.Parameters.AddWithValue("@ADM_ID", ADM_ID);
            comm.Parameters.AddWithValue("@ADM_Username", adm.ADM_Username);
            comm.Parameters.AddWithValue("@ADM_Password", adm.ADM_Password);
            comm.Parameters.AddWithValue("@ADM_Role", adm.ADM_Role);

            conn.Open();
            try
            {
                a = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Admin"));
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
        public HttpResponseMessage Delete_Admin([FromUri] int ADM_ID)
        {
            int a = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@ADM_ID INT', @ADM_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_Admin @ADM_ID");
            comm.Parameters.AddWithValue("@ADM_ID", ADM_ID);

            conn.Open();
            try
            {
                a = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Admin"));
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