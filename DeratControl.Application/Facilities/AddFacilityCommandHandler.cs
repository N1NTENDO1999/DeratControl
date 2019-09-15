using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using DeratControl.Domain.Root.Exceptions;
using System.Threading.Tasks;
using System;

namespace DeratControl.Application.Facilities
{
    public class AddFacilityCommandHandler : BaseCommandHandler<AddFacilityCommand>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public AddFacilityCommandHandler(
            IOrganizationRepository organizationRepository)
        {
            this._organizationRepository = organizationRepository;
        }



        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddFacilityCommand request)
        {
            if (await this._organizationRepository.IsInclude(request.Address))
            {
                throw new FacilityAlreadyExistsException();
            }

            var newFacility = new Facility(
                request.OrganizationId,
                request.Address,
                executionContext.RequestedUser.Id
                );

            var organization = this._organizationRepository.FindById(request.OrganizationId);

            organization.AddFacility(newFacility, executionContext.RequestedUser);

            //this._organizationRepository.Save(); Waiting for Unit of Work to show up

            return new CommandCreateResult<int>(newFacility.Id);

        }
        
        protected override void AssertRequestIsValid(AddFacilityCommand request)
        {
            base.AssertRequestIsValid(request);
            if (request.Address.Equals(string.Empty))
            {
                throw new ArgumentNullException("Address in undefined");
            }
        }
    }
}
