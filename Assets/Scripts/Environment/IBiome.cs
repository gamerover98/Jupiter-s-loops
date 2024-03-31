using System.Collections.Generic;
using Environment.Collectible;

namespace Environment
{
    public interface IBiome<out TPortal, out TCapsule>
        where TPortal : IPortal
        where TCapsule : ICapsule
    {
        TPortal GetEntryPortal();

        TPortal GetExitPortal();

        IEnumerable<TCapsule> GetCapsules();
    }
}