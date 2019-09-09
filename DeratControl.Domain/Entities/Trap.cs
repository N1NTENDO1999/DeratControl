using DeratControl.Domain.Root;

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

        private Trap()
        {

        }
    }
}
