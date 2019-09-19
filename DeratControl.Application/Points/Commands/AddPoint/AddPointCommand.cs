using DeratControl.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Points.Commands.AddPoint
{
   public class PointDto
   {
        public string Location { get; set; }

        public int Order { get; set; }

    }

   public class AddPointsCommand:IRequest
    {
        public int PerimeterId { get; set; }

        public List<PointDto> Points { get; set; }
    }
}
