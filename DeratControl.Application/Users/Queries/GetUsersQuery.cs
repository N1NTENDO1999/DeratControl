using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Application.Interfaces;

namespace DeratControl.Application.Users.Queries
{
    public class GetUsersQuery: IRequest
    {
        public int RoleId { get; set; }
    }
}
