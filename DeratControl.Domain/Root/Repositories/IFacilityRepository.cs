using System;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IFacilityRepository : IRepository<Facility, int>
    {
        Task<bool> IsInclude(int facilityId, PerimeterType perimeterType);
    }
}
