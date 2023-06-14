using Mapster;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.ActorModels;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Core.Services;

public class ActorService : IActorService
{
    private readonly IActorRepository _repository;

    public ActorService(IActorRepository repository)
    {
        _repository = repository;
    }
    public async Task<Envelope<ActorServiceModel>> AddActorAsync(ActorRequest actor, CancellationToken token)
    {
        if (actor == null)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Data is null",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var result = await _repository.AddAsync(actor.Adapt<Actor>(), token);

        if (!result)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Not added Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<ActorServiceModel>
        {
            Message = "Success",
            Value = new ActorServiceModel()
        };
    }

    public async Task<Envelope<ActorServiceModel>> DeleteActorAsync(int id, CancellationToken token)
    {
        if (id <= 0)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Id must be not less or equal zero",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var movie = await _repository.GetByIdAsync(id, token);

        if (movie == null)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Data not Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound,
            };
        }

        var result = await _repository.DeleteAsync(movie, token);

        if (!result)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Not deleted Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<ActorServiceModel>
        {
            Message = "Success",
            Value = new ActorServiceModel()
        };
    }

    public async Task<Envelope<IList<ActorServiceModel>>> GetAllActorAsync(CancellationToken token)
    {
        var actors = await _repository.GetAllAsync(token);

        if (actors == null)
        {
            return new Envelope<IList<ActorServiceModel>>
            {
                Message = "Not Data Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound
            };
        }

        return new Envelope<IList<ActorServiceModel>>
        {
            Value = actors.Adapt<IList<ActorServiceModel>>(),
            Message = "Success"
        };
    }

    public async Task<Envelope<ActorServiceModel>> GetActorByIdAsync(int id, CancellationToken token)
    {
        if (id <= 0)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Id must be not less or equal zero",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var actor = await _repository.GetByIdAsync(id, token);

        if (actor == null)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Actor Not Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound,
            };
        }

        return new Envelope<ActorServiceModel>
        {
            Value = actor.Adapt<ActorServiceModel>(),
            Message = "Success"
        };
    }

    public async Task<Envelope<ActorServiceModel>> UpdateActorAsync(ActorUpdateRequest actor)
    {
        if (actor == null)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Data is null",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var result = await _repository.UpdateAsync(actor.Adapt<Actor>());

        if (!result)
        {
            return new Envelope<ActorServiceModel>
            {
                Message = "Not updated Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<ActorServiceModel>
        {
            Message = "Success",
            Value = new ActorServiceModel()
        };
    }
}
