namespace MovieApp.Core.Entities.MovieModels;

public class MovieUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public DateTime CreatedDate { get; set; }
}
