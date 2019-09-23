using DeratControl.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Review.Queries.GetReviewsByEmpleyee
{
    class GetReviewsQuery : IRequest
    {
        public int EmployeeId { get; set; }
    }
}
