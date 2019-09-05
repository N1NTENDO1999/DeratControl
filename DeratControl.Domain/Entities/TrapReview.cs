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
        Review Review { get; set; }
        Point Point { get; set; }
        string Comment { get; set; }
        List<TrapReviewImage> ListOfImages { get; set; }
        TrapRewiewState TrapRewiewState { get; set; }

        public TrapReview()
        {
            ListOfImages = new List<TrapReviewImage>();
        } 
    }
}
