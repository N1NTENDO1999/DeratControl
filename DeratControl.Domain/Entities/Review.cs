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

        public DateTime Date { get;  set; }

        public DateTime StartedAt { get;  set; }

        public DateTime FinishedAt { get; set; }

        public DateTime PostponedTo { get;  set; }

        public string Status { get;  set; }

        public Facility Facility { get;  set; }

        public User AssignedEmployee { get;  set; }

        public ICollection<Trap> ListOfTrapsToReview { get; protected set; }
    }
}
