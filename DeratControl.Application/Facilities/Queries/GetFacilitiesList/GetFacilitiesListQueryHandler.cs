using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using System;
using System.Threading.Tasks;

namespace DeratControl.Application.Facilities.Queries.GetFacilitiesList
{
    public class GetFacilitiesListQueryHandler : IQueryHandler<GetFacilitiesListQuery, FacilitiesListViewModel>
    {
        readonly private IUnitOfWork _unitOfWork;

        public GetFacilitiesListQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<FacilitiesListViewModel> Handle(CommandExecutionContext executionContext, GetFacilitiesListQuery request)
        {
            var facility = await _unitOfWork.FacilityRepository.FindByIdAsync(request.FacilityId);

            if (facility == null)
            {
                throw new OrganizationNotExistException();
            }

            return new FacilitiesListViewModel() { Facility = facility };
        }
    }
}

