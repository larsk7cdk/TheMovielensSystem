using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Movielens.Application.Configuration;
using Movielens.Data.Configuration;
using Movielens.FaaS;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Movielens.FaaS;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.ConfigureApplication();
        builder.Services.ConfigureData();
    }
}