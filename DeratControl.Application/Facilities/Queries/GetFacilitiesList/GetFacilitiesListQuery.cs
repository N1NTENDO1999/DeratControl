using DeratControl.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Facilities.Queries.GetFacilitiesList
{
    public class GetFacilitiesListQuery : IRequest
    {
        public int FacilityId { get; set; }
    }
}
