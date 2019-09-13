using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class Facility : EntityBase<int>
    {
        public string Address { get; private set; }
        public Organization Organization { get; private set; }
        public ICollection<Perimeter> Perimeters { get; private set; }
        public ICollection<Review> Reviews { get; private set; }

        private Facility()
        {
            this.Perimeters = new List<Perimeter>();
            this.Reviews = new List<Review>();
        }
        public void AddPerimeter(Perimeter perimeter, User user)
        {
            this.Perimeters.Add(perimeter);
            perimeter.CreatedBy = user.FirstName + " " + user.LastName;
        }
    }
}
