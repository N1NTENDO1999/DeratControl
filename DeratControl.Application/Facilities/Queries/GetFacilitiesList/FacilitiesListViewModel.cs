using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Facilities.Queries.GetFacilitiesList
{
    class FacilitiesListViewModel : IQueryResult
    {
        public ICollection<Facility> Facilities { get; set; }

    }
}
