using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Domain.Root.Exceptions;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Traps.Commands.SetTrap
{
    public class SetTrapCommand : IRequest
    {
        public string Data { get; set; }
        public int TrapPointId { get; set; }
        public TrapType TrapType { get; set; }
    }

    public class SetTrapCommandHandler : BaseCommandHandler<SetTrapCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public SetTrapCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, SetTrapCommand request)
        {
            var point = await unitOfWork.PointRepository.FindByIdAsync(request.TrapPointId);

            if(point == null)
            {
                throw new PointDoesNotExistException();
            }

            var entity = new Trap(point, request.Data, request.TrapType, executionContext.RequestedUser);

            point.Trap = entity;

            unitOfWork.PointRepository.Update(point);

            await unitOfWork.TrapRepository.AddAsync(entity);
            await unitOfWork.Commit();
            return new CommandCreateResult<int>(entity.Id);
        }
    }
}
