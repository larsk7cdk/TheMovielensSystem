using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Movielens.Application.Services;

namespace Movielens.FaaS.Functions;

public class MoviesByGenre
{
    private readonly ILogger<MoviesByGenre> _logger;
    private readonly IMoviesService _moviesService;

    public MoviesByGenre(IMoviesService moviesService, ILogger<MoviesByGenre> logger)
    {
        _moviesService = moviesService;
        _logger = logger;
    }

    [FunctionName("MoviesByGenre")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "genre/{genre}")]HttpRequest request, string genre)
    {
        _logger.LogInformation("Get movies by genre {Genre}", genre);

        var movies = await _moviesService.GetMoviesByGenre(genre);

        if (!movies.Any())
            return new NotFoundObjectResult($"No movies found with genre {genre}");

        return new OkObjectResult(movies);
    }
}