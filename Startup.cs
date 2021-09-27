using Microsoft.Extensions.Configuration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using AzFunctionCosmosDbPagination.DependencyInjection;

[assembly: WebJobsStartup(typeof(AzFunctionCosmosDbPagination.Startup))]
namespace AzFunctionCosmosDbPagination
{
    internal class Startup : IWebJobsStartup
    {
        private IConfiguration _configuration;

        public void Configure(IWebJobsBuilder builder)
        {
            ConfigureSettings();

            builder.Services.AddAppConfiguration(_configuration);
            builder.Services.AddDataServices();
            builder.Services.AddBusinessServices();
        }

        private void ConfigureSettings()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)
               .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            _configuration = config;
        }
    }
}
