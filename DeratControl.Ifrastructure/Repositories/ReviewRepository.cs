using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class ReviewRepository : Repository<Review, int>, IReviewRepository
    {
        public ReviewRepository(DbContext databaseContext)
            : base(databaseContext)
        {

        }
    }
}
