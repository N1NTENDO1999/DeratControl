using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class UserRole
    { 
        public int RoleId { get; protected set; }
        public string RoleName { get; set; }

        private readonly Dictionary<int, string> roles = new Dictionary<int, string>
        {
            {0,"Customer"},
            {1,"Admin"},
            {2,"Employee"}
        };

        public UserRole(string RoleName)
        {
            var roleName = IsValid(RoleName);
            if (roleName.Value != null)
            {
                this.RoleName = roleName.Value;
                RoleId = roleName.Key;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private KeyValuePair<int,string> IsValid(string roleName)
        {
            return roles.Where(x => x.Value == roleName).FirstOrDefault();
        }

    }
}
