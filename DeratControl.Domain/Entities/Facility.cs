using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class Facility : EntityBase<int>
    {
        public string Address { get; private set; }
        public int OrganizationId { get; private set; }
        public virtual Organization Organization { get; private set; }
        public virtual ICollection<Perimeter> Perimeters { get; private set; } = new HashSet<Perimeter>();
        public virtual ICollection<Review> Reviews { get; private set; } = new HashSet<Review>();
        private Facility()
        {
        }

        public Facility(int organizationId, string address, int createdBy)
        {
            this.OrganizationId = organizationId;
            this.Address = address;
            this.CreatedBy = createdBy;
            this.CreatedAt = DateTime.Now;
        }
    }
}
