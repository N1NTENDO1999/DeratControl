using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Facilities
{
    public class AddFacilityCommandHandler : ICommandHandler<AddFacilityCommand>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public AddFacilityCommandHandler(
            IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }



        public async Task<CommandResult> Handle(CommandExecutionContext executionContext, AddFacilityCommand request)
        {
            if (IsValidRequest(request))
            {
                var newFacility = new Facility(request.OrganizationId, 
                    executionContext.RequestedUser.Organization,
                    executionContext.RequestedUser.Address,
                    executionContext.RequestedUser.FirstName + " " + 
                    executionContext.RequestedUser.LastName
                    );

                if (_organizationRepository.IsInclude(newFacility))
                {
                    throw new Exception("Current organization already has this facility");
                }
                else
                {
                    var organization = _organizationRepository.FindById(request.OrganizationId);

                    organization.AddFacility(newFacility, executionContext.RequestedUser);

                    _organizationRepository.Save();

                    return  new CommandCreateResult<int>(newFacility.Id);
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }



        private bool IsValidRequest(AddFacilityCommand request)
        {
            if (request == null)
            {
                return false;
            }
            else if (request.Address.Equals(string.Empty) || request.Organization == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
