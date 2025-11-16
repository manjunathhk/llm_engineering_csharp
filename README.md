# LLM Engineering in C#

A comprehensive C# implementation of LLM Engineering concepts, converted from Ed Donner's Python-based LLM Engineering course. This repository provides production-ready, enterprise-grade implementations of modern AI engineering patterns using .NET technologies.

## 🎯 Course Overview

This is an 8-week journey through LLM Engineering, implementing real-world AI applications:

### Week 1: AI-Powered Web Scraper & Brochure Generator
- **Goal**: Build an AI system that scrapes company websites and generates professional brochures
- **Technologies**: HtmlAgilityPack, OpenAI API, ASP.NET Core
- **Key Concepts**: Web scraping, prompt engineering, content generation

### Week 2: Frontier APIs & Customer Service Chatbots
- **Goal**: Create multi-modal customer service agents with UI and function calling
- **Technologies**: OpenAI, Anthropic, Blazor, SignalR
- **Key Concepts**: API integration, real-time chat, tool usage

### Week 3: Audio Processing & Meeting Minutes
- **Goal**: Convert audio to meeting minutes and action items using open and closed-source models
- **Technologies**: NAudio, Azure Speech Services, ML.NET
- **Key Concepts**: Audio processing, transcription, summarization

### Week 4: AI Code Converter
- **Goal**: Build AI that converts Python to optimized C++, achieving 60,000x performance improvements
- **Technologies**: Roslyn, CodeAnalysis APIs, OpenAI
- **Key Concepts**: Code analysis, optimization, transpilation

### Week 5: RAG Knowledge Worker
- **Goal**: Create an AI expert on company matters using Retrieval-Augmented Generation
- **Technologies**: Qdrant, Semantic Kernel, Entity Framework
- **Key Concepts**: Vector databases, embeddings, knowledge retrieval

### Week 6: Price Prediction with Frontier Models
- **Goal**: Predict product prices from descriptions using state-of-the-art models
- **Technologies**: ML.NET, Azure ML, OpenAI
- **Key Concepts**: Price modeling, feature engineering, model evaluation

### Week 7: Fine-Tuning with QLoRA
- **Goal**: Fine-tune open-source models to compete with frontier models in price prediction
- **Technologies**: ONNX Runtime, HuggingFace.NET, Azure ML
- **Key Concepts**: Model fine-tuning, parameter-efficient training

### Week 8: Autonomous Multi-Agent System
- **Goal**: Build collaborative agents that spot deals and notify users of special bargains
- **Technologies**: MassTransit, Azure Service Bus, Multi-agent frameworks
- **Key Concepts**: Agent orchestration, autonomous systems, real-time notifications

## 🏗️ Architecture

```
LLM.Engineering.CSharp/
├── src/
│   ├── LLM.Engineering.Core/              # Core abstractions & models
│   ├── LLM.Engineering.Infrastructure/    # External API integrations  
│   ├── LLM.Engineering.Application/       # Business logic & services
│   └── LLM.Engineering.Web/              # Web API & Blazor UI
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

## 🚀 Quick Start

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or VS Code with C# Dev Kit
- Docker Desktop (for vector databases)
- API Keys: OpenAI, Anthropic (optional)

### Setup
```bash
# Clone the repository
git clone https://github.com/manjunath/llm-engineering-csharp.git
cd llm-engineering-csharp

# Restore packages
dotnet restore

# Set up API keys (user secrets)
dotnet user-secrets init --project src/LLM.Engineering.Web
dotnet user-secrets set "LLM:OpenAI:ApiKey" "your-openai-key"
dotnet user-secrets set "LLM:Anthropic:ApiKey" "your-anthropic-key"

# Run the web application
dotnet run --project src/LLM.Engineering.Web
```

### Local LLM Alternative (Ollama)
```bash
# Install Ollama and run local models
ollama run llama3.2

