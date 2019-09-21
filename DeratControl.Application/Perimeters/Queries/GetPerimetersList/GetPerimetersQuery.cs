using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Perimeters.Queries.GetPerimetersList
{
    public class GetPerimetersListQuery : IRequest
    {
        public int FacilityId { get; set; }
    }

    public class GetPerimetersQueryHandler : IQueryHandler<GetPerimetersListQuery, PerimetersViewModelResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPerimetersQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PerimetersViewModelResult> Handle(CommandExecutionContext executionContext, GetPerimetersListQuery request)
        {
            var facility = await unitOfWork.FacilityRepository.FindByIdAsync(request.FacilityId);
            if (facility == null)
            {
                throw new FacilityDoesNotExistsException("Current facility does not exists", StatusCodes.Status400BadRequest);
            }

            return new PerimetersViewModelResult() { Perimeter = facility.Perimeters };
        }
    }
}
