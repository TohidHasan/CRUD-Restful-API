using CRUDRestfulAPI.Models;
using CRUDRestfulAPI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDRestfulAPI.Controllers
{
    public class DeleteController : ApiController
    {

        public HttpResponseMessage Delete([FromBody]Employee objEmployee)
        {
            HttpResponseMessage response;
            DeleteService objDeleteService = new DeleteService();
            string vMsg = string.Empty;

            try
            {
                vMsg = objDeleteService.Delete(objEmployee);


                if (string.IsNullOrEmpty(vMsg))
                {
                    string jsontxt = "{ STATUS : 'SUCCESS' , MESSAGE : 'Delete Employee Successfully' }";
                    JObject json = JObject.Parse(jsontxt);
                    response = Request.CreateResponse(HttpStatusCode.OK, json);
                }
                else
                {
                    string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Delete Employee Failed!' }";
                    JObject json = JObject.Parse(jsontxt);
                    response = Request.CreateResponse(HttpStatusCode.OK, json);
                }


                return response;
            }
            catch (Exception ex)
            {
                string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Delete Employee Failed!' }";
                JObject json = JObject.Parse(jsontxt);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }

    }
}
