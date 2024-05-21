using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WebCrawler
{
    public partial class Form1 : Form
    {
        private TextBox textBoxUrl;
        private Button buttonStart;
        private ListBox listBoxVisited;
        private ListBox listBoxErrors;
        private HttpClient client;
        private HashSet<string> visitedUrls;
        private Queue<string> urlQueue;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize components
            textBoxUrl = new TextBox { Width = 400, Top = 10, Left = 10 };
            buttonStart = new Button { Text = "启动爬虫", Left = 420, Top = 10, Width = 100 };
            listBoxVisited = new ListBox { Top = 40, Left = 10, Width = 500, Height = 300 };
            listBoxErrors = new ListBox { Top = 40, Left = 520, Width = 500, Height = 300 };

            // Add components to form
            Controls.Add(textBoxUrl);
            Controls.Add(buttonStart);
            Controls.Add(listBoxVisited);
            Controls.Add(listBoxErrors);

            // Event handlers
            buttonStart.Click += buttonStart_Click;

            // Initialize other fields
            client = new HttpClient();
            visitedUrls = new HashSet<string>();
            urlQueue = new Queue<string>();

            // Form settings
            Text = "Web Crawler";
            Width = 1040;
            Height = 400;
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            string initialUrl = textBoxUrl.Text;
            if (!Uri.IsWellFormedUriString(initialUrl, UriKind.Absolute))
            {
                MessageBox.Show("请输入有效的URL。");
                return;
            }

            urlQueue.Enqueue(initialUrl);
            await CrawlAsync();
        }

        private async Task CrawlAsync()
        {
            while (urlQueue.Count > 0)
            {
                string url = urlQueue.Dequeue();
                if (visitedUrls.Contains(url))
                {
                    continue;
                }

                visitedUrls.Add(url);
                listBoxVisited.Items.Add(url);

                try
                {
                    string content = await client.GetStringAsync(url);
                    ParseLinks(url, content);
                }
                catch (Exception ex)
                {
                    listBoxErrors.Items.Add($"{url} - {ex.Message}");
                }
            }
        }

        private void ParseLinks(string baseUrl, string content)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            var links = doc.DocumentNode.SelectNodes("//a[@href]");
            if (links == null)
            {
                return;
            }

            foreach (var link in links)
            {
                string href = link.GetAttributeValue("href", string.Empty);
                if (IsValidUrl(href, baseUrl, out string fullUrl))
                {
                    if (!visitedUrls.Contains(fullUrl) && !urlQueue.Contains(fullUrl))
                    {
                        urlQueue.Enqueue(fullUrl);
                    }
                }
            }
        }

        private bool IsValidUrl(string url, string baseUrl, out string fullUrl)
        {
            fullUrl = string.Empty;

            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

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

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
