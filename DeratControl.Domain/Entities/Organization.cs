using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;

namespace DeratControl.Domain.Entities
{
    class Organization:EntityBase<int>
    {
        public Organization()
        {
            this.Facilities = new List<Facility>();

            this.ContactPeople = new List<User>();
        }

        public string Name { get;  set; }

        public ICollection<User> ContactPeople { get;  set; }

        public ICollection<Facility> Facilities { get;  set; }
    }
}
