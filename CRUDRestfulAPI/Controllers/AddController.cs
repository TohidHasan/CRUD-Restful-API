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
    public class AddController : ApiController
    {



        public HttpResponseMessage Add([FromBody]Employee objEmployee)
        {
            HttpResponseMessage response;
            AddService objAddService = new AddService();
            string vMsg = string.Empty;

            try
            {
                vMsg = objAddService.Add(objEmployee);


                if (string.IsNullOrEmpty(vMsg))
                {
                    string jsontxt = "{ STATUS : 'SUCCESS' , MESSAGE : 'Add Employee Successfully' }";
                    JObject json = JObject.Parse(jsontxt);
                    response = Request.CreateResponse(HttpStatusCode.OK, json);
                }
                else
                {
                    string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Add Employee Failed!' }";
                    JObject json = JObject.Parse(jsontxt);
                    response = Request.CreateResponse(HttpStatusCode.OK, json);
                }


                return response;
            }
            catch (Exception ex)
            {
                string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Add Employee Failed!' }";
                JObject json = JObject.Parse(jsontxt);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }




    }
}
