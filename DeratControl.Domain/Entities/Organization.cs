using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;

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

        public Facility AddFacility(string address, User user)
        {
            var facilityExists = this.Facilities.Any(o => o.Address == address);

            if (facilityExists)
            {
                throw new FacilityAlreadyExistsException();
            }

            var newFacility = new Facility(this.Id, address, user.Id);
            this.Facilities.Add(newFacility);
            return newFacility;
        }

        public void AddUser(User user)
        {
            ContactPeople.Add(user);
        }
    }
}
