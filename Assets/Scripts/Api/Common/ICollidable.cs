namespace Api.Common
{
    /// <summary>Represents an object that can collide with another object of type TCollider.</summary>
    /// <typeparam name="TCollider">The type of collider object.</typeparam>
    public interface ICollidable<in TCollider>
    {
        /// <summary>Called when this object collides with another collider object.</summary>
        /// <param name="colliderObject">The collider object with which this object collided.</param>
        void OnCollide(TCollider colliderObject);
    }
}