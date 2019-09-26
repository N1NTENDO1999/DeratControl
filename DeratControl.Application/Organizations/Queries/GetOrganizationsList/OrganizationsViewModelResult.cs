using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Organizations.Queries.GetOrganizationsList
{
    public class OrganizationsViewModelResult : IQueryResult
    {
        public ICollection<Organization> Organizations { get; set; }
    }
}
