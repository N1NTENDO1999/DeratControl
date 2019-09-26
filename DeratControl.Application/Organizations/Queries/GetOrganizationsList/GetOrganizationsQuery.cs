using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;

namespace DeratControl.Application.Organizations.Queries.GetOrganizationsList
{
    public class GetOrganizationsQuery : IRequest
    {
        public int OrganizationID { get; set; }
    }

    public class GetOrganizationsQueryHandler : IQueryHandler<GetOrganizationsQuery, OrganizationsViewModelResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetOrganizationsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrganizationsViewModelResult> Handle(CommandExecutionContext executionContext, GetOrganizationsQuery request)
        {
            ICollection<Organization> organizations = (ICollection<Organization>)unitOfWork.OrganizationRepository.ToListAsync();
            if (organizations == null)
            {
                throw new OrganizationNotExistException();
            }
            return await Task.FromResult(new OrganizationsViewModelResult() { Organizations = organizations });
        }
    }

}
