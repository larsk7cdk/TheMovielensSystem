using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Movielens.FaaS.Functions;

namespace Movielens.FaaS.IntegrationTest.Setup;

public class TestStartup : Startup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        base.Configure(builder);

        builder.Services.AddTransient<MoviesAll>();
        builder.Services.AddTransient<MoviesByTitle>();
        builder.Services.AddTransient<MoviesByGenre>();
    }
}