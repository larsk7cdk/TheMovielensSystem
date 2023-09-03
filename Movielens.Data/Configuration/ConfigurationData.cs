using Microsoft.Extensions.DependencyInjection;
using Movielens.Data.DataAccess;

namespace Movielens.Data.Configuration;

public static class ConfigurationData
{
    public static IServiceCollection ConfigureDataWebApi(this IServiceCollection services)
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var moviesJsonPath = Path.Combine(basePath, "Fakes", "movies.json");

        services.AddSingleton<IMoviesDataAccess>(_ => new MoviesDataAccess(moviesJsonPath));

        return services;
    }

    public static IServiceCollection ConfigureDataAzureFunc(this IServiceCollection services)
    {
        string basePath = Environment.GetEnvironmentVariable("AzureWebJobsScriptRoot");
        string moviesJsonPath = System.IO.Path.Combine(basePath, "Fakes", "movies.json");

        services.AddSingleton<IMoviesDataAccess>(_ => new MoviesDataAccess(moviesJsonPath));

        return services;
    }
}