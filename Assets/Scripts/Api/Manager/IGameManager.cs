﻿namespace Api.Manager
{
    public interface IGameManager
    {
        /// <summary>The game state.</summary>
        /// <returns>The current game state</returns>
        GameState GetGameState();
    }

    public enum GameState
    {
        /// <summary>
        /// During this state the game is loading the scene.
        /// <para>The next state must be the playing state.</para>
        /// </summary>
        Loading,

        /// <summary>
        /// During this state the game is running.
        /// <para>The next state can be pause or end state.</para>
        /// </summary>
        Playing,

        /// <summary>
        /// During this state the game is paused.
        /// <para>The next state can be playing or end state.</para>
        /// </summary>
        Pause,

        /// <summary>
        /// Defines the end of the game.
        /// <para>There are no next states.</para>
        /// </summary>
        Ending
    }
}