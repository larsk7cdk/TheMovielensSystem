using Movielens.Contracts.Models;

namespace Movielens.Application.Services;

public interface IMoviesService
{
    Task<IList<Movie>> GetMovies();
    Task<IList<Movie>> GetMoviesByTitle(string title);
    Task<IList<Movie>> GetMoviesByGenre(string genre);
}