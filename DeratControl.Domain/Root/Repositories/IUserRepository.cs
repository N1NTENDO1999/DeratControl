using System;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        bool Exists(string email);
    }
}
