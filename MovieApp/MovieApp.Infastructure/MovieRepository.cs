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

    public async Task AddAsync(Movie movie)
    {
        await _context.AddAsync(movie);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id)
    {
        var movie = await GetByIdAsync(Id);

        _context.Remove(movie);

        await _context.SaveChangesAsync();
    }

    public async Task<IList<Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Update(movie);

        await _context.SaveChangesAsync();
    }
}
