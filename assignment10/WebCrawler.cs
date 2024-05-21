using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class WebCrawler
    {
        private HttpClient _client = new HttpClient();
        private ConcurrentDictionary<string, bool> _visitedUrls = new ConcurrentDictionary<string, bool>();
        private ConcurrentQueue<string> _urlQueue = new ConcurrentQueue<string>();

        public async Task StartCrawlingAsync(string initialUrl)
        {
            _urlQueue.Enqueue(initialUrl);

            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)  // Number of parallel tasks
            {
                tasks.Add(Task.Run(async () => await ProcessQueueAsync()));
            }

            await Task.WhenAll(tasks);
        }

        private async Task ProcessQueueAsync()
        {
            while (_urlQueue.TryDequeue(out string url))
            {
                if (_visitedUrls.TryAdd(url, true))
                {
                    Console.WriteLine($"Crawling: {url}");
                    try
                    {
                        string content = await _client.GetStringAsync(url);
                        ParseLinks(url, content);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error crawling {url}: {ex.Message}");
                    }
                }
            }
        }

        private void ParseLinks(string baseUrl, string content)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            var links = doc.DocumentNode.SelectNodes("//a[@href]");
            if (links == null) return;

            foreach (var link in links)
            {
                string href = link.GetAttributeValue("href", string.Empty);
                if (IsValidUrl(href, baseUrl, out string fullUrl))
                {
                    if (_visitedUrls.TryAdd(fullUrl, false))
                    {
                        _urlQueue.Enqueue(fullUrl);
                    }
                }
            }
        }

        private bool IsValidUrl(string url, string baseUrl, out string fullUrl)
        {
            fullUrl = string.Empty;

            if (string.IsNullOrWhiteSpace(url)) return false;

            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                fullUrl = url;
            }
            else if (url.StartsWith("/"))
            {
                var baseUri = new Uri(baseUrl);
                fullUrl = $"{baseUri.Scheme}://{baseUri.Host}{url}";
            }
            else
            {
                var baseUri = new Uri(baseUrl);
                fullUrl = new Uri(baseUri, url).ToString();
            }

            return (fullUrl.EndsWith(".html") || fullUrl.EndsWith(".htm") ||
                    fullUrl.EndsWith(".aspx") || fullUrl.EndsWith(".php") ||
                    fullUrl.EndsWith(".jsp"));
        }
    }
}
