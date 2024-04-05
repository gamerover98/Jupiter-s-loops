using Api.Entity;

namespace Api.Manager
{
    public interface IGameManager<out TPlayer> where TPlayer : IPlayer
    {
        TPlayer GetPlayer();
    }
}