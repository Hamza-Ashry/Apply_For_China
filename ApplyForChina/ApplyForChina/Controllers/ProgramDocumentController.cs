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
    public class ProgramDocumentController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_PRG_Documents([FromUri] long PRG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PRG_ID", PRG_ID);

                IEnumerable<Program_Document> pd = await SingletonSqlConnection.Instance.Connection.QueryAsync<Program_Document>("Get_PRG_Documents", Parameters, commandType: CommandType.StoredProcedure);

                if (pd.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, pd);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        
        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Program_Document([FromBody] Program_Document dprg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PDOC_Field", dprg.PDOC_Field);
                Parameters.Add("@PDOC_PRG_ID", dprg.PDOC_PRG_ID);

                IEnumerable<int> pd = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Program_Document", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Program Document"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        
        [HttpPut]
        public async Task<HttpResponseMessage> Update_Program_Document([FromUri] long PDOC_ID, [FromBody] Program_Document dprg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PDOC_ID", PDOC_ID);
                Parameters.Add("@PDOC_Field", dprg.PDOC_Field);
                Parameters.Add("@PDOC_PRG_ID", dprg.PDOC_PRG_ID);

                IEnumerable<int> pd = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Program_Document", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Program Document"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}