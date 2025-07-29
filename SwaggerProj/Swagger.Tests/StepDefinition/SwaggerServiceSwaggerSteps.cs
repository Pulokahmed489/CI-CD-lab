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
    public class SwaggerServiceSwaggerSteps
    {
        private SwaggerServiceApiObjects _apiObject;
        private ApiResponse _apiResponse;
        private readonly WebRequestHelper _webRequest = new WebRequestHelper();
        private ResponseBody _responseBody = new ResponseBody();
        private UserResponseBody _userResponseBody = new UserResponseBody();

        public SwaggerServiceSwaggerSteps(SwaggerServiceApiObjects apiObject, ApiResponse apiResponse)
        {
            _apiObject = apiObject;
            _apiResponse = apiResponse;
        }

        [Given("I have an API service '(.*)'")]
        public void GivenIHaveAnApiService(string endpoint)
        {
            var id = _responseBody?.id.ToString() ?? "default_id";
            _apiObject = _apiObject.setCartApiEndPoint(endpoint, _apiObject, id);
            Log.Debug("Set API Endpoint {0}", endpoint);
        }

        [When("I hit the API to place the order")]
        public void WhenIHitTheApiToPlaceTheOrder()
        {
            _apiResponse = _webRequest.CreateSwaggerServiceRequest(_apiObject, "POST");
            _responseBody = JsonConvert.DeserializeObject<ResponseBody>(_apiResponse.Data);

            Assertions assertions = new Assertions(_apiResponse, _responseBody);
            assertions.VerifyItem();
        }

        [When("I hit the user API with user info")]
        public void WhenIHitTheUserApiWithUserInfo()
        {
            _apiResponse = _webRequest.GetRequestReturnApiResponse(_apiObject);

            Assertions assertions = new Assertions(_apiResponse, _responseBody);
            assertions.VerifyuserItem();
        }

        [When("I hit the API to get the order details")]
        public void WhenIHitTheApiToGetTheOrderDetails()
        {
            _apiResponse = _webRequest.GetRequestReturnApiResponse(_apiObject, "GET");
            _responseBody = JsonConvert.DeserializeObject<ResponseBody>(_apiResponse.Data);
        }

        [When("I hit the delete API '(.*)'")]
        public void WhenIHitTheDeleteApi(string endpoint)
        {
            _apiResponse = _webRequest.CreateSwaggerDeleteService(_apiObject, "DELETE");
        }

        [Then("I should get a valid response '(.*)'")]
        public void ThenIShouldGetAValidResponse(string status)
        {
            Assert.AreEqual(status, _apiResponse.StatusCode.ToString());
        }
    }
}