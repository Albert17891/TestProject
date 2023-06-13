using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.ActorModels;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Core.Services;

public class ActorService : IActorService
{
    private readonly IBaseRepository<Actor> _repository;

    public ActorService(IBaseRepository<Actor> repository)
    {
        _repository = repository;
    }
    public async Task<bool> AddActorAsync(ActorRequest actor, CancellationToken token)
    {
        if (actor == null)
            throw new ArgumentNullException(nameof(actor));

        return await _repository.AddAsync(actor.Adapt<Actor>(), token);
    }

    public async Task<bool> DeleteActorAsync(int id, CancellationToken token)
    {
        var actor = await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);

        if (actor == null)
            throw new NullReferenceException();

        return await _repository.DeleteAsync(actor, token);
    }

    public async Task<IList<ActorServiceModel>> GetAllActorAsync(CancellationToken token)
    {
        var actors = await _repository.GetAllAsync(token);

        return actors.Adapt<IList<ActorServiceModel>>();
    }

    public async Task<ActorServiceModel?> GetActorByIdAsync(int id, CancellationToken token)
    {
        var actor = await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);

        return actor?.Adapt<ActorServiceModel>();
    }

    public async Task<bool> UpdateActorAsync(ActorUpdateRequest actor)
    {
        if (actor == null)
            throw new NullReferenceException();

        return await _repository.UpdateAsync(actor.Adapt<Actor>());
    }
}
