using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root
{
    public interface IRepository<T, Tkey>
        where T : EntityBase<Tkey>
        where Tkey : struct
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(Tkey Id);
    }
}
