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
    public class FacilityRepository : Repository<Facility, int>, IFacilityRepository
    {

        public FacilityRepository(DbContext databaseContext)
        : base(databaseContext)
        {

        }

        public Task<bool> Exists(Facility facility)
        {
            throw new NotImplementedException();
        }

        public override async Task<Facility> FindByIdAsync(int Id)
        {
            return (await databaseContext.Set<Facility>().Include(f => f.Perimeters).ToListAsync()).SingleOrDefault();
        }
    }
}
