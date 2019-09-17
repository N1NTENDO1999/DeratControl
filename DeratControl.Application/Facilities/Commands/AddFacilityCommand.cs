using DeratControl.Application.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Facilities.Commands
{
    public class AddFacilityCommand : IRequest
    {
        public int OrganizationId { get; set; }
        
        public string Address { get; set; }
    }
}
