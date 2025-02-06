using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

var builder = FunctionsApplication.CreateBuilder(args);
//builder.UseMiddleware();
builder.Build().Run();


public class HttpTriggerFunction
{
    private readonly ILogger<HttpTriggerFunction> _logger;

    public HttpTriggerFunction(ILogger<HttpTriggerFunction> logger)
    {
        _logger = logger;
    }

    [Function("HttpExample")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req,
        FunctionContext executionContext)
    {
        _logger.LogInformation("Hello world");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteString("Hello world");

        return response;
    }
}