using MovieApp.Core.Entities.ActorModels;

namespace MovieApp.Core.Interfaces;

public interface IActorRepository:IBaseRepository<Actor>
{
    Task<Actor> GetByIdAsync(int id,CancellationToken token);
    Task<IList<Actor>> GetAllAsync(CancellationToken token);
}
