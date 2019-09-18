using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using System.Threading.Tasks;

namespace DeratControl.Application.Facilities.Commands
{
    public class RemoveFacilityCommand : IRequest
    {
        public string Address { get; set; }
        public int OrganizationId { get; set; }
    }

    public class RemoveFacilityCommandHandler : BaseCommandHandler<RemoveFacilityCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveFacilityCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, RemoveFacilityCommand request)
        {
            var organization = await unitOfWork.OrganizationRepository.FindByIdAsync(request.OrganizationId);

            if (organization == null)
            {
                throw new OrganizationNotExistException();
            }

            organization.RemoveFacility(request.Address);

            await unitOfWork.Commit();
            return new CommandResult();
        }
    }
}