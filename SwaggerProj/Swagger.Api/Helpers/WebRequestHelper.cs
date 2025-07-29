using Swagger.Api.Models;
using System.IO;
using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace Swagger.Api.Helpers
{
    public class WebRequestHelper
    {
        public ApiResponse GetRequestReturnApiResponse(SwaggerServiceApiObjects apiObject, object T = null)
        {

            WebRequest webRequest = null;
            webRequest = sendWebRequest(apiObject, T);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            DateTime tempdate = DateTime.UtcNow;

            string currentTime = tempdate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

            Stream receiveStream = webResponse.GetResponseStream();
            Encoding encode = Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode);
            string responseData = readStream.ReadToEnd();

            ApiResponse apiResponse = new ApiResponse()
            {
                StatusCode = (int)webResponse.StatusCode,
                StatusDescription = webResponse.StatusDescription.ToString(),
                Data = responseData,
                timeStamp = currentTime

            };

            readStream.Close();
            webResponse.Close();
            return apiResponse;
        }

        private WebRequest sendWebRequest(SwaggerServiceApiObjects apiObject, Object T = null)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(apiObject.Url);
                if (webRequest != null)
                {
                    webRequest.Method = RequestMethod.GET.ToString();
                    webRequest.Timeout = 10000;
                    webRequest.ContentType = "application/json";

                    return webRequest;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public ApiResponse CreateSwaggerServiceRequest(SwaggerServiceApiObjects apiObject, string RequestMethod)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(apiObject.Url);
                webRequest.Method = RequestMethod;
                webRequest.Timeout = 12000;
                byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(apiObject.body));
                webRequest.ContentLength = byteArray.Length;
                webRequest.ContentType = "application/json";
                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                var webResponse = (HttpWebResponse)webRequest.GetResponseWithoutException();
                var result = "";
                using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                ApiResponse apiResponse = new ApiResponse()
                {
                    StatusCode = (int)webResponse.StatusCode,
                    StatusDescription = webResponse.StatusDescription.ToString(),
                    Data = result
                };

                return apiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse apiResponse = new ApiResponse()
                {
                    StatusCode = 400,
                    StatusDescription = ex.Message,
                    Data = ex.Message
                };

                return apiResponse;
            }
        }

        public ApiResponse CreateSwaggerUserInfoRequest(SwaggerServiceApiObjects apiObject, string RequestMethod)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(apiObject.Url);
                webRequest.Method = RequestMethod;
                webRequest.Timeout = 12000;
                byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(apiObject.arraylist));
                webRequest.ContentLength = byteArray.Length;
                webRequest.ContentType = "application/json";
                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                var webResponse = (HttpWebResponse)webRequest.GetResponseWithoutException();
                var result = "";
                using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                ApiResponse apiResponse = new ApiResponse()
                {
                    StatusCode = (int)webResponse.StatusCode,
                    StatusDescription = webResponse.StatusDescription.ToString(),
                    Data = result
                };

                 return apiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse apiResponse = new ApiResponse()
                {
                    StatusCode = 400,
                    StatusDescription = ex.Message,
                    Data = ex.Message
                };

                return apiResponse;
            }
        }

        public ApiResponse CreateSwaggerDeleteService(SwaggerServiceApiObjects apiObject, string RequestMethod)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(apiObject.Url);
                webRequest.Method = RequestMethod;
                webRequest.Timeout = 12000;
                byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(apiObject.body));
                webRequest.ContentLength = byteArray.Length;
                webRequest.ContentType = "application/json";
                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                var webResponse = (HttpWebResponse)webRequest.GetResponseWithoutException();
                var result = "";
                using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                ApiResponse apiResponse = new ApiResponse()
                {
                    StatusCode = (int)webResponse.StatusCode,
                    StatusDescription = webResponse.StatusDescription.ToString(),
                    Data = result
                };

                return apiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse apiResponse = new ApiResponse()
                {
                    StatusCode = 400,
                    StatusDescription = ex.Message,
                    Data = ex.Message
                };

                return apiResponse;
            }
        }
    }





    public enum RequestMethod
    {
        GET,
        POST,
        PUT,
        DELET
    }

    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Data { get; set; }
        public string status { get; set; }
        public string timeStamp { get; set; }
    }
}
