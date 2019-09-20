using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;

namespace DeratControl.Application.Users.Queries
{
    class UsersViewModelResult:IQueryResult
    {
        public ICollection<User> Users { get; set; }
    }
}
