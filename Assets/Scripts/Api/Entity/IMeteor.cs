using Api.Common;

namespace Api.Entity
{
    public interface IMeteor<in TVector2> : IEnemy<TVector2>, IResettable
    {
        // nothing to do.
    }
}