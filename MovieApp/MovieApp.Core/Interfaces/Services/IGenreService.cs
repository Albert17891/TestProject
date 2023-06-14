using MovieApp.Core.Entities;
using MovieApp.Core.Entities.GenreModels;

namespace MovieApp.Core.Interfaces.Services;

public interface IGenreService
{
    Task<Envelope<GenreServiceModel>> GetGenreByIdAsync(int id, CancellationToken token);
    Task<Envelope<IList<GenreServiceModel>>> GetAllGenreAsync(CancellationToken token);
    Task<Envelope<GenreServiceModel>> AddGenreAsync(GenreRequest genreRequest, CancellationToken token);
    Task<Envelope<GenreServiceModel>> UpdateGenreAsync(GenreUpdateRequest genre);
    Task<Envelope<GenreServiceModel>> DeleteGenreAsync(int id, CancellationToken token);
}