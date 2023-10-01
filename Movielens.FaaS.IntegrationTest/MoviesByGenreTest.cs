using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Movielens.Contracts.Models;
using Movielens.FaaS.Functions;
using Movielens.FaaS.IntegrationTest.Setup;

namespace Movielens.FaaS.IntegrationTest;

[Collection(IntegrationTestsCollection.Name)]
public class MoviesByGenreTest : IClassFixture<TestStartup>
{
    private readonly MoviesByGenre? _sut;

    public MoviesByGenreTest(TestsInitializer testsInitializer)
    {
        _sut = testsInitializer.ServiceProvider.GetService<MoviesByGenre>();
    }

    [Fact]
    public async Task Get_ShouldGetAllMoviesByGenre_WhenCalledWithGenre()
    {
        // Arrange
        const string genre = "Comedy";

        // Act
        var result = await _sut!.RunAsync(null, genre);
        var actual = (result as OkObjectResult)?.Value as IList<Movie>;

        // Assert
        actual.Should().HaveCount(1200);
    }
}