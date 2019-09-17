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
        public virtual ICollection<Perimeter> Perimeters { get; private set; }
        public virtual ICollection<Review> Reviews { get; private set; }
        private Facility()
        {
            this.Perimeters = new List<Perimeter>();
            this.Reviews = new List<Review>();
        }

        public Perimeter RemovePerimeter(PerimeterType perimeterType)
        {
            var PerimeterExists = this.Perimeters.Any(f => f.PerimeterType == perimeterType);
            if (PerimeterExists == false)
            {
                throw new PerimeterMissingException();
            }

            var perimeterToRemove = (from perimeter in this.Perimeters
                                     where perimeter.PerimeterType == perimeterType
                                     select perimeter).Single();
            this.Perimeters.Remove(perimeterToRemove);
            return perimeterToRemove;
        }
    }
}
