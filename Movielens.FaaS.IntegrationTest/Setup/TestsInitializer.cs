using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;

namespace Movielens.FaaS.IntegrationTest.Setup;

public class TestsInitializer
{
    public TestsInitializer()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var basePathIndex = baseDirectory.IndexOf("TheMovielensSystem", StringComparison.Ordinal);
        var dataPath = Path.Combine(baseDirectory[..basePathIndex], "TheMovielensSystem", "Movielens.Data");

        Environment.SetEnvironmentVariable("AzureWebJobsScriptRoot", dataPath);

        var host = new HostBuilder()
            .ConfigureWebJobs(builder => builder.UseWebJobsStartup(typeof(TestStartup), new WebJobsBuilderContext(), NullLoggerFactory.Instance))
            .ConfigureHostConfiguration(builder => { })
            .Build();

        ServiceProvider = host.Services;
    }

    public IServiceProvider ServiceProvider { get; }
}