using System;
using System.Threading.Tasks;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IFacilityRepository : IRepository<Facility, int>
    {
    }
}
