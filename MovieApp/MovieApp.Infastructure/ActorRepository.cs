using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.ActorModels;
using MovieApp.Core.Interfaces;
using MovieApp.Infastructure.Data;

namespace MovieApp.Infastructure;

public class ActorRepository : BaseRepository<Actor>, IActorRepository
{
    private readonly AppDbContext _context;
    public ActorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<Actor>> GetAllAsync(CancellationToken token)
    {
        return await _context.Actors.ToListAsync(token);    
    }

    public async Task<Actor> GetByIdAsync(int id, CancellationToken token)
    {
        return await _context.Actors.FirstOrDefaultAsync(x => x.Id == id, token);
    }
}
