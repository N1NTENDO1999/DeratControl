using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Perimeters.Commands
{
    public class RemovePerimeterCommand : IRequest
    {
        public PerimeterType PerimeterType { get; set; }
        public int FacilityId { get; set; }
    }

    public class RemovePerimeterCommandHandler : BaseCommandHandler<RemovePerimeterCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemovePerimeterCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, RemovePerimeterCommand request)
        {
            var facility = await unitOfWork.FacilityRepository.FindByIdAsync(request.FacilityId);
            if (facility == null)
            {
                throw new FacilityDoesNotExistsException();
            }

            facility.RemovePerimeter(request.PerimeterType);
            await unitOfWork.Commit();
            return new CommandResult();
        }
    }
}