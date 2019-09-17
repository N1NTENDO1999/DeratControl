using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Users
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
      

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Address)}: {Address}";
        }
    }

   
}
