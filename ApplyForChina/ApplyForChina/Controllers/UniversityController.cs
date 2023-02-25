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
        public async Task<HttpResponseMessage> Get_All_Universities([FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                IEnumerable<University> unv =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<University>("Get_ALL_Universities", Parameters, commandType: CommandType.StoredProcedure);

                if (unv.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, unv);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_University_By_ID([FromUri] long UNV_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@UNV_ID", UNV_ID);

                IEnumerable<University> unv =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<University>("Get_University_By_ID", Parameters, commandType: CommandType.StoredProcedure);

                if (unv.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, unv);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_University_Total()
        {
            try
            {
                IEnumerable<int> total =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Get_University_Total", commandType: CommandType.StoredProcedure);

                if (total.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, total.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_University([FromBody] University unv)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@UNV_Image", unv.UNV_Image);
                Parameters.Add("@UNV_BG_Image", unv.UNV_BG_Image);
                Parameters.Add("@UNV_Overview", unv.UNV_Overview);
                Parameters.Add("@UNV_Name", unv.UNV_Name);
                Parameters.Add("@UNV_City", unv.UNV_City);
                Parameters.Add("@UNV_Found_in", unv.UNV_Found_in);
                Parameters.Add("@UNV_UNVT_ID", unv.UNV_UNVT_ID);
                Parameters.Add("@UNV_NoOfTotalStudents", unv.UNV_NoOfTotalStudents);
                Parameters.Add("@UNV_NoOfInternationalStudents", unv.UNV_NoOfInternationalStudents);
                Parameters.Add("@UNV_NoOfFaculty", unv.UNV_NoOfFaculty);
                Parameters.Add("@UNV_About", unv.UNV_About);
                Parameters.Add("@UNV_ScholarShip_Rank", unv.UNV_ScholarShip_Rank);
                Parameters.Add("@UNV_World_Rank", unv.UNV_World_Rank);
                Parameters.Add("@UNV_ARWU_Rank", unv.UNV_ARWU_Rank);
                Parameters.Add("@UNV_Advantages", unv.UNV_Advantages);

                IEnumerable<int> u =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_University", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("University"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_University([FromUri] long UNV_ID, [FromBody] University unv)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@UNV_ID", UNV_ID);
                Parameters.Add("@UNV_Image", unv.UNV_Image);
                Parameters.Add("@UNV_BG_Image", unv.UNV_BG_Image);
                Parameters.Add("@UNV_Overview", unv.UNV_Overview);
                Parameters.Add("@UNV_Name", unv.UNV_Name);
                Parameters.Add("@UNV_City", unv.UNV_City);
                Parameters.Add("@UNV_Found_in", unv.UNV_Found_in);
                Parameters.Add("@UNV_UNVT_ID", unv.UNV_UNVT_ID);
                Parameters.Add("@UNV_NoOfTotalStudents", unv.UNV_NoOfTotalStudents);
                Parameters.Add("@UNV_NoOfInternationalStudents", unv.UNV_NoOfInternationalStudents);
                Parameters.Add("@UNV_NoOfFaculty", unv.UNV_NoOfFaculty);
                Parameters.Add("@UNV_About", unv.UNV_About);
                Parameters.Add("@UNV_ScholarShip_Rank", unv.UNV_ScholarShip_Rank);
                Parameters.Add("@UNV_World_Rank", unv.UNV_World_Rank);
                Parameters.Add("@UNV_ARWU_Rank", unv.UNV_ARWU_Rank);
                Parameters.Add("@UNV_Advantages", unv.UNV_Advantages);

                IEnumerable<int> u =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_University", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("University"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
         
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_University([FromUri] long UNV_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@UNV_ID", UNV_ID);

                IEnumerable<int> u =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_University", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("University"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}