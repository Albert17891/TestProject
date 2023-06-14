using MovieApp.Core.Interfaces;
using MovieApp.Infastructure.Data;

namespace MovieApp.Infastructure;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(T entity, CancellationToken token)
    {
        await _context.AddAsync(entity, token);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(T entity, CancellationToken token)
    {

        _context.Remove(entity);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _context.Update(entity);

        return await _context.SaveChangesAsync() > 0;
    }
}