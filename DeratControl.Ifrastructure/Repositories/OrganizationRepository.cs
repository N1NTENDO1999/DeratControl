using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class OrganizationRepository : Repository<Organization, int>, IOrganizationRepository
    {
        private DbContext databaseContext;

        public OrganizationRepository(DbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Task<bool> Exists(string organizationName)
        {
            throw new NotImplementedException();
        }
    }
}
