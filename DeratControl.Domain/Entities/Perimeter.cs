using DeratControl.Domain.Root;
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
        Fence
    }
    public class Perimeter : EntityBase<int>
    {
        public virtual Facility Facility { get; set; }
        public PerimeterType PerimeterType { get; set; }
        public virtual IEnumerable<Point> TrapPoints { get; protected set; }
        private Perimeter()
        {
            this.TrapPoints = new List<Point>();
        }
    }
}
