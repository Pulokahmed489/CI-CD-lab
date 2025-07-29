using Newtonsoft.Json;
using NUnit.Framework;
using Serilog;
using Swagger.Api.Helpers;
using Swagger.Api.Models;
using Swagger.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static Swagger.Api.Models.SwaggerServiceApiObjects;

namespace Swagger.Tests.StepDefinition
{
    [Binding]
    class SwaggerServiceSwaggerSteps
    {
        SwaggerServiceApiObjects _apiObject;
        ApiResponse _apiResponse;
        WebRequestHelper webRequest = new WebRequestHelper();
        ResponseBody _responsebody = new ResponseBody();
        UserResponseBody _UserResponseBody = new UserResponseBody();
        public SwaggerServiceSwaggerSteps(SwaggerServiceApiObjects aPIObject, ApiResponse apiResponse)
        {
            this._apiObject = aPIObject;
            this._apiResponse = apiResponse;
        }

        [Given(@"I have a Api Service '(.*)'")]
        public void GivenIHaveSwaggerServicesAPI(string endPoint)
        {
            _apiObject = _apiObject.setCartApiEndPoint(endPoint, _apiObject, _responsebody.id.ToString());
            Log.Debug("Set Api Endpoint {0}", endPoint);
        }

        [When(@"I hit the api to place the order")]
        public void WhenIPerformAWebRequest()
        {
            _apiResponse = webRequest.CreateSwaggerServiceRequest(_apiObject, "POST");
            _responsebody = JsonConvert.DeserializeObject<ResponseBody>(_apiResponse.Data);

            Assertions assertions = new Assertions(_apiResponse, _responsebody);
            assertions.VerifyItem();

        }

        [When(@"I hit the user api with user info")]
        public void WhenIPerformAWebRequestWithUserInfo()
        {
            _apiResponse = webRequest.GetRequestReturnApiResponse(_apiObject);

            Assertions assertions = new Assertions(_apiResponse, _responsebody);
            assertions.VerifyuserItem();

        }

        [When(@"I hit the api to get the order details")]
        public void WhenIHitTheAPItoGetTheOrderDetails()
        {
            _apiResponse = webRequest.GetRequestReturnApiResponse(_apiObject, "GET");
            _responsebody = JsonConvert.DeserializeObject<ResponseBody>(_apiResponse.Data);
            //Assertions assertions = new Assertions(_responsebody);
            //assertions.VerifyItem();

        }



        [Then(@"I should get a valid response'(.*)'")]
        public void ThenIShouldSeeValidResponseContent(string status)
        {
            Assert.AreEqual(_apiResponse.StatusCode.ToString(), status);
        }

        [When(@"I hit the delete Api'(.*)'")]
        public void AndIHitTheDeleteApi(string endPoint)
        {
            _apiResponse = webRequest.CreateSwaggerDeleteService(_apiObject, "DELETE");
        }
    }
}
