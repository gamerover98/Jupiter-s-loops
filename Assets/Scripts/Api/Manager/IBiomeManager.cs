using System.Collections.Generic;
using Api.Collectible;
using Api.Entity;

namespace Api.Manager
{
    public interface IBiomeManager<out TBiome, out TPortal, out TCapsule, out TMeteor>
        where TBiome : IBiome<TPortal, TCapsule, TMeteor>
        where TPortal : IPortal
        where TCapsule : ICapsule
        where TMeteor : IMeteor
    {
        IEnumerable<TBiome> GetBiomes();
    }
}