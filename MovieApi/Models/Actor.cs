using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Actor
{
    public int Id { get; set; }
    [StringLength(100)]
    public required string Name { get; set; }
    public int BirthYear { get; set; }
    public ICollection<Movie> Movies { get; set; }  = new List<Movie>();
}