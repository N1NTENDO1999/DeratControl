using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Application.Interfaces;
using DeratControl.Domain.Root;

namespace DeratControl.Application.Organizations.Queries.GetOrganizationsList
{
    public class GetOrganizationsQuery : IRequest
    {
        public int OrganizationID { get; set; }
    }


}
