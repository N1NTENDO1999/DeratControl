﻿using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;

namespace DeratControl.Domain.Entities
{
   public class Organization:EntityBase<int>
    {
        private Organization()
        {
            this.Facilities = new List<Facility>();

            this.ContactPeople = new List<User>();
        }

        public string Name { get;  set; }

        public virtual ICollection<User> ContactPeople { get;  set; }

        public virtual ICollection<Facility> Facilities { get;  set; }
    }
}
