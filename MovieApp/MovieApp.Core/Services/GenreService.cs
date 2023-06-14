using Mapster;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.GenreModels;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Core.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _repository;

    public GenreService(IGenreRepository repository)
    {
        _repository = repository;
    }
    public async Task<Envelope<GenreServiceModel>> AddGenreAsync(GenreRequest genreRequest, CancellationToken token)
    {
        if (genreRequest == null)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Data is null",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var result = await _repository.AddAsync(genreRequest.Adapt<Genre>(), token);

        if (!result)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Not added Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<GenreServiceModel>
        {
            Message = "Success",
            Value = genreRequest.Adapt<GenreServiceModel>(),
        };
    }

    public async Task<Envelope<GenreServiceModel>> DeleteGenreAsync(int id, CancellationToken token)
    {
        if (id <= 0)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Id must be not less or equal zero",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var genre = await _repository.GetByIdAsync(id, token);

        if (genre == null)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Data not Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound,
            };
        }

        var result = await _repository.DeleteAsync(genre, token);

        if (!result)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Not deleted Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<GenreServiceModel>
        {
            Message = "Success",
            Value = genre.Adapt<GenreServiceModel>(),
        };
    }

    public async Task<Envelope<IList<GenreServiceModel>>> GetAllGenreAsync(CancellationToken token)
    {
        var genres = await _repository.GetAllAsync(token);

        if (genres == null)
        {
            return new Envelope<IList<GenreServiceModel>>
            {
                Message = "Not Data Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound
            };
        }

        return new Envelope<IList<GenreServiceModel>>
        {
            Value = genres.Adapt<IList<GenreServiceModel>>(),
            Message = "Success"
        };
    }

    public async Task<Envelope<GenreServiceModel>> GetGenreByIdAsync(int id, CancellationToken token)
    {
        if (id <= 0)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Id must be not less or equal zero",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var genre = await _repository.GetByIdAsync(id, token);

        if (genre == null)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Genre Not Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound,
            };
        }

        return new Envelope<GenreServiceModel>
        {
            Value = genre?.Adapt<GenreServiceModel>(),
            Message = "Success"
        };
    }

    public async Task<Envelope<GenreServiceModel>> UpdateGenreAsync(GenreUpdateRequest genre)
    {
        if (genre == null)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Data is null",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var result = await _repository.UpdateAsync(genre.Adapt<Genre>());

        if (!result)
        {
            return new Envelope<GenreServiceModel>
            {
                Message = "Not updated Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<GenreServiceModel>
        {
            Message = "Success",
            Value = genre.Adapt<GenreServiceModel>(),
        };
    }
}
