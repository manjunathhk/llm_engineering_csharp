using LLM.Engineering.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LLM.Engineering.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WebScrapingController : ControllerBase
{
    private readonly IWebScrapingService _webScrapingService;
    private readonly ILogger<WebScrapingController> _logger;

    public WebScrapingController(IWebScrapingService webScrapingService, ILogger<WebScrapingController> logger)
    {
        _webScrapingService = webScrapingService;
        _logger = logger;
    }

    [HttpPost("scrape")]
    public async Task<IActionResult> ScrapeWebsite([FromBody] ScrapeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _webScrapingService.ExtractCompanyDataAsync(request.Url, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error scraping website {Url}", request.Url);
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost("scrape-multiple")]
    public async Task<IActionResult> ScrapeMultipleWebsites([FromBody] ScrapeMultipleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _webScrapingService.ExtractMultipleCompanyDataAsync(request.Urls, cancellationToken);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error scraping multiple websites");
            return BadRequest(new { error = ex.Message });
        }
    }
}

public record ScrapeRequest(string Url);
public record ScrapeMultipleRequest(List<string> Urls);