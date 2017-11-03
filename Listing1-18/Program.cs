using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Listing1_18
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);

            Console.Read();
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}
