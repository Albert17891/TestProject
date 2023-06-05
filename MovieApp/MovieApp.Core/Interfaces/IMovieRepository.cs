using MovieApp.Core.Entities;

namespace MovieApp.Core.Interfaces;

public interface IMovieRepository
{
   Task<Movie?> GetByIdAsync(int id);
   Task<IList<Movie>> GetAllAsync();    
   Task AddAsync(Movie movie);
   Task UpdateAsync(Movie movie);
   Task DeleteAsync(int Id);
}
