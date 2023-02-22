using CampaignManager.Business.ServicesTests.Services;
using CampaignManager.Infrastructure.Models.ConfigModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StructureMap; 

namespace CampaignManager.Business.ServicesTests.DependencyResolver
{
    public class UnitTestDependencyResolver
    {
        public IOptions<AWSS3Config> InitiateAppSetting()
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            // add the framework services
            var services = new ServiceCollection();
            // add StructureMap
            var container = new Container();

            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(S3bucketServiceTests));
                    _.WithDefaultConventions();
                });
                services.AddScoped<AWSS3Config>();
                services.AddOptions<IOptions<AWSS3Config>>();
                services.Configure<AWSS3Config>(x => configuration.GetSection("AWSS3Config").Bind(x));
                // Populate the container using the service collection
                config.Populate(services);
            });
            var serviceProvider = container.GetInstance<IServiceProvider>();
            return serviceProvider.GetService<IOptions<AWSS3Config>>();
        }
    }
}
