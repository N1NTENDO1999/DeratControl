using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Perimeters.Queries.GetPerimeterIndividual
{
    public class GetPerimeterQuery : IRequest
    {
        public int PerimeterId { get; set; }
    }

    public class GetPerimeterQueryHandler : IQueryHandler<GetPerimeterQuery, PerimeterViewModelResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPerimeterQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PerimeterViewModelResult> Handle(CommandExecutionContext executionContext, GetPerimeterQuery request)
        {
            var perimeter = await unitOfWork.PerimeterRepository.FindByIdAsync(request.PerimeterId);
            if (perimeter == null)
            {
                throw new PerimeterDoesNotExists("Current perimeter does not exists", StatusCodes.Status400BadRequest);
            }

            return new PerimeterViewModelResult() { Perimeter = perimeter };
        }
    }
}
