using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.IdentityModel.Protocols;

namespace MT
{
    public class FunctionTrigger
    {
        [Function("SendMail")]
        public async Task<IActionResult> Run(
            [Microsoft.Azure.Functions.Worker.HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestData req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = ""; // req.Uri.qu["name"];

            string requestBody = await new StreamReader(new MemoryStream(req.Body)).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello,. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
