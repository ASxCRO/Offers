namespace Offers.API.Repositories
{
    public interface IRepository<T, TId> where T : class
    {
        Task<T> GetByIdAsync(TId id);
        Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<TId> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(TId id);
        Task<int> TotalCountAsync();
    }
}
