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
    public class ProgramFeeStructureController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_PRG_Fees([FromUri] long PRG_ID)
        {
            List<Program_FeeStructure> pfs = new List<Program_FeeStructure>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PRG_ID BIGINT', @PRG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_PRG_Fees @PRG_ID");
            comm.Parameters.AddWithValue("@PRG_ID", PRG_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    pfs.Add(new Program_FeeStructure()
                    {
                        PFS_ID = long.Parse(reader[0].ToString()),
                        PFS_FeeStructure = reader[1].ToString(),
                        PFS_Price = float.Parse(reader[2].ToString()),
                        PFS_PRG_ID = long.Parse(reader[3].ToString())
                    });
                }
                if (pfs.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, pfs);
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
        public HttpResponseMessage Insert_Program_FeeStructure([FromBody] Program_FeeStructure pfs)
        {
            int f = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PFS_FeeStructure NVARCHAR(MAX), @PFS_Price DECIMAL(9,2), @PFS_PRG_ID BIGINT', @PFS_FeeStructure, @PFS_Price, @PFS_PRG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Program_FeeStructure @PFS_FeeStructure, @PFS_Price, @PFS_PRG_ID");
            comm.Parameters.AddWithValue("@PFS_FeeStructure", pfs.PFS_FeeStructure);
            comm.Parameters.AddWithValue("@PFS_Price", pfs.PFS_Price);
            comm.Parameters.AddWithValue("@PFS_PRG_ID", pfs.PFS_PRG_ID);

            conn.Open();
            try
            {
                f = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Program FeeStructure"));
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
        public HttpResponseMessage Update_Program_FeeStructure([FromUri] long PFS_ID, [FromBody] Program_FeeStructure pfs)
        {
            int f = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PFS_ID BIGINT, @PFS_FeeStructure NVARCHAR(MAX), @PFS_Price DECIMAL(9,2), @PFS_PRG_ID BIGINT', @PFS_ID, @PFS_FeeStructure, @PFS_Price, @PFS_PRG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Program_FeeStructure @PFS_ID, @PFS_FeeStructure, @PFS_Price, @PFS_PRG_ID");
            comm.Parameters.AddWithValue("@PFS_ID", PFS_ID);
            comm.Parameters.AddWithValue("@PFS_FeeStructure", pfs.PFS_FeeStructure);
            comm.Parameters.AddWithValue("@PFS_Price", pfs.PFS_Price);
            comm.Parameters.AddWithValue("@PFS_PRG_ID", pfs.PFS_PRG_ID);

            conn.Open();
            try
            {
                f = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Program FeeStructure"));
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