using LLM.Engineering.Core.ValueObjects;

namespace LLM.Engineering.Core.Interfaces;

public interface IWebScraper
{
    Task<ScrapingResult> ScrapeAsync(string url, CancellationToken cancellationToken = default);

    Task<List<ScrapingResult>> ScrapeMultipleAsync(IEnumerable<string> urls, CancellationToken cancellationToken = default);
}