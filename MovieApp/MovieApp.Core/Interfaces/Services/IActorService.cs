using MovieApp.Core.Entities.ActorModels;

namespace MovieApp.Core.Interfaces.Services;

public interface IActorService
{
    Task<ActorServiceModel?> GetActorByIdAsync(int id, CancellationToken token);
    Task<IList<ActorServiceModel>> GetAllActorAsync(CancellationToken token);
    Task<bool> AddActorAsync(ActorRequest actor, CancellationToken token);
    Task<bool> UpdateActorAsync(ActorUpdateRequest actor);
    Task<bool> DeleteActorAsync(int id, CancellationToken token);
}
