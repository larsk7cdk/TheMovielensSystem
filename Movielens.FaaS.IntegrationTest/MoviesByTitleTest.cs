using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Movielens.Contracts.Models;
using Movielens.FaaS.Functions;
using Movielens.FaaS.IntegrationTest.Setup;

namespace Movielens.FaaS.IntegrationTest;

[Collection(IntegrationTestsCollection.Name)]
public class MoviesByTitleTest : IClassFixture<TestStartup>
{
    private readonly MoviesByTitle? _sut;

    public MoviesByTitleTest(TestsInitializer testsInitializer)
    {
        _sut = testsInitializer.ServiceProvider.GetService<MoviesByTitle>();
    }

    [Fact]
    public async Task Get_ShouldGetMovieByTitle_WhenCalledWithTitle()
    {
        // Arrange
        const string title = "Forrest Gump";

        // Act
        var result = await _sut!.RunAsync(null, title);
        var actual = (result as OkObjectResult)?.Value as IList<Movie>;

        // Assert
        actual.Should().HaveCount(1);
    }
}