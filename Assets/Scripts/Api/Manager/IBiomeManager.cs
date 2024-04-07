using System.Collections.Generic;
using System.Linq;
using Api.Collectible;
using Api.Common;
using Api.Entity;

namespace Api.Manager
{
    public interface IBiomeManager<out TBiome, out TPortal, out TCapsule, out TMeteor>
        where TBiome : IBiome<TPortal, TCapsule, TMeteor>
        where TPortal : IPortal
        where TCapsule : ICapsule
        where TMeteor : IMeteor
    {
        /// <summary>
        /// The collection of biome settings.
        /// </summary>
        /// <returns>An enumerable collection of biome settings.</returns>
        public IEnumerable<IBiomeSettings<TBiome, TPortal, TCapsule, TMeteor>> GetBiomesSettings();

        /// <returns>A random biome settings.</returns>
        public TBiome GetRandomBiome();
    }

    public interface IBiomeSettings<out TBiome, out TPortal, out TCapsule, out TMeteor>
        where TBiome : IBiome<TPortal, TCapsule, TMeteor>
        where TPortal : IPortal
        where TCapsule : ICapsule
        where TMeteor : IMeteor
    {
        /// <summary>
        /// The biome instance.
        /// </summary>
        public TBiome GetBiome();

        /// <summary>
        /// The value for the weighted average.
        /// </summary>
        public int GetWeight();
    }
}