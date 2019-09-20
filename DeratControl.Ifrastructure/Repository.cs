using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Domain.Root;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
        where TKey : struct
    {
        public DbContext databaseContext { get;}

        public IEnumerable<TEntity> List => throw new NotImplementedException();

        public Repository(DbContext context)
        {
            this.databaseContext = context;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await databaseContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            databaseContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<TEntity> FindByIdAsync(TKey Id)
        {
           return await databaseContext.Set<TEntity>().FindAsync(Id);
        }

        public void Update(TEntity entity)
        {
            databaseContext.Set<TEntity>().Update(entity);
        }
    }
}
