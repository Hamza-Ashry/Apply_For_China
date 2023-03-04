using ApplyForChina.Attributes;
using ApplyForChina.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
    public class SearchController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Search_University([FromUri] string UNV_Name, [FromUri] string City,
            [FromUri] string Degree, [FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@UNV_Name", UNV_Name);
                Parameters.Add("@City", City);
                Parameters.Add("@Degree", Degree);
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                var results =
                await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("Search_University", Parameters, commandType: CommandType.StoredProcedure);

                var unv = results.Read<University>().ToList();

                if (unv.Count() == 0)
                {
                    HttpContext.Current.Response.Headers.Add("Universities-total-count", results.Read<int>().FirstOrDefault().ToString());
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                }

                HttpContext.Current.Response.Headers.Add("Universities-total-count", results.Read<int>().FirstOrDefault().ToString());
                return Request.CreateResponse(HttpStatusCode.OK, unv);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Search_Program([FromUri] string PRG_Code, [FromUri] string PRG_Field,
            [FromUri] string PRG_Degree, [FromUri] string PRG_TL, [FromUri] float PRG_Duration,
            [FromUri] int PRG_Year, [FromUri] string PRG_Intake, [FromUri] string PRG_City, [FromUri] string UNV_Name,
            [FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Program_Code", PRG_Code);
                Parameters.Add("@Field", PRG_Field);
                Parameters.Add("@Degree", PRG_Degree);
                Parameters.Add("@Teaching_Languages", PRG_TL);
                Parameters.Add("@Duration", PRG_Duration);
                Parameters.Add("@Year", PRG_Year);
                Parameters.Add("@Intake", PRG_Intake);
                Parameters.Add("@City", PRG_City);
                Parameters.Add("@UNV_Name", UNV_Name);
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                var results =
                await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("Search_Program", Parameters, commandType: CommandType.StoredProcedure);

                var prg_unv = results.Read<dynamic>().ToList();

                if (prg_unv.Count() == 0)
                {
                    HttpContext.Current.Response.Headers.Add("Programs-total-count", results.Read<int>().FirstOrDefault().ToString());
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                }

                HttpContext.Current.Response.Headers.Add("Programs-total-count", results.Read<int>().FirstOrDefault().ToString());
                return Request.CreateResponse(HttpStatusCode.OK, prg_unv);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Search_Student([FromUri] int USR_ID, [FromUri] string Term, [FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@USR_ID", USR_ID);
                Parameters.Add("@Search_Term", Term);
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

               var results =
                    await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("Search_Student", Parameters, commandType: CommandType.StoredProcedure);

                var std = results.Read<Student>().ToList();
                if (std.Count() == 0)
                {
                    HttpContext.Current.Response.Headers.Add("Students-total-count", results.Read<int>().FirstOrDefault().ToString());
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                }

                HttpContext.Current.Response.Headers.Add("Students-total-count", results.Read<int>().FirstOrDefault().ToString());
                return Request.CreateResponse(HttpStatusCode.OK, std);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Search_Order([FromUri] int USR_ID, [FromUri] string Term, [FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@USR_ID", USR_ID);
                Parameters.Add("@Search_Term", Term);
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);
                
                var results =
                    await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("Search_Order", Parameters, commandType: CommandType.StoredProcedure);

                var ord_std = results.Read<dynamic>().ToList();

                if (ord_std.Count() == 0)
                {
                    HttpContext.Current.Response.Headers.Add("Orders-total-count", results.Read<int>().FirstOrDefault().ToString());
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                }

                HttpContext.Current.Response.Headers.Add("Orders-total-count", results.Read<int>().FirstOrDefault().ToString());
                return Request.CreateResponse(HttpStatusCode.OK, ord_std);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}