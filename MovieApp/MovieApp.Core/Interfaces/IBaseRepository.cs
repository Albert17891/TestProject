namespace MovieApp.Core.Interfaces;

public interface IBaseRepository<T>
{
    IQueryable<T> Table { get; }   
    Task<IList<T>> GetAllAsync(CancellationToken token);
    Task<bool> AddAsync(T movie, CancellationToken token);
    Task<bool> UpdateAsync(T movie);
    Task<bool> DeleteAsync(T entity, CancellationToken token);
}
