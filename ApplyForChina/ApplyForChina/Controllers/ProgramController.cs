using ApplyForChina.Attributes;
using ApplyForChina.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public class ProgramController : ApiController
    {
        private IEnumerable<Program_Document> Get_PRG_Documents(long PRG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_ID", PRG_ID);

                IEnumerable<Program_Document> pd = 
                    SingletonSqlConnection.Instance.Connection.Query<Program_Document>("Get_PRG_Documents", Parameters, commandType: CommandType.StoredProcedure);

                if (pd.Count() == 0)
                    return null;
                return pd;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Program_FeeStructure> Get_PRG_Fees(long PRG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_ID", PRG_ID);

                IEnumerable<Program_FeeStructure> pfs = 
                    SingletonSqlConnection.Instance.Connection.Query<Program_FeeStructure>("Get_PRG_Fees", Parameters, commandType: CommandType.StoredProcedure);

                if (pfs.Count() == 0)
                    return null;
                return pfs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Program_By_ID([FromUri] long PRG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_ID", PRG_ID);

                var result =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Program>("Get_Program_By_ID", Parameters, commandType: CommandType.StoredProcedure);


                Program full_prg = null;
                full_prg = result.FirstOrDefault();
                if (full_prg != null)
                {
                    full_prg.PDOC = Get_PRG_Documents(full_prg.PRG_ID);
                    full_prg.PFS = Get_PRG_Fees(full_prg.PRG_ID);
                }
                
                if (full_prg == null)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, full_prg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Hot_Programs([FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                var results =
                    await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("Get_Hot_Programs", Parameters, commandType: CommandType.StoredProcedure);

                var hprg = results.Read<dynamic>().ToList();

                HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Type, HotPrograms-total-count");

                if (hprg.Count() == 0)
                {
                    HttpContext.Current.Response.Headers.Add("HotPrograms-total-count", results.Read<int>().FirstOrDefault().ToString());
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                }

                HttpContext.Current.Response.Headers.Add("HotPrograms-total-count", results.Read<int>().FirstOrDefault().ToString());
                return Request.CreateResponse(HttpStatusCode.OK, hprg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Program([FromBody] Program prg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_Image", prg.PRG_Image);
                Parameters.Add("@PRG_Name", prg.PRG_Name);
                Parameters.Add("@PRG_SST_ID", prg.PRG_SST_ID);
                Parameters.Add("@PRG_Old_Price", prg.PRG_Old_Price);
                Parameters.Add("@PRG_New_Price", prg.PRG_New_Price);
                Parameters.Add("@PRG_Intake", prg.PRG_Intake);
                Parameters.Add("@PRG_Year", prg.PRG_Year);
                Parameters.Add("@PRG_Degree", prg.PRG_Degree);
                Parameters.Add("@PRG_Teaching_Languages", prg.PRG_Teaching_Languages);
                Parameters.Add("@PRG_Field", prg.PRG_Field);
                Parameters.Add("@PRG_Expired_date", prg.PRG_Expired_date);
                Parameters.Add("@PRG_Duration", prg.PRG_Duration);
                Parameters.Add("@PRG_Policy", prg.PRG_Policy);
                Parameters.Add("@PRG_Requerments", prg.PRG_Requerments);
                Parameters.Add("@PRG_Special_Notes", prg.PRG_Special_Notes);
                Parameters.Add("@PRG_UNV_ID", prg.PRG_UNV_ID);

                IEnumerable<int> p =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Program", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Program", p.First()));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Hot_Program([FromBody] Hot_Program hprg)
        {
            using (var Transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
            {
                try
                {
                    foreach (int id in hprg.PHOT_PRG_IDs)
                    {
                        IEnumerable<int> p =
                            await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Hot_Program", new { PHOT_PRG_ID = id }, commandType: CommandType.StoredProcedure, transaction: Transaction);
                    }

                    Transaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Hot Program"));
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
                }
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_Program([FromUri] long PRG_ID, [FromBody] Program prg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_ID", PRG_ID);
                Parameters.Add("@PRG_Image", prg.PRG_Image);
                Parameters.Add("@PRG_Name", prg.PRG_Name);
                Parameters.Add("@PRG_SST_ID", prg.PRG_SST_ID);
                Parameters.Add("@PRG_Old_Price", prg.PRG_Old_Price);
                Parameters.Add("@PRG_New_Price", prg.PRG_New_Price);
                Parameters.Add("@PRG_Intake", prg.PRG_Intake);
                Parameters.Add("@PRG_Year", prg.PRG_Year);
                Parameters.Add("@PRG_Degree", prg.PRG_Degree);
                Parameters.Add("@PRG_Teaching_Languages", prg.PRG_Teaching_Languages);
                Parameters.Add("@PRG_Field", prg.PRG_Field);
                Parameters.Add("@PRG_Expired_date", prg.PRG_Expired_date);
                Parameters.Add("@PRG_Duration", prg.PRG_Duration);
                Parameters.Add("@PRG_Policy", prg.PRG_Policy);
                Parameters.Add("@PRG_Requerments", prg.PRG_Requerments);
                Parameters.Add("@PRG_Special_Notes", prg.PRG_Special_Notes);
                Parameters.Add("@PRG_UNV_ID", prg.PRG_UNV_ID);

                IEnumerable<int> p =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Program", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Program"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Program([FromUri] long PRG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_ID", PRG_ID);

                IEnumerable<int> p =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Program", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Program"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Hot_Program([FromUri] long PHOT_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PHOT_ID", PHOT_ID);

                IEnumerable<int> p =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Hot_Program", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Hot Program"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}