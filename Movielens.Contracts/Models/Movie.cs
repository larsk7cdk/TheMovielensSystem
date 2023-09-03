using Swashbuckle.AspNetCore.Annotations;

namespace Movielens.Contracts.Models;

/// <summary>
///     Model information for a movie
/// </summary>
[SwaggerSchema(Title = "Movie", Description = "Information about a movie")]
public class Movie
{
    public Movie(int id, string title, int year, string[] genres)
    {
        Id = id;
        Title = title;
        Year = year;
        Genres = genres;
    }

    [SwaggerSchema("Id of movie")] 
    public int Id { get; init; }

    [SwaggerSchema("Title of movie")] 
    public string Title { get; init; }

    [SwaggerSchema("Release year of movie")]
    public int Year { get; init; }

    [SwaggerSchema("Genres of movie")] 
    public string[] Genres { get; init; }
}