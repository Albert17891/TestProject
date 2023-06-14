using MovieApp.Core.Entities.GenreModels;

namespace MovieApp.Core.Interfaces.Services;

public interface IGenreService
{
    Task<GenreServiceModel?> GetGenreByIdAsync(int id, CancellationToken token);
    Task<IList<GenreServiceModel>> GetAllGenreAsync(CancellationToken token);
    Task AddGenreAsync(GenreRequest genreRequest, CancellationToken token);
    Task UpdateGenreAsync(GenreUpdateRequest genre);
    Task DeleteGenreAsync(int id, CancellationToken token);
}
