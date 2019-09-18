using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using DeratControl.Domain.Root.Exceptions;
using System.Threading.Tasks;
using System;
using DeratControl.Domain.Root;

namespace DeratControl.Application.Facilities.Commands
{
    public class AddFacilityCommandHandler : BaseCommandHandler<AddFacilityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddFacilityCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddFacilityCommand request)
        {
<<<<<<< HEAD:DeratControl.Application/Facilities/Commands/AddFacilityCommandHandler.cs
            var organization = this._unitOfWork.OrganizationRepository.FindById(request.OrganizationId);
=======
            var organization = await this._unitOfWork.OrganizationRepository.FindByIdAsync(request.OrganizationId);
>>>>>>> b4613e809ab5c08850a32d5f443811a4ad6b5ecc:DeratControl.Application/Facilities/AddFacilityCommandHandler.cs

            if (organization == null)
            {
                throw new OrganizationNotExistException();
            }

            var newFacility  = organization.AddFacility(request.Address, executionContext.RequestedUser);

            await this._unitOfWork.Commit();

            return new CommandCreateResult<int>(newFacility.Id);
        }
        
        protected override void AssertRequestIsValid(AddFacilityCommand request)
        {
            base.AssertRequestIsValid(request);
            if (string.IsNullOrEmpty(request.Address))
            {
                throw new ArgumentNullException("Address in undefined");
            }
        }
    }
}
