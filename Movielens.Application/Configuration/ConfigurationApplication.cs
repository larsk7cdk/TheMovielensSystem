using Microsoft.Extensions.DependencyInjection;
using Movielens.Application.Services;

namespace Movielens.Application.Configuration;

public static class ConfigurationApplication
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMoviesService, MoviesService>();

        return services;
    }
}