using System;
using System.Threading.Tasks;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IOrganizationRepository : IRepository<Organization, int>
    {
        Task<bool> Exists(string organizationName);

        /// <summary>
        /// Checks if Organization already has facility at this address
        /// </summary>
        Task<bool> IsInclude(Organization organization, string FacilityAddress);
    }
}