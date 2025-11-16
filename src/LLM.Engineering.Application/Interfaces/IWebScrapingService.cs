using LLM.Engineering.Application.Models;

namespace LLM.Engineering.Application.Interfaces;

public interface IWebScrapingService
{
    Task<CompanyDataResult> ExtractCompanyDataAsync(string url, CancellationToken cancellationToken = default);

    Task<List<CompanyDataResult>> ExtractMultipleCompanyDataAsync(IEnumerable<string> urls, CancellationToken cancellationToken = default);
}