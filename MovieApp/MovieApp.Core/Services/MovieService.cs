using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.MovieModels;
using MovieApp.Core.Exceptions;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Core.Services;

public class MovieService : IMovieService
{
    private readonly IBaseRepository<Movie> _repository;

    public MovieService(IBaseRepository<Movie> repository)
    {
        _repository = repository;
    }
    public async Task AddMovieAsync(MovieRequest movie, CancellationToken token)
    {
        if (movie == null)
            throw new ArgumentNullException(nameof(movie));

        var result = await _repository.AddAsync(movie.Adapt<Movie>(), token);

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
    }

    public async Task DeleteMovieAsync(int id, CancellationToken token)
    {
        var movie = await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);

        if (movie == null)
            throw new NullReferenceException(nameof(movie));

        var result = await _repository.DeleteAsync(movie, token);

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
    }

    public async Task<IList<MovieServiceModel>> GetAllMovieAsync(CancellationToken token)
    {
        var movies = await _repository.GetAllAsync(token);

        return movies.Adapt<IList<MovieServiceModel>>();
    }

    public async Task<MovieServiceModel?> GetMovieByIdAsync(int id, CancellationToken token)
    {
        var movie = await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);

        return movie?.Adapt<MovieServiceModel>();
    }

    public async Task UpdateMovieAsync(MovieUpdateRequest movie)
    {
        if (movie == null)
            throw new NullReferenceException();

        var result = await _repository.UpdateAsync(movie.Adapt<Movie>());

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
    }
}
