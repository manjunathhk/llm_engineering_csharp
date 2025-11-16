# LLM Engineering in C# (.NET 10)

A comprehensive C# implementation of LLM Engineering concepts, converted from Ed Donner's Python-based course. Enterprise-grade implementations of modern AI engineering patterns using .NET 10 LTS and Visual Studio 2026.

## 🚀 Quick Start

### Prerequisites
- **.NET 10.0 SDK** (LTS - released November 2025)
- **Visual Studio 2026** or VS Code with C# Dev Kit
- **Docker Desktop** (for vector databases)
- **API Keys**: OpenAI, Anthropic (optional for local Ollama)

### Setup
```bash
git clone https://github.com/manjunathhk/llm_engineering_csharp.git
cd llm_engineering_csharp

# Restore packages
dotnet restore

# Configure API keys (user secrets)
dotnet user-secrets init --project src/LLM.Engineering.Web
dotnet user-secrets set "LLM:OpenAI:ApiKey" "your-openai-key"
dotnet user-secrets set "LLM:Anthropic:ApiKey" "your-anthropic-key"

# Run application
dotnet run --project src/LLM.Engineering.Web
```

### Local LLM Alternative (Ollama)
```bash
# Install and run Ollama
ollama run llama3.2

# Configure for local usage
dotnet user-secrets set "LLM:OpenAI:BaseUrl" "http://localhost:11434/v1"
dotnet user-secrets set "LLM:OpenAI:ApiKey" "ollama"
```

## 📚 Course Overview

8-week journey through LLM Engineering with real-world AI applications:

### Week 1: AI-Powered Web Scraper & Brochure Generator
- **Goal**: Build AI system for website scraping and professional brochure generation
- **Tech**: HtmlAgilityPack, OpenAI API, ASP.NET Core 10
- **Concepts**: Web scraping, prompt engineering, content generation

### Week 2: Frontier APIs & Customer Service Chatbots  
- **Goal**: Multi-modal customer service agents with UI and function calling
- **Tech**: OpenAI, Anthropic, Blazor 10, SignalR
- **Concepts**: API integration, real-time chat, tool usage

### Week 3: Audio Processing & Meeting Minutes
- **Goal**: Convert audio to meeting minutes using open/closed-source models
- **Tech**: NAudio, Azure Speech Services, ML.NET
- **Concepts**: Audio processing, transcription, summarization

### Week 4: AI Code Converter
- **Goal**: Build AI for Python to optimized C++ conversion (60,000x improvements)
- **Tech**: Roslyn, CodeAnalysis APIs, OpenAI
- **Concepts**: Code analysis, optimization, transpilation

### Week 5: RAG Knowledge Worker
- **Goal**: AI expert on company matters using Retrieval-Augmented Generation
- **Tech**: Qdrant, Semantic Kernel, Entity Framework Core 10
- **Concepts**: Vector databases, embeddings, knowledge retrieval

### Week 6: Price Prediction with Frontier Models
- **Goal**: Predict product prices from descriptions using state-of-the-art models
- **Tech**: ML.NET, Azure ML, OpenAI
- **Concepts**: Price modeling, feature engineering, evaluation

### Week 7: Fine-Tuning with QLoRA
- **Goal**: Fine-tune open-source models to compete with frontier models
- **Tech**: ONNX Runtime, HuggingFace.NET, Azure ML
- **Concepts**: Model fine-tuning, parameter-efficient training

### Week 8: Autonomous Multi-Agent System
- **Goal**: Collaborative agents for deal spotting and bargain notifications
- **Tech**: Microsoft Agent Framework, MassTransit, Azure Service Bus
- **Concepts**: Agent orchestration, autonomous systems, notifications

## 🏗️ Architecture

```
llm_engineering_csharp/
├── src/
│   ├── LLM.Engineering.Core/              # Domain models & abstractions
│   ├── LLM.Engineering.Infrastructure/    # External API integrations  
│   ├── LLM.Engineering.Application/       # Business logic & services
│   └── LLM.Engineering.Web/              # ASP.NET Core 10 API & Blazor UI
├── samples/
│   ├── Week01.WebScraper/                # Web scraping + brochures
│   ├── Week02.CustomerService/           # Customer service chatbots
│   ├── Week03.AudioProcessing/           # Meeting minutes from audio
│   ├── Week04.CodeConverter/             # AI code converter
│   ├── Week05.RAGSystem/                 # RAG knowledge worker
│   ├── Week06.PricePrediction/           # Price prediction models
│   ├── Week07.FineTuning/                # Model fine-tuning
│   └── Week08.MultiAgent/                # Multi-agent systems
└── tests/
    ├── LLM.Engineering.Core.Tests/
    ├── LLM.Engineering.Application.Tests/
    └── LLM.Engineering.Integration.Tests/
```

