using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Entities
{
    public enum PerimeterType
    {
        Internal,
        External,
        Third
    }
    class Perimeter
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public Facility Facility { get; set; }
        public PerimeterType PerimeterType { get; set; }
        public List<Point> TrapPoints { get; set; }
    }
}
