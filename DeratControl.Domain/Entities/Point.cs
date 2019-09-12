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

        public string Order { get; private set; }
        public string Location { get; private set; }
        public string Description { get; private set; }

        public virtual ICollection<TrapReview> ListOfReviews { get; protected set; } = new HashSet<TrapReview>();

        public int PerimeterId { get; private set; }
        public virtual Perimeter Perimeter { get; private set; }

        public int? TrapId { get; private set; }
        public virtual Trap Trap { get; private set; }

    }
}
