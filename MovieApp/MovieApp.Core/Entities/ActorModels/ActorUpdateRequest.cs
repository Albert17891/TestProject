namespace MovieApp.Core.Entities.ActorModels;

public class ActorUpdateRequest 
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string Name { get; set; }
    public DateTime BirthName { get; set; }
}
