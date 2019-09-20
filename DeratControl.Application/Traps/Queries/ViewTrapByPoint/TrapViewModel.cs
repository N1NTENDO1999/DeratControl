using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Traps.Queries.ViewTrapByPoint
{
    public class TrapViewModelResult : IQueryResult
    {
        public Trap Trap{ get; set; }
    }
}
