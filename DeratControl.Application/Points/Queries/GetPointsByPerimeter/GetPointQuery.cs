using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Application.Interfaces;

namespace DeratControl.Application.Points.Queries.GetPointsByPerimeter
{
    public class GetPointsQuery:IRequest
    {
        public int PerimeterId { get; set; }
    }
}
