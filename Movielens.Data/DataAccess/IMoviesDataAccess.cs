using Movielens.Contracts.Models;

namespace Movielens.Data.DataAccess;

public interface IMoviesDataAccess
{
    Task<IList<Movie>> FetchAllMovies();
}