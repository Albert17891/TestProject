using MovieApp.Core.Entities.GenreModels;

namespace MovieApp.Core.Interfaces.Services;

public interface IGenreService
{
    Task<GenreServiceModel?> GetGenreByIdAsync(int id, CancellationToken token);
    Task<IList<GenreServiceModel>> GetAllGenreAsync(CancellationToken token);
    Task<bool> AddGenreAsync(GenreRequest genreRequest, CancellationToken token);
    Task<bool> UpdateGenreAsync(GenreUpdateRequest genre);
    Task<bool> DeleteGenreAsync(int id, CancellationToken token);
}
