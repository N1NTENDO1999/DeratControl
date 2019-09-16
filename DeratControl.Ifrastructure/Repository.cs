using System;
using System.Collections.Generic;
using System.Text;
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

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(TKey Id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
