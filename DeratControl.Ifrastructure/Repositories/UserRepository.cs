using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
    }
}
