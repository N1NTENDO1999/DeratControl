using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class Facility : EntityBase<int>
    {
        public string Address { get; private set; }
        public int OrganizationId { get; private set; }
        public virtual Organization Organization { get; private set; }
        public virtual ICollection<Perimeter> Perimeters { get; private set; } = new HashSet<Perimeter>();
        public virtual ICollection<Review> Reviews { get; private set; } = new HashSet<Review>();

        private Facility()
        {
        }

        public void RemovePerimeter(PerimeterType perimeterType)
        {
            var isPerimeterExists = this.Perimeters.Any(f => f.PerimeterType == perimeterType);
            if (isPerimeterExists == false)
            {
                throw new PerimeterDoesNotExistException();
            }

            var perimeterToRemove = (from perimeter in this.Perimeters
                                     where perimeter.PerimeterType == perimeterType
                                     select perimeter).SingleOrDefault();

            if (perimeterToRemove == null)
            {
                throw new PerimeterDoesNotExistException();
            }

            var isHasActiveReview = (from point in perimeterToRemove.TrapPoints
                                     from t in point.ListOfReviews
                                     select t).Any(t => t.TrapRewiewState == TrapRewiewState.Active);

            if (isHasActiveReview)
            {
                throw new PerimeterHasActiveReviewException();
            }

            else
            {
                this.Perimeters.Remove(perimeterToRemove);
            }
        }
    }
}
