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
    public class ProgramDocumentController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_PRG_Documents([FromUri] long PRG_ID)
        {
            List<Program_Document> dprg = new List<Program_Document>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PRG_ID BIGINT', @PRG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_PRG_Documents @PRG_ID");
            comm.Parameters.AddWithValue("@PRG_ID", PRG_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dprg.Add(new Program_Document()
                    {
                        PDOC_ID = long.Parse(reader[0].ToString()),
                        PDOC_Field = reader[1].ToString(),
                        PDOC_PRG_ID = long.Parse(reader[2].ToString())
                    });
                }
                if (dprg.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, dprg);
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
        public HttpResponseMessage Insert_Program_Document([FromBody] Program_Document dprg)
        {
            int d = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PDOC_Field NVARCHAR(MAX), @PDOC_PRG_ID BIGINT', @PDOC_Field, @PDOC_PRG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Program_Document @PDOC_Field, @PDOC_PRG_ID");
            comm.Parameters.AddWithValue("@PDOC_Field", dprg.PDOC_Field);
            comm.Parameters.AddWithValue("@PDOC_PRG_ID", dprg.PDOC_PRG_ID);

            conn.Open();
            try
            {
                d = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Program Document"));
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
        public HttpResponseMessage Update_Program_Document([FromUri] long PDOC_ID, [FromBody] Program_Document dprg)
        {
            int d = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PDOC_ID BIGINT, @PDOC_Field NVARCHAR(MAX), @PDOC_PRG_ID BIGINT', @PDOC_ID, @PDOC_Field, @PDOC_PRG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Program_Document @PDOC_ID, @PDOC_Field, @PDOC_PRG_ID");
            comm.Parameters.AddWithValue("@PDOC_ID", PDOC_ID);
            comm.Parameters.AddWithValue("@PDOC_Field", dprg.PDOC_Field);
            comm.Parameters.AddWithValue("@PDOC_PRG_ID", dprg.PDOC_PRG_ID);

            conn.Open();
            try
            {
                d = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Program Document"));
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