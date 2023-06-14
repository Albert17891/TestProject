using Mapster;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.MovieModels;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Core.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }
    public async Task<Envelope<MovieServiceModel>> AddMovieAsync(MovieRequest movie, CancellationToken token)
    {
        if (movie == null)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Data is null",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var result = await _repository.AddAsync(movie.Adapt<Movie>(), token);

        if (!result)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Not added Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<MovieServiceModel>
        {
            Message = "Success",
            Value = movie.Adapt<MovieServiceModel>()
        };
    }

    public async Task<Envelope<MovieServiceModel>> DeleteMovieAsync(int id, CancellationToken token)
    {
        if (id <= 0)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Id must be not less or equal zero",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var movie = await _repository.GetByIdAsync(id, token);

        if (movie == null)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Data not Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound,
            };
        }

        var result = await _repository.DeleteAsync(movie, token);

        if (!result)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Not deleted Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<MovieServiceModel>
        {
            Message = "Success",
            Value= movie.Adapt<MovieServiceModel>()
        };
    }

    public async Task<Envelope<IList<MovieServiceModel>>> GetAllMovieAsync(CancellationToken token)
    {
        var movies = await _repository.GetAllAsync(token);

        if (movies == null)
        {
            return new Envelope<IList<MovieServiceModel>>
            {
                Message = "Not Data Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound
            };
        }

        return new Envelope<IList<MovieServiceModel>>
        {
            Value = movies.Adapt<IList<MovieServiceModel>>(),
            Message = "Success"
        };
    }

    public async Task<Envelope<MovieServiceModel>> GetMovieByIdAsync(int id, CancellationToken token)
    {
        if (id <= 0)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Id must be not less or equal zero",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var movie = await _repository.GetByIdAsync(id, token);

        if (movie == null)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Movie Not Found",
                EnvelopeStatusCode = EnvelopeStatusCode.NotFound,
            };
        }

        return new Envelope<MovieServiceModel>
        {
            Value = movie.Adapt<MovieServiceModel>(),
            Message = "Success"
        };
    }

    public async Task<Envelope<MovieServiceModel>> UpdateMovieAsync(MovieUpdateRequest movie)
    {
        if (movie == null)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Data is null",
                EnvelopeStatusCode = EnvelopeStatusCode.BadRequest,
            };
        }

        var result = await _repository.UpdateAsync(movie.Adapt<Movie>());

        if (!result)
        {
            return new Envelope<MovieServiceModel>
            {
                Message = "Not updated Data",
                EnvelopeStatusCode = EnvelopeStatusCode.InternalServerError,
            };
        }

        return new Envelope<MovieServiceModel>
        {
            Message = "Success",
            Value = movie.Adapt<MovieServiceModel>()
        };
    }
}
