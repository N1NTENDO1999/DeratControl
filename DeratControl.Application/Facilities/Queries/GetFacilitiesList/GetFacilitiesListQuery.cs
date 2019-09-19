using DeratControl.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Facilities.Queries.GetFacilitiesList
{
    class GetFacilitiesListQuery : IRequest
    {
        public int OrganizationId { get; set; }
    }
}
