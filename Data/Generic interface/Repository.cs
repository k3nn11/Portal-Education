using Data.DbInitializer;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Generic_interface
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly PortalContext _portalContext;
        private readonly DbSet<T> _dbSet;
        public Repository(PortalContext portalContext) 
        {
            _portalContext = portalContext
                ?? throw new ArgumentNullException(nameof(portalContext));
            _dbSet = portalContext.Set<T>();
        }
        public async Task Create(T entity)
        {
            if (entity is not null)
            {
                await _portalContext.AddAsync(entity);
                await _portalContext.SaveChangesAsync();
            }
        }

        public async Task<T> GetByID(int? Id)
        {
            T? item = default;
            await Task.Run(() =>
            {
                item = _dbSet.FirstOrDefault(x => x.Id == Id);
                if (item == null)
                {
                    return;
                }
                //return item;
            }).ConfigureAwait(false);
            return item;
        }

        public async Task<List<T>?> GetAll()
        {
            return !await _dbSet.AnyAsync() ? null : await _dbSet.ToListAsync();
        }

        public async Task Update(T entity)
        {
            if (entity is not null)
            {
                var data = _dbSet.FirstOrDefault(x => x.Id == entity.Id);
                if (data != null)
                {
                    await Task.Run(() =>
                    {
                        _dbSet.Update(data);
                        _portalContext.SaveChanges();
                    });
                }
            }
          
        }

        public async Task Delete(int Id)
        {
            if (Id == 0)
            {
                return;
            }
            var data = _dbSet.FirstOrDefault(x => x.Id == Id);
            if (data != null)
            {
                await Task.Run(() =>
                {
                    _dbSet.Remove(data);
                    _portalContext.SaveChanges();
                });
            }
        }
    }
}
