using Catalog.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DataAccessLayer.EFCore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseDALEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(TEntity entity)
        {
            _context.Remove<TEntity>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> Get(int id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task Post(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Put(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
