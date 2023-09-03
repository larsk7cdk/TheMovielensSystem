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
    private readonly IMoviesService _moviesService;

    public MoviesAll(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }

    [FunctionName("MoviesAll")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("Get all movies");

        var movies = await _moviesService.GetMovies();
        return new OkObjectResult(movies);
    }
}