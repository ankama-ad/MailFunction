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
           
            // IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            try
            {

                var accessToken = "H4sIAAAAAAAEACWWtQ70CBKE3-VPfZKZTtrANOYxY2ZmZq_u3W9Wm3fQ_XWpqv7-YyZPPyX5n__-adsIyvumEESll5936yU6pKZPXocfplRsEZWeroHUqZvGoPV6zjQyeOCjku4xarlnCYKjo5ZeV5qfqTikVR_bugeGkXLFDuE5KnPowHkwmb5VnVGOSYfVO8qtLCDG2UIwMLHqqbdRwFfPteKE3QfVZ1S6Lm6NjIHPnNQ4UjGvQMjT3mTFV2N6k8uuzva0sGn8mV8k4jKGELHIT8BcVqjJb9gR8qPDEKaQvk_CtgwV7HZux0B59F3XbR9Y4NJIkQQYkRfsKMVKHzXTGZZsnqNb5UwoVCpeZJw3FZwhZbh4wY4YqHDsIjyCO-_U6ZqZJ-sW3fMMSwff-OMID0dHgAuFwgJ4320qWjzyeWzrpGiwLMSPi3YjkAgM2gPoOv9soVbfCj0-R0LqsREW4ETlEauHg7t1bO5c0xx2W719sIqXYfn8QjAxg5zp5nDD7hqVqwAJXi8dspimxmF4kMkh3igdeYNPIBw4OsG0v8bZXxjaH6jgvp8iDsmwRpzoxqnduPnquvgUJBFlF-6da0OSoE5bJCiCf0-LrKMo1RwLYENusYQ-0pVLNnKgk3iVdYi5KrII3XYdMMcM3gMvm5fAptc-VtdBZRNFG4AkhS-WdzaZBcwqfxvNaGMK5Bgq2kktDrcT3UQfPHdTcZbN6D7fxQW6itJTN2Bf4szobK2aZFKPNDlDzpmCxzEZLY_LgqULXdwnPSeORlK-8ANeIznFhqFJW9DVdnNndXpvTfHtCDrgFQbhFF8fj_IGJAp2Wna8E-gDDSYgZaxt90gEqSxdu6ckWnwD2Vv-TSj_tPCLksGo1xQMZmDoHjOIUeRe0v24FBTjdCCHhQPMxYbHFjINpziF3JoyuRPatj8Q7p4wt2QHGwcoDwPk9VT8zSLBXZRpSVUDwV3VXeHGmsakukVbQ28t_mEuEdFO2gkse71vWCxfLZbShTZWqwWR7gOBmAQGYx_rohiM9ndOJ2nCXZAo2OURjry1BaRDNclwbfVb8fOp4VYiStBrTVXVlMQBd24COR22ZBHMONK3BEha_F6eV8cCgR6925FRM4v4NfSbKvbnjV-HzPXDJhzGQX-nrFivvvRbihIqSvWfCC9CYWnETqM-uuvFtq9wnHcf7jQSxmCwsqwh-R0y7gZmdaMsS6eZix2sqefHHnOzUluabFE1kXJEwnrdXnbKpfm9JZMrPh8EjFKoCHgxFaMluhSMI608sCGEcvYj3jcudU4tEazrsnaxHMvY9I43ptUMwROJaTsIXG-Iom8tdSwz65l8Ux-3S8qn9TmTfh91bZZ3eTlqKdNijepxEjloqtmEDqu9JLEVkA8CAXy5SHabRj7ic6Fk-DquxAGxjd0UEG9S-_IrM5KFeuxIARN2hstCjNW3kzMjTAj0kwYFNx47fnRxExlE439DvqksIzc4DUhD4xu6EZKwrZ3Gh745EMReDM8HMLXGXz-VgBLH4aa80kJaERpA6dXO2xTjuCUPnQ48S8uef98eidAgATAq0i_fyKZj1ACMcNXNkBxZgJD1wVPgIexAko8nj5eeaTysbswYre3uVNeMOCmp7CYh1aaKDxnTkEh5YxR_NZmI3LE4dAljmgBHAihAFqTmB9V2Jbk_-Aisytczmp8YA5buF6k7vSrA9JVbOIX46l4OEahj8-c9c-Edmb1AGVX_e_ir54wVZ5N1CgNQanhASv17RbH1Vk02Jcrp0LFBSOO9zM-o8exqThBoroI_qUl8SHhU4YNW_7zAICyUBRxSLWFH3DU2TtMVzO_u0qRrr2YQMmDB9q7LTrJsfavnFeEKLusmh-yuCBFUnagZn2_alPWDWfxr_6DZHB7cvpKBpuG5lPsJewKcFjOQS62b-lGJfIMtiFuMl4u_8EdRnqlO0L0Sca7xTMsLAI_Bh_mUxihCis66CswbQrruv7wlI4un3oLgdYVG9bS3bRPTGI0dcUw8pHVvnoi_-KzmKMxW_1gSTMQT319Swb2TIVmD1foOjQcmd20u1BFzNJnSOSplX_EX9VtdT2vP8b6pDXOl7n63Rr3fVlq_HF2kZXOYmtryX27cJvegdN5HfTOCSqB_ucGqt-nNx5ofYRrhAUAg7Ets92iSXHMzh43Tx2GriRakFjiTsxU6huFGZ3haBpi_jKBs2H7DhU_yKbekZDQr2yBu-iihBHbVzpPCx3Aitn-xfY0lIa2xycg6_rGPZe4ghLx3wQT0S3EOU42ezv7SAJ3JR0Mqm3DWgNfE7OhHsrroYvmU9V5XWXJeOvpgAJlIpOaX4ldxBd0n8VNhcXN3DH5D1V3psSxVo29-T4KeNemdYcjSUfBjPoFPI4fv9CkVTgUZoic9VMXPyvQCtjnKNN8XerFMWWcIVjQN40M6wnoSHp5Z6W37sTCnnc24v3-O1PCbYuacPiTIWOyEWRy5ePWXkehNpyF7LyV23zQ4KWkmg9_F9uc_f7j1mfdJLZ5fHdNa5ddzJmkGFHdQjIu1iFPOw62v09Nu1bHt3MiioYUytfgJ46t_fjrR1bI7HqNgol8k6ck6atXKH4TjhcEwSN76O2jzCj7fjAaQ8k_luiCb0g5XKx7-c-_UcB0vk_wKDLEa183qDGZoIwbXvjVkhL0Cm2E3JpzX12uVXxvcPxxxIUiN_QjDbZnHBeune09DEocEKwE_vgkCd7HZEdMxeHylwl-3M6qM1Qh98JQAQyMraskBnqhDfdHHuK-a4ygis3WCPqLWkEekFS5dF-3KDZ3C2_F4inibnWgVKGk9ll1h-bRFLWRj2nGK55gXa8pZA78pzr5Ozn-wwiwTyzCLz9Nl1V9__YP5metilf0fZRnodyIZWx571GVwPoPul-2_U05Tjcl-rMVvrE6WH9_ZzMO4C5w6tQ92vdCHmosDqNoeUZeJSZ3npaWLPx18Z743K8N76dwcxQ4gFQgLctlw1Xe5eVAYfRMuHS_Ph-YfnadEL18tdlg8DrgkZkB1H3iAgCzbQb798hTBNrphgg9xFVT6b8fLQ3u8N5-eiPet-yPVzzxmJi0GBY87LEQ9iyNQUaO31gi92gF-fgBU0SqN4jqTjSuQ4ypmE-4UYuynOZsPZJLysp2Toc9Gm9vuBXMOgPyJQtCYySotxUO2iqIVOiCD0ypH_JNHsu7BTy40sfGzrtZ-fjUxKGZg5SKt-SXlHY-O1Krio3uCcIy53KjgQ0IvX6tT9Nuxuhzmh_l__wcRIchVggwAAA==.eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLVVTLU5PUlRILUNFTlRSQUwtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjpmYWxzZX19";
                var embedUrl = "https://app.powerbi.com/reportEmbed?reportId=f6bfd646-b718-44dc-a378-b73e6b528204&groupId=be8908da-da25-452e-b220-163f52476cdd&config=eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLVVTLU5PUlRILUNFTlRSQUwtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjp0cnVlLCJjZXJ0aWZpZWRUZWxlbWV0cnlFbWJlZCI6dHJ1ZX19";
                var reportId = "f6bfd646-b718-44dc-a378-b73e6b528204";
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
                var path = await GetFilePath(reportId, accessToken, embedUrl);
                await page.GoToAsync(path);
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
                    //message.To.Add("kalidasu.surada@amnetdigital.com");
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

        public static async Task<string> GetFilePath(string reportId, string accessToken, string embedUrl){
                                  
               // await page.EmulateMediaTypeAsync(PuppeteerSharp.Media.MediaType.Screen);
            string html;
            using (var reader = new StreamReader("./index.html")){
            html = reader.ReadToEnd();
            }
                // await page.SetContentAsync(_html);
                //Path.DirectorySeparatorChar = '/';
                // Path.AltDirectorySeparatorChar = '/';
            html = html.Replace(":accessToken", accessToken);
            html =  html.Replace(":embedUrl", embedUrl);
            html = html.Replace(":reportId", reportId);
            var guid = Guid.NewGuid();
            await File.WriteAllTextAsync( guid +".html", html); 
            return new Uri(Path.GetFullPath("./" + guid +".html" )).AbsoluteUri;
        }
    }
}
