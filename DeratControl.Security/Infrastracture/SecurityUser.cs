using DeratControl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace DeratControl.Security
{
    public class SecurityUser : IdentityUser
    {
        public int UserId { get; set; }
        //public User User { get; set; }
        public SecurityUser(int userId)
        {
            UserId = userId;
        }
    }
}