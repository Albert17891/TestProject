using MovieApp.Core.Entities.MovieModels;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Core.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository)
    {
        _repository=repository;
    }
    public Task AddMovieAsync(MovieRequest movie, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMovieAsync(int Id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IList<MovieServiceModel>> GetAllMovieAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<MovieServiceModel?> GetMovieByIdAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMovieAsync(MovieUpdateRequest movie)
    {
        throw new NotImplementedException();
    }
}
