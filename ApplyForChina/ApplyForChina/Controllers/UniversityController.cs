using ApplyForChina.Attributes;
using ApplyForChina.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UniversityController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get_All_Universities()
        {
            List<University> unv = new List<University>();

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_ALL_Universities");

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    unv.Add(new University()
                    {
                        UNV_ID = long.Parse(reader[0].ToString()),
                        UNV_Image = reader[1].ToString(),
                        UNV_BG_Image = reader[2].ToString(),
                        UNV_Overview = reader[3].ToString(),
                        UNV_Name = reader[4].ToString(),
                        UNV_City = reader[5].ToString(),
                        UNV_Found_in = int.Parse(reader[6].ToString()),
                        UNV_UNVT_ID = short.Parse(reader[7].ToString()),
                        UNV_NoOfTotalStudents = int.Parse(reader[8].ToString()),
                        UNV_NoOfInternationalStudents = int.Parse(reader[9].ToString()),
                        UNV_NoOfFaculty = int.Parse(reader[10].ToString()),
                        UNV_About = reader[11].ToString(),
                        UNV_ScholarShip_Rank = int.Parse(reader[12].ToString()),
                        UNV_World_Rank = int.Parse(reader[13].ToString()),
                        UNV_ARWU_Rank = int.Parse(reader[14].ToString()),
                        UNV_Advantages = reader[15].ToString(),
                        UNV_NoofPrograms = int.Parse(reader[16].ToString())
                    });
                }
                if (unv.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, unv);
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
        public HttpResponseMessage Get_University_By_ID([FromUri] long UNV_ID)
        {
            University unv = null;

            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@UNV_ID BIGINT', @UNV_ID";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Get_University_By_ID @UNV_ID");
            comm.Parameters.AddWithValue("@UNV_ID", UNV_ID);

            conn.Open();
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    unv = new University()
                    {
                        UNV_ID = long.Parse(reader[0].ToString()),
                        UNV_Image = reader[1].ToString(),
                        UNV_BG_Image = reader[2].ToString(),
                        UNV_Overview = reader[3].ToString(),
                        UNV_Name = reader[4].ToString(),
                        UNV_City = reader[5].ToString(),
                        UNV_Found_in = int.Parse(reader[6].ToString()),
                        UNV_UNVT_ID = short.Parse(reader[7].ToString()),
                        UNV_NoOfTotalStudents = int.Parse(reader[8].ToString()),
                        UNV_NoOfInternationalStudents = int.Parse(reader[9].ToString()),
                        UNV_NoOfFaculty = int.Parse(reader[10].ToString()),
                        UNV_About = reader[11].ToString(),
                        UNV_ScholarShip_Rank = int.Parse(reader[12].ToString()),
                        UNV_World_Rank = int.Parse(reader[13].ToString()),
                        UNV_ARWU_Rank = int.Parse(reader[14].ToString()),
                        UNV_Advantages = reader[15].ToString(),
                        UNV_NoofPrograms = int.Parse(reader[16].ToString())
                    };
                }
                if (unv == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, unv);
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
        public HttpResponseMessage Insert_University([FromBody] University unv)
        {
            int u = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql," +
                " N'@UNV_Image NVARCHAR(MAX), @UNV_BG_Image NVARCHAR(MAX), @UNV_Overview NVARCHAR(MAX), @UNV_Name NVARCHAR(50), @UNV_City NVARCHAR(50), @UNV_Found_in INT, @UNV_UNVT_ID TINYINT, @UNV_NoOfTotalStudents INT, @UNV_NoOfinternationalStudents INT, @UNV_NoOfFaculty INT, @UNV_About NVARCHAR(MAX), @UNV_ScholarShip_Rank INT, @UNV_World_Rank INT, @UNV_ARWU_Rank INT, @UNV_Advantages NVARCHAR(MAX)'," +
                " @UNV_Image, @UNV_BG_Image, @UNV_Overview, @UNV_Name, @UNV_City, @UNV_Found_in, @UNV_UNVT_ID, @UNV_NoOfTotalStudents, @UNV_NoOfInternationalStudents, @UNV_NoOfFaculty, @UNV_About, @UNV_ScholarShip_Rank, @UNV_World_Rank, @UNV_ARWU_Rank, @UNV_Advantages";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Insert_University @UNV_Image, @UNV_BG_Image, @UNV_Overview, @UNV_Name, @UNV_City, @UNV_Found_in, @UNV_UNVT_ID, @UNV_NoOfTotalStudents, @UNV_NoOfInternationalStudents, @UNV_NoOfFaculty, @UNV_About, @UNV_ScholarShip_Rank, @UNV_World_Rank, @UNV_ARWU_Rank, @UNV_Advantages");
            comm.Parameters.AddWithValue("@UNV_Image", unv.UNV_Image);
            comm.Parameters.AddWithValue("@UNV_BG_Image", unv.UNV_BG_Image);
            comm.Parameters.AddWithValue("@UNV_Overview", unv.UNV_Overview);
            comm.Parameters.AddWithValue("@UNV_Name", unv.UNV_Name);
            comm.Parameters.AddWithValue("@UNV_City", unv.UNV_City);
            comm.Parameters.AddWithValue("@UNV_Found_in", unv.UNV_Found_in);
            comm.Parameters.AddWithValue("@UNV_UNVT_ID", unv.UNV_UNVT_ID);
            comm.Parameters.AddWithValue("@UNV_NoOfTotalStudents", unv.UNV_NoOfTotalStudents);
            comm.Parameters.AddWithValue("@UNV_NoOfInternationalStudents", unv.UNV_NoOfInternationalStudents);
            comm.Parameters.AddWithValue("@UNV_NoOfFaculty", unv.UNV_NoOfFaculty);
            comm.Parameters.AddWithValue("@UNV_About", unv.UNV_About);
            comm.Parameters.AddWithValue("@UNV_ScholarShip_Rank", unv.UNV_ScholarShip_Rank);
            comm.Parameters.AddWithValue("@UNV_World_Rank", unv.UNV_World_Rank);
            comm.Parameters.AddWithValue("@UNV_ARWU_Rank", unv.UNV_ARWU_Rank);
            comm.Parameters.AddWithValue("@UNV_Advantages", unv.UNV_Advantages);

            conn.Open();
            try
            {
                u = comm.ExecuteNonQuery();
                
                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("University"));
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
        public HttpResponseMessage Update_University([FromUri] long UNV_ID, [FromBody] University unv)
        {
            int u = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql," +
                " N'@UNV_ID BIGINT, @UNV_Image NVARCHAR(MAX), @UNV_BG_Image NVARCHAR(MAX), @UNV_Overview NVARCHAR(MAX), @UNV_Name NVARCHAR(50), @UNV_City NVARCHAR(50), @UNV_Found_in INT, @UNV_UNVT_ID TINYINT, @UNV_NoOfTotalStudents INT, @UNV_NoOfinternationalStudents INT, @UNV_NoOfFaculty INT, @UNV_About NVARCHAR(MAX), @UNV_ScholarShip_Rank INT, @UNV_World_Rank INT, @UNV_ARWU_Rank INT, @UNV_Advantages NVARCHAR(MAX)'," +
                " @UNV_ID, @UNV_Image, @UNV_BG_Image, @UNV_Overview, @UNV_Name, @UNV_City, @UNV_Found_in, @UNV_UNVT_ID, @UNV_NoOfTotalStudents, @UNV_NoOfInternationalStudents, @UNV_NoOfFaculty, @UNV_About, @UNV_ScholarShip_Rank, @UNV_World_Rank, @UNV_ARWU_Rank, @UNV_Advantages";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Update_University @UNV_ID, @UNV_Image, @UNV_BG_Image, @UNV_Overview, @UNV_Name, @UNV_City, @UNV_Found_in, @UNV_UNVT_ID, @UNV_NoOfTotalStudents, @UNV_NoOfInternationalStudents, @UNV_NoOfFaculty, @UNV_About, @UNV_ScholarShip_Rank, @UNV_World_Rank, @UNV_ARWU_Rank, @UNV_Advantages");
            comm.Parameters.AddWithValue("@UNV_ID", UNV_ID);
            comm.Parameters.AddWithValue("@UNV_Image", unv.UNV_Image);
            comm.Parameters.AddWithValue("@UNV_BG_Image", unv.UNV_BG_Image);
            comm.Parameters.AddWithValue("@UNV_Overview", unv.UNV_Overview);
            comm.Parameters.AddWithValue("@UNV_Name", unv.UNV_Name);
            comm.Parameters.AddWithValue("@UNV_City", unv.UNV_City);
            comm.Parameters.AddWithValue("@UNV_Found_in", unv.UNV_Found_in);
            comm.Parameters.AddWithValue("@UNV_UNVT_ID", unv.UNV_UNVT_ID);
            comm.Parameters.AddWithValue("@UNV_NoOfTotalStudents", unv.UNV_NoOfTotalStudents);
            comm.Parameters.AddWithValue("@UNV_NoOfInternationalStudents", unv.UNV_NoOfInternationalStudents);
            comm.Parameters.AddWithValue("@UNV_NoOfFaculty", unv.UNV_NoOfFaculty);
            comm.Parameters.AddWithValue("@UNV_About", unv.UNV_About);
            comm.Parameters.AddWithValue("@UNV_ScholarShip_Rank", unv.UNV_ScholarShip_Rank);
            comm.Parameters.AddWithValue("@UNV_World_Rank", unv.UNV_World_Rank);
            comm.Parameters.AddWithValue("@UNV_ARWU_Rank", unv.UNV_ARWU_Rank);
            comm.Parameters.AddWithValue("@UNV_Advantages", unv.UNV_Advantages);

            conn.Open();
            try
            {
                u = comm.ExecuteNonQuery();

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("University"));
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
        public HttpResponseMessage Delete_University([FromUri] long UNV_ID)
        {
            int u = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConStr());
            string query = "EXEC sp_executesql @sql, N'@UNV_ID BIGINT', @UNV_ID ";
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@sql", "EXEC Delete_University @UNV_ID");
            comm.Parameters.AddWithValue("@UNV_ID", UNV_ID);

            conn.Open();
            try
            {
                u = comm.ExecuteNonQuery();

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