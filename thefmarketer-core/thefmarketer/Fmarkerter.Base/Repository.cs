using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fmarketer.Base
{
    public abstract class Repository<TEntity, TPkType> where TEntity : BaseEntity<TPkType>
    {
        protected readonly DbContext _context;
        protected DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task<TEntity> Get(TPkType id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.Created = DateTime.Now;
            entity.IsDeleted = false;
            entity.Updated = DateTime.Now;

            await _entities.AddAsync(entity);

            return await Get(entity.Id);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            for (int i = 0; i < entities.Count() ; i++)
            {
                entities.ElementAt(i).Created = DateTime.Now;
                entities.ElementAt(i).IsDeleted = false;
                entities.ElementAt(i).Updated = DateTime.Now;
            }

            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            for (int i = 0; i < entities.Count(); i++)
            {
                entities.ElementAt(i).IsDeleted = true;
                Update(entities.ElementAt(i));
            }
        }

        public virtual void Update(TEntity entity)
        {
            entity.Updated = DateTime.Now;
            _entities.Update(entity);
        }
    }
}
