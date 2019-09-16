using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        private DbContext databaseContext;

        public UserRepository(DbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
