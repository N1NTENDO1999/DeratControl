using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class Facility : EntityBase<int>
    {
        public string Address { get;  set; }
        public Organization Organization { get;  set; }
        public ICollection<Perimeter> Perimeters { get; private set; }
        public ICollection<Review> Reviews { get; private set; }
        public Facility()
        {
            this.Perimeters = new List<Perimeter>();
            this.Reviews = new List<Review>();
        }
    }
}
