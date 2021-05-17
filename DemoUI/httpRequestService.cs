using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using DemoUI.Model;
using Newtonsoft.Json;

namespace DemoUI
{
    public class httpRequestService
    {

        public static APIServiceResponse MakeRequest(string requestUrl, string uriData, string bodyData, string contentType, HttpMethod httpMethod)
        {
            APIServiceResponse objResponse = new APIServiceResponse();

            try
            {

                string fullURL = requestUrl + uriData;


                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(30);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

                    if (httpMethod == HttpMethod.Get)
                    {
                        var task = client.GetAsync(fullURL)
                        .ContinueWith((taskwithresponse) =>
                        {
                            var response = taskwithresponse.Result;
                            var jsonString = response.Content.ReadAsStringAsync();
                            jsonString.Wait();
                            objResponse = JsonConvert.DeserializeObject<APIServiceResponse>(jsonString.Result);
                        });
                        task.Wait();

                    }
                    else if (httpMethod == HttpMethod.Post)
                    {
                        HttpContent contentPost = new StringContent(bodyData, Encoding.UTF8, contentType);

                        var task = client.PostAsync(fullURL, contentPost)
                         .ContinueWith((taskwithresponse) =>
                         {
                             var response = taskwithresponse.Result;
                             var jsonString = response.Content.ReadAsStringAsync();
                             jsonString.Wait();
                             objResponse = JsonConvert.DeserializeObject<APIServiceResponse>(jsonString.Result);

                         });
                        task.Wait();
                    }


                    return objResponse;
                }



            }
            catch (Exception ex)
            {
                objResponse.MESSAGE = (ex.InnerException != null) ? ex.Message + " :: " + ex.InnerException.Message : ex.Message;
                return objResponse;
            }
        }




        //public static List<Employee> GetAllRequest(string requestUrl, string uriData, string bodyData, string contentType, HttpMethod httpMethod)
        //{
        //    APIServiceResponse objResponse = new APIServiceResponse();
        //    Employee objEmployee = new Employee();
        //    List<Employee> listOfEmployee = new List<Employee>();

        //    try
        //    {

        //        string fullURL = requestUrl + uriData;


        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.Timeout = TimeSpan.FromMinutes(30);

        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

        //            if (httpMethod == HttpMethod.Get)
        //            {
        //                var task = client.GetAsync(fullURL)
        //                .ContinueWith((taskwithresponse) =>
        //                {
        //                    var response = taskwithresponse.Result;
        //                    var jsonString = response.Content.ReadAsStringAsync();
        //                    jsonString.Wait();
        //                    listOfEmployee = JsonConvert.DeserializeObject<List<Employee>>(jsonString.Result);
        //                });
        //                task.Wait();

        //            }
        //            else if (httpMethod == HttpMethod.Post)
        //            {
        //                HttpContent contentPost = new StringContent(bodyData, Encoding.UTF8, contentType);

        //                var task = client.PostAsync(fullURL, contentPost)
        //                 .ContinueWith((taskwithresponse) =>
        //                 {
        //                     var response = taskwithresponse.Result;
        //                     var jsonString = response.Content.ReadAsStringAsync();
        //                     jsonString.Wait();
        //                     objResponse = JsonConvert.DeserializeObject<APIServiceResponse>(jsonString.Result);

        //                 });
        //                task.Wait();
        //            }


        //            return listOfEmployee;
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        objResponse.MESSAGE = (ex.InnerException != null) ? ex.Message + " :: " + ex.InnerException.Message : ex.Message;
        //        return listOfEmployee;
        //    }
        //}






        public static List<Employee> GetAllRequest(string requestUrl, string uriData, string bodyData, string contentType, HttpMethod httpMethod)
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            Employee objEmployee = new Employee();
            List<Employee> listOfEmployee = new List<Employee>();

            try
            {

                string fullURL = requestUrl + uriData;




                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullURL);

                // turn our request string into a byte stream
                //byte[] postBytes = Encoding.ASCII.GetBytes(pRequestBody);

             
                 request.ContentType = "application/json";

                // If required by the server, set the credentials.
                request.Method = "GET";
                //request.ContentLength = postBytes.Length;
               // request.Credentials = CredentialCache.DefaultCredentials;

                //request.Headers.Add("X-API-KEY", pApiKey);
                //request.Headers.Add("X-AUTH-SECRET", pAuthSecret);
                //request.Headers.Add("X-ROUTE", pBranchRoutingNumber);

                //if (pMethod == "POST" && pRequestBody != "")
                //{
                //    using (var stream = request.GetRequestStream())
                //    {
                //        stream.Write(postBytes, 0, postBytes.Length);
                //    }
                //}

                // Get the response.
                WebResponse response = request.GetResponse();
                //////Library.WriteErrorLog("response", " TITASNONMETERGAS pCustomerCode", "", "");
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams and the response.
                reader.Close();
                response.Close();
                //////Library.WriteErrorLog("reader.Close()", " TITASNONMETERGAS pCustomerCode", "", "");
                //return responseFromServer;



                //objResponse = JsonConvert.DeserializeObject<Employee>(responseFromServer);

                listOfEmployee = JsonConvert.DeserializeObject<List<Employee>>(responseFromServer);


                return listOfEmployee;
              



            }
            catch (Exception ex)
            {
                objResponse.MESSAGE = (ex.InnerException != null) ? ex.Message + " :: " + ex.InnerException.Message : ex.Message;
                return listOfEmployee;
            }
        }







    }
}