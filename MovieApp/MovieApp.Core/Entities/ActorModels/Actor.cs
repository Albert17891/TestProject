using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Entities.ActorModels;
public class Actor
{
    public int Id { get; set; } 
    public int MovieId { get; set; }
    public string Name { get; set; }
    public DateTime BirthName { get; set; }

    ////////////////////////////////////////////
    public Movie Movies { get; set; }    
}
