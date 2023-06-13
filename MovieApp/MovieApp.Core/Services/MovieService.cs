using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.MovieModels;
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
    public async Task<bool> AddMovieAsync(MovieRequest movie, CancellationToken token)
    {
        if (movie == null)
            throw new ArgumentNullException(nameof(movie));

       return await _repository.AddAsync(movie.Adapt<Movie>(), token);
    }

    public async Task<bool> DeleteMovieAsync(int id, CancellationToken token)
    {
        var movie = await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);

        if (movie == null)
            throw new NullReferenceException();

       return await _repository.DeleteAsync(movie, token);
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

    public async Task<bool> UpdateMovieAsync(MovieUpdateRequest movie)
    {
        if (movie == null)
            throw new NullReferenceException();

        return await _repository.UpdateAsync(movie.Adapt<Movie>());
    }
}
