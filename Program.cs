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

                // var accessToken = 'H4sIAAAAAAAEACWWxQ7tyBVF_-VNHclMkXpgZl8zzcxsXzO08u-5nYzrqKSzamvt-vuPlT7DnBZ__v1H3cpVS7ZA2Vf-esxpZJgUOsUbeLTVvXQA6GU4Y47aL3ug8BnBgD0N8SwBCS0XAHyHgweXTIUtaaOmO4vVt5wqf8sL_OagowuKjiPnt6wGeDmJIZpiX4wA-cN2WHuWltJPTodDUHB5j2G42zwZUEj7-RhyjYmSfd7SJYL1dkPxEY37iDO2X-QUYX9JgBTfJIGgp5xJZdNeSSEEeL-LJDAfAajzvwtBTOiw3hdXvuZeFMVJ9KJ5Fbg_SsExcg2V8JcQeaNKAcr-_QgjK543gJ7CwHZrSB4MMEPrEfW8qOZA1baslvrtvmCsjyvXJBFTVdkMor7N_dFIJBBDALUkGUAYpPugu6oGd0NTEpsvvUT695jajwJF-DLOn48VwxQ0D1lAQ3gBj3oribN56BEVgEE3KFf0RGz_FHaeQWYsZ2qrbi5DD5-pRwUMixXBo0ceGUfM4PPpfMvx01k7HUME6ToExmwj3KlwX-oYkd8lkwb6ApWITDjTttmiGIQCIH5wTGK2hwOvQMYK8qvwpsatlfw5R6DstljCVySX9Y1d2evYTp5wnXUBTecLhr_kAErIUTIVClnMUZ8n32aK56unL6DOmxYjXK8brDv-nfEkHLrlOx42vWDQytD9AQ7ZV-d0jjSazS8Cxq8mO-RX8jHeuNSIRGr4EO60lKGuCzEuG62z7QCYzMiBLGYMqJ7BN36a-UpnQTtcJsXMbaU7qIEzNARo5wHyN1RPzRJiPjoLFxD0PSwvaVZBulJA3GRRRACrxplyY-smWwFmH4awQVqmpEg3mTJ8ulZ3zlKffZdE0bdsSTry7AgXD6E6ck4-qy2Z-3dq7VWrNeVUQaaeR7Mb-vW4399zL_mguo--8ujkR6orJRUyqTjFopTIdRz8th3yjpYQEZFi2hcB1op12qldm_PdUJaOejD5sUcba0qMWrSbJpswPR-UDXga_fjCHOUX6lhkZAwe5LdXhFiuRg-Zqk5Cf2sI28y-YX-vmM1SiS93HifHpH5SN0LJ1VQ82Xu-W4ROgizRpCp8-CsyDMDibhrsnO-Yih2tpvK17gtOqYOcnzHWIpAq1i8jX8gyHQ1xQ7tJhEDrKSXW5zfIYtrctaoE4Le4Ot8YWHe5wI75Oi9ageVv5206Uy6Dd-3W4-WqFhnFdG64FBeZOl1dE3ZLo4fzJSA73NagrhkztHkUfpJ9rIHg0J6juco4mt6KtwMfkRAlYhxvA6SwAk6D2sYIOJNMxwFsdgg1ldf6FTfgEItYTiaszVU7VYY-jaSLlu4xRjjNxw0vWtLgCP012RH4YqaVk-tNDOYZBqw7QB1Aj8cQBsyGWSCj6sTDDZg-DacevUagwfEq35l-qANU7w1kPOiM30JiXsl1X713mZCFfvgXfp73pFeqeiEZVamTbYsmRLYQZ-vWiayiAVEAYlb3SR9hCvb8dxnTLNOpoGPtZ3ZauigwpXJS697CZ6tTPdfBasFBPcgCm1YgFvEh3NXbc7cvbHBZs72lcybKYg9cxpgpnJePKEmNcpeVO0486AFNXaAx82a-WLvUaqChR_uxwRgK825Z7ohVThmO7GCpMeanL6zXIs-CYBjRjYC5JKoh-y3--o7DE5Z1b9mIC-lkv34somjswDOdlXJa8manDgMYxiNf2fcTwOU1QMRSfb4bjcacYBw8hZ0leHkYatWut7_r1DCjO7IQjYR8qebSgsudQmz2-UOuzZachfJvyyB23tCb0KMo9eSlXerTkTBu12-qUKROJUicm3mjzQ0SAwwBq8-Lt93NWaiU9gkZhnpj9XWW-d2RcBng0JN0Mgm9_CrM09QvsWd7yIPgRJLf2c_d98INVoLhSoUP9AzErOtb379knK8wWXRUXQqnpnByoDuQfl5i3RaA1SoRANAPycI1ZkywSyj4BZPOGLg6qPBIbAvVV6iJRNMxjSA-1Aptfqu8H2nBqO0aEDqX96jPamDfXG3QjiOP93TBwa8z5sv9bYS9DILV3dlLYagYKlRplH4CX5bMmVhvGGBZEXKbzZ-WKfrZ_CiNZOQ_XUNS3ZEEHAuPw1vcsNkehfC2xdFc34Myv7fuil9FPFxXGyBzBZGLAYN32kXOGOAN4e_l6SiUzwZpY4W2fErrQKGDmuVKbBBg5afAzxFP5z0Cctz-6bLlMzuLtjaA7Ej94BQ8HJzyViG0SuCNoLM4XL_-wjcuZIgxKZ3UpV1AXPj4kN1VT4Do1MzT0dblSozN1lLTuYDfeD2urSq7pJZewwflz6qM7frw5Bqb2atRjiGPaC3C66nBtoiueFENU34tY_tLQXkxWt9NxqDCymcr3iEgsDmXh0yAUE8RP5skv8JbWKc6AAlv50AOgDvemcq1WlpM5Hj1U68Jz2dfe68iiYclGT5TfMwajEINoYjltv_668-__nDr891nrXx-36yYIgKbqIgeDC8PUp0wKEYzdiqYAlVEl6edhOPgZdyDjCtUWRdo1jUBVoBgrGuXt49TD4kkwsmSAeXkn05CPZ6mnKRRbIEzdUDu07VEi-zEN0HZyK1jd4ATO7Vzpl17w0_lNrolmLUmT53HKwXiC4v8s2PwQwdKqroORxi8qh4w0-Nsw4O3PGdi52bQHi4LUpLjksT3zcKkyYhH1tl5Z1QB0QNRTpUoPnPZSeaF4pZpIXDzwlce06oD83aaF5ec3fbX5E0E3TtbpVhVMzz8xHrdX1t-4R9D5hfeEsNPoy4uyyFRMFjSzNfRQnQ1cKs9GLfYCAZ10LoP8Hl-JVEWW71l1_8xP9-mXJXgRxkdcAzRtQ_JPp4Zu8qFQo3C_G_Kbesp3Y-1_I1dgnDxts-yG0ggPMVeJuB0vb1xUgRx7WrEYl9uDS7cRvoKxMITW60n0TSJmbnnUvJLSJcMFXQhzWWYVd2xX4si27VLxGlfOe5IKvY7T7kreEZuHkRR1yo2DbmXhdjoRBj13rKIIQtfVW8uXArgV_jE7n12vMoAECaWmyeq5rziNjFQ6wgSp_n-6ux13fpEPuIJBJfIKJViQlT9GjfLTMFwEMhtpemqRCezzS7rk5FrPmuveEAsg48gYvsEFF_wtoFvyiepNVO6pQlCWyxbW7gfJK10f4qDBH_wCy5_5y5WnEnpwR51kw9y7iL6oqQt1SpJO9y2dxovIE2BpLh7fI8P9A_m__wX48Rb4VoMAAA=.eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLVVTLU5PUlRILUNFTlRSQUwtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjpmYWxzZX19';
                // var embedUrl = 'https://app.powerbi.com/reportEmbed?reportId=f6bfd646-b718-44dc-a378-b73e6b528204&groupId=be8908da-da25-452e-b220-163f52476cdd&config=eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLVVTLU5PUlRILUNFTlRSQUwtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjp0cnVlLCJjZXJ0aWZpZWRUZWxlbWV0cnlFbWJlZCI6dHJ1ZX19';
                // var reportId = 'f6bfd646-b718-44dc-a378-b73e6b528204';
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
            string _html;
            using (var reader = new StreamReader("./index.html")){
            _html = reader.ReadToEnd();
            }
                // await page.SetContentAsync(_html);
                //Path.DirectorySeparatorChar = '/';
                // Path.AltDirectorySeparatorChar = '/';
                var path = new Uri(Path.GetFullPath("./index.html"));
                await page.GoToAsync(path.AbsoluteUri);
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


                    MailMessage message = new MailMessage("anks501@gmail.com", "ankama.bollimuntha@amnetdigital.com", "not done yet working on value bind with template", emailReadyHtml);
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                    // Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(base64Stream));
                    // System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

                    // var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
                    // imageToInline.ContentId = "MyImage";
                    // var altviewItem = new AlternateView(streamBitmap);
                    // alternateView.LinkedResources.Add(imageToInline);

                    message.IsBodyHtml = true;
                    message.To.Add("kalidasu.surada@amnetdigital.com");
                    message.To.Add("saikrishna.kusuma@amnetdigital.com");
                    message.To.Add("anudeep.kappakanti@amnetdigital.com");
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
