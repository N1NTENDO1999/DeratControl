using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class PerimeterRepository : Repository<Perimeter, int>, IPerimeterRepository
    {
       
        public PerimeterRepository(DbContext databaseContext)
            : base(databaseContext)
        {

        }
    }
}
