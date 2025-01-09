using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = FunctionsApplication.CreateBuilder(args);
builder.ConfigureFunctionsWebApplication();
builder.Build().Run();


public class Function
{
    private readonly ILogger<Function> _logger;

    public Function(ILogger<Function> logger)
    {
        _logger = logger;
    }

    [Function("HttpFunction")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("Hello world");
        return new OkObjectResult("Hello world");
    }
}