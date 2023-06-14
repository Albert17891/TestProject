using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Interfaces;

public interface IMovieRepository:IBaseRepository<Movie>    
{
    Task<Movie> GetByIdAsync(int id,CancellationToken token); 
    Task<IList<Movie>> GetAllAsync(CancellationToken token);
}
