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
    public class PayedImageController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get_Payed_Images([FromUri] int Page_Number, [FromUri] int Limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Page_Number", Page_Number);
                Parameters.Add("@Limit", Limit);

                IEnumerable<Payed_Image> pimg =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<Payed_Image>("Get_Payed_Images", Parameters, commandType: CommandType.StoredProcedure);

                if (pimg.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, pimg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert_Payed_Image([FromBody] Payed_Image pimg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PIMG_Image", pimg.PIMG_Image);
                Parameters.Add("@PIMG_PNL_ID", pimg.PIMG_PNL_ID);
                Parameters.Add("@PIMG_ORD_ID", pimg.PIMG_ORD_ID);

                IEnumerable<int> p =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Insert_Payed_Image", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Inserted_Successfully("Payed Image"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get_Payed_Images_Total()
        {
            try
            {
                IEnumerable<int> pimg =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Get_Payed_Images_Total", commandType: CommandType.StoredProcedure);

                if (pimg.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.Gone, Messages.Not_Found());
                return Request.CreateResponse(HttpStatusCode.OK, pimg.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_Payed_Image([FromUri] long PIMG_ID, [FromBody] Payed_Image pimg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PIMG_ID", PIMG_ID);
                Parameters.Add("@PIMG_Image", pimg.PIMG_Image);
                Parameters.Add("@PIMG_PNL_ID", pimg.PIMG_PNL_ID);
                Parameters.Add("@PIMG_ORD_ID", pimg.PIMG_ORD_ID);

                IEnumerable<int> p =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_Payed_Image", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Payed Image"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update_PayedImage_Approved([FromUri] long PIMG_ID, [FromBody] Payed_Image pimg)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PIMG_ID", PIMG_ID);
                Parameters.Add("@PIMG_IsApproved", pimg.@PIMG_IsApproved);

                IEnumerable<int> p =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Update_PayedImage_Approved", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Updated_Successfully("Payed Image"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete_Payed_Image([FromUri] long PIMG_ID)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PIMG_ID", PIMG_ID);

                IEnumerable<int> p =
                    await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("Delete_Payed_Image", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.Deleted_Successfully("Payed Image"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
    }
}