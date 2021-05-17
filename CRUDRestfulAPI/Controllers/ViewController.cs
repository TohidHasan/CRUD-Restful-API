using CRUDRestfulAPI.Models;
using CRUDRestfulAPI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CRUDRestfulAPI.Controllers
{
    public class ViewController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage View(string  EmployeeId)
        {
            HttpResponseMessage response;
            ViewService objViewService = new ViewService();
            Employee objEmployee = new Employee();
            string vMsg = string.Empty;


            try
            {
                objEmployee = objViewService.View(EmployeeId.ToString());


                if (string.IsNullOrEmpty(vMsg))
                {
                    //string jsontxt = "{ STATUS : 'SUCCESS' , MESSAGE : 'Get Data Successfully' }";
                    //JObject json = JObject.Parse(jsontxt);
                    //response = Request.CreateResponse(HttpStatusCode.OK, json);
                    
                    response = Request.CreateResponse(HttpStatusCode.OK, objEmployee);
                    return response;


                }
                else
                {
                    string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Get Data Failed!' }";
                    JObject json = JObject.Parse(jsontxt);
                    response = Request.CreateResponse(HttpStatusCode.OK, json);
                }


                return response;
            }
            catch (Exception ex)
            {
                string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Get Data Failed!' }";
                JObject json = JObject.Parse(jsontxt);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }



        [HttpGet]
        [Route("api/ViewAll")]
        public HttpResponseMessage ViewAll()
        {
            HttpResponseMessage response;
            ViewService objViewService = new ViewService();
            Employee objEmployee = new Employee();
            List<Employee> listObjEmployee = new List<Employee>();
            string vMsg = string.Empty;


            try
            {
                listObjEmployee = objViewService.ViewAll();


                if (string.IsNullOrEmpty(vMsg))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, listObjEmployee);
                    return response;


                }
                else
                {
                    string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Get Data Failed!' }";
                    JObject json = JObject.Parse(jsontxt);
                    response = Request.CreateResponse(HttpStatusCode.OK, json);
                }


                return response;
            }
            catch (Exception ex)
            {
                string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Get Data Failed!' }";
                JObject json = JObject.Parse(jsontxt);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }






    }
}
