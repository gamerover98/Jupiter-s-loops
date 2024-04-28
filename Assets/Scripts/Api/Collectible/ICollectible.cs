using Api.Common;

namespace Api.Collectible
{
    public interface ICollectible<in TTrigger> : ITriggerable<TTrigger>, IResettable
    {
        // Nothing to do.
    }
}