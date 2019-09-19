using DeratControl.Domain.Root;
using System;

namespace DeratControl.Domain.Entities
{
    public enum TrapType
    {
        DisinfestationContainer,
        Traps,
        GreaseTrap,
        CombinedTrap,
        UniversalTrap,
        TemporaryTrap,
        InsecticidalLamp,
        Detector
    }

    public class Trap : EntityBase<int>
    {
        public string Data { get; set; }
        public virtual Point TrapPoint { get; set; }
        public TrapType TrapType { get; set; }

        public Trap(Point point, string data, TrapType trapType, User user)
        {
            TrapPoint = point;
            Data = data;
            TrapType = trapType;
            CreatedAt = DateTime.Now;
            CreatedBy = user.Id;
        }

        private Trap()
        {

        }
    }
}
