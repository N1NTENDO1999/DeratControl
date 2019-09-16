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

        public async Task AddAsync(TEntity entity)
        {
            await databaseContext.Set<TEntity>().AddAsync(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            databaseContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<TEntity> FindByIdAsync(TKey Id)
        {
           return await databaseContext.Set<TEntity>().FindAsync(Id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            databaseContext.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
    }
}
