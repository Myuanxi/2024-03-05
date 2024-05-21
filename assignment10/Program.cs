using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCrawler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var crawler = new WebCrawler();
            await crawler.StartCrawlingAsync("https://example.com");

            Console.WriteLine("Crawling finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
