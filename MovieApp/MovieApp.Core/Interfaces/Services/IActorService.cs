using MovieApp.Core.Entities.ActorModels;

namespace MovieApp.Core.Interfaces.Services;

public interface IActorService
{
    Task<Envelope<ActorServiceModel>> GetActorByIdAsync(int id, CancellationToken token);
    Task<IList<ActorServiceModel>> GetAllActorAsync(CancellationToken token);
    Task AddActorAsync(ActorRequest actor, CancellationToken token);
    Task UpdateActorAsync(ActorUpdateRequest actor);
    Task DeleteActorAsync(int id, CancellationToken token);
}
