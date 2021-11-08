using System;
using System.Linq; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Web;
using System.Net;

namespace TwoCaptcha.Examples
{
    public class ReCaptchaV2Example
    {
      static  string prodiid;
       static string ammount;
        static string x_token;
        static int min=59;
        static int sec=57;
        static string cokie = null;
        static string crsf=null;
        public static void Main(string[] arg)
        {
            Console.WriteLine("prodiid");
            prodiid = Console.ReadLine();

            Console.WriteLine("ammount");
            ammount = Console.ReadLine();

            Console.WriteLine(prodiid);
            Console.WriteLine(ammount);


            Console.WriteLine("cokie");
            cokie = Console.ReadLine();

            Console.WriteLine("crsf");
            crsf = Console.ReadLine();

            Console.WriteLine("введите токен");
            x_token = Console.ReadLine();
          


            Console.WriteLine("go gogogoog");          
            Console.WriteLine(min);
            Console.WriteLine(sec);
            while (true)
            {

                if (DateTime.Now.Minute == min && DateTime.Now.Second == sec)
                {

                    try
                    {


                        new Thread(delegate ()
                        {
                            while (true)
                            {
                                buy_unlim_misterybox();
                            }
                        }).Start();
                        Thread.Sleep(100);
                        new Thread(delegate ()
                        {
                            while (true)
                            {
                                buy_unlim_misterybox();
                            }
                        }).Start();

                        Thread.Sleep(800);

                    }
                    catch (AggregateException e)
                    {
                        Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
                    }
                }
                
            }
        }

       static void buy_unlim_misterybox()
        {
            try
            {
                while (true)

                {

                    var url = "https://www.binance.com/bapi/nft/v1/private/nft/mystery-box/purchase";

                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpRequest.Method = "POST";

                    httpRequest.Headers["clienttype"] = "web";
                    httpRequest.ContentType = "application/json";
                    httpRequest.Headers["cookie"] = cokie;
                    httpRequest.Headers["csrftoken"] = crsf;
                    httpRequest.ContentType = "application/json";
                    httpRequest.Headers["x-nft-checkbot-sitekey"] = "6LeUPckbAAAAAIX0YxfqgiXvD3EOXSeuq0OpO8u_";
                    httpRequest.Headers["x-nft-checkbot-token"] = x_token;

                    var data = "{\"number\":" + ammount + ",\"productId\":\"" + prodiid + "\"}";

                    using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        streamWriter.Write(data);
                    }
                    HttpWebResponse httpResponse = null;
                    httpResponse = (HttpWebResponse)httpRequest.GetResponse();


                    var de = new StreamReader(httpResponse.GetResponseStream()).ReadToEnd();

                    Console.WriteLine(httpResponse.StatusCode);
                    Console.WriteLine(de.ToString() );

                    Console.WriteLine("\n"+DateTime.Now.Second+":"+ DateTime.Now.Millisecond);
                    // nft_user_update();
                }

            }
            catch (Exception ex)
            { 
            }
        }
    }
}