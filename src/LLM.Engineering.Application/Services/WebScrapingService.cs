using LLM.Engineering.Application.Interfaces;
using LLM.Engineering.Application.Models;
using LLM.Engineering.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LLM.Engineering.Application.Services;

public class WebScrapingService : IWebScrapingService
{
    private readonly IWebScraper _webScraper;
    private readonly ILLMProvider _llmProvider;
    private readonly ILogger<WebScrapingService> _logger;

    public WebScrapingService(
        IWebScraper webScraper,
        ILLMProvider llmProvider,
        ILogger<WebScrapingService> logger)
    {
        _webScraper = webScraper;
        _llmProvider = llmProvider;
        _logger = logger;
    }

    public async Task<CompanyDataResult> ExtractCompanyDataAsync(string url, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Extracting company data from {Url}", url);

        var scrapingResult = await _webScraper.ScrapeAsync(url, cancellationToken);

        var prompt = $"""
            Extract company information from this content and return ONLY valid JSON with no other text:

            Content: {scrapingResult.Content}

            Return JSON with keys: companyName, description, services, keyMessages, industry, foundedYear
            Do not include markdown formatting or explanatory text.
            """;

        var response = await _llmProvider.GenerateStructuredResponseAsync<CompanyData>(prompt, cancellationToken);

        return new CompanyDataResult(response, scrapingResult);
    }

    public async Task<List<CompanyDataResult>> ExtractMultipleCompanyDataAsync(
        IEnumerable<string> urls,
        CancellationToken cancellationToken = default)
    {
        var tasks = urls.Select(url => ExtractCompanyDataAsync(url, cancellationToken));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }
}