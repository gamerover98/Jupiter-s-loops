namespace Api.Common
{
    /// <summary>Represents an object that can collide with another object of type TCollider.</summary>
    /// <typeparam name="TCollider">The type of collider.</typeparam>
    /// <typeparam name="TCollision">The type that implements a collision.</typeparam>
    public interface ICollidable<in TCollider, in TCollision>
    {
        /// <summary>Called when this object collides with another collider object.</summary>
        /// <param name="colliderObject">The collider object instance.</param>
        /// <param name="collision">The collision object instance.</param>
        void OnCollide(TCollider colliderObject, TCollision collision);
    }
}