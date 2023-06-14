using MovieApp.Core.Entities;
using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Interfaces.Services;
public interface IMovieService
{
    Task<Envelope<MovieServiceModel>> GetMovieByIdAsync(int id, CancellationToken token);
    Task<Envelope<IList<MovieServiceModel>>> GetAllMovieAsync(CancellationToken token);
    Task<Envelope<MovieServiceModel>> AddMovieAsync(MovieRequest movie, CancellationToken token);
    Task<Envelope<MovieServiceModel>> UpdateMovieAsync(MovieUpdateRequest movie);
    Task<Envelope<MovieServiceModel>> DeleteMovieAsync(int id, CancellationToken token);
}