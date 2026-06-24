using Microsoft.EntityFrameworkCore;
using MovieApi.Controllers;
using MovieApi.Data;
using MovieApi.Models;

namespace MovieApi.Tests.Controllers;

public class MoviesControllerTests
{
    private static MovieApiContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<MovieApiContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new MovieApiContext(options);
    }
    
    [Fact]
    public async Task GetMovie_ReturnsMovie_WhenMovieExists()
    {
        // Arrange
        await using var context = CreateContext();

        var movie = new Movie
        {
            Id = 1,
            Title = "Inception",
            Genre = "Sci-Fi",
            Duration = "148"
        };

        context.Movie.Add(movie);
        await context.SaveChangesAsync();

        var controller = new MoviesController(context);

        // Act
        var result = await controller.GetMovie(1);

        // Assert
        Assert.NotNull(result.Value);
        Assert.Equal("Inception", result.Value.Title);
    }
    
    [Fact]
    public async Task DeleteMovie_ReturnsNoContent_WhenMovieExists()
    {
        // Arrange
        await using var context = CreateContext();

        var movie = new Movie
        {
            Id = 1,
            Title = "Inception",
            Genre = "Sci-Fi",
            Duration = "148"
        };

        context.Movie.Add(movie);
        await context.SaveChangesAsync();

        var controller = new MoviesController(context);

        // Act
        var result = await controller.DeleteMovie(1);

        // Assert
        Assert.IsType<Microsoft.AspNetCore.Mvc.NoContentResult>(result);
    }
    
    [Fact]
    public async Task GetMovie_ReturnsNotFound_WhenMovieDoesNotExist()
    {
        // Arrange
        await using var context = CreateContext();
        var controller = new MoviesController(context);

        // Act
        var result = await controller.GetMovie(999);

        // Assert
        Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result.Result);
    }
}