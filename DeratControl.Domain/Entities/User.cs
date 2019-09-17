using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class User : EntityBase<int>
    {
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public string Address { get; private set; }
        public int Phone { get; private set; }
        public string Email { get;private set; }

        public int? OrganizationId { get;private set; }
        public virtual Organization Organization { get;private set; }
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        private User()
        {

        }
    }
}
