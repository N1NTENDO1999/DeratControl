using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Perimeters.Queries.GetPerimetersList
{
    public class GetPerimetersQuery : IRequest
    {
        public int PerimeterId { get; set; }
    }

    public class GetPerimetersQueryHandler : IQueryHandler<GetPerimetersQuery, PerimetersViewModelResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPerimetersQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PerimetersViewModelResult> Handle(CommandExecutionContext executionContext, GetPerimetersQuery request)
        {
            var perimeter = await unitOfWork.PerimeterRepository.FindByIdAsync(request.PerimeterId);
            if (perimeter == null)
            {
                throw new FacilityDoesNotExistsException();
            }

            return new PerimetersViewModelResult() { Perimeter=perimeter};
        }
    }
}
