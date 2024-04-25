namespace Api.Entity
{
    public interface IEntity<TVector2>
    {
        /// <returns>True if the biome is active in the scene.</returns>
        bool IsActive();

        /// <param name="active">Enable or disable this biome from the scene.</param>
        void SetActive(bool active);

        /// <summary>Change the entity position.</summary>
        /// <param name="position">The new entity position.</param>
        void Teleport(TVector2 position);
        
        /// <summary>Sets the entity velocity.</summary>
        /// <param name="velocity">The new player velocity.</param>
        void SetVelocity(TVector2 velocity);

        /// <summary>Gets the entity velocity.</summary>
        /// <returns>The Vector velocity instance.</returns>
        TVector2 GetVelocity();
    }
}