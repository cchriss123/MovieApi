using MovieApi.Dto;
using MovieApi.Models;

namespace MovieApi.Mapper;

public static class MovieMapper
{

    public static List< MovieDto> MapMovies(List<Movie> movies)
    {
        return movies.Select(movie => new MovieDto(movie)).ToList();
    }
    
}