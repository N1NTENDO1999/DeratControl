using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeratControl.Infrastructure.Repositories
{
    public class OrganizationRepository : Repository<Organization, int>, IOrganizationRepository
    {
        
        public OrganizationRepository(DbContext databaseContext)
            : base(databaseContext)
        {

        }

        public Task<bool> Exists(string organizationName)
        {
            var existing = databaseContext.Set<Organization>()
                .FirstOrDefault(x => x.Name == organizationName);
            return existing == null ? Task.FromResult(false) : Task.FromResult(true);
        }

        public Task<bool> IsInclude(string facilityAddress)
        {
            throw new NotImplementedException();
        }
    }
}
