using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Review.Commands.AddReview
{
    public class AddReviewCommand : IRequest
    {
        public int FacilityId { get; set; }
        public int EmployeeId { get; set; }
    }
}