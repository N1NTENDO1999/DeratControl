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

        public DbSet<Facility> Facilities { get; private set; }
        public DbSet<Organization> Organizations { get; private set; }
        public DbSet<Perimeter> Perimeters { get; private set; }
        public DbSet<Point> Points { get; private set; }
        public DbSet<Review> Reviews { get; private set; }
        public DbSet<Trap> Traps { get; private set; }
        public DbSet<TrapReview> TrapReviews { get; private set; }
        public DbSet<User> Users { get; private set; }

        public DeratContext(DbContextOptions<DeratContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new TrapConfiguration());

            modelBuilder.ApplyConfiguration(new PointConfiguration());
            modelBuilder.ApplyConfiguration(new PerimeterConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityConfiguration());
            modelBuilder.ApplyConfiguration(new TrapReviewConfiguration());
            modelBuilder.ApplyConfiguration(new TrapReviewConfiguration());
        }
    }
}
