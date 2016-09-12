using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sixeyed.Uptimer
{
    public class Program
    {

        private static string _StorageConnectionString;
        private static string _Url;

        public static void Main(string[] args)
        {
            _StorageConnectionString = Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING");
            _Url = args[0];
            var frequency = args[1];

            var timer = new Timer(async (s)=> await TestUrl(s), null, TimeSpan.Zero, TimeSpan.Parse(frequency));

            Console.ReadLine();
        }

        private static async Task TestUrl(object state)
        {
            var stopwatch = Stopwatch.StartNew();
            var response = await GetResponse();

            Console.WriteLine("ping to URL: {0}. Took: {1}ms", _Url, stopwatch.ElapsedMilliseconds);
        }

        private static async Task<HttpResponseMessage> GetResponse()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, _Url);
                using (var client = new HttpClient())
                {
                    return await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                }
            }
            catch (Exception ex)
            {
                //TODO - logging
                return null;
            }
        }
    }
}