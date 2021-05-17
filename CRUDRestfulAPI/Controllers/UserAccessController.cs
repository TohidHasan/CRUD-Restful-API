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
    
    public class UserAccessController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetUserAccess(string UserId, string Password)
        {
            HttpResponseMessage response;
            UserAccessService objUserAccessService = new UserAccessService();
            USER_PROFILE ObjUSER_PROFILE = new USER_PROFILE();
            string vMsg = string.Empty;


            try
            {
                ObjUSER_PROFILE = objUserAccessService.GetUserAccess(UserId, Password);


                if (!string.IsNullOrEmpty(ObjUSER_PROFILE.USER_ID))
                {
                    if (string.Compare(UserId, ObjUSER_PROFILE.USER_ID) == 0 && string.Compare(Password, ObjUSER_PROFILE.USER_PASSWORD) == 0)
                    {
                        string jsontxt = "{ STATUS : 'SUCCESS', MESSAGE : 'Log In Succesfully!' }";
                        JObject json = JObject.Parse(jsontxt);
                        response = Request.CreateResponse(HttpStatusCode.OK, json);
                        //response = Request.CreateResponse(HttpStatusCode.OK, ObjUSER_PROFILE);
                    }
                    else
                    {
                        string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Invalid User Id or Password!' }";
                        JObject json = JObject.Parse(jsontxt);
                        response = Request.CreateResponse(HttpStatusCode.OK, json);
                    }
                    
                    return response;


                }
                else
                {
                    string jsontxt = "{ STATUS : 'FAIL', MESSAGE : 'Invalid User Id or Password!' }";
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
