using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Points.Queries.GetPointsByPerimeter
{
   public class PointsViewModelResult:IQueryResult
    {
        public ICollection<Point> Points { get; set; }
    }
}
