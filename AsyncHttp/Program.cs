using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncHttp
{
    class Program
    {
        static void Main(string[] args)
        {
            // build apiRequest
            object apiRequest = null;

            var result =  GetUserData(apiRequest);

            Console.WriteLine("Hello World!");
            Console.WriteLine("guid is: " + result);
            Console.WriteLine("Hello World2");
        }

        private static string GetUserData(object apiRequest)
        {
            string url = "http://xzoo.org";  // get url from apiRequest or something else place

            var webRequest = (HttpWebRequest) WebRequest.Create(url);
            // do something read data apiRequest and save to webRequest's header
            webRequest.Headers[HttpRequestHeader.Authorization] = "xxxx";
            var response = InvokeAPI(10, url, (HttpWebRequest)webRequest);

            return response.Result;
        }

        private static string ParseResponse(HttpWebResponse httpResponse)
        {
            if (httpResponse == null) return null;

            if (httpResponse != null && httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        throw new InvalidOperationException("cannot get stream");
                    }

                    string stream = new StreamReader(responseStream).ReadToEnd();
                    //Console.WriteLine(stream);
                    return stream.Substring(0, 20);
                }
            }
            return null;
        }

        private static async Task<string> InvokeAPI(int t, string url, HttpWebRequest webRequest)
        {
            Console.WriteLine("invoke API " + t + " seconds");

            var response = (HttpWebResponse)await Task.Factory
                .FromAsync<WebResponse>(webRequest.BeginGetResponse,
                                        webRequest.EndGetResponse,
                                        null);

            await DoBusy(t);

            Console.WriteLine("invoke API --- done");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return ParseResponse(response);
            }
            else
            {
                throw new Exception("Web socket error");
            }
        }

        private static async Task DoBusy(int seconds)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(seconds * 1000);
            });
        }
    }
}
