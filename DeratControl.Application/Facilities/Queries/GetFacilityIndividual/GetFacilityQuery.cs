using DeratControl.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Facilities.Queries.GetFacilitiesList
{
    public class GetFacilityQuery : IRequest
    {
        public int OrganizationId { get; set; }
    }
}
