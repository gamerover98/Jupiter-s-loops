namespace Api.Collectible
{
    public interface ICapsule<in TTrigger> : ICollectible<TTrigger>
    {
        /// <returns>True if the biome is active in the scene.</returns>
        bool IsActive();

        /// <param name="active">Enable or disable this biome from the scene.</param>
        void SetActive(bool active);
    }
}