using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.MovieModels;
using MovieApp.Core.Interfaces;
using MovieApp.Infastructure.Data;

namespace MovieApp.Infastructure;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    private readonly AppDbContext _context;
    public MovieRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<Movie>> GetAllAsync(CancellationToken token)
    {
        return await _context.Movies.ToListAsync(token);
    }

    public async Task<Movie> GetByIdAsync(int id, CancellationToken token)
    {
        return await _context.Movies.FirstOrDefaultAsync(x => x.Id == id, token);
    }
}
