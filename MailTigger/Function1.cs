using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;

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

    public static class Function1
    {
        [Function("Function1")]
        public static async Task<IActionResult> Run(
            [Microsoft.Azure.Functions.Worker.HttpTrigger(Microsoft.Azure.Functions.Worker.AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            // return new OkObjectResult(responseMessage);
            try
            {
                //// var subscriptionsByuser = new List<IGrouping<int?, SubscriptionDataModel>>(); 

                var listsring = "[{\"ReportSubscriptionId\":0,\"ReportId\":\"7779d348-1f55-4527-8594-4b1dcb9e7364\",\"WorkspaceId\":\"a5ebd5be-6706-4bcc-b342-1d0771af780c\",\"Email\":\"ajay@powerbiaxes.onmicrosoft.com\",\"UseridEmail\":7,\"Frequency\":null,\"Weekday\":null,\"DateOfMonth\":null,\"SheduledTime\":null,\"StartDate\":null,\"EndDate\":null},{\"ReportSubscriptionId\":0,\"ReportId\":\"f75d4ca3-9020-4c7a-90e0-3946ae90d564\",\"WorkspaceId\":\"4c8870bb-dd4d-4055-8be6-e09d11802a46\",\"Email\":\"ajay@powerbiaxes.onmicrosoft.com\",\"UseridEmail\":7,\"Frequency\":null,\"Weekday\":null,\"DateOfMonth\":null,\"SheduledTime\":null,\"StartDate\":null,\"EndDate\":null},{\"ReportSubscriptionId\":0,\"ReportId\":\"a2e10dc8-4302-4ec2-9471-33f5470dda7a\",\"WorkspaceId\":\"0a4344d7-c25c-40fa-8bdd-4359a7d30216\",\"Email\":\"ajay@powerbiaxes.onmicrosoft.com\",\"UseridEmail\":7,\"Frequency\":null,\"Weekday\":null,\"DateOfMonth\":null,\"SheduledTime\":null,\"StartDate\":null,\"EndDate\":null},{\"ReportSubscriptionId\":0,\"ReportId\":\"7248a900-c98f-4d8e-956f-ad1177432804\",\"WorkspaceId\":\"27d60dc0-5c5e-4559-ba25-25b47ab85633\",\"Email\":\"ajay@powerbiaxes.onmicrosoft.com\",\"UseridEmail\":7,\"Frequency\":null,\"Weekday\":null,\"DateOfMonth\":null,\"SheduledTime\":null,\"StartDate\":null,\"EndDate\":null}]";
                 var list = System.Text.Json.JsonSerializer.Deserialize<List<SubscriptionDataModel>>(listsring);
                var subscriptionsByuser = list.GroupBy(c => c.UseridEmail).ToList();


                foreach (var subs in subscriptionsByuser)
                {
                    //int propertyIntOfClassA = userid.;

                    //iterating through values
                    foreach (var sub in subs)
                    {

                        // int key = classA.PropertyIntOfClassA;
                        await SendMailForUser(sub);
                    }
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);
                return new OkObjectResult(e.Message);
            }
            return new OkObjectResult(responseMessage);
            // Console.WriteLine("End");
        }

        private static async Task SendMailForUser(SubscriptionDataModel subscription)
        {

            var embedResult = await EmbedService.GetEmbedParams(Guid.Parse(subscription.WorkspaceId), Guid.Parse(subscription.ReportId));


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

            // await page.EmulateMediaTypeAsync(PuppeteerSharp.Media.MediaType.Screen);
            // string _html;
            // using (var reader = new StreamReader("./index.html")){
            // _html = reader.ReadToEnd();
            // }
            //     // await page.SetContentAsync(_html);
            //     //Path.DirectorySeparatorChar = '/';
            //     // Path.AltDirectorySeparatorChar = '/';
            //     var path = new Uri(Path.GetFullPath("./index.html"));
            var path = await GetFilePath(reportId, accessToken, embedUrl, title);
            await page.GoToAsync(new Uri(path).AbsoluteUri);
            //var watchDog = page.WaitForFunctionAsync(" () => window.reportRendered");

            // var pdfContent = await page.PdfStreamAsync(new PdfOptions
            // {
            //     Format = PaperFormat.A4,
            //     PrintBackground = true
            // });

            ////await page.WaitForNavigationAsync(navOptions);
            // await page.GoToAsync("http://localhost:4200/#/dashboard", navOptions);
            await page.WaitForSelectorAsync("#rendered");
            await Task.Delay(2000);
            //await watchDog;
            await page.ScreenshotAsync(subscription.ReportId + ".jpeg");
            Console.WriteLine("screenshot saved");

            using (var memStream = new MemoryStream())
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

                // Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(base64Stream));
                // System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

                // var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
                // imageToInline.ContentId = "MyImage";
                // var altviewItem = new AlternateView(streamBitmap);
                // alternateView.LinkedResources.Add(imageToInline);

                message.IsBodyHtml = true;
                // message.To.Add("kalidasu.surada@amnetdigital.com");
                //message.To.Add("saikrishna.kusuma@amnetdigital.com");
                message.To.Add("anudeep.kappakanti@amnetdigital.com");
                ContentType c = new ContentType("image/jpeg");
                //Console.WriteLine("stream");
                //Console.WriteLine(Convert.ToBase64String(memStream.ToArray()));
                //LinkedResource linkedResource2 = new LinkedResource(memStream);
                //linkedResource2.ContentType = c;
                //linkedResource2.ContentId = "smile";
                //linkedResource2.TransferEncoding = TransferEncoding.Base64;

                // create image resource from image path using LinkedResource class.
                LinkedResource linkedResource1 = new LinkedResource(subscription.ReportId + ".jpeg");
                linkedResource1.ContentType = c;
                linkedResource1.ContentId = "yasser";
                linkedResource1.TransferEncoding = TransferEncoding.Base64;

                AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(emailReadyHtml, null, MediaTypeNames.Text.Html);

                alternativeView.ContentId = "htmlView";
                alternativeView.TransferEncoding = TransferEncoding.SevenBit;

                alternativeView.LinkedResources.Add(linkedResource1);
                // alternativeView.LinkedResources.Add(linkedResource2);

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


                // we need to use the prefix 'cid' in the img src value
                // string emailReadyHtml = string.Empty;
                // emailReadyHtml += "<p>Hello World, below are two embedded images : </p>";
                // // emailReadyHtml += "<img src=\"cid:yasser\" >";
                // emailReadyHtml += "<img src=\"cid:smile\" >";

                // MailMessage mailMessage = new MailMessage();

                // mailMessage.To.Add("yasser@mail.yy");
                // mailMessage.From = new MailAddress("info@mail.yy", "Info");

                // mailMessage.Subject = "Test Mail";
                // mailMessage.IsBodyHtml = true;

                //string image1Path = HttpContext.Current.Server.MapPath("../../../pupeteer-shot.jpeg");
                //byte[] image2Bytes = someArrayOfByte;

                // ContentType c = new ContentType("image/jpeg");

                // create image resource from image path using LinkedResource class.
                // LinkedResource linkedResource1 = new LinkedResource("../../../pupeteer-shot.jpeg");
                // linkedResource1.ContentType = c;
                // linkedResource1.ContentId = "yasser";
                // linkedResource1.TransferEncoding = TransferEncoding.Base64;

                // the linked resource can be created from bytes also, which may be stored in database (which was my case)
                // LinkedResource linkedResource2 = new LinkedResource(memStream);
                // linkedResource2.ContentType = c;
                // linkedResource2.ContentId = "smile";
                // linkedResource2.TransferEncoding = TransferEncoding.Base64;

                // AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(emailReadyHtml, null, MediaTypeNames.Text.Html);

                // alternativeView.ContentId = "htmlView";
                // alternativeView.TransferEncoding = TransferEncoding.SevenBit;

                // //alternativeView.LinkedResources.Add(linkedResource1);
                // alternativeView.LinkedResources.Add(linkedResource2);

                // mailMessage.AlternateViews.Add(alternativeView);

                // SmtpClient smtpClient = new SmtpClient();
                // smtpClient.Send(mailMessage);


            }



        }

        public static string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", string.Empty); sbText.Replace(" ", string.Empty);
            return sbText.ToString();
        }

        public static async Task<string> GetFilePath(string reportId, string accessToken, string embedUrl, string title)
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
