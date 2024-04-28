using System.Collections.Generic;
using Api.Collectible;
using Api.Entity;

namespace Api.Manager
{
    public interface IBiomeManager<
        out TBiome,
        out TPortal,
        out TCapsule,
        out TMeteor,
        out TVector2,
        out TTrigger>
        where TBiome : IBiome<TPortal, TCapsule, TMeteor, TVector2, TTrigger>
        where TPortal : IPortal
        where TCapsule : ICapsule<TTrigger>
        where TMeteor : IMeteor<TVector2, TTrigger>
    {
        /// <summary>
        /// The collection of biome settings.
        /// </summary>
        /// <returns>An enumerable collection of biome settings.</returns>
        public IEnumerable<IBiomeSettings<TBiome, TPortal, TCapsule, TMeteor, TVector2, TTrigger>> GetBiomesSettings();

        /// <summary>This is the biome where the player is.</summary>
        /// <returns>The not-null biome instance.</returns>
        public IBiomeSettings<TBiome, TPortal, TCapsule, TMeteor, TVector2, TTrigger> GetCurrentBiome();

        /// <summary>
        /// The next biome must be a different instance of the current biome.
        /// <para>
        /// NB: The next biome is always placed after the
        ///     current biome to give the sense of continuity.
        ///     When the player goes into this biome, this will be the current
        ///     and a next biome is placed.
        /// </para>
        /// </summary>
        /// <returns>The not-null biome instance.</returns>
        public IBiomeSettings<TBiome, TPortal, TCapsule, TMeteor, TVector2, TTrigger> GetNextBiome();

        /// <returns>A not-null random biome settings.</returns>
        public IBiomeSettings<TBiome, TPortal, TCapsule, TMeteor, TVector2, TTrigger> GetRandomBiomeSettings();
    }

    public interface IBiomeSettings<
        out TBiome,
        out TPortal,
        out TCapsule,
        out TMeteor,
        out TVector2,
        out TTrigger>
        where TBiome : IBiome<TPortal, TCapsule, TMeteor, TVector2, TTrigger>
        where TPortal : IPortal
        where TCapsule : ICapsule<TTrigger>
        where TMeteor : IMeteor<TVector2, TTrigger>
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