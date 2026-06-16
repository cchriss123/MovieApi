namespace MovieApi.Models;

public class Review
{
    public int Id { get; set; }
    public required string ReviewerName { get; set; }
    public string? Comment { get; set; }
    public required Rating Rating { get; set; }
    
}


public enum Rating
 {
     One = 1,
     Two = 2,
     Three = 3,
     Four = 4,
     Five = 5
 }