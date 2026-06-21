using MovieApi.Dto;
using MovieApi.Models;

namespace MovieApi.Mapper;

public static class MovieMapper
{

    public static List< MovieDto> MapMovies(List<Movie> movies)
    {
        return movies.Select(movie => new MovieDto(movie)).ToList();
    }

    public static Movie MapCreate(MovieCreateDto createMovieDto)
    {
        return new Movie
        {
            Title = createMovieDto.Title,
            Genre = createMovieDto.Genre,
            Year = createMovieDto.Year,
            Duration = createMovieDto.Duration
        };
    }
    
    public static void MapUpdate(Movie movie, MovieUpdateDto updateMovieDto)
    {
        movie.Title = updateMovieDto.Title;
        movie.Genre = updateMovieDto.Genre;
        movie.Year = updateMovieDto.Year;
        movie.Duration = updateMovieDto.Duration;
    }
}

