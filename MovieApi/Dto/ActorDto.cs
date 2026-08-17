using MovieApi.Models;

namespace MovieApi.Dto;

public class ActorDto(Actor actor)
{
    public int Id { get; set; } = actor.Id;
    public string Name { get; set; } = actor.Name;
    public int BirthYear { get; set; } = actor.BirthYear;
}