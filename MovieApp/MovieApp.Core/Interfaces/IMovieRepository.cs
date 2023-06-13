using MovieApp.Core.Entities.MovieModels;

namespace MovieApp.Core.Interfaces;

public interface IMovieRepository
{
   Task<Movie?> GetByIdAsync(int id,CancellationToken token);
   Task<IList<Movie>> GetAllAsync(CancellationToken token);    
   Task AddAsync(Movie movie,CancellationToken token);
   Task UpdateAsync(Movie movie);
   Task DeleteAsync(int Id,CancellationToken token);
}
