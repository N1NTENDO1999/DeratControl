using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Points.Commands.AddPoint
{
    public class AddPointCommandHandler : BaseCommandHandler<AddPointCommand>
    {
        public IUnitOfWork UnitOfWork { get;}

        public AddPointCommandHandler(IUnitOfWork unitofwork)
        {
            this.UnitOfWork = unitofwork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddPointCommand request)
        {
            Perimeter perimeter = await this.UnitOfWork.PerimeterRepository.FindByIdAsync(request.PerimeterId);

            if (perimeter == null)
                throw new NullReferenceException("Perimeter not found!");

            Point newpoint = new Point(request.Location, request.PerimeterId, perimeter);

            perimeter.TrapPoints.Add(newpoint);

            await this.UnitOfWork.Commit();

            return new CommandCreateResult<int>(newpoint.Id);
        }

        protected override void AssertRequestIsValid(AddPointCommand request)
        {
            base.AssertRequestIsValid(request);

            if(string.IsNullOrEmpty(request.Location))
                throw new ArgumentNullException(nameof(request.Location));
        }
    }
}
