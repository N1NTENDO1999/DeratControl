﻿using System;
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
        
        public OrganizationRepository(DbContext databaseContext)
            : base(databaseContext)
        {

        }

        public Task<bool> Exists(string organizationName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInclude(string facilityAddress)
        {
            throw new NotImplementedException();
        }
    }
}
