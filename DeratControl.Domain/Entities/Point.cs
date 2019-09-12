using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class Point : EntityBase<int>
    {
        private Point()
        {
            
        }

        public string Order { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TrapReview> ListOfReviews { get; protected set; } = new HashSet<TrapReview>();

        public int PerimeterId { get; set; }
        public virtual Perimeter Perimeter { get; set; }

        public int? TrapId { get; set; }
        public virtual Trap Trap { get; set; }

    }
}
