using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace DeratControl.Application.Facilities.Queries.GetFacilitiesList
{
    public class GetFacilityQueryHandler : IQueryHandler<GetFacilityQuery, FacilityViewModel>
    {
        readonly private IUnitOfWork _unitOfWork;

        public GetFacilityQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<FacilityViewModel> Handle(CommandExecutionContext executionContext, GetFacilityQuery request)
        {
            var organization = await _unitOfWork.OrganizationRepository.FindByIdAsync(request.OrganizationId);

            if (organization == null)
            {
                throw new FacilityDoesNotExistsException("Current facility does not exists", StatusCodes.Status400BadRequest);
            }
            
            return new FacilityViewModel() { Facility = facility };
        }
    }
}

