using Serilog;
using Swagger.Api.Helpers;
using Swagger.Api.Models;
using TechTalk.SpecFlow;
using System;
using NUnit.Framework;

namespace Swagger.Tests.StepDefinition
{
    [Binding]
    class SwaggerServiceBase
    {
        SwaggerServiceApiObjects _apiObject;
        ApiResponse _apiResponse;
        string starttime;
        string endtime;
        WebRequestHelper webRequest = new WebRequestHelper();
        ApiResponse _body = new ApiResponse();
        public SwaggerServiceBase(SwaggerServiceApiObjects aPIObject, ApiResponse apiResponse)
        {
            this._apiObject = aPIObject;
            this._apiResponse = apiResponse;
        }

        [Given(@"I have a Swagger Services API '(.*)'")]
        public void GivenIHaveSwaggerServicesAPI(string endPoint)
        {
            _apiObject = _apiObject.setCartApiEndPoint(endPoint, _apiObject);
            Log.Debug("Set Api Endpoint {0}", endPoint);
        }

        [When(@"I perform a web request")]
        public void WhenIPerformAWebRequest()
        {
            _apiResponse = webRequest.GetRequestReturnApiResponse(_apiObject);
            starttime = DateTime.Now.ToString("hh:dd:tt:ss");
            Console.WriteLine("Start time is" + starttime);
        }

        [When(@"I perform a second web request")]
        public void WhenIPerformASecondWebRequest()
        {
            _apiResponse = webRequest.GetRequestReturnApiResponse(_apiObject);
            endtime = DateTime.Now.ToString("hh:dd:tt:ss");
            Console.WriteLine("end time is" + endtime);
        }

        [Then(@"I should see a valid response'(.*)'")]
        public void ThenIShouldSeeValidResponseContent(string status)
        {

            Assert.AreEqual(_apiResponse.StatusCode.ToString(), status);
        }
    }
}
