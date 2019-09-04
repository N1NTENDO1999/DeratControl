using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
    }
}
