using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class TrapReviewImage : EntityBase<int>
    {
        public int TrapReviewId { get; private set; }

        public virtual TrapReview TrapReview { get; private set; }
    }
}
