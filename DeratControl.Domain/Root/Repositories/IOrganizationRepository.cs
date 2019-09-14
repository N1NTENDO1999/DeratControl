using System;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IOrganizationRepository : IRepository<Organization, int>
    {
        bool IsExists(Organization organization);

        bool IsInclude(Facility facility);

        void Save();
    }
}
