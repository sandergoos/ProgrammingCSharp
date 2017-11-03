using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bogus;

namespace AsyncTest
{
    public class Fake
    {
        public string Content { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> websites = new List<string>();
            foreach (var num in Enumerable.Range(0, 100))
            {
                var fake = new Faker<Fake>().RuleFor(x => x.Content, f => f.Internet.Url()).Generate();
                websites.Add(fake.Content);
            }

            List<Task> tasks = new List<Task>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var count = 0;
            foreach (var website in websites)
            {
                tasks.Add(GetSiteAsync(website, count++));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Elapsed: " + stopWatch.Elapsed);

            stopWatch.Restart();

            var count1 = 0;
            foreach (var website in websites)
            {
               GetSite(website, count1++);
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Elapsed: " + stopWatch.Elapsed);

            Console.ReadKey();
        }

        public static async Task GetSiteAsync(string website, int i)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 5);
                    var downloadedString = await httpClient.GetStringAsync(website);

                    if (downloadedString.Length > 50)
                        downloadedString = downloadedString.Substring(0, 50);

                    Console.WriteLine("Thread {0}: Content: {1}", Thread.CurrentThread.ManagedThreadId, "Counter" + i + downloadedString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Thread {0}: Content: {1}", Thread.CurrentThread.ManagedThreadId, "Counter" + i);
            }
        }

        public static void GetSite(string website, int i)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 5);
                    var downloadedString = httpClient.GetStringAsync(website).Result;

                    if (downloadedString.Length > 50)
                        downloadedString = downloadedString.Substring(0, 50);

                    Console.WriteLine("Thread {0}: Content: {1}", Thread.CurrentThread.ManagedThreadId, "Counter" + i + downloadedString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Thread {0}: Content: {1}", Thread.CurrentThread.ManagedThreadId, "Counter" + i);
            }
        }
    }
}
