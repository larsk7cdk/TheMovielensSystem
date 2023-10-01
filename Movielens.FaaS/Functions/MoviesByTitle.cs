using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Movielens.Application.Services;

namespace Movielens.FaaS.Functions;

public class MoviesByTitle
{
    private const int TitleMinimumCharacters = 2;
    private readonly ILogger<MoviesByTitle> _logger;
    private readonly IMoviesService _moviesService;

    public MoviesByTitle(IMoviesService moviesService, ILogger<MoviesByTitle> logger)
    {
        _moviesService = moviesService;
        _logger = logger;
    }

    [FunctionName("MoviesByTitle")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "title/{title}")] HttpRequest req, string title)
    {
        _logger.LogInformation("Get movies by title {Title}", title);

        var movies = await _moviesService.GetMoviesByTitle(title);

        if (title.Length < TitleMinimumCharacters)
            return new BadRequestObjectResult($"The title has to have a length of minimum {TitleMinimumCharacters} characters");

        if (!movies.Any())
            return new NotFoundObjectResult($"No movies found with title {title}");

        return new OkObjectResult(movies);
    }
}