﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Domain.Root
{
    public interface IRepository<T, Tkey>
        where T : EntityBase<Tkey>
        where Tkey : struct
    {
        IEnumerable<T> List { get; }
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> FindByIdAsync(Tkey Id);
    }
}
