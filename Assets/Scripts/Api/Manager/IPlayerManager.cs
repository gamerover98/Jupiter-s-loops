using Api.Entity;

namespace Api.Manager
{
    public interface IPlayerManager<out TPlayer, out TCamera, in TVector2>
        where TCamera : ICamera<TVector2>
        where TPlayer : IPlayer<TVector2, TCamera>
    {
        /// <summary>The player instance.</summary>
        /// <returns>The current player instance</returns>
        TPlayer GetPlayer();

        /// <summary>The game camera.</summary>
        /// <returns>The game camera instance.</returns>
        TCamera GetCamera();
    }
}