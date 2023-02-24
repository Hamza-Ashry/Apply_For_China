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
    public class ProgramController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_ALL_Programs()
        {
            List<Program> prg = new List<Program>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_ALL_Programs");

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    prg.Add(new Program()
                    {
                        PRG_ID = long.Parse(reader[0].ToString()),
                        PRG_Image = reader[1].ToString(),
                        PRG_Name = reader[2].ToString(),
                        PRG_Program_Code = reader[3].ToString(),
                        PRG_SST_ID = short.Parse(reader[4].ToString()),
                        PRG_Old_Price = float.Parse(reader[5].ToString()),
                        PRG_New_Price = float.Parse(reader[6].ToString()),
                        PRG_Intake = reader[7].ToString(),
                        PRG_Year = int.Parse(reader[8].ToString()),
                        PRG_Degree = reader[9].ToString(),
                        PRG_Teaching_Languages = reader[10].ToString(),
                        PRG_Field = reader[11].ToString(),
                        PRG_Expired_date = DateTime.Parse(reader[12].ToString()),
                        PRG_Duration = float.Parse(reader[13].ToString()),
                        PRG_Policy = reader[14].ToString(),
                        PRG_Requerments = reader[15].ToString(),
                        PRG_Special_Notes = reader[16].ToString(),
                        PRG_IsExpired = bool.Parse(reader[17].ToString()),
                        PRG_UNV_ID = long.Parse(reader[18].ToString())
                    });
                }
                if (prg.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, prg);
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
        public HttpResponseMessage Get_Scholarships()
        {
            List<Program> prg = new List<Program>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Scholarships");

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    prg.Add(new Program()
                    {
                        PRG_ID = long.Parse(reader[0].ToString()),
                        PRG_Image = reader[1].ToString(),
                        PRG_Name = reader[2].ToString(),
                        PRG_Program_Code = reader[3].ToString(),
                        PRG_SST_ID = short.Parse(reader[4].ToString()),
                        PRG_Old_Price = float.Parse(reader[5].ToString()),
                        PRG_New_Price = float.Parse(reader[6].ToString()),
                        PRG_Intake = reader[7].ToString(),
                        PRG_Year = int.Parse(reader[8].ToString()),
                        PRG_Degree = reader[9].ToString(),
                        PRG_Teaching_Languages = reader[10].ToString(),
                        PRG_Field = reader[11].ToString(),
                        PRG_Expired_date = DateTime.Parse(reader[12].ToString()),
                        PRG_Duration = float.Parse(reader[13].ToString()),
                        PRG_Policy = reader[14].ToString(),
                        PRG_Requerments = reader[15].ToString(),
                        PRG_Special_Notes = reader[16].ToString(),
                        PRG_IsExpired = bool.Parse(reader[17].ToString()),
                        PRG_UNV_ID = long.Parse(reader[18].ToString())
                    });
                }
                if (prg.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());

                return Request.CreateResponse(HttpStatusCode.OK, prg);
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
        public HttpResponseMessage Get_Selffinanceds()
        {
            List<Program> prg = new List<Program>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Selffinanceds");

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    prg.Add(new Program()
                    {
                        PRG_ID = long.Parse(reader[0].ToString()),
                        PRG_Image = reader[1].ToString(),
                        PRG_Name = reader[2].ToString(),
                        PRG_Program_Code = reader[3].ToString(),
                        PRG_SST_ID = short.Parse(reader[4].ToString()),
                        PRG_Old_Price = float.Parse(reader[5].ToString()),
                        PRG_New_Price = float.Parse(reader[6].ToString()),
                        PRG_Intake = reader[7].ToString(),
                        PRG_Year = int.Parse(reader[8].ToString()),
                        PRG_Degree = reader[9].ToString(),
                        PRG_Teaching_Languages = reader[10].ToString(),
                        PRG_Field = reader[11].ToString(),
                        PRG_Expired_date = DateTime.Parse(reader[12].ToString()),
                        PRG_Duration = float.Parse(reader[13].ToString()),
                        PRG_Policy = reader[14].ToString(),
                        PRG_Requerments = reader[15].ToString(),
                        PRG_Special_Notes = reader[16].ToString(),
                        PRG_IsExpired = bool.Parse(reader[17].ToString()),
                        PRG_UNV_ID = long.Parse(reader[18].ToString())
                    });
                }
                if (prg.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());

                return Request.CreateResponse(HttpStatusCode.OK, prg);
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
        public HttpResponseMessage Get_Program_By_ID([FromUri] long PRG_ID)
        {
            Program prg = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PRG_ID BIGINT', @PRG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Program_By_ID @PRG_ID");
            comm.Parameters.AddWithValue("@PRG_ID", PRG_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    prg = new Program()
                    {
                        PRG_ID = long.Parse(reader[0].ToString()),
                        PRG_Image = reader[1].ToString(),
                        PRG_Name = reader[2].ToString(),
                        PRG_Program_Code = reader[3].ToString(),
                        PRG_SST_ID = short.Parse(reader[4].ToString()),
                        PRG_Old_Price = float.Parse(reader[5].ToString()),
                        PRG_New_Price = float.Parse(reader[6].ToString()),
                        PRG_Intake = reader[7].ToString(),
                        PRG_Year = int.Parse(reader[8].ToString()),
                        PRG_Degree = reader[9].ToString(),
                        PRG_Teaching_Languages = reader[10].ToString(),
                        PRG_Field = reader[11].ToString(),
                        PRG_Expired_date = DateTime.Parse(reader[12].ToString()),
                        PRG_Duration = float.Parse(reader[13].ToString()),
                        PRG_Policy = reader[14].ToString(),
                        PRG_Requerments = reader[15].ToString(),
                        PRG_Special_Notes = reader[16].ToString(),
                        PRG_IsExpired = bool.Parse(reader[17].ToString()),
                        PRG_UNV_ID = long.Parse(reader[18].ToString())
                    };
                }
                if (prg == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, prg);
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
        public HttpResponseMessage Get_Program_By_Code([FromUri] string PRG_Code)
        {
            Program prg = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PRG_Program_Code CHAR(12)', @PRG_Program_Code";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_Program_By_Code @PRG_Program_Code");
            comm.Parameters.AddWithValue("@PRG_Program_Code", PRG_Code);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    prg = new Program()
                    {
                        PRG_ID = long.Parse(reader[0].ToString()),
                        PRG_Image = reader[1].ToString(),
                        PRG_Name = reader[2].ToString(),
                        PRG_Program_Code = reader[3].ToString(),
                        PRG_SST_ID = short.Parse(reader[4].ToString()),
                        PRG_Old_Price = float.Parse(reader[5].ToString()),
                        PRG_New_Price = float.Parse(reader[6].ToString()),
                        PRG_Intake = reader[7].ToString(),
                        PRG_Year = int.Parse(reader[8].ToString()),
                        PRG_Degree = reader[9].ToString(),
                        PRG_Teaching_Languages = reader[10].ToString(),
                        PRG_Field = reader[11].ToString(),
                        PRG_Expired_date = DateTime.Parse(reader[12].ToString()),
                        PRG_Duration = float.Parse(reader[13].ToString()),
                        PRG_Policy = reader[14].ToString(),
                        PRG_Requerments = reader[15].ToString(),
                        PRG_Special_Notes = reader[16].ToString(),
                        PRG_IsExpired = bool.Parse(reader[17].ToString()),
                        PRG_UNV_ID = long.Parse(reader[18].ToString())
                    };
                }
                if (prg == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());

                return Request.CreateResponse(HttpStatusCode.OK, prg);
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
        public HttpResponseMessage Insert_Program([FromBody] Program prg)
        {
            int p = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql," +
                " N'@PRG_Image NVARCHAR(MAX), @PRG_Name NVARCHAR(50), @PRG_SST_ID TINYINT, @PRG_Old_Price DECIMAL(9, 2), @PRG_New_Price DECIMAL(9, 2), @PRG_Intake NVARCHAR(12), @PRG_Year INT, @PRG_Degree NVARCHAR(100), @PRG_Teaching_Languages NVARCHAR(50), @PRG_Field NVARCHAR(30), @PRG_Expired_date DATE, @PRG_Duration DECIMAL(3, 1), @PRG_Policy NVARCHAR(MAX), @PRG_Requerments NVARCHAR(MAX), @PRG_Special_Notes NVARCHAR(MAX), @PRG_UNV_ID BIGINT'," +
                " @PRG_Image, @PRG_Name, @PRG_SST_ID, @PRG_Old_Price, @PRG_New_Price, @PRG_Intake, @PRG_Year, @PRG_Degree, @PRG_Teaching_Languages, @PRG_Field, @PRG_Expired_date, @PRG_Duration, @PRG_Policy, @PRG_Requerments, @PRG_Special_Notes, @PRG_UNV_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_Program @PRG_Image, @PRG_Name, @PRG_SST_ID, @PRG_Old_Price, @PRG_New_Price, @PRG_Intake, @PRG_Year, @PRG_Degree, @PRG_Teaching_Languages, @PRG_Field, @PRG_Expired_date, @PRG_Duration, @PRG_Policy, @PRG_Requerments, @PRG_Special_Notes, @PRG_UNV_ID");
            comm.Parameters.AddWithValue("@PRG_Image", prg.PRG_Image);
            comm.Parameters.AddWithValue("@PRG_Name", prg.PRG_Name);
            comm.Parameters.AddWithValue("@PRG_SST_ID", prg.PRG_SST_ID);
            comm.Parameters.AddWithValue("@PRG_Old_Price", prg.PRG_Old_Price);
            comm.Parameters.AddWithValue("@PRG_New_Price", prg.PRG_New_Price);
            comm.Parameters.AddWithValue("@PRG_Intake", prg.PRG_Intake);
            comm.Parameters.AddWithValue("@PRG_Year", prg.PRG_Year);
            comm.Parameters.AddWithValue("@PRG_Degree", prg.PRG_Degree);
            comm.Parameters.AddWithValue("@PRG_Teaching_Languages", prg.PRG_Teaching_Languages);
            comm.Parameters.AddWithValue("@PRG_Field", prg.PRG_Field);
            comm.Parameters.AddWithValue("@PRG_Expired_date", prg.PRG_Expired_date);
            comm.Parameters.AddWithValue("@PRG_Duration", prg.PRG_Duration);
            comm.Parameters.AddWithValue("@PRG_Policy", prg.PRG_Policy);
            comm.Parameters.AddWithValue("@PRG_Requerments", prg.PRG_Requerments);
            comm.Parameters.AddWithValue("@PRG_Special_Notes", prg.PRG_Special_Notes);
            comm.Parameters.AddWithValue("@PRG_UNV_ID", prg.PRG_UNV_ID);

            conn.Open();
            try
            {
                p = int.Parse(comm.ExecuteScalar().ToString());

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Program", p));
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
        public HttpResponseMessage Update_Program([FromUri] long PRG_ID, [FromBody] Program prg)
        {
            int p = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql," +
                 " N'@PRG_ID BIGINT, @PRG_Image NVARCHAR(MAX), @PRG_Name NVARCHAR(50), @PRG_SST_ID TINYINT, @PRG_Old_Price DECIMAL(9, 2), @PRG_New_Price DECIMAL(9, 2), @PRG_Intake NVARCHAR(12), @PRG_Year INT, @PRG_Degree NVARCHAR(100), @PRG_Teaching_Languages NVARCHAR(50), @PRG_Field NVARCHAR(30), @PRG_Expired_date DATE, @PRG_Duration DECIMAL(3, 1), @PRG_Policy NVARCHAR(MAX), @PRG_Requerments NVARCHAR(MAX), @PRG_Special_Notes NVARCHAR(MAX), @PRG_UNV_ID BIGINT'," +
                 " @PRG_ID, @PRG_Image, @PRG_Name, @PRG_SST_ID, @PRG_Old_Price, @PRG_New_Price, @PRG_Intake, @PRG_Year, @PRG_Degree, @PRG_Teaching_Languages, @PRG_Field, @PRG_Expired_date, @PRG_Duration, @PRG_Policy, @PRG_Requerments, @PRG_Special_Notes, @PRG_UNV_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_Program @PRG_ID, @PRG_Image, @PRG_Name, @PRG_SST_ID, @PRG_Old_Price, @PRG_New_Price, @PRG_Intake, @PRG_Year, @PRG_Degree, @PRG_Teaching_Languages, @PRG_Field, @PRG_Expired_date, @PRG_Duration, @PRG_Policy, @PRG_Requerments, @PRG_Special_Notes, @PRG_UNV_ID");
            comm.Parameters.AddWithValue("@PRG_ID", PRG_ID);
            comm.Parameters.AddWithValue("@PRG_Image", prg.PRG_Image);
            comm.Parameters.AddWithValue("@PRG_Name", prg.PRG_Name);
            comm.Parameters.AddWithValue("@PRG_SST_ID", prg.PRG_SST_ID);
            comm.Parameters.AddWithValue("@PRG_Old_Price", prg.PRG_Old_Price);
            comm.Parameters.AddWithValue("@PRG_New_Price", prg.PRG_New_Price);
            comm.Parameters.AddWithValue("@PRG_Intake", prg.PRG_Intake);
            comm.Parameters.AddWithValue("@PRG_Year", prg.PRG_Year);
            comm.Parameters.AddWithValue("@PRG_Degree", prg.PRG_Degree);
            comm.Parameters.AddWithValue("@PRG_Teaching_Languages", prg.PRG_Teaching_Languages);
            comm.Parameters.AddWithValue("@PRG_Field", prg.PRG_Field);
            comm.Parameters.AddWithValue("@PRG_Expired_date", prg.PRG_Expired_date);
            comm.Parameters.AddWithValue("@PRG_Duration", prg.PRG_Duration);
            comm.Parameters.AddWithValue("@PRG_Policy", prg.PRG_Policy);
            comm.Parameters.AddWithValue("@PRG_Requerments", prg.PRG_Requerments);
            comm.Parameters.AddWithValue("@PRG_Special_Notes", prg.PRG_Special_Notes);
            comm.Parameters.AddWithValue("@PRG_UNV_ID", prg.PRG_UNV_ID);

            conn.Open();
            try
            {
                p = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Program"));
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
        public HttpResponseMessage Delete_Program([FromUri] long PRG_ID)
        {
            int p = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@PRG_ID BIGINT', @PRG_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_Program @PRG_ID");
            comm.Parameters.AddWithValue("@PRG_ID", PRG_ID);

            conn.Open();
            try
            {
                p = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("University"));
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