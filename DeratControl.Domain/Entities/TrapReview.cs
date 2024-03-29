﻿using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace DeratControl.Domain.Entities
{
    public enum TrapRewiewState
    {
        Planned,
        Active,
        Done,
        Postponed
    }

    public class TrapReview : EntityBase<int>
    {
        public int ReviewId { get; private set; }

        public int PointId { get; private set; }

        public virtual Point Point { get; private set; }

        public virtual Review Review { get; private set; }        

        public string Comment { get; private set; }

        public ICollection<TrapReviewImage> ListOfImages { get; private set; }
            = new HashSet<TrapReviewImage>();

        public TrapRewiewState TrapRewiewState { get; private set; } 

        private TrapReview()
        {

        } 
    }
}
