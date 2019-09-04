using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;

namespace DeratControl.Domain.Entities
{
    class Review:EntityBase<int>
    {
        public Review()
        {
            this.ListOfTrapsToReview = new List<Trap>();
        }

        public DateTime Date { get; protected set; }

        public DateTime StartedAt { get; protected set; }

        public DateTime FinishedAt { get;protected set; }

        public DateTime PostponedTo { get; protected set; }

        public string Status { get; protected set; }

        public Facility Facility { get; protected set; }

        public User AssignedEmployee { get; protected set; }

        public ICollection<Trap> ListOfTrapsToReview { get; protected set; }
    }
}
