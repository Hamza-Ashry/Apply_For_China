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
    public class UserController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage User_Login([FromUri] string USR_Username, [FromUri]  string USR_Password)
        {
            User usr = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@USR_Username NVARCHAR(50), @USR_Password NVARCHAR(20)', @USR_Username, @USR_Password";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC User_Login @USR_Username, @USR_Password");
            comm.Parameters.AddWithValue("@USR_Username", USR_Username);
            comm.Parameters.AddWithValue("@USR_Password", USR_Password);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while(reader.Read())
                {
                    usr = new User()
                    {
                        USR_ID = int.Parse(reader[0].ToString()),
                        USR_Username = reader[1].ToString(),
                        USR_City = reader[2].ToString(),
                        USR_Email = reader[3].ToString(),
                        USR_Password = reader[4].ToString(),
                        USR_Nationality = reader[5].ToString(),
                        USR_Phone = reader[6].ToString(),
                        USR_ROL_ID = short.Parse(reader[7].ToString())
                    };
                }

                if (usr == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, usr);
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
        public HttpResponseMessage Insert_User([FromBody] User usr)
        {
            int u = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql," +
                " N'@USR_Username NVARCHAR(50), @USR_City NVARCHAR(50), @USR_Email NVARCHAR(50), @USR_Password NVARCHAR(20), @USR_Nationality NVARCHAR(50), @USR_Phone NVARCHAR(15), @USR_ROL_ID TINYINT'," +
                " @USR_Username, @USR_City, @USR_Email, @USR_Password, @USR_Nationality, @USR_Phone, @USR_ROL_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_User @USR_Username, @USR_City, @USR_Email, @USR_Password, @USR_Nationality, @USR_Phone, @USR_ROL_ID");
            comm.Parameters.AddWithValue("@USR_Username", usr.USR_Username);
            comm.Parameters.AddWithValue("@USR_City", usr.USR_City);
            comm.Parameters.AddWithValue("@USR_Email", usr.USR_Email);
            comm.Parameters.AddWithValue("@USR_Password", usr.USR_Password);
            comm.Parameters.AddWithValue("@USR_Nationality", usr.USR_Nationality);
            comm.Parameters.AddWithValue("@USR_Phone", usr.USR_Phone);
            comm.Parameters.AddWithValue("@USR_ROL_ID", usr.USR_ROL_ID);

            conn.Open();
            try
            {
                u = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("User"));
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
        public HttpResponseMessage Update_User([FromUri] int USR_ID, [FromBody] User usr)
        {
            int u = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql," +
                " N'@USR_ID INT, @USR_Username NVARCHAR(50), @USR_City NVARCHAR(50), @USR_Email NVARCHAR(50), @USR_Password NVARCHAR(20), @USR_Nationality NVARCHAR(50), @USR_Phone NVARCHAR(15), @USR_ROL_ID TINYINT'," +
                " @USR_ID, @USR_Username, @USR_City, @USR_Email, @USR_Password, @USR_Nationality, @USR_Phone, @USR_ROL_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_User @USR_ID, @USR_Username, @USR_City, @USR_Email, @USR_Password, @USR_Nationality, @USR_Phone, @USR_ROL_ID");
            comm.Parameters.AddWithValue("@USR_ID", USR_ID);
            comm.Parameters.AddWithValue("@USR_Username", usr.USR_Username);
            comm.Parameters.AddWithValue("@USR_City", usr.USR_City);
            comm.Parameters.AddWithValue("@USR_Email", usr.USR_Email);
            comm.Parameters.AddWithValue("@USR_Password", usr.USR_Password);
            comm.Parameters.AddWithValue("@USR_Nationality", usr.USR_Nationality);
            comm.Parameters.AddWithValue("@USR_Phone", usr.USR_Phone);
            comm.Parameters.AddWithValue("@USR_ROL_ID", usr.USR_ROL_ID);

            conn.Open();
            try
            {
                u = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("User"));
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
        public HttpResponseMessage Delete_User([FromUri] int USR_ID)
        {
            int u = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@USR_ID INT', @USR_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_User @USR_ID");
            comm.Parameters.AddWithValue("@USR_ID", USR_ID);

            conn.Open();
            try
            {
                u = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("User"));
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