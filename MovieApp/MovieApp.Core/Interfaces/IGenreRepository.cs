using MovieApp.Core.Entities.GenreModels;

namespace MovieApp.Core.Interfaces;

public interface IGenreRepository:IBaseRepository<Genre>
{
    Task<Genre> GetByIdAsync(int id,CancellationToken token);   
    Task<IList<Genre>> GetAllAsync(CancellationToken token);
}
