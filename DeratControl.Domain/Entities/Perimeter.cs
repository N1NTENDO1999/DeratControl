using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;
namespace DeratControl.Domain.Entities
{
    public enum PerimeterType
    {
        Internal,
        External,
        Third
    }
    class Perimeter : EntityBase<int>
    {
        public Facility Facility { get; set; }
        public PerimeterType PerimeterType { get; set; }
        public List<Point> TrapPoints { get; set; }
        public Perimeter()
        {
            TrapPoints = new List<Point>();
        }
    }
}
