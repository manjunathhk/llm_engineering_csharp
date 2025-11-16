using LLM.Engineering.Core.Interfaces;
using LLM.Engineering.Infrastructure.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;

namespace LLM.Engineering.Infrastructure.LLM;

public class OpenAIProvider : ILLMProvider
{
    private readonly OpenAIClient _client;
    private readonly ILogger<OpenAIProvider> _logger;
    private readonly OpenAIOptions _options;

    public string ProviderName => "OpenAI";

    public OpenAIProvider(IOptions<OpenAIOptions> options, ILogger<OpenAIProvider> logger)
    {
        _options = options.Value;
        _logger = logger;
        _client = new OpenAIClient(_options.ApiKey);
    }

    public async Task<string> GenerateResponseAsync(string prompt, CancellationToken cancellationToken = default)
    {
        try
        {
            var chatClient = _client.GetChatClient(_options.Model);
            var messages = new List<ChatMessage>
            {
                new UserChatMessage(prompt)
            };

            var response = await chatClient.CompleteChatAsync(messages, cancellationToken: cancellationToken);
            return response.Value.Content[0].Text;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating response from OpenAI");
            throw;
        }
    }

    public async Task<T> GenerateStructuredResponseAsync<T>(string prompt, CancellationToken cancellationToken = default)
    {
        var response = await GenerateResponseAsync(prompt, cancellationToken);

        // Clean markdown code blocks
        var cleanedResponse = response
            .Replace("```json", "")
            .Replace("```", "")
            .Trim();

        return System.Text.Json.JsonSerializer.Deserialize<T>(cleanedResponse) ?? throw new InvalidOperationException("Failed to deserialize response");
    }

    public async Task<bool> IsAvailableAsync()
    {
        try
        {
            await GenerateResponseAsync("Test", CancellationToken.None);
            return true;
        }
        catch
        {
            return false;
        }
    }
}