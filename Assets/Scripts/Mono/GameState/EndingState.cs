using Api;
using Mono.Manager;
using UnityEngine;

namespace Mono.GameState
{
    public class EndingState : GenericGameState
    {
        public override void Start()
        {
            base.Start();
            Time.timeScale = 0;

            Debug.Log("Game Over!");
            var playerManager = MonoGameManager.GetPlayerManager();
            
            ScoreboardManager
                .SaveGame(
                    playerManager.Capsules,
                    playerManager.Distance);

            IsEnding = true;
        }

        public override GameStateType? GetNext() => null;
    }
}