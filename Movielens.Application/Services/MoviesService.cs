using Movielens.Contracts.Models;
using Movielens.Data.DataAccess;

namespace Movielens.Application.Services;

public class MoviesService : IMoviesService
{
    private readonly IMoviesDataAccess _moviesDataAccess;

    public MoviesService(IMoviesDataAccess moviesDataAccess)
    {
        _moviesDataAccess = moviesDataAccess;
    }

    public async Task<IList<Movie>> GetMovies()
    {
        var moviesData = await _moviesDataAccess.FetchAllMovies();

        return await Task.FromResult(moviesData);
    }

    public async Task<IList<Movie>> GetMoviesByTitle(string title)
    {
        var moviesData = await _moviesDataAccess.FetchAllMovies();

        var movies = moviesData.Where(s => s.Title.ToLower().Contains(title.ToLower())).ToList();
        if (!movies.Any())
            return await Task.FromResult(new List<Movie>());

        return await Task.FromResult(movies);
    }

    public async Task<IList<Movie>> GetMoviesByGenre(string genre)
    {
        var moviesData = await _moviesDataAccess.FetchAllMovies();

        var movies = moviesData.Where(s => s.Genres.Contains(genre)).ToList();
        if (!movies.Any())
            return await Task.FromResult(new List<Movie>());

        return await Task.FromResult(movies);
    }
}