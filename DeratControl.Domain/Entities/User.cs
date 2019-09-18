using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class User : EntityBase<int>
    {
<<<<<<< HEAD

        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public string Address { get; private set; }
        public int Phone { get; private set; }
        public string Email { get;private set; }

        public int? OrganizationId { get;private set; }
        public virtual Organization Organization { get;private set; }
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

=======
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual Organization Organization { get; set; }
>>>>>>> Fixed problems

        public virtual UserRole UserRole { get; set; }

        private User()
        {

        }

        public User(string firstName, string lastName, string address, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
        }

    }
}
