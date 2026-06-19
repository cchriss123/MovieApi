namespace MovieApi.Dto;

public class MovieDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int Year { get; set; }

    public string Duration { get; set; } = string.Empty;

    public MovieDetailDto? MovieDetails { get; set; }

    public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();

    public ICollection<ActorDto> Actors { get; set; } = new List<ActorDto>();
}