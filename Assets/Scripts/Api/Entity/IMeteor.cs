using Api.Common;

namespace Api.Entity
{
    public interface IMeteor<TVector2> : IEnemy<TVector2>, IResettable
    {
        // nothing to do.
    }
}