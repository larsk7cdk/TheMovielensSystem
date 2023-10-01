using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Movielens.Contracts.Models;
using Movielens.FaaS.Functions;
using Movielens.FaaS.IntegrationTest.Setup;

namespace Movielens.FaaS.IntegrationTest;

[Collection(IntegrationTestsCollection.Name)]
public class MoviesAllTest : IClassFixture<TestStartup>
{
    private readonly MoviesAll? _sut;

    public MoviesAllTest(TestsInitializer testsInitializer)
    {
        _sut = testsInitializer.ServiceProvider.GetService<MoviesAll>();
    }

    [Fact]
    public async Task Get_ShouldGetAllMovies_WhenCalled()
    {
        // Arrange
        const string genre = "Comedy";

        // Act
        var result = await _sut!.RunAsync(null);
        var actual = (result as OkObjectResult)?.Value as IList<Movie>;

        // Assert
        actual.Should().HaveCount(3883);
    }
}