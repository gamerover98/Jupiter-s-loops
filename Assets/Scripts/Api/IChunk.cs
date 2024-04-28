using Api.Common;

namespace Api
{
    public interface IChunk<in TCollider, in TCollision> : ICollidable<TCollider, TCollision>
    {
        //TODO: not implemented yet.
    }
}