using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;

;

namespace MailTest
{
    
    namespace DemoIsolatedFunction.Functions
    {
        public class test
        {
            public string name { get; set; }
        }
        public class MailTrigger
        {                      
            [Function("SendMail")]
            public async Task<HttpResponseData> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
                 HttpRequestData req,
                FunctionContext executionContext)
            {
                HttpResponseData response;
                var logger = executionContext.GetLogger("InsertTodo");
                logger.LogInformation("C# HTTP trigger function processed a request.");

                try
                {
                    var request = await new StreamReader(req.Body).ReadToEndAsync();

                    //var todo = JsonSerializer.Deserialize<TodoItem>(request);                   

                    response = req.CreateResponse(HttpStatusCode.OK);
                    var list = new List<test>() { new test { name = "2" }, new test { name = "3" }, };
                    var s = new MemoryStream();
                    new BinaryFormatter().Serialize(s, list);
                    response.Body = (s);
                }
                catch (Exception ex)
                {
                    logger.LogError($"Exception thrown: {ex.Message}");
                    response = req.CreateResponse(HttpStatusCode.InternalServerError);
                }

                return response;
            }
        }
    }
}