# Configure for local usage
dotnet user-secrets set "LLM:OpenAI:BaseUrl" "http://localhost:11434/v1"
dotnet user-secrets set "LLM:OpenAI:ApiKey" "ollama"
```

## 📦 Key Technologies

### LLM Integration
- **OpenAI**: `OpenAI` NuGet package
- **Anthropic**: `Anthropic.SDK`
- **Azure OpenAI**: `Azure.AI.OpenAI`
- **Semantic Kernel**: Microsoft's LLM orchestration framework

### Vector Databases
- **Qdrant**: `Qdrant.Client` - production vector database
- **Azure AI Search**: `Azure.Search.Documents`
- **In-memory**: Custom FAISS wrapper

### Data Processing
- **ML.NET**: Microsoft's machine learning framework
- **ONNX Runtime**: Cross-platform ML inference
- **CsvHelper**: CSV data processing
- **HtmlAgilityPack**: Web scraping

### Audio/Media
- **NAudio**: Audio processing and manipulation
- **SixLabors.ImageSharp**: Image processing
- **FFMpegCore**: Video/audio encoding

### Web & API
- **ASP.NET Core**: Web API framework
- **Blazor**: Interactive web UI
- **SignalR**: Real-time communication
- **Polly**: Resilience and fault tolerance

## 🔧 Configuration

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
      "DefaultModel": "claude-3-haiku-20240307",
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

### Environment Variables
```bash
LLM__OpenAI__ApiKey=your-openai-key
LLM__Anthropic__ApiKey=your-anthropic-key
VectorStore__ConnectionString=your-vector-db-connection
```

## 🧪 Testing

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test tests/LLM.Engineering.Core.Tests/

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## 📖 Week-by-Week Progress

- [x] **Week 1**: Web Scraper & Brochure Generator ✅
- [ ] **Week 2**: Customer Service Chatbots 🚧
- [ ] **Week 3**: Audio Processing & Meeting Minutes
- [ ] **Week 4**: AI Code Converter
- [ ] **Week 5**: RAG Knowledge Worker
- [ ] **Week 6**: Price Prediction Models
- [ ] **Week 7**: Model Fine-Tuning
- [ ] **Week 8**: Multi-Agent Systems

## 🎓 Learning Path

Each week builds upon previous concepts:

1. **Foundations**: Basic LLM integration and prompt engineering
2. **APIs**: Working with multiple LLM providers
3. **Multi-modal**: Handling text, audio, and images
4. **Code Intelligence**: AI-powered code analysis and generation
5. **Knowledge Systems**: RAG and vector databases
6. **Machine Learning**: Training and fine-tuning models
7. **Advanced ML**: Parameter-efficient fine-tuning
8. **Systems**: Multi-agent orchestration and automation

## 💰 Cost Management

- **Development**: Use `gpt-4o-mini` and `claude-3-haiku` for cost efficiency
- **Local Alternative**: Ollama with Llama 3.2 for offline development
- **Monitoring**: Built-in usage tracking and cost alerts
- **Estimated**: <$5 total for entire course completion

## 🤝 Contributing

This repository follows Clean Architecture principles:

1. **Core**: Domain models and abstractions (no dependencies)
2. **Infrastructure**: External service implementations
3. **Application**: Business logic and use cases
4. **Web**: Presentation layer and APIs

### Development Guidelines
- Follow SOLID principles
- Use dependency injection
- Implement comprehensive logging
- Write unit and integration tests
- Document public APIs

## 📚 Additional Resources

- **Original Course**: [Ed Donner's LLM Engineering](https://github.com/ed-donner/llm_engineering)
- **.NET AI**: [Microsoft Learn AI](https://learn.microsoft.com/en-us/dotnet/ai/)
- **Semantic Kernel**: [Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel)
- **ML.NET**: [Machine Learning for .NET](https://dotnet.microsoft.com/en-us/apps/machinelearning-ai/ml-dotnet)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙋‍♂️ About

Created by **Manjunath** as a C# implementation of modern LLM Engineering patterns. This repository demonstrates enterprise-grade AI applications using .NET technologies, following best practices for production deployment.

**Tech Stack**: .NET 8, C#, ASP.NET Core, Blazor, ML.NET, Azure AI Services

---

⭐ **Star this repository** if you find it helpful for your LLM engineering journey!
