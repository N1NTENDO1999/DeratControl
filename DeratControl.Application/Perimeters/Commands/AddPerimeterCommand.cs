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
namespace DeratControl.Application.Perimeters.Commands
{   /// <summary>
/// DTO class for adding perimeters command
/// </summary>
    public class AddPerimeterCommand : IRequest
    {
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        public PerimeterType PerimeterType { get; set; }
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
            if (await _repository.IsInclude(request.FacilityId, request.PerimeterType))
            {
                throw new PerimeterAlreadyExistsException();
            }
            var newPerimeter = new Perimeter(request.FacilityId,
                request.Facility,
                request.PerimeterType,
                executionContext.RequestedUser.Id);
            var facility = _repository.FindById(request.FacilityId);
            facility.AddPerimeter(newPerimeter, executionContext.RequestedUser);
            //_repository.Save();//Unit Of Work will do it instead repository
            return new CommandCreateResult<int>(newPerimeter.Id);
        }
        protected override void AssertRequestIsValid(AddPerimeterCommand request)
        {
            base.AssertRequestIsValid(request);
            if (request.Facility == null ||)
            {
                throw new ArgumentNullException(nameof(request.Facility));
            }
        }
    }
}
