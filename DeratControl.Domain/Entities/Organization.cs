﻿using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;

namespace DeratControl.Domain.Entities
{
    public class Organization : EntityBase<int>
    {
        private Organization()
        {
            this.Facilities = new HashSet<Facility>();

            this.ContactPeople = new HashSet<User>();
        }

        public Organization(string name, User user)
        {
            this.Name = name;

            this.CreatedBy = user.Id;
        }

        public string Name { get;  set; }

        public virtual ICollection<User> ContactPeople { get; protected set; }

        public virtual ICollection<Facility> Facilities { get; protected set; }


        public void AddFacility(Facility facility, User user)
        {
            this.Facilities.Add(facility);
            facility.CreatedBy = user.Id;
        }
    }
}
