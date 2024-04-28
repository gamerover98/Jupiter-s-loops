using Api.Common;

namespace Api.Entity
{
    public interface IMeteor<TVector2, in TTrigger> : IEnemy<TVector2>, ITriggerable<TTrigger>, IResettable
    {
        // nothing to do.
    }
}