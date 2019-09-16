using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class TrapReviewRepository : Repository<TrapReview, int>, ITrapReviewRepository
    {
        private DbContext databaseContext;

        public TrapReviewRepository(DbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
