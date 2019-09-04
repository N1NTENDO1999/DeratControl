using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;

namespace DeratControl.Domain.Entities
{
    class Trap : EntityBase<int>
    {
        public string Data { get; set; }
        public virtual Point TrapPoint { get; set; }
        public string TrapType { get; set; }
    }
}
