using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DeratControl.Infrastructure.EntitiesConfigurations;
using DeratControl.Domain.Entities;

namespace DeratControl.Infrastructure
{
    public class DeratContext : DbContext
    {

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Perimeter> Perimeters { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Trap> Traps { get; set; }
        public DbSet<TrapReview> TrapReviews { get; set; }
        public DbSet<User> Users { get; set; }

        public DeratContext(DbContextOptions<DeratContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new PointConfiguration());
            modelBuilder.ApplyConfiguration(new PerimeterConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());



        }
    }
}
