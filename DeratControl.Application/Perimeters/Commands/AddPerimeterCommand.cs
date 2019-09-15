using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using DeratControl.Domain.Root.Exceptions;
using System.Linq;

namespace DeratControl.Application.Perimeters.Commands
{   /// <summary>
/// DTO class for adding perimeters command
/// </summary>
    public class AddPerimeterCommand : IRequest
    {
        public PerimeterType PerimeterType { get; }
        public int FacilityId { get; }
    }
    /// <summary>
    /// class that will implement CommandHandler : Add Perimeter to facility
    /// </summary>
    public class AddPerimeterCommandHandler : BaseCommandHandler<AddPerimeterCommand>
    {
        private readonly IFacilityRepository _repository;
        //TODO : inject IUnitOfWork instead of IFacilityRepository when available
        public AddPerimeterCommandHandler(IFacilityRepository repository)
        {
            this._repository = repository;
        }
        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddPerimeterCommand request)
        {

            var facility = _repository.FindById(request.FacilityId);
            if (facility == null)
                throw new Exception("this facility doesn`t exists");
            facility.AddPerimeter(request.PerimeterType, executionContext.RequestedUser);
            //_repository.Save();//Unit Of Work will do it instead repository
            var id = from i in facility.Perimeters where i.PerimeterType == request.PerimeterType select i.Id;
            return new CommandCreateResult<int>(id.First());
        }
        protected override void AssertRequestIsValid(AddPerimeterCommand request)
        {
            base.AssertRequestIsValid(request);
        }
    }
}
