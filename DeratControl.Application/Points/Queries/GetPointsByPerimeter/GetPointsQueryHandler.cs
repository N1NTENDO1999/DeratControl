using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Points.Queries.GetPointsByPerimeter
{
    public class GetPointsQueryHandler : IQueryHandler<GetPointsQuery,PointsViewModelResult>
    {
        private IUnitOfWork _unitofwork;

        public GetPointsQueryHandler(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }

       public async Task<PointsViewModelResult> Handle(CommandExecutionContext executionContext, GetPointsQuery request)
        {
            var perimeter= await _unitofwork.PerimeterRepository.FindByIdAsync(request.PerimeterId);

            if (perimeter == null)
                throw new NullReferenceException("Perimeter with specified id does not exist!");

            return  new PointsViewModelResult() {Points=perimeter.TrapPoints};
        }
    }
}
