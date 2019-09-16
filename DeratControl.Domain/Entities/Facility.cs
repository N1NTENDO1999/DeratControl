using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root.Exceptions;

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
        public void AddPerimeter(PerimeterType perimeterType, User user)
        {
            foreach (var perimeter in this.Perimeters)
            {
                if (perimeterType == perimeter.PerimeterType)
                {
                    throw new PerimeterAlreadyExistsException();
                }
            }
            this.Perimeters.Add(new Perimeter(this.Id, this, perimeterType, user.Id));
        }
    }
}
