using Api;
using Mono.Manager;

namespace Mono.GameState
{
    public class StartingState : GenericGameState
    {
        public override void Start()
        {
            base.Start();
            MonoGameManager.GetInputManager().ActivePlayerMovements = false;
            
            MonoGameManager.GetEventManager().startingCountdownStartEvent?.Invoke();
            MonoGameManager.GetEventManager().startingCountdownEndEvent.AddListener(() => IsEnding = true);
        }

        public override void End()
        {
            base.End();
            MonoGameManager.GetInputManager().ActivePlayerMovements = true;
        }

        public override GameStateType? GetNext() => GameStateType.Playing;
    }
}