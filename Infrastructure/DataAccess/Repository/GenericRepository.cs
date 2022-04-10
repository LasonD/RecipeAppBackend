using Application.Exceptions;
using Application.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : AbstractEntity
    {
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query(bool asTracking = true) =>
            asTracking ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

        public Task<T?> GetByIdAsync(int id) => _context.FindAsync<T>(id).AsTask();

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.AddAsync(entity).AsTask();

            return result.Entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id) ?? throw new EntityNotFoundException<T>(id);

            return _context.Set<T>().Remove(entity).Entity;
        }

        public Task<T> UpdateAsync(int id, T entity)
        {
            entity.Id = id;

            return Task.FromResult(_context.Set<T>().Update(entity).Entity);
        }

        public Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
