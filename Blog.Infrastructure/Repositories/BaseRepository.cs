using Blog.Domain.Models;
using Blog.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly BlogDBContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(BlogDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) return null;

            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) return;

            var entity = await GetByIdAsync(id);
            if (entity == null) throw new ArgumentException($"Entity with id: {id} couldn't be found.");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
