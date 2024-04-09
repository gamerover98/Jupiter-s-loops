using System.Collections.Generic;
using Api.Collectible;
using Api.Entity;

namespace Api
{
    public interface IBiome<out TPortal, out TCapsule, out TMeteor, out TVector2>
        where TPortal : IPortal
        where TCapsule : ICapsule
        where TMeteor : IMeteor
    {
        /// <returns>True if the biome is active in the scene.</returns>
        bool IsActive();

        /// <param name="active">Enable or disable this biome from the scene.</param>
        void SetActive(bool active);

        /// <summary>Reset the current biome instance.</summary>
        void ResetBiome();

        /// <returns>The relative spawn position for the player</returns>
        TVector2 GetPlayerSpawnPosition();

        /// <returns>The relative spawn position for the next adjacent biome</returns>
        TVector2 GetNextBiomeSpawnPosition();

        /// <returns>The entry portal instance</returns>
        TPortal GetEntryPortal();

        /// <returns>The exit portal instance</returns>
        TPortal GetExitPortal();

        /// <returns>A collection of capsule instances.</returns>
        IEnumerable<TCapsule> GetCapsules();

        /// <returns>A collection of meteors instances.</returns>
        IEnumerable<TMeteor> GetMeteors();
    }
}