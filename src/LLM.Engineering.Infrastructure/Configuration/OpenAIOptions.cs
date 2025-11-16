namespace LLM.Engineering.Infrastructure.Configuration;

public class OpenAIOptions
{
    public const string SectionName = "LLM:OpenAI";

    public string ApiKey { get; set; } = string.Empty;
    public string Model { get; set; } = "phi3:latest";
    public double Temperature { get; set; } = 0.7;
    public int MaxTokens { get; set; } = 1000;
    public string BaseUrl { get; set; } = "https://localhost:11436/v1";
}