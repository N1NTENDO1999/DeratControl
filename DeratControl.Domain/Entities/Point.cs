﻿using DeratControl.Domain.Root;
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

        public string Order { get; protected set; }
        public string Location { get; protected set; }
        public string Description { get; protected set; }

        public virtual ICollection<TrapReview> ListOfReviews { get; protected set; } = new HashSet<TrapReview>();

        public int PerimeterId { get; protected set; }
        public virtual Perimeter Perimeter { get; private set; }

        public int? TrapId { get; protected set; }
        public virtual Trap Trap { get; protected set; }

    }
}
