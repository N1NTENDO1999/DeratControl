using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root.Exceptions;
using System.Linq;

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

        public Perimeter AddPerimeter(PerimeterType perimeterType, User user)
        {
            var perimeterExists = this.Perimeters.Any(f => f.PerimeterType == perimeterType);
            if (perimeterExists)
            {
                throw new PerimeterAlreadyExistsException();
            }
            var newPerimeter = new Perimeter(this, perimeterType, user.Id);
            this.Perimeters.Add(newPerimeter);
            return newPerimeter;
        }
    }
}
    