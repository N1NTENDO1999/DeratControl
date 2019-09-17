using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using System;
using System.Threading.Tasks;

namespace DeratControl.Application.Facilities.Queries.GetFacilitiesList
{
    class GetFacilitiesListQueryHandler : IQueryHandler<GetFacilitiesListQuery, FacilitiesListViewModel>
    {
        private IUnitOfWork _unitOfWork;

        public GetFacilitiesListQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<FacilitiesListViewModel> Handle(CommandExecutionContext executionContext, GetFacilitiesListQuery request)
        {
            var organization = _unitOfWork.OrganizationRepository.FindById(request.OrganizationId);

            if (organization == null)
                throw new OrganizationIsNullException();

            return await Task.FromResult(new FacilitiesListViewModel() { Facilities = organization.Facilities });
        }
    }
}

