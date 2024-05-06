using Api.Common;

namespace Api.Entity
{
    public interface IIceCrystal<TVector2, in TTrigger> : IEnemy<TVector2>, ITriggerable<TTrigger>, IResettable
    {
        // nothing to do.
    }
}