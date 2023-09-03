using Movielens.Contracts.Entities;
using Movielens.Contracts.Models;
using Newtonsoft.Json;

namespace Movielens.Data.DataAccess;

public class MoviesDataAccess : IMoviesDataAccess
{
    private readonly List<Movie> _movies = new();

    public async Task<IList<Movie>> FetchAllMovies()
    {
        if (_movies.Any())
            return _movies;

        await Task.Run(() =>
        {
            var movieEntities = JsonConvert.DeserializeObject<List<MovieEntity>>(File.ReadAllText(@"Fakes\movies.json"))!;
            var movies = movieEntities.Select(s =>
            {
                var title = s.Title.Substring(0, s.Title.Length - 7);
                var year = int.Parse(s.Title.Substring(s.Title.Length - 5, 4));
                return new Movie(s.Id, title, year, s.Genres);
            });

            _movies.AddRange(movies);
        });

        return _movies;
    }
}