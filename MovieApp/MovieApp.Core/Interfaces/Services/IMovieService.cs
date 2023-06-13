using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Interfaces.Services;
public interface IMovieService
{
    Task<MovieServiceModel?> GetMovieByIdAsync(int id, CancellationToken token);
    Task<IList<MovieServiceModel>> GetAllMovieAsync(CancellationToken token);
    Task AddMovieAsync(MovieRequest movie, CancellationToken token);
    Task UpdateMovieAsync(MovieUpdateRequest movie);
    Task DeleteMovieAsync(int Id, CancellationToken token);
}
