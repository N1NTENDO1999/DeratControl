using DeratControl.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Points.Commands.AddPoint
{
   public class AddPointCommand:IRequest
    {
        public int PerimeterId { get; set; }

        public string Location { get; set; }
    }
}
