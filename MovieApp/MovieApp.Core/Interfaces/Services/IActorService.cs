using MovieApp.Core.Entities;
using MovieApp.Core.Entities.ActorModels;

namespace MovieApp.Core.Interfaces.Services;

public interface IActorService
{
    Task<Envelope<ActorServiceModel>> GetActorByIdAsync(int id, CancellationToken token);
    Task<Envelope<IList<ActorServiceModel>>> GetAllActorAsync(CancellationToken token);
    Task<Envelope<ActorServiceModel>> AddActorAsync(ActorRequest actor, CancellationToken token);
    Task<Envelope<ActorServiceModel>> UpdateActorAsync(ActorUpdateRequest actor);
    Task<Envelope<ActorServiceModel>> DeleteActorAsync(int id, CancellationToken token);
}