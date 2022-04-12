namespace Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query(bool asTracking = true);
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<T> UpdateAsync(int id, T entity);
        Task SaveChangesAsync();
    }
}
