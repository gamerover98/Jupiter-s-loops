namespace Api.Manager
{
    public interface IGameState
    {
        /// <summary>Invoked at the beginning of the lifecycle.</summary>
        void Start();

        /// <summary>Invoked every frame.</summary>
        void Update();

        /// <summary>Invoked at the end of the lifecycle.</summary>
        void End();

        /// <summary>Returns the next game state (possible null).</summary>
        GameStateType? GetNext();
    }
    
    public enum GameStateType
    {
        /// <summary>
        /// During this state the game is starting the scene.
        /// <para>The next state must be the 'playing' state.</para>
        /// </summary>
        Starting,

        /// <summary>
        /// During this state the game is running.
        /// <para>The next state can be 'pause' or 'end' state.</para>
        /// </summary>
        Playing,
        
        /// <summary>
        /// Defines the end of the game.
        /// <para>There are no next states.</para>
        /// </summary>
        Ending
    }
}