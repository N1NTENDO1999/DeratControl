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
    public class GetPointQueryHandler : IQueryHandler<GetPointQuery, PointViewModelResult>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetPointQueryHandler(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }

        public async Task<PointViewModelResult> Handle(CommandExecutionContext executionContext, GetPointQuery request)
        {
            var perimeter= await _unitofwork.PerimeterRepository.FindByIdAsync(request.PerimeterId);

            if (perimeter == null)
                throw new NullReferenceException("Perimeter with specified id does not exist!");

            return new PointViewModelResult() { Point = point };
        }
    }
}
