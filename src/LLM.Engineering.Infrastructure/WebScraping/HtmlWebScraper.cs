using HtmlAgilityPack;
using LLM.Engineering.Core.Interfaces;
using LLM.Engineering.Core.ValueObjects;
using Microsoft.Extensions.Logging;

namespace LLM.Engineering.Infrastructure.WebScraping;

public class HtmlWebScraper : IWebScraper
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HtmlWebScraper> _logger;

    public HtmlWebScraper(HttpClient httpClient, ILogger<HtmlWebScraper> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<ScrapingResult> ScrapeAsync(string url, CancellationToken cancellationToken = default)
    {
        try
        {
            var html = await _httpClient.GetStringAsync(url, cancellationToken);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var title = doc.DocumentNode.SelectSingleNode("//title")?.InnerText?.Trim() ?? "";
            var content = ExtractTextContent(doc);
            var images = ExtractImages(doc, url);
            var metadata = ExtractMetadata(doc);

            return new ScrapingResult(url, title, content, metadata, images, DateTime.UtcNow);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error scraping URL: {Url}", url);
            throw;
        }
    }

    public async Task<List<ScrapingResult>> ScrapeMultipleAsync(IEnumerable<string> urls, CancellationToken cancellationToken = default)
    {
        var tasks = urls.Select(url => ScrapeAsync(url, cancellationToken));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }

    private string ExtractTextContent(HtmlDocument doc)
    {
        // Remove script and style elements
        var elementsToRemove = doc.DocumentNode.SelectNodes("//script | //style | //nav | //header | //footer");
        elementsToRemove?.ToList().ForEach(node => node.Remove());

        // Get main content
        var contentNode = doc.DocumentNode.SelectSingleNode("//main")
                         ?? doc.DocumentNode.SelectSingleNode("//body");

        return contentNode?.InnerText?.Trim() ?? "";
    }

    private List<string> ExtractImages(HtmlDocument doc, string baseUrl)
    {
        var images = new List<string>();
        var imgNodes = doc.DocumentNode.SelectNodes("//img[@src]");

        if (imgNodes != null)
        {
            foreach (var img in imgNodes)
            {
                var src = img.GetAttributeValue("src", "");
                if (!string.IsNullOrEmpty(src))
                {
                    images.Add(Uri.IsWellFormedUriString(src, UriKind.Absolute) ? src : new Uri(new Uri(baseUrl), src).ToString());
                }
            }
        }

        return images;
    }

    private Dictionary<string, string> ExtractMetadata(HtmlDocument doc)
    {
        var metadata = new Dictionary<string, string>();

        var metaTags = doc.DocumentNode.SelectNodes("//meta[@name or @property]");
        if (metaTags != null)
        {
            foreach (var meta in metaTags)
            {
                var name = meta.GetAttributeValue("name", "") ?? meta.GetAttributeValue("property", "");
                var content = meta.GetAttributeValue("content", "");
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(content))
                {
                    metadata[name] = content;
                }
            }
        }

        return metadata;
    }
}