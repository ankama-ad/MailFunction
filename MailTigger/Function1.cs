using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using PuppeteerSharp;
using System.Net.Mail;
using System.Net.Mime;
using AppOwnsData.Services;
using System.Text.Json;
using System.Collections.Generic;
//using ERP.Data.Services;
//using ERP.Data.Subscriptions;
using MailFunction.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace MailTigger
{
    public class SubscriptionDataModel
    {
        public int ReportSubscriptionId { get; set; }
        public string ReportId { get; set; }
        public string WorkspaceId { get; set; }

        public string Email { get; set; }
        public int? UseridEmail { get; set; }
        public string Frequency { get; set; }
        public string Weekday { get; set; }
        public string DateOfMonth { get; set; }
        public TimeSpan? SheduledTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class Function1
    {
        [Function("Function1")]
        public async Task<HttpResponseData> Run(
            [Microsoft.Azure.Functions.Worker.HttpTrigger(Microsoft.Azure.Functions.Worker.AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            string name = ""; //  req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonSerializer.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            // return new OkObjectResult(responseMessage);
            try
            {
                //// var subscriptionsByuser = new List<IGrouping<int?, SubscriptionDataModel>>(); 

                var listsring = "[{\"ReportSubscriptionId\":0,\"ReportId\":\"7779d348-1f55-4527-8594-4b1dcb9e7364\",\"WorkspaceId\":\"a5ebd5be-6706-4bcc-b342-1d0771af780c\",\"Email\":\"ajay@powerbiaxes.onmicrosoft.com\",\"UseridEmail\":7,\"Frequency\":null,\"Weekday\":null,\"DateOfMonth\":null,\"SheduledTime\":null,\"StartDate\":null,\"EndDate\":null}]";
                var list = JsonSerializer.Deserialize<List<SubscriptionDataModel>>(listsring);
                var subscriptionsByuser = list.GroupBy(c => c.UseridEmail).ToList();

                logger.LogInformation(JsonSerializer.Serialize(list));
                foreach (var subs in subscriptionsByuser)
                {
                    //int propertyIntOfClassA = userid.;

                    //iterating through values
                    foreach (var sub in subs)
                    {

                        // int key = classA.PropertyIntOfClassA;
                        await this.SendMailForUser(sub);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return req.CreateResponse(HttpStatusCode.InternalServerError);

            }
            var response = req.CreateResponse(HttpStatusCode.OK);
            return response;
            // return new OkObjectResult(responseMessage);
            // Console.WriteLine("End");
        }

        private async Task SendMailForUser(SubscriptionDataModel subscription)
        {
            try
            {
                var embedResult = await EmbedService.GetEmbedParams(Guid.Parse(subscription.WorkspaceId), Guid.Parse(subscription.ReportId));

                Console.WriteLine(JsonSerializer.Serialize(embedResult));
                var accessToken = embedResult.EmbedToken.Token;
                var embedUrl = embedResult.EmbedReports[0].EmbedUrl;
                var reportId = embedResult.EmbedReports[0].ReportId.ToString();
                var title = embedResult.EmbedReports[0].ReportName;
                //Renderer.PrintOptions.RenderDelay = 5000;
                //Renderer.PrintOptions.EnableJavaScript = true;
                //Renderer.RenderUrlAsPdf("http://localhost:4200/#/login").SaveAs("../../../url.pdf");
                //var uri = new Uri("http://localhost:4200/#/login");

                //var state  = await Renderer.RenderUrlAsPdfAsync(uri);
                //state.SaveAs("../../../report.pdf");
                //Console.WriteLine("file saved");


                // *****************************puppeteer sharp ***************************//


                var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
                Browser browser = await Puppeteer.LaunchAsync(
                    new LaunchOptions { Headless = true });
                var page = await browser.NewPageAsync();
                await page.SetViewportAsync(new ViewPortOptions
                {
                    Width = 1900,
                    Height = 900
                });
                var navOptions = new NavigationOptions() { Timeout = 30000, WaitUntil = new WaitUntilNavigation[] { WaitUntilNavigation.Networkidle2 } };               
                var path = await GetFilePath(reportId, accessToken, embedUrl, title);
                await page.GoToAsync(new Uri(path).AbsoluteUri);
               
                Console.WriteLine("waiting for page load");
                await page.WaitForSelectorAsync("#rendered");
                await Task.Delay(6000);
                //await watchDog;
                await page.ScreenshotAsync(subscription.ReportId + ".jpeg");
                Console.WriteLine("screenshot saved");

                using (var memStream = new MemoryStream())
                {
                    try
                    {
                        page.ScreenshotStreamAsync().Result.CopyTo(memStream);
                        var base64Stream = Convert.ToBase64String(memStream.ToArray());
                        // Attachment attach = new Attachment(pf.InputStream, pf.FileName);
                        // message.Attachments.Add(attach);
                        // Console.WriteLine(mything);
                        //var html = "<body>< img src = 'data:image/jpeg;base64," + base64Stream + "\'/></body>";
                        var html = "<body><img alt =\"\" src =\"cid: MyImage\"/></body>";
                        string emailReadyHtml = string.Empty;
                        emailReadyHtml += "<p>Hello World, below are two embedded images : </p>";
                        emailReadyHtml += "<img src=\"cid:yasser\" >";
                        emailReadyHtml += "<img src=\"cid:smile\" >";


                        MailMessage message = new MailMessage("anks501@gmail.com", "ankama.bollimuntha@amnetdigital.com", "Report Updates", emailReadyHtml);
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                        message.IsBodyHtml = true;
                        // message.To.Add("kalidasu.surada@amnetdigital.com");
                        //message.To.Add("saikrishna.kusuma@amnetdigital.com");
                        //message.To.Add("anudeep.kappakanti@amnetdigital.com");
                        ContentType c = new ContentType("image/jpeg");                        
                        // create image resource from image path using LinkedResource class.
                        LinkedResource linkedResource1 = new LinkedResource(subscription.ReportId + ".jpeg");
                        linkedResource1.ContentType = c;
                        linkedResource1.ContentId = "yasser";
                        linkedResource1.TransferEncoding = TransferEncoding.Base64;

                        AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(emailReadyHtml, null, MediaTypeNames.Text.Html);
                        alternativeView.ContentId = "htmlView";
                        alternativeView.TransferEncoding = TransferEncoding.SevenBit;
                        alternativeView.LinkedResources.Add(linkedResource1);
                        message.AlternateViews.Add(alternativeView);

                        //message.AlternateViews.Add(altviewItem);
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential("ankama.dev.test@gmail.com", "@nkama@123");
                        client.Send(message);
                        Console.WriteLine("mail sent");
                        // Check if file exists with its full path    
                        if (File.Exists(path))
                        {
                            // If file found, delete it    
                            File.Delete(path);
                            //File.Delete(subscription.ReportId + ".jpeg");

                            Console.WriteLine("File deleted : " + path);
                        }
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", string.Empty); sbText.Replace(" ", string.Empty);
            return sbText.ToString();
        }

        public async Task<string> GetFilePath(string reportId, string accessToken, string embedUrl, string title)
        {

            // await page.EmulateMediaTypeAsync(PuppeteerSharp.Media.MediaType.Screen);
            string html;
            using (var reader = new StreamReader("./index.html"))
            {
                html = reader.ReadToEnd();
            }
            // await page.SetContentAsync(_html);
            //Path.DirectorySeparatorChar = '/';
            // Path.AltDirectorySeparatorChar = '/';
            html = html.Replace(":accessToken", accessToken);
            html = html.Replace(":embedUrl", embedUrl);
            html = html.Replace(":reportId", reportId);
            html = html.Replace(":title", title);
            var guid = Guid.NewGuid();
            await File.WriteAllTextAsync(guid + ".html", html);
            return Path.GetFullPath("./" + guid + ".html");
        }
    }
}
