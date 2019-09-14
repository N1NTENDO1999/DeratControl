using DeratControl.Application.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Facilities
{
    public class AddFacilityCommand : IRequest
    {
        public int OrganizationId { get; private set; }

        public Organization Organization { get; private set; }

        public string Address { get; private set; }
    }
}
