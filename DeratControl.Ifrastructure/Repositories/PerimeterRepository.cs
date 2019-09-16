using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class PerimeterRepository : Repository<Perimeter, int>, IPerimeterRepository
    {
        private DbContext databaseContext;

        public PerimeterRepository(DbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
