using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.ActorModels;
using MovieApp.Core.Exceptions;
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
    public async Task AddActorAsync(ActorRequest actor, CancellationToken token)
    {
        if (actor == null)
            throw new ArgumentNullException(nameof(actor));

        var result = await _repository.AddAsync(actor.Adapt<Actor>(), token);

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
    }

    public async Task DeleteActorAsync(int id, CancellationToken token)
    {
        var actor = await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);

        if (actor == null)
            throw new NullReferenceException(nameof(actor));

        var result = await _repository.DeleteAsync(actor, token);

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
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

    public async Task UpdateActorAsync(ActorUpdateRequest actor)
    {
        if (actor == null)
            throw new NullReferenceException();

        var result = await _repository.UpdateAsync(actor.Adapt<Actor>());

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
    }
}
