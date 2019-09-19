using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Perimeters.Queries.GetPerimeterIndividual
{
    public class GetPerimeterIndividualQuery : IRequest
    {
        public int PerimeterId { get; set; }
    }

    public class GetPerimeterIndividualQueryHandler : IQueryHandler<GetPerimeterIndividualQuery, PerimeterIndividualViewModel>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPerimeterIndividualQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PerimeterIndividualViewModel> Handle(CommandExecutionContext executionContext, GetPerimeterIndividualQuery request)
        {
            var perimeter = await unitOfWork.PerimeterRepository.FindByIdAsync(request.PerimeterId);
            if (perimeter == null)
            {
                throw new PerimeterDoesExistsException();
            }

            return new PerimeterIndividualViewModel(perimeter.Facility, perimeter.PerimeterType, perimeter.TrapPoints);
        }
    }
}
