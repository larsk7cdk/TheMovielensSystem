using System.Net.Http.Json;
using FluentAssertions;
using Movielens.Contracts.Models;

namespace Movielens.API.IntegrationTest;

public class MoviesTest
{
    [Fact]
    public async Task Get_ShouldGetAllMovies_WhenCalled()
    {
        // Arrange
        await using var api = new MovielensApiFactory();
        var client = api.CreateClient();

        // Act 
        var actual = await client.GetFromJsonAsync<List<Movie>>("/movies/all");

        // Assert
        actual.Should().HaveCount(3883);
    }

    [Fact]
    public async Task Get_ShouldGetMovieByTitle_WhenCalledWithTitle()
    {
        // Arrange
        await using var api = new MovielensApiFactory();
        var client = api.CreateClient();

        // Act 
        var actual = await client.GetFromJsonAsync<List<Movie>>("/movies/title/forrest gump");

        // Assert
        actual.Should().HaveCount(1);
    }

    [Fact]
    public async Task Get_ShouldGetAllMoviesByGenre_WhenCalledWithGenre()
    {
        // Arrange
        await using var api = new MovielensApiFactory();
        var client = api.CreateClient();

        // Act 
        var actual = await client.GetFromJsonAsync<List<Movie>>("/movies/genre/Comedy");

        // Assert
        actual.Should().HaveCount(1200);
    }
}