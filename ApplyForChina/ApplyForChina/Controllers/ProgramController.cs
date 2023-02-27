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
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApplyForChina.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProgramController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_ALL_Programs([FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                IEnumerable<Program> prg =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Program>("Get_ALL_Programs", Parameters, commandType: CommandType.StoredProcedure);

                if (prg.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, prg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Scholarships([FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                IEnumerable<Program> prg =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Program>("Get_Scholarships", Parameters, commandType: CommandType.StoredProcedure);

                if (prg.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, prg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Selffinanceds([FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                IEnumerable<Program> prg =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Program>("Get_Selffinanceds", Parameters, commandType: CommandType.StoredProcedure);

                if (prg.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, prg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Program_By_ID([FromUri] long PRG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_ID", PRG_ID);

                IEnumerable<Program> prg =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Program>("Get_Program_By_ID", Parameters, commandType: CommandType.StoredProcedure);

                if (prg.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, prg.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Program_By_Code([FromUri] string PRG_Code)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_Program_Code", PRG_Code);

                IEnumerable<Program> prg =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Program>("Get_Program_By_Code", Parameters, commandType: CommandType.StoredProcedure);

                if (prg.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, prg.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Programs_Total()
        {
            try
            {
                IEnumerable<int> total =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Get_Programs_Total", commandType: CommandType.StoredProcedure);

                if (total.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, total.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Scholarships_Total()
        {
            try
            {
                IEnumerable<int> total =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Get_Scholarships_Total", commandType: CommandType.StoredProcedure);

                if (total.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, total.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Selffinanceds_Total()
        {
            try
            {
                IEnumerable<int> total =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Get_Selffinanceds_Total", commandType: CommandType.StoredProcedure);

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
    }
}