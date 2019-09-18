using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Review.Queries.GetReviewsByEmpleyee
{
    class GetReviewsQueryHandler : IQueryHandler<GetReviewsQuery, ReviewsDTO>
    {
        private  readonly IUnitOfWork unitOfWork;

        public GetReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ReviewsDTO> Handle(CommandExecutionContext executionContext, GetReviewsQuery request)
        {
            var employee = unitOfWork.UserRepository.FindByIdAsync(request.EmployeeId);

            if (employee.Result.OrganizationId == null)
                throw new UserIsNotEmployeeException();

            var review = employee.Result.Reviews;

            return (new ReviewsDTO(review));
        }
    }
}
