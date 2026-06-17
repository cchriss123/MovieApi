using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Data.Seed;

public class DbSeeder
{
    public static async Task SeedAsync(MovieApiContext context)
    {
        if (await context.Movie.AnyAsync() || await context.Actor.AnyAsync())
            return;
        
        var alPacino = new Actor { Name = "Al Pacino", BirthYear = 1940 };
        var marlonBrando = new Actor { Name = "Marlon Brando", BirthYear = 1924 };
        var morganFreeman = new Actor { Name = "Morgan Freeman", BirthYear = 1937 };
        var timRobbins = new Actor { Name = "Tim Robbins", BirthYear = 1958 };
        var johnTravolta = new Actor { Name = "John Travolta", BirthYear = 1954 };
        var samuelJackson = new Actor { Name = "Samuel L. Jackson", BirthYear = 1948 };

        var movies = new List<Movie>
        {
            new()
            {
                Title = "The Godfather",
                Genre = "Crime",
                Duration = "2h 55m",
                Year = 1972,
                MovieDetails = new MovieDetails
                {
                    Synopsis = "The aging patriarch of a crime family transfers control of his empire to his reluctant son.",
                    Language = "English",
                    Budget = "$6,000,000"
                },
                Actors = new List<Actor> { marlonBrando, alPacino },
                Reviews = new List<Review>
                {
                    new() { ReviewerName = "Chris", Comment = "A slow but powerful crime classic.", Rating = Rating.Five }
                }
            },
            new()
            {
                Title = "The Shawshank Redemption",
                Genre = "Drama",
                Duration = "2h 22m",
                Year = 1994,
                MovieDetails = new MovieDetails
                {
                    Synopsis = "Two imprisoned men form a lasting friendship while seeking hope and redemption.",
                    Language = "English",
                    Budget = "$25,000,000"
                },
                Actors = new List<Actor> { timRobbins, morganFreeman },
                Reviews = new List<Review>
                {
                    new() { ReviewerName = "Alex", Comment = "Very emotional and memorable.", Rating = Rating.Five }
                }
            },
            new()
            {
                Title = "Pulp Fiction",
                Genre = "Crime",
                Duration = "2h 34m",
                Year = 1994,
                MovieDetails = new MovieDetails
                {
                    Synopsis = "Several connected stories follow criminals, boxers and gangsters in Los Angeles.",
                    Language = "English",
                    Budget = "$8,000,000"
                },
                Actors = new List<Actor> { johnTravolta, samuelJackson },
                Reviews = new List<Review>
                {
                    new() { ReviewerName = "Sam", Comment = "Stylish, weird and quotable.", Rating = Rating.Four }
                }
            }
        };
        
        context.Movie.AddRange(movies);
        await context.SaveChangesAsync();
    }
}