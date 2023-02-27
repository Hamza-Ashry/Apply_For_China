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
    public class ProgramFeeStructureController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_PRG_Fees([FromUri] long PRG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_ID", PRG_ID);

                IEnumerable<Program_FeeStructure> pfs =  await SingletonSqlConnection.Instance.Connection.QueryAsync<Program_FeeStructure>("Get_PRG_Fees", Parameters, commandType: CommandType.StoredProcedure);

                if (pfs.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, pfs);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        
        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Program_FeeStructure([FromBody] Program_FeeStructure pfs)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PFS_FeeStructure", pfs.PFS_FeeStructure);
                Parameters.Add("@PFS_Price", pfs.PFS_Price);
                Parameters.Add("@PFS_PRG_ID", pfs.PFS_PRG_ID);

                IEnumerable<int> p = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Program_FeeStructure", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Programs FeeStructure"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        
        [HttpPut]
        public async Task<HttpResponseMessage> Update_Program_FeeStructure([FromUri] long PFS_ID, [FromBody] Program_FeeStructure pfs)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PFS_ID", PFS_ID);
                Parameters.Add("@PFS_FeeStructure", pfs.PFS_FeeStructure);
                Parameters.Add("@PFS_Price", pfs.PFS_Price);
                Parameters.Add("@PFS_PRG_ID", pfs.PFS_PRG_ID);

                IEnumerable<int> p = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Program_FeeStructure", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Programs FeeStructure"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}