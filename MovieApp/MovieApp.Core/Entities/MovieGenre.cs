using MovieApp.Core.Entities.GenreModels;
using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Entities;
public class MovieGenre
{
    public int MovieId { get; set; }    
    public int GenreId { get; set;}

    public Movie Movie { get; set; }
    public Genre Genre { get; set; }
}
