﻿using DeratControl.Domain.Root;
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
        public int FacilityId { get; set; }

        public virtual Facility Facility { get; set; }

        public PerimeterType PerimeterType { get; set; }

        public virtual ICollection<Point> TrapPoints { get; protected set; } = new HashSet<Point>();

        private Perimeter()
        {
        }

        public Perimeter(Facility facility, PerimeterType perimeterType, int createdBy)
        {
            this.Facility = facility;
            this.PerimeterType = perimeterType;
            this.CreatedBy = createdBy;
            this.CreatedAt = DateTime.Now;
        }
    }
}
