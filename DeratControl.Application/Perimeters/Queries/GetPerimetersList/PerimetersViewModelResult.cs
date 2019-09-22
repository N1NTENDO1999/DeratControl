using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Perimeters.Queries.GetPerimetersList
{
    public class PerimetersViewModelResult : IQueryResult
    {
        public Perimeter Perimeter { get; set; } 
       
    }
}
