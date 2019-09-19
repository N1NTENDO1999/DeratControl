using System;
using System.Collections.Generic;
using System.Linq;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(DbContext databaseContext)
            : base(databaseContext)
        {

        }

        public bool Exists(string email)
        {
            return databaseContext.Set<User>().Where(x => x.Email == email).FirstOrDefault() != null;
        }

        public ICollection<User> FindRoleById(int RoleId)
        {
            if (RoleId < 0 || RoleId > 2)
            {
                throw new ArgumentException();
            }
            return databaseContext.Set<User>().Where(x => x.UserRole == UserRole.Employee).ToList();
        }
    }
}
