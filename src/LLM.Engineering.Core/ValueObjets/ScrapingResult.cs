namespace LLM.Engineering.Core.ValueObjects;

public record ScrapingResult(
    string Url,
    string Title,
    string Content,
    Dictionary<string, string> Metadata,
    List<string> Images,
    DateTime ScrapedAt
);