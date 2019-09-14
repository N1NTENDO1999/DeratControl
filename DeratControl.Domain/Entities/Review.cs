using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;

namespace DeratControl.Domain.Entities
{
    public enum Status
    {
        ToDo,
        InProgress,
        Done
    }

   public class Review:EntityBase<int>
    {
        private Review()
        {
            this.ListOfTrapsToReview = new HashSet<Trap>();
        }

        public Review(DateTime endTime, int createdBy)
        {
            this.Date = endTime;

            this.CreatedBy = createdBy;

        }

        public DateTime Date { get;  set; }

        public DateTime? StartedAt { get;  set; }

        public DateTime? FinishedAt { get; set; }

        public DateTime? PostponedTo { get;  set; }

        public Status Status { get;  set; }

        public int FacilityId { get; set; }
        public virtual Facility Facility { get;  set; }

        public int UserId { get; set; }
        public virtual User AssignedEmployee { get;  set; }

        public virtual ICollection<Trap> ListOfTrapsToReview { get; protected set; }
    }
}
