using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    class Facility : Root.EntityBase<int>
    {
        public string Address { get; set; }
        public Organization Organization { get; set; }
        public List<Perimeter> Perimeters { get; set; }
        public List<Review> Reviews { get; set; }
        public Facility()
        {
            this.Perimeters = new List<Perimeter>();
            this.Reviews = new List<Review>();
        }
    }
}
