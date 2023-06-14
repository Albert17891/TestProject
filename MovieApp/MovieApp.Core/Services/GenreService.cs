using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.GenreModels;
using MovieApp.Core.Exceptions;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Interfaces.Services;

namespace MovieApp.Core.Services;

public class GenreService : IGenreService
{
    private readonly IBaseRepository<Genre> _repository;

    public GenreService(IBaseRepository<Genre> repository)
    {
        _repository = repository;
    }
    public async Task AddGenreAsync(GenreRequest genreRequest, CancellationToken token)
    {
        if (genreRequest == null)
            throw new ArgumentNullException(nameof(genreRequest));

        var result = await _repository.AddAsync(genreRequest.Adapt<Genre>(), token);

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
    }

    public async Task DeleteGenreAsync(int id, CancellationToken token)
    {
        var genre = await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);

        if (genre == null)
            throw new NullReferenceException(nameof(genre));

        var result = await _repository.DeleteAsync(genre, token);

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
    }

    public async Task<IList<GenreServiceModel>> GetAllGenreAsync(CancellationToken token)
    {
        var genres = await _repository.GetAllAsync(token);

        return genres.Adapt<IList<GenreServiceModel>>();
    }

    public async Task<GenreServiceModel?> GetGenreByIdAsync(int id, CancellationToken token)
    {
        var genre = await _repository.Table.FirstOrDefaultAsync(x => x.Id == id);

        return genre?.Adapt<GenreServiceModel>();
    }

    public async Task UpdateGenreAsync(GenreUpdateRequest genre)
    {
        if (genre == null)
            throw new NullReferenceException();

        var result = await _repository.UpdateAsync(genre.Adapt<Genre>());

        if (!result)
            throw new NotAffectedExceptions(nameof(result));
    }
}
