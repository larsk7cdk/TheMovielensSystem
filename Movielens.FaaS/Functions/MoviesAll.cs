using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Movielens.Application.Services;

namespace Movielens.FaaS.Functions;

public class MoviesAll
{
    private readonly ILogger<MoviesAll> _logger;
    private readonly IMoviesService _moviesService;

    public MoviesAll(IMoviesService moviesService, ILogger<MoviesAll> logger)
    {
        _moviesService = moviesService;
        _logger = logger;
    }

    [FunctionName("MoviesAll")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest request)
    {
        _logger.LogInformation("Get all movies");


        var movies = await _moviesService.GetMovies();

        if (!movies.Any())
            return new NotFoundObjectResult("No movies found");

        return new OkObjectResult(movies);
    }
}