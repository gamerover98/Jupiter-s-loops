namespace Api.Entity
{
    public interface IEntity<in TVector2>
    {
        /// <returns>True if the biome is active in the scene.</returns>
        bool IsActive();

        /// <param name="active">Enable or disable this biome from the scene.</param>
        void SetActive(bool active);

        /// <summary>Change the entity position.</summary>
        /// <param name="position">The new entity position.</param>
        void Teleport(TVector2 position);
    }
}