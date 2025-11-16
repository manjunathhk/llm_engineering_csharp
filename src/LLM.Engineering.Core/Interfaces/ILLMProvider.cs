using System;
using System.Collections.Generic;
using System.Text;

namespace LLM.Engineering.Core.Interfaces;

public interface ILLMProvider
{
    string ProviderName { get; }

    Task<string> GenerateResponseAsync(string prompt, CancellationToken cancellationToken = default);

    Task<T> GenerateStructuredResponseAsync<T>(string prompt, CancellationToken cancellationToken = default);

    Task<bool> IsAvailableAsync();
}