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
    public class GetPointsQueryHandler : IQueryHandler<GetPointQuery, PointsViewModelResult>
    {
        private IUnitOfWork _unitofwork;

        public GetPointsQueryHandler(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }

        public async Task<PointsViewModelResult> Handle(CommandExecutionContext executionContext, GetPointQuery request)
        {
            var point = await _unitofwork.PointRepository.FindByIdAsync(request.PointId);

            if (point == null)
                throw new NullReferenceException("Perimeter with specified id does not exist!");

            return new PointsViewModelResult() { Point = point };
        }
    }
}
