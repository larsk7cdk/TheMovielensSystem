using Microsoft.Extensions.DependencyInjection;
using Movielens.Data.DataAccess;

namespace Movielens.Data.Configuration;

public static class ConfigurationData
{
    public static IServiceCollection ConfigureData(this IServiceCollection services)
    {
        services.AddSingleton<IMoviesDataAccess, MoviesDataAccess>();

        return services;
    }
}