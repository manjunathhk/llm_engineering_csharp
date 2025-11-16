namespace LLM.Engineering.Application.Models;

public record CompanyData(
    string CompanyName,
    string Description,
    List<string> Services,
    List<string> KeyMessages,
    string Industry,
    int? FoundedYear
);

public record CompanyDataResult(
    CompanyData CompanyData,
    Core.ValueObjects.ScrapingResult ScrapingResult
);