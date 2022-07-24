using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace TeamworkSystem.Shared.Extensions;

public static class LoggingExtensions
{
    public static ILoggingBuilder AddCustomLogging(
        this ILoggingBuilder loggingBuilder,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog(new LoggerConfiguration()
                                  .Enrich.FromLogContext()
                                  .Enrich.WithMachineName()
                                  .WriteTo.Console()
                                  .WriteTo.Elasticsearch(
                                      new ElasticsearchSinkOptions(new Uri(configuration["ElasticUrl"]))
                                      {
                                          IndexFormat = $"api-logs-{DateTime.UtcNow:yyyy-MM}",
                                          AutoRegisterTemplate = true,
                                          NumberOfShards = 2,
                                          NumberOfReplicas = 1
                                      })
                                  .Enrich.WithProperty("Environment", webHostEnvironment.EnvironmentName)
                                  .ReadFrom.Configuration(configuration)
                                  .CreateLogger());

        return loggingBuilder;
    }
}
