using System;
using System.Threading.Tasks;
using IronPdf;
using PuppeteerSharp;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;
using AppOwnsData.Services;
using ERP.Data.Services;
using ERP.Data.Subscriptions;
using MailFunction.Services;

namespace Main
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            try
            {
                var config = AppConfiguration.Configuration;
                var tenant = config["tenat"];

                var subscriptionsByuser = new SusbscriptionService().GetReportSubscriptions();


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


                //var embedResult = await EmbedService.GetEmbedParams(ConfigValidatorService.WorkspaceId, ConfigValidatorService.ReportId);                   
               

                //var accessToken = "H4sIAAAAAAAEAB2Wxc7GCm-E7-VsUylMlf5FmJM3DLswM6fqvfc73Vuy_Yw84__555e-w5wW__z3PxA2zrbODrCkbxGkyxbMnTIalC92WRhFqZA694Yno1SZ2I6PxGbzbWcxold_l4eWJCNUNfJza9BpwHPuvo29q3EyPKwQtRABt_OCCpOxsdPDjR67yvxsCtwAy6GEjgkvvOgHSPSvNwF3ctpZsXgDY5JG4jdC4blgr1382t8iUhqdWMvdSfxvGkRRO88ra5SRfHoSEDwkJYRVnmRAvpgDTo6MtAhrV8ufhmzlQJv2FHq7TF1auKfn66dLaV3vddgcTGbRaVN8p7-ExWg3nUGzOFMbOmbaKxG9O55BjpecA24YLvG19oav2HfdyldE_DaRBCAzIkHHY2Neu3ScKbygRxz1R7xQkqFDdO20JgVSpQW0JQizoiZ6WXd0uhHdj4UZ3cWg1dTqffUNMFoyzB-RM39Y1DB5U-lHC50b9KpJXgqoPnsKFrqgZESKOBPA4gKhunVM0tHHCP4B98EgmkhoZeSwSHFK34jo_RGe_gSg52MYHZZLCxJp-lCE7blnPH1hYDJoQZVlj6HP6mI-KiRS3yA6Q0fI3hKqDDpy9VJEzgqlkBNG-nR3RbuoAVLKfdVl0bfprIQR2gyAWkzzF-pzPPxpKvoTsc1yIfDrke3VaAwtQZ2zZrMCbtWMDJWX0RP_tWa3oSYL7s2PH_K-RZ6Q_-QaHnXBMPXdgsrgtlfXvs93CB6EbeMrJMYem4ty9ZiYeMXdTMSTUyQfwKdhloyyQtNfqeVH09r8Ezw-_Xt-qy-g8S9-ut26XMHsCKpdssVxpoBcwybvBP-zI0AFqCohP5gN8XO4B4iCxgUbTVgnYhmWqDeUx4-ILq-UOdpy8gA0P4-Mzsojtn3XoLGn2DtWicFS3HfNNuBP_Ifs9jPVkhai9SNqXw2R4dv_hDclK_buJTMU2Ll4LUZVu3AhccfSVtEsz3MZnAf_ytkDSPRHS1wADnp8PE-PQTHRcA5Uc-xQ59Q8KPuAeeP6exheF2l-h8d65_qheNifRYJA2hpP1Doh-_7Oxpp4FiuN6B0ZpQES8GNRRgKcuLlZO95fk68UXIlyqWw_6I9D_CZ25jayeL7nh4_dWB-SBa1jDkCuu4d3TkC-KLy-CGi_VIq1N5JMy4CU3FeZZKAPGt9fLFaby_1xzdmDfWUHd-evUTp-mTNwVnEJIRgBX64faknN5C4jOj9P2pUUzW9Y10wLN4UQMiVT7nf4KZBhOQvuujiPIOk42BhhRdZDW9n8HdTUAwerue5cwCnnX5qKkFix6E1iX53rl7x2TfLtcieKBd0AvohEWzMFoQ_G0AhMW2VYCts5t0X9LTNZXM72og3TR3tgbw_YoB1RLmOPm2ET7buo9XxRKwvKolaOz1Lu2Cpb303QAPAgWu-bUoRJIroMdTAa-JT2uSP6pgE3a-XbkVltjht_1jF7zSofgHutOrxdXuczQQvif0Eilnx1JBW0zkc4R_qWLmiY_czc__21-Dh7g387R6mqiEIhK_cvTLZEKvxwCpWfKHAjyMoCgwLqvN-WyKTWWdkdxezV8fV7ZhYDPp1lMdkAi-csFG6Se3mN04bjXy155fBgZFC56jhbjQGU6yIM0qZzUzepXWLLHZUnflEZ41BUelxZGwN-EH8LiB2wZWQjcCsbv0vY2vSQNFu0kVaZ0TIFakMErT_YKG6HNv-d4p2GuWHctCfJRKbYlcI5TL-vzYbxqS436WRvOgM_ntLnEHD_OeOP8Eis7IkRGVhnDq90z-5MZ_2TLeGOYlggNYFEjWqaWjV1Dmq0b-kTeqh0Clsh8rXaFkpSy4OzSlmX0qUW-jvW1rZwLskJmFXxzbKPSIhW1Qq29M84wGIu1NW_WouaF-oWQq0TiNL87QDJwRTy9jFO6XffPyq8SCebL08C4oqA2XLIipOKJRfAcLA9oLvv2JHcGSyUd5vscS_p_FlYgZQPi4y-mZa5MF8JvdP4RH_LtY04GmItt9QV5_jb1TTxnXIRALGIbPBz-zfIxlRRS8ArL271qHou_X49bUO_pr7cohNfQ0OmZmC5V6DHeJ5JvrRXxqkppiTxAnrG3mcHzy_FTV3N4RgDqru7TY0QqGwYQkafhyY1lHmg2s2UPC7cEKglMHfNP2FPEhSsyz4W5BlGUPv2XZAAMlz3tli_efWUT8bJhCTkbzZHiKOnE9zTeckFD7ZN5HoaoJOoMj60J0xbMnd9hv_MWHGGTX_LCTJmHlHEve1l2Tm5wqg6jidL-eHNIeWLb6Sv2MAtAG7EXEGlOnSskRMBPV7ShS4btWig3U4PsLnUN3zQ2niz5oOfmPgWHBcilm1Xs3DYmtZo9iDBtDADz6T8t-XAHJlg2T1T0kr5mSHd_JJD8-mNUjNfIaatQ3NXUUaJW0xUxpa2TOj5YCIfGaqS0iozicyJPnNEcBS7B_64HrayUkU6vJhJi_QYzyU2R5v8ZuWO0nFTT1H_-a9_uO1djn-N4e8dS3BDqhLjuDowymJADLCRQ_qN2b2nf-PqCkVF-NCsy48E0PMGuZA-GGSSgYQp_-ELKUfUEgv9lBDUZDJXwTtPrFP9dOKpBKxjtw4xQZ_IZmbWRY1Wl7FY74vzGhwvZAMRwccS0FPxLNrOMhP1Hjxa6y7IFWnt-wujF_QdXG5BwOvuGYl4eBe5iDmFZi_FFInjvvHpjEY_VTEGB0X7CmAUvkQBCLQx_Q4_T19mpT_FR9tS1XTRzb_UDzB5urD4z87pFIUTSyyYumwEmuZanU4hSaxlbFO9v4XIsNNvyJYZmHplJp05eUEQKetr7C8kX3UsKx1zaml9lhjlLdirK714Ppb5z3_-xfwuTbkpwR_lDZIw8Bdum3Vr7Hbazdh5aP3_VW5bT-lxbuW_ZQPZo7sbWpekKFK_Chl0uMdTsgOAfsG3WMjd3gXSYgPWxgLbTLjwTDgKrTfkWA_8ylrmfsLZ-KJ3WL0nbfyKuYhKgxQgNuAakEC4-GrWnRw3IS_K8mvY-XP54HddxATz1d_zgdm01zWLYEONdlulLjvCC7xpB-Lm57ox6M5kDphxpGzq6979oeisEm9f3ZkUR03nPEFYOmc21cuZSprD-WGJVx2p5EXrIc_L_4VaCGF1TBUwSczoof7UCuxYfAP1WXkWW3qbRjamGetanAzKKac87wMqkg35lJ5yuUuVxYH8Zr8D8hwNeMqVzOc5U7PtxQ9qSdirzkTnHn1ugcqwm7P_MP_v_wGljVsMggwAAA==.eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLVVTLU5PUlRILUNFTlRSQUwtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjpmYWxzZX19";
                //var embedUrl = "https://app.powerbi.com/reportEmbed?reportId=f6bfd646-b718-44dc-a378-b73e6b528204&groupId=be8908da-da25-452e-b220-163f52476cdd&config=eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLVVTLU5PUlRILUNFTlRSQUwtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjp0cnVlLCJjZXJ0aWZpZWRUZWxlbWV0cnlFbWJlZCI6dHJ1ZX19";
                //var reportId = "f6bfd646-b718-44dc-a378-b73e6b528204";
                ////Renderer.PrintOptions.RenderDelay = 5000;
                ////Renderer.PrintOptions.EnableJavaScript = true;
                ////Renderer.RenderUrlAsPdf("http://localhost:4200/#/login").SaveAs("../../../url.pdf");
                ////var uri = new Uri("http://localhost:4200/#/login");

                ////var state  = await Renderer.RenderUrlAsPdfAsync(uri);
                ////state.SaveAs("../../../report.pdf");
                ////Console.WriteLine("file saved");


                //// *****************************puppeteer sharp ***************************//


                //var browserFetcher = new BrowserFetcher();
                //await browserFetcher.DownloadAsync();
                //Browser browser = await Puppeteer.LaunchAsync(
                //    new LaunchOptions { Headless = true });
                //var page = await browser.NewPageAsync();
                //await page.SetViewportAsync(new ViewPortOptions
                //{
                //    Width = 1900,
                //    Height = 900
                //});
                //var navOptions = new NavigationOptions() { Timeout = 30000, WaitUntil = new WaitUntilNavigation[] { WaitUntilNavigation.Networkidle2 } };

                //// await page.EmulateMediaTypeAsync(PuppeteerSharp.Media.MediaType.Screen);
                //// string _html;
                //// using (var reader = new StreamReader("./index.html")){
                //// _html = reader.ReadToEnd();
                //// }
                ////     // await page.SetContentAsync(_html);
                ////     //Path.DirectorySeparatorChar = '/';
                ////     // Path.AltDirectorySeparatorChar = '/';
                ////     var path = new Uri(Path.GetFullPath("./index.html"));
                //var path = await GetFilePath(reportId, accessToken, embedUrl);
                //await page.GoToAsync(new Uri(path).AbsoluteUri);
                ////var watchDog = page.WaitForFunctionAsync(" () => window.reportRendered");

                //// var pdfContent = await page.PdfStreamAsync(new PdfOptions
                //// {
                ////     Format = PaperFormat.A4,
                ////     PrintBackground = true
                //// });

                //////await page.WaitForNavigationAsync(navOptions);
                //// await page.GoToAsync("http://localhost:4200/#/dashboard", navOptions);
                //await page.WaitForSelectorAsync("#rendered");
                //await Task.Delay(2000);
                ////await watchDog;
                //await page.ScreenshotAsync("pupeteer-shot.jpeg");
                //Console.WriteLine("screenshot saved");

                //using (var memStream = new MemoryStream())
                //{
                //    page.ScreenshotStreamAsync().Result.CopyTo(memStream);
                //    var base64Stream = Convert.ToBase64String(memStream.ToArray());
                //    // Attachment attach = new Attachment(pf.InputStream, pf.FileName);
                //    // message.Attachments.Add(attach);
                //    // Console.WriteLine(mything);
                //    //var html = "<body>< img src = 'data:image/jpeg;base64," + base64Stream + "\'/></body>";
                //    var html = "<body><img alt =\"\" src =\"cid: MyImage\"/></body>";
                //    string emailReadyHtml = string.Empty;
                //    emailReadyHtml += "<p>Hello World, below are two embedded images : </p>";
                //    emailReadyHtml += "<img src=\"cid:yasser\" >";
                //    emailReadyHtml += "<img src=\"cid:smile\" >";


                //    MailMessage message = new MailMessage("anks501@gmail.com", "ankama.bollimuntha@amnetdigital.com", "not done yet working on value bind with template", emailReadyHtml);
                //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                //    // Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(base64Stream));
                //    // System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

                //    // var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
                //    // imageToInline.ContentId = "MyImage";
                //    // var altviewItem = new AlternateView(streamBitmap);
                //    // alternateView.LinkedResources.Add(imageToInline);

                //    message.IsBodyHtml = true;
                //    //message.To.Add("kalidasu.surada@amnetdigital.com");
                //    //message.To.Add("saikrishna.kusuma@amnetdigital.com");
                //    //message.To.Add("anudeep.kappakanti@amnetdigital.com");
                //    ContentType c = new ContentType("image/jpeg");
                //    Console.WriteLine("stream");
                //    Console.WriteLine(Convert.ToBase64String(memStream.ToArray()));
                //    LinkedResource linkedResource2 = new LinkedResource(memStream);
                //    linkedResource2.ContentType = c;
                //    linkedResource2.ContentId = "smile";
                //    linkedResource2.TransferEncoding = TransferEncoding.Base64;

                //    // create image resource from image path using LinkedResource class.
                //    LinkedResource linkedResource1 = new LinkedResource("pupeteer-shot.jpeg");
                //    linkedResource1.ContentType = c;
                //    linkedResource1.ContentId = "yasser";
                //    linkedResource1.TransferEncoding = TransferEncoding.Base64;

                //    AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(emailReadyHtml, null, MediaTypeNames.Text.Html);

                //    alternativeView.ContentId = "htmlView";
                //    alternativeView.TransferEncoding = TransferEncoding.SevenBit;

                //    alternativeView.LinkedResources.Add(linkedResource1);
                //    alternativeView.LinkedResources.Add(linkedResource2);

                //    message.AlternateViews.Add(alternativeView);
                //    //message.AlternateViews.Add(altviewItem);
                //    client.EnableSsl = true;
                //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //    client.UseDefaultCredentials = false;
                //    client.Credentials = new System.Net.NetworkCredential("ankama.dev.test@gmail.com", "@nkama@123");
                //    //client.Send(message);
                //    Console.WriteLine("mail sent");
                //    // Check if file exists with its full path    
                //    if (File.Exists(path))    
                //    {
                //        // If file found, delete it    
                //        File.Delete(path);
                //        Console.WriteLine("File deleted : " + path);
                //    }


                //    // we need to use the prefix 'cid' in the img src value
                //    // string emailReadyHtml = string.Empty;
                //    // emailReadyHtml += "<p>Hello World, below are two embedded images : </p>";
                //    // // emailReadyHtml += "<img src=\"cid:yasser\" >";
                //    // emailReadyHtml += "<img src=\"cid:smile\" >";

                //    // MailMessage mailMessage = new MailMessage();

                //    // mailMessage.To.Add("yasser@mail.yy");
                //    // mailMessage.From = new MailAddress("info@mail.yy", "Info");

                //    // mailMessage.Subject = "Test Mail";
                //    // mailMessage.IsBodyHtml = true;

                //    //string image1Path = HttpContext.Current.Server.MapPath("../../../pupeteer-shot.jpeg");
                //    //byte[] image2Bytes = someArrayOfByte;

                //    // ContentType c = new ContentType("image/jpeg");

                //    // create image resource from image path using LinkedResource class.
                //    // LinkedResource linkedResource1 = new LinkedResource("../../../pupeteer-shot.jpeg");
                //    // linkedResource1.ContentType = c;
                //    // linkedResource1.ContentId = "yasser";
                //    // linkedResource1.TransferEncoding = TransferEncoding.Base64;

                //    // the linked resource can be created from bytes also, which may be stored in database (which was my case)
                //    // LinkedResource linkedResource2 = new LinkedResource(memStream);
                //    // linkedResource2.ContentType = c;
                //    // linkedResource2.ContentId = "smile";
                //    // linkedResource2.TransferEncoding = TransferEncoding.Base64;

                //    // AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(emailReadyHtml, null, MediaTypeNames.Text.Html);

                //    // alternativeView.ContentId = "htmlView";
                //    // alternativeView.TransferEncoding = TransferEncoding.SevenBit;

                //    // //alternativeView.LinkedResources.Add(linkedResource1);
                //    // alternativeView.LinkedResources.Add(linkedResource2);

                //    // mailMessage.AlternateViews.Add(alternativeView);

                //    // SmtpClient smtpClient = new SmtpClient();
                //    // smtpClient.Send(mailMessage);
                //    Console.ReadKey();

                //}


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

            Console.Read();
        }

        private static async Task SendMailForUser(SubscriptionDataModel subscription)
        {

            var embedResult = await EmbedService.GetEmbedParams( Guid.Parse(subscription.WorkspaceId), Guid.Parse(subscription.ReportId));


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


                MailMessage message = new MailMessage("anks501@gmail.com", "ankama.bollimuntha@amnetdigital.com", "not done yet working on value bind with template", emailReadyHtml);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                // Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(base64Stream));
                // System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

                // var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
                // imageToInline.ContentId = "MyImage";
                // var altviewItem = new AlternateView(streamBitmap);
                // alternateView.LinkedResources.Add(imageToInline);

                message.IsBodyHtml = true;
                //message.To.Add("kalidasu.surada@amnetdigital.com");
                //message.To.Add("saikrishna.kusuma@amnetdigital.com");
                //message.To.Add("anudeep.kappakanti@amnetdigital.com");
                ContentType c = new ContentType("image/jpeg");
                Console.WriteLine("stream");
                Console.WriteLine(Convert.ToBase64String(memStream.ToArray()));
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
                //client.Send(message);
                Console.WriteLine("mail sent");
                // Check if file exists with its full path    
                if (File.Exists(path))
                {
                    // If file found, delete it    
                    File.Delete(path);
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
                Console.ReadKey();

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
