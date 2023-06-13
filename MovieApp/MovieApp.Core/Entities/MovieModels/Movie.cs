using MovieApp.Core.Entities.ActorModels;
using MovieApp.Core.Entities.GenreModels;

namespace MovieApp.Core.Entities.MovieModels;

public class Movie
{
    public int Id { get; set; }   
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }

    public List<Actor> Actors { get; set; } 
    public List<MovieGenre> MovieGenres { get; set; }   
}
