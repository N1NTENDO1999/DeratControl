﻿using DeratControl.Domain.Root;
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
        public virtual ICollection<Perimeter> Perimeters { get; private set; }
        public virtual ICollection<Review> Reviews { get; private set; }
        private Facility()
        {
            this.Perimeters = new List<Perimeter>();
            this.Reviews = new List<Review>();
        }

        public Facility(int OrganizationId, Organization Organization, string Address, string CreatedBy)
        {
            this.OrganizationId = OrganizationId;
            this.Address = Address;
            this.Organization = Organization;
            this.CreatedBy = CreatedBy;
        }


    }
}
