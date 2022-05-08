using System.Linq.Expressions;
using Application.Abstractions.Database;
using Application.Domains.Entities;
using BiometriaService.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace BiometriaService.Database.Repositories;

public class AndroidRepository: IRepository<AndroidEntity>
    {
        private readonly DbSet<AndroidEntity> _dbSet;
        private readonly BiometriaServiceContext _context;
        public AndroidRepository(BiometriaServiceContext context)
        {
            _context = context;
            _dbSet = context.Set<AndroidEntity>();
        }

        public IEnumerable<AndroidEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<AndroidEntity> Get(Func<AndroidEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public AndroidEntity FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public int Create(AndroidEntity item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges();
        }
        public int Update(AndroidEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Remove(AndroidEntity item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges();
        }

        public IEnumerable<AndroidEntity> GetWithInclude(params Expression<Func<AndroidEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<AndroidEntity> GetWithInclude(Func<AndroidEntity, bool> predicate,
            params Expression<Func<AndroidEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public AndroidEntity GetWithIncludeWithoutRelatedEntities(Guid Id)
        {
            throw new NotImplementedException();
        }

        private IQueryable<AndroidEntity> Include(params Expression<Func<AndroidEntity, object>>[] includeProperties)
        {
            IQueryable<AndroidEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
}