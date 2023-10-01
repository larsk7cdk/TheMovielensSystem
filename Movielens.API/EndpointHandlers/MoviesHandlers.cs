using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Movielens.Application.Services;
using Movielens.Contracts.Models;

namespace Movielens.API.EndpointHandlers;

public static class MoviesHandlers
{
    private const int TitleMinimumCharacters = 2;

    public static RouteGroupBuilder MapMovies(this RouteGroupBuilder group)
    {
        group
            .WithTags("Movies")
            .WithDescription("Operations for Movies");

        group.MapGet("/all", async Task<Results<BadRequest<string>, NotFound<string>, Ok<IList<Movie>>>> (
                [FromServices] IMoviesService moviesService,
                CancellationToken token) =>
            {
                var movies = await moviesService.GetMovies();
                return TypedResults.Ok(movies);
            })
            .WithSummary("Get all movies")
            .Produces<IList<Movie>>();

        group.MapGet("/title/{title}", async Task<Results<BadRequest<string>, NotFound<string>, Ok<IList<Movie>>>> (
                [FromServices] IMoviesService moviesService,
                [FromRoute] string title,
                CancellationToken token) =>
            {
                var movies = await moviesService.GetMoviesByTitle(title);

                if (title.Length < TitleMinimumCharacters)
                    return TypedResults.BadRequest($"The title has to have a length of minimum {TitleMinimumCharacters} characters");

                if (!movies.Any())
                    return TypedResults.NotFound($"No movies found with title {title}");

                return TypedResults.Ok(movies);
            })
            .WithSummary("Get all movies by genre")
            .Produces<IList<Movie>>();
        group.MapGet("/genre/{genre}", async Task<Results<BadRequest<string>, NotFound<string>, Ok<IList<Movie>>>> (
                [FromServices] IMoviesService moviesService,
                [FromRoute] string genre,
                CancellationToken token) =>
            {
                var movies = await moviesService.GetMoviesByGenre(genre);

                if (!movies.Any())
                    return TypedResults.NotFound($"No movies found with genre {genre}");

                return TypedResults.Ok(movies);
            })
            .WithSummary("Get all movies by genre")
            .Produces<IList<Movie>>();

        return group;
    }
}