using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.GenreModels;
using MovieApp.Core.Interfaces;
using MovieApp.Infastructure.Data;

namespace MovieApp.Infastructure;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    private readonly AppDbContext _context;
    public GenreRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<Genre>> GetAllAsync(CancellationToken token)
    {
        return await _context.Genres.ToListAsync(token);
    }

    public Task<Genre> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Genre> GetByIdAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}