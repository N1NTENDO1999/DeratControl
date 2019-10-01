using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public class Facility : EntityBase<int>
    {
        public string Address { get; private set; }
        public int OrganizationId { get; private set; }
        public virtual Organization Organization { get; private set; }
        public virtual ICollection<Perimeter> Perimeters { get; private set; } = new HashSet<Perimeter>();
        public virtual ICollection<Review> Reviews { get; private set; } = new HashSet<Review>();

        private Facility()
        {
        }

        public Facility(int organizationId, string address, int createdBy)
        {
            this.OrganizationId = organizationId;
            this.Address = address;
            this.CreatedBy = createdBy;
            this.CreatedAt = DateTime.Now;
        }
        
        public Perimeter AddPerimeter(PerimeterType perimeterType, User user)
        {
            var perimeterExists = this.Perimeters.Any(f => f.PerimeterType == perimeterType);
            if (perimeterExists)
            {
                throw new PerimeterAlreadyExistsException("Current perimeter already exists", StatusCodes.Status400BadRequest);
            }

            var newPerimeter = new Perimeter(this, perimeterType, user.Id);
            this.Perimeters.Add(newPerimeter);
            return newPerimeter;
         }
    }
}
