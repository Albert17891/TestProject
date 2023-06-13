using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Interfaces.Services;
public interface IMovieService
{
    Task<MovieServiceModel?> GetMovieByIdAsync(int id, CancellationToken token);
    Task<IList<MovieServiceModel>> GetAllMovieAsync(CancellationToken token);
    Task<bool> AddMovieAsync(MovieRequest movie, CancellationToken token);
    Task<bool> UpdateMovieAsync(MovieUpdateRequest movie);
    Task<bool> DeleteMovieAsync(int id, CancellationToken token);
}
