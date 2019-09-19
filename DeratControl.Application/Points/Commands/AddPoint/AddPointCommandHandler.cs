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
    public class AddPointCommandHandler : BaseCommandHandler<AddPointsCommand>
    {
        public IUnitOfWork UnitOfWork { get;}

        public AddPointCommandHandler(IUnitOfWork unitofwork)
        {
            this.UnitOfWork = unitofwork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddPointsCommand request)
        {
            Perimeter perimeter = await this.UnitOfWork.PerimeterRepository.FindByIdAsync(request.PerimeterId);

            if (perimeter == null)
                throw new NullReferenceException("Perimeter not found!");

            foreach(var point in request.Points)
            {
                perimeter.TrapPoints.Add(new Point(point.Location,point.Order, request.PerimeterId, perimeter));
            }

            await this.UnitOfWork.Commit();

            return new CommandResult();
        }

        protected override void AssertRequestIsValid(AddPointsCommand request)
        {
            base.AssertRequestIsValid(request);

            foreach(var point in request.Points)
            {
                if (string.IsNullOrEmpty(point.Location))
                    throw new ArgumentNullException(nameof(point.Location));
            }
            
        }
    }
}
