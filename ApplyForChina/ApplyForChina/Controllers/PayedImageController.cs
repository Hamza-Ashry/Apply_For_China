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
    public class PayedImageController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_Payed_Images()
        {
            List<Payed_Image> pimg = new List<Payed_Image>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Payed_Images");

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    pimg.Add(new Payed_Image()
                    {
                        PIMG_ID = long.Parse(reader[0].ToString()),
                        PIMG_Image = reader[1].ToString(),
                        PIMG_IsApproved = bool.Parse(reader[2].ToString()),
                        PIMG_PNL_ID = short.Parse(reader[3].ToString()),
                        PIMG_ORD_ID = long.Parse(reader[4].ToString()),
                        PIMG_IsViewed = bool.Parse(reader[5].ToString())
                    });
                }

                if (pimg.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, pimg);
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
        public HttpResponseMessage Insert_Payed_Image([FromBody] Payed_Image pimg)
        {
            int p = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PIMG_Image NVARCHAR(MAX), @PIMG_PNL_ID TINYINT, @PIMG_ORD_ID BIGINT', @PIMG_Image, @PIMG_PNL_ID, @PIMG_ORD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Payed_Image @PIMG_Image, @PIMG_PNL_ID, @PIMG_ORD_ID");
            comm.Parameters.AddWithValue("@PIMG_Image", pimg.PIMG_Image);
            comm.Parameters.AddWithValue("@PIMG_PNL_ID", pimg.PIMG_PNL_ID);
            comm.Parameters.AddWithValue("@PIMG_ORD_ID", pimg.PIMG_ORD_ID);

            conn.Open();
            try
            {
                p = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Payed Images"));
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
        public HttpResponseMessage Update_Payed_Image([FromUri] long PIMG_ID, [FromBody] Payed_Image pimg)
        {
            int p = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PIMG_ID BIGINT, @PIMG_Image NVARCHAR(MAX), @PIMG_PNL_ID TINYINT, @PIMG_ORD_ID BIGINT', @PIMG_ID, @PIMG_Image, @PIMG_PNL_ID, @PIMG_ORD_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Payed_Image @PIMG_ID, @PIMG_Image, @PIMG_PNL_ID, @PIMG_ORD_ID");
            comm.Parameters.AddWithValue("@PIMG_ID", PIMG_ID);
            comm.Parameters.AddWithValue("@PIMG_Image", pimg.PIMG_Image);
            comm.Parameters.AddWithValue("@PIMG_PNL_ID", pimg.PIMG_PNL_ID);
            comm.Parameters.AddWithValue("@PIMG_ORD_ID", pimg.PIMG_ORD_ID);

            conn.Open();
            try
            {
                p = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Payed Images"));
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
        public HttpResponseMessage Update_PayedImage_Approved([FromUri] long PIMG_ID, [FromBody] Payed_Image pimg)
        {
            int p = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PIMG_ID BIGINT, @PIMG_IsApproved BIT', @PIMG_ID, @PIMG_IsApproved";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_PayedImage_Approved @PIMG_ID, @PIMG_IsApproved");
            comm.Parameters.AddWithValue("@PIMG_ID", PIMG_ID);
            comm.Parameters.AddWithValue("@PIMG_IsApproved", pimg.@PIMG_IsApproved);

            conn.Open();
            try
            {
                p = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Payed Images"));
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
        public HttpResponseMessage Delete_Payed_Image([FromUri] long PIMG_ID)
        {
            int p = 0;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PIMG_ID BIGINT', @PIMG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_Payed_Image @PIMG_ID");
            comm.Parameters.AddWithValue("@PIMG_ID", PIMG_ID);

            conn.Open();
            try
            {
                p = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Payed Images"));
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