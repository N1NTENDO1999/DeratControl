using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class PointRepository : Repository<Point, int>, IPointRepository
    {
        private DbContext databaseContext;

        public PointRepository(DbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
