using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;

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
        public int FacilityId { get; protected set; }
        public virtual Facility Facility { get; protected set; }
        public PerimeterType PerimeterType { get; protected set; }
        public virtual IEnumerable<Point> TrapPoints { get; protected set; }
        private Perimeter()
        {
            this.TrapPoints = new List<Point>();
        }
        public Perimeter(Facility facility, PerimeterType perimeterType, int createdBy)
        {
            this.FacilityId = FacilityId;
            this.Facility = facility;
            this.PerimeterType = perimeterType;
            this.CreatedBy = createdBy;
            this.CreatedAt = DateTime.Now;
        }
        public Perimeter(int facilityId, PerimeterType perimeterType)
        {
            this.FacilityId = facilityId;
            this.PerimeterType = perimeterType;
        }
    }
}
