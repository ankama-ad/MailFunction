using System;

namespace MailFunction
{
    class Program
    {
       static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");           
            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
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
                var navOptions = new NavigationOptions() {  Timeout =  60000 };
                ////await page.WaitForNavigationAsync(navOptions);
                await page.GoToAsync("http://localhost:4200/#/dashboard");
                await page.ScreenshotAsync("../../../pupeteer-shot.jpeg");
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

                    

                    MailMessage message = new MailMessage("anks501@gmail.com", "ankama.bollimuntha@amnetdigital.com", "test mail", html);
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                    Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(base64Stream));
                    System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

                    var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
                    imageToInline.ContentId = "MyImage";
                    var altviewItem = new AlternateView(streamBitmap);
                    // alternateView.LinkedResources.Add(imageToInline);
                   
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(altviewItem);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("anks501@gmail.com", "@^k$-so1_G");
                    client.Send(message);
                    Console.WriteLine("mail sent");
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
            catch(Exception e){
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
