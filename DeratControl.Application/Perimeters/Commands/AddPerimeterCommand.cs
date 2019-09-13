using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
namespace DeratControl.Application.Perimeters.Commands
{   /// <summary>
/// DTO class for adding perimeters command
/// </summary>
    public class AddPerimeterCommandDTO : IRequest
    {
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        public PerimeterType PerimeterType { get; set; }
    }
    /// <summary>
    /// class that will implement CommandHandler : Add Perimeter to facility
    /// </summary>
    public class AddPerimeterCommandHandler : ICommandHandler<AddPerimeterCommandDTO>
    {
        public IFacilityRepository _repository;
        public AddPerimeterCommandHandler(IFacilityRepository repository)
        {
            this._repository = repository;
        }
        public async Task<CommandResult> Handle(CommandExecutionContext executionContext, AddPerimeterCommandDTO request)
        {
            if (request == null)
                throw new Exception("request == null");
            var newPerimeter = new Perimeter(request.FacilityId,
                request.Facility,
                request.PerimeterType,
                executionContext.RequestedUser.FirstName + " " + executionContext.RequestedUser.LastName);
            if (request.Facility != null && _repository.IsInclude(newPerimeter)) // we need to compare FacilityId & PerimeterType
                throw new Exception("Current Facility already has this type of perimeter");
            var facility = _repository.FindById(request.FacilityId);
            facility.AddPerimeter(newPerimeter, executionContext.RequestedUser);
            _repository.Save();//Unit Of Work will do it instead repository
            return new CommandCreateResult<int>(newPerimeter.Id);
        }
    }
}
