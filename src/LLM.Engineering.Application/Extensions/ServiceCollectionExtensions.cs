using LLM.Engineering.Application.Interfaces;
using LLM.Engineering.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LLM.Engineering.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IWebScrapingService, WebScrapingService>();

        // MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}