using System;
using System.Threading.Tasks;
using IronPdf;
using PuppeteerSharp;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;

namespace MailFunction
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            try
            {
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
                var navOptions = new NavigationOptions() { Timeout= 30000, WaitUntil = new WaitUntilNavigation[] { WaitUntilNavigation.Networkidle2 }};
                ////await page.WaitForNavigationAsync(navOptions);
                await page.GoToAsync("http://localhost:4200/#/dashboard",navOptions);
                await Task.Delay(20000);
                await page.ScreenshotAsync("pupeteer-shot.jpeg");
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


                    MailMessage message = new MailMessage("anks501@gmail.com", "ankama.bollimuntha@amnetdigital.com", "Test mail", emailReadyHtml);
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                    // Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(base64Stream));
                    // System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

                    // var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
                    // imageToInline.ContentId = "MyImage";
                    // var altviewItem = new AlternateView(streamBitmap);
                    // alternateView.LinkedResources.Add(imageToInline);

                    message.IsBodyHtml = true;                   
                    //message.To.Add("saikrishna.kusuma@amnetdigital.com");
                    //message.To.Add("anudeep.kappakanti@amnetdigital.com");
                    ContentType c = new ContentType("image/jpeg");
                    Console.WriteLine("stream");
                    Console.WriteLine(Convert.ToBase64String(memStream.ToArray()));
                    LinkedResource linkedResource2 = new LinkedResource(memStream);
                    linkedResource2.ContentType = c;
                    linkedResource2.ContentId = "smile";
                    linkedResource2.TransferEncoding = TransferEncoding.Base64;

                    // create image resource from image path using LinkedResource class.
                    LinkedResource linkedResource1 = new LinkedResource("pupeteer-shot.jpeg");
                    linkedResource1.ContentType = c;
                    linkedResource1.ContentId = "yasser";
                    linkedResource1.TransferEncoding = TransferEncoding.Base64;

                    AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(emailReadyHtml, null, MediaTypeNames.Text.Html);

                    alternativeView.ContentId = "htmlView";
                    alternativeView.TransferEncoding = TransferEncoding.SevenBit;

                    alternativeView.LinkedResources.Add(linkedResource1);
                    alternativeView.LinkedResources.Add(linkedResource2);

                    message.AlternateViews.Add(alternativeView);
                    //message.AlternateViews.Add(altviewItem);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("ankama.dev.test@gmail.com", "@nkama@123");
                    client.Send(message);
                    Console.WriteLine("mail sent");

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
                    Console.ReadKey();
                }


                //if (upload.HasFile)
                //{



                //HttpFileCollection fc = Request.Files;
                //    for (int i = 0; i <= fc.Count - 1; i++)
                //    {
                //        HttpPostedFile pf = fc[i];
                //        Attachment attach = new Attachment(pf.InputStream, pf.FileName);
                //        message.Attachments.Add(attach);
                //    }
                // }

                // status.Text = "message was sent successfully";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        public static string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", string.Empty); sbText.Replace(" ", string.Empty);
            return sbText.ToString();
        }
    }
}
