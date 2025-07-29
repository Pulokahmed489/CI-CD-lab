using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swagger.Api.Models
{
    public class SwaggerServiceApiObjects
    {
        public Body body = new Body();
        public List<Body2> arraylist = new List<Body2>();
        public string Url { get; set; }

        [Serializable]
        public class Body
        {
            public int id { get; set; } = 1;
            public int petId { get; set; } = 10;
            public int quantity { get; set; } = 5;
            public string status { get; set; } = "placed";
            public Boolean complete { get; set; } = true;
        }

        [Serializable]
        public class Body2

        {
            public int id { get; set; } = 2;
            public string username { get; set; } = "Mahboob Hassan";
            public string firstName { get; set; } = "Mahboob";
            public string lastName { get; set; } = "Hassan";
            public string email { get; set; } = "hassan@yahoo.com";
            public string password { get; set; } = "123";
            public string phone { get; set; } = "145677";
            public int userStatus { get; set; } = 1;

           
        }

        string BaseUrl = "https://petstore.swagger.io/";

        public SwaggerServiceApiObjects setCartApiEndPoint(string endPoint, SwaggerServiceApiObjects swaggerServiceAPIObject, string orderId = null, string cartItemId = null,string status=null)
        {
            switch (endPoint.ToLower())
            {
                case "health":
                    swaggerServiceAPIObject.Url = $"{BaseUrl}?_ga=2.105844231.522434209.1637891362-43478109.1637202612";
                    break;
                case "create":
                    swaggerServiceAPIObject.Url = $"{BaseUrl}v2/store/order";
                    break;
                case "get":
                    swaggerServiceAPIObject.Url = $"{BaseUrl}v2/store/order/{orderId}";
                    break;
                case "delete":
                    swaggerServiceAPIObject.Url = $"{BaseUrl}v2/store/order/{orderId}";
                    break;
                case "usercreate":
                    swaggerServiceAPIObject.Url = $"{BaseUrl}v2/user/createWithArray";
                    break;
                case "findbystatus":
                    swaggerServiceAPIObject.Url = $"{BaseUrl}v2/pet/findByStatus?status={status}";
                    break;
                default: return null;
            }
            return swaggerServiceAPIObject;
        }

        public class ResponseBody
        {
            public int id { get; set; }
            public int petId { get; set; }
            public int quantity { get; set; }
            public string status { get; set; }
            public Boolean complete { get; set; }
        }

        public class UserResponseBody
        {
            public int code { get; set; }
            public string type { get; set; }
            public string message { get; set; }
        }
    }
}
