using System;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IFacilityRepository : IRepository<Facility, int>
    {
        bool IsInclude(Perimeter perimeter);
        void Save();
    }
}
