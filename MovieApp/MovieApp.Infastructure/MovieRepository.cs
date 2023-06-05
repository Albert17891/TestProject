using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using MovieApp.Infastructure.Data;

namespace MovieApp.Infastructure;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Movie movie,CancellationToken token)
    {
        await _context.AddAsync(movie,token);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id,CancellationToken token)
    {
        var movie = await GetByIdAsync(Id,token);

        if(movie == null)
        {
            throw new NullReferenceException(nameof(movie));
        }

        _context.Remove(movie);

        await _context.SaveChangesAsync();
    }

    public async Task<IList<Movie>> GetAllAsync(CancellationToken token)
    {
        return await _context.Movies.ToListAsync(token);
    }

    public async Task<Movie?> GetByIdAsync(int id,CancellationToken token)
    {
        return await _context.Movies.FirstOrDefaultAsync(x => x.Id == id,token);
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Update(movie);

        await _context.SaveChangesAsync();
    }
}
