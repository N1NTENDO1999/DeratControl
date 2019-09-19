using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Perimeters.Queries.GetPerimeterIndividual
{
    public class PerimeterIndividualViewModel : IQueryResult
    {

        public virtual Facility Facility { get; set; }

        public PerimeterType PerimeterType { get; set; }

        public virtual ICollection<Point> TrapPoints { get; protected set; } = new HashSet<Point>();

        public PerimeterIndividualViewModel(Facility facility, PerimeterType perimeterType, ICollection<Point> trapPoints)
        {
            this.Facility = facility;
            this.PerimeterType = perimeterType;
            this.TrapPoints = trapPoints;
        }
    }
}
