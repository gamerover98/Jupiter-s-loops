using Api.Common;

namespace Api.Collectible
{
    public interface ICollectible<in TCollider> : ICollidable<TCollider>, IResettable
    {
        // Nothing to do.
    }
}