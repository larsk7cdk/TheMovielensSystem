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
    private readonly IMoviesService _moviesService;

    public MoviesByGenre(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }

    [FunctionName("MoviesByGenre")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        string genre = req.Query["genre"];

        log.LogInformation("Get movies by genre {Genre}", genre);

        var movies = await _moviesService.GetMoviesByGenre(genre);

        if (!movies.Any())
            return new NotFoundObjectResult($"No movies found with genre {genre}");

        return new OkObjectResult(movies);
    }
}