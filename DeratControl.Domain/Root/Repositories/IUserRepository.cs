using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        bool Exists(string email);
        ICollection<User> FindRoleById(int RoleId);
    }
}
