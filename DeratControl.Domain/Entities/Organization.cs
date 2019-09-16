using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;

namespace DeratControl.Domain.Entities
{
    public class Organization : EntityBase<int>
    {
        private Organization()
        {
           
        }

        public Organization(string name, User user)
        {
            this.Name = name;

            this.CreatedBy = user.Id;
        }

        public string Name { get;  set; }

        public virtual ICollection<User> ContactPeople { get; protected set; } = new HashSet<User>();

        public virtual ICollection<Facility> Facilities { get; protected set; } = new HashSet<Facility>();
    }
}