## 🔧 Key Technologies

### .NET 10 & C# 14 Features
- **File-based apps**: Single-file applications with `#sdk` directives
- **Field-backed properties**: Enhanced property syntax
- **Performance**: JIT improvements, better struct handling
- **Microsoft Agent Framework**: Multi-agent AI orchestration

### LLM Integration
- **OpenAI**: Latest GPT models with structured outputs
- **Anthropic**: Claude 3.5 Sonnet integration
- **Azure OpenAI**: Enterprise-grade AI services
- **Semantic Kernel**: Microsoft's LLM orchestration framework

### Data & Vector Stores
- **Qdrant**: Production vector database
- **Azure AI Search**: Cognitive search capabilities
- **Entity Framework Core 10**: Modern ORM with .NET 10 optimizations
- **ML.NET**: Microsoft's machine learning framework

### Web & Real-time
- **ASP.NET Core 10**: High-performance web framework
- **Blazor 10**: Interactive WebAssembly applications
- **SignalR**: Real-time communication
- **Minimal APIs**: Lightweight API endpoints

## ⚙️ Configuration

### appsettings.json
```json
{
  "LLM": {
    "OpenAI": {
      "DefaultModel": "gpt-4o-mini",
      "Temperature": 0.7,
      "MaxTokens": 1000
    },
    "Anthropic": {
      "DefaultModel": "claude-3-5-sonnet-20241022",
      "Temperature": 0.7,
      "MaxTokens": 1000
    }
  },
  "VectorStore": {
    "Provider": "Qdrant", 
    "ConnectionString": "http://localhost:6333"
  }
}
```

### Directory.Build.props
```xml
<Project>
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <LangVersion>14.0</LangVersion>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

## 🧪 Testing

```bash
# Run all tests
dotnet test

# Test with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific project
dotnet test tests/LLM.Engineering.Core.Tests/
```

## 📈 Progress

- [x] **Week 1**: Web Scraper & Brochure Generator ✅
- [ ] **Week 2**: Customer Service Chatbots 🚧
- [ ] **Week 3**: Audio Processing & Meeting Minutes
- [ ] **Week 4**: AI Code Converter  
- [ ] **Week 5**: RAG Knowledge Worker
- [ ] **Week 6**: Price Prediction Models
- [ ] **Week 7**: Model Fine-Tuning
- [ ] **Week 8**: Multi-Agent Systems

## 💡 Learning Path

1. **Foundations**: LLM integration and prompt engineering
2. **Multi-modal**: Text, audio, and image processing
3. **Code Intelligence**: AI-powered development tools
4. **Knowledge Systems**: RAG and semantic search
5. **Machine Learning**: Training and optimization
6. **Agent Systems**: Autonomous AI collaboration

## 💰 Cost Management

- **Development**: Use `gpt-4o-mini` and `claude-3-haiku` for cost efficiency
- **Local Development**: Ollama with Llama 3.2 for offline work
- **Monitoring**: Built-in usage tracking and cost alerts
- **Estimated Cost**: <$5 for complete course

## 🤝 Contributing

Follows Clean Architecture and .NET 10 best practices:

- **Core**: Domain models (no dependencies)
- **Infrastructure**: External service implementations  
- **Application**: Business logic and use cases
- **Web**: Presentation layer and APIs

### Development Guidelines
- Use .NET 10 and C# 14 features
- Follow SOLID principles
- Implement comprehensive logging
- Write unit and integration tests
- Document public APIs

## 📚 Resources

- **Original Course**: [Ed Donner's LLM Engineering](https://github.com/ed-donner/llm_engineering)
- **.NET 10**: [What's New in .NET 10](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/overview)
- **C# 14**: [C# 14 Features](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14)
- **Semantic Kernel**: [Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel)
- **ML.NET**: [Machine Learning for .NET](https://dotnet.microsoft.com/en-us/apps/machinelearning-ai/ml-dotnet)

## 📄 License

MIT License - see [LICENSE](LICENSE) file for details.

## 👨‍💻 About

Created by **Manjunath** as a comprehensive C# implementation of modern LLM Engineering patterns using .NET 10 LTS and Visual Studio 2026.

**Tech Stack**: .NET 10, C# 14, ASP.NET Core 10, Blazor 10, ML.NET, Azure AI Services

---

⭐ **Star this repository** if you find it helpful for your LLM engineering journey!