using System;
using DeratControl.Domain.Root.Exceptions;
using System.Threading.Tasks;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using System.Linq;
namespace DeratControl.Application.Perimeters.Commands
{   /// <summary>
/// DTO class for adding perimeters command
/// </summary>
    public class AddPerimeterCommand : IRequest
    {
        public PerimeterType PerimeterType { get; set; }
        public int FacilityId { get; set; }
    }
    /// <summary>
    /// class that will implement CommandHandler : Add Perimeter to facility
    /// </summary>
    public class AddPerimeterCommandHandler : BaseCommandHandler<AddPerimeterCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddPerimeterCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddPerimeterCommand request)
        {
            var facility = await unitOfWork.FacilityRepository.FindByIdAsync(request.FacilityId);
            if (facility == null)
            {
                throw new FacilityDoesNotExistsException();
            }

            var newPerimeter = facility.AddPerimeter(request.PerimeterType, executionContext.RequestedUser);
            await unitOfWork.Commit();
            return new CommandCreateResult<int>(newPerimeter.Id);
        }
    }
}
