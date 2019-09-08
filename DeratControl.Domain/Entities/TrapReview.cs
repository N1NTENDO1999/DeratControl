using DeratControl.Domain.Root;
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

    class TrapReview : EntityBase<int>
    {
        public Review Review { get; set; }
        public Point Point { get; set; }
        public string Comment { get; set; }
        public ICollection<TrapReviewImage> ListOfImages { get; set; }
        public TrapRewiewState TrapRewiewState { get; protected set; }

        private TrapReview()
        {
            this.ListOfImages = new List<TrapReviewImage>();
        } 
    }
}
