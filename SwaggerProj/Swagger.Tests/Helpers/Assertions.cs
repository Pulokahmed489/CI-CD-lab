using Newtonsoft.Json;
using NUnit.Framework;
using Swagger.Api.Helpers;
using Swagger.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using static Swagger.Api.Models.SwaggerServiceApiObjects;
using FluentAssertions;

namespace Swagger.Tests.Helpers
{
    public class Assertions 
    {
        ApiResponse _jsonResponse;
        ResponseBody _responseBody;
        UserResponseBody _userResponseBody;
        SwaggerServiceApiObjects ApiObjects = new SwaggerServiceApiObjects();
        public Assertions(ApiResponse JsonResponse, ResponseBody responseBody)
        {
            _jsonResponse = JsonResponse;
            _responseBody = responseBody;
        }
        public void VerifyItem()
        {
            Assert.AreEqual(_responseBody.id, ApiObjects.body.id);
            Assert.AreEqual(_responseBody.petId, ApiObjects.body.petId);
            Assert.AreEqual(_responseBody.quantity, ApiObjects.body.quantity);
            Assert.AreEqual(_responseBody.status, ApiObjects.body.status);
            Assert.AreEqual(_responseBody.complete, ApiObjects.body.complete);
        }

        public void VerifyuserItem()
        {
            Assert.AreEqual(_jsonResponse.StatusDescription, _jsonResponse.StatusDescription);
            Assert.AreEqual(_jsonResponse.StatusCode, 200);
            Assert.AreEqual(_jsonResponse.status, null);
        }
    }
}
