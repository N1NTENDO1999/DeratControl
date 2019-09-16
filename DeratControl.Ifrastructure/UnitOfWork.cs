using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Repositories;
using DeratControl.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IFacilityRepository facilityRepository;
        private IOrganizationRepository organizationRepository;
        private IPerimeterRepository perimeterRepository;
        private IPointRepository pointRepository;
        private IReviewRepository reviewRepository;
        private ITrapRepository trapRepository;
        private ITrapReviewRepository trapReviewRepository;
        private IUserRepository userRepository;

        public IFacilityRepository FacilityRepository
        {
            get
            {
                if (facilityRepository == null)
                {
                    facilityRepository = new FacilityRepository(DatabaseContext);
                }
                return facilityRepository;
            }
        }
        public IOrganizationRepository OrganizationRepository
        {
            get
            {
                if (organizationRepository == null)
                {
                    organizationRepository = new OrganizationRepository(DatabaseContext);
                }
                return organizationRepository;
            }
        }
        public IPerimeterRepository PerimeterRepository
        {
            get
            {
                if (perimeterRepository == null)
                {
                    perimeterRepository = new PerimeterRepository(DatabaseContext);
                }
                return perimeterRepository;
            }
        }
        public IPointRepository PointRepository
        {
            get
            {
                if (pointRepository == null)
                {
                    pointRepository = new PointRepository(DatabaseContext);
                }
                return pointRepository;
            }
        }
        public IReviewRepository ReviewRepository
        {
            get
            {
                if (reviewRepository == null)
                {
                    reviewRepository = new ReviewRepository(DatabaseContext);
                }
                return reviewRepository;
            }
        }
        public ITrapRepository TrapRepository
        {
            get
            {
                if (trapRepository == null)
                {
                    trapRepository = new TrapRepository(DatabaseContext);
                }
                return trapRepository;
            }
        }

        public ITrapReviewRepository TrapReviewRepository
        {
            get
            {
                if (trapReviewRepository == null)
                {
                    trapReviewRepository = new TrapReviewRepository(DatabaseContext);
                }
                return trapReviewRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(DatabaseContext);
                }
                return userRepository;
            }
        }

        public DbContext DatabaseContext { get; private set; }

        public UnitOfWork(DbContext dbContext)
        {
            DatabaseContext = dbContext;
        }

        public Task Commit()
        {
            return DatabaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DatabaseContext.Dispose();
        }
    }
}
