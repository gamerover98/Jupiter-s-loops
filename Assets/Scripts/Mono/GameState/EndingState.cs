using Api;
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
            IsEnding = true;
        }

        public override GameStateType? GetNext() => null;
    }
}