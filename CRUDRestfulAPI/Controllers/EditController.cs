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
    public class EditController : ApiController
    {


        public HttpResponseMessage Edit([FromBody]Employee objEmployee)
        {
            HttpResponseMessage response;
            EditService objAddService = new EditService();
            string vMsg = string.Empty;

            try
            {
                vMsg = objAddService.Edit(objEmployee);


                if (string.IsNullOrEmpty(vMsg))
                {
                    string jsontxt = "{ STATUS : 'SUCCESS' , MESSAGE : 'Update Employee Successfully' }";
                    JObject json = JObject.Parse(jsontxt);
                    response = Request.CreateResponse(HttpStatusCode.OK, json);
                }
                else
                {
                    string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Update Employee Failed!' }";
                    JObject json = JObject.Parse(jsontxt);
                    response = Request.CreateResponse(HttpStatusCode.OK, json);
                }


                return response;
            }
            catch (Exception ex)
            {
                string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Update Employee Failed!' }";
                JObject json = JObject.Parse(jsontxt);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }


    }
}
