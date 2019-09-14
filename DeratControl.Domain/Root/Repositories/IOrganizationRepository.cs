using System;
using System.Threading.Tasks;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IOrganizationRepository : IRepository<Organization, int>
    {
        Task<bool> IsExists(Organization organization);

        Task<bool> IsInclude(Organization organization, string Address);
    }
}
