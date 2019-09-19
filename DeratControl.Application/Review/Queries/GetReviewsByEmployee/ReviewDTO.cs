using DeratControl.Application.Requests.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;
namespace DeratControl.Application.Review.Queries.GetReviewsByEmpleyee
{
    public class ReviewDTO : IQueryResult
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public int FacilityId { get; set; }
        public int EmployeeId { get; set; }

        public ReviewDTO(Domain.Entities.Review review)
        {
            this.Date = review.Date;
            this.Status = review.Status;
            this.FacilityId = review.FacilityId;
            this.EmployeeId = review.EmployeeId;
        }
    }

    public class ReviewsDTO : IQueryResult
    {
        public ICollection<ReviewDTO> reviews { get; set; }

        public ReviewsDTO(ICollection<Domain.Entities.Review> collection)
        {
            foreach (var item in collection)
            {
                this.reviews.Add(new ReviewDTO(item));
            }
        }
    }
}
