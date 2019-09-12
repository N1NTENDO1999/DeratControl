using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Security.Infrastracture
{
    public class ApplicationDbContext : IdentityDbContext<SecurityUser>
    {
        public ApplicationDbContext(){ }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
