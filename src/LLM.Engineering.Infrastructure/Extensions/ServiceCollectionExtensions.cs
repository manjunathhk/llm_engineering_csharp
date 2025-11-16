using LLM.Engineering.Core.Interfaces;
using LLM.Engineering.Infrastructure.Configuration;
using LLM.Engineering.Infrastructure.LLM;
using LLM.Engineering.Infrastructure.WebScraping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LLM.Engineering.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuration
        services.Configure<OpenAIOptions>(configuration.GetSection(OpenAIOptions.SectionName));

        // HTTP Client with basic retry
        services.AddHttpClient<IWebScraper, HtmlWebScraper>(client =>
        {
            client.DefaultRequestHeaders.Add("User-Agent", "LLM-Engineering-Bot/1.0");
            client.Timeout = TimeSpan.FromMinutes(2);
        });

        // LLM Providers
        services.AddScoped<ILLMProvider, OpenAIProvider>();

        return services;
    }
}