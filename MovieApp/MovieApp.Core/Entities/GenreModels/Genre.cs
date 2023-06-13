using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Entities.GenreModels;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }    
    public List<MovieGenre> MovieGenres { get; set; }
}
