using System.Collections.Generic;
using Api.Collectible;

namespace Api
{
    public interface IBiome<out TPortal, out TCapsule, out TMeteor>
        where TPortal : IPortal
        where TCapsule : ICapsule
    {

        /// <returns>True if the biome is active in the scene.</returns>
        bool IsActive();

        /// <param name="active">Enable or disable this biome from the scene.</param>
        void SetActive(bool active);
        
        /// <summary>
        /// Reset the current biome instance.
        /// </summary>
        void ResetBiome();
        
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