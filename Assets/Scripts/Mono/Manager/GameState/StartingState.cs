using Api.Manager;

namespace Mono.Manager.GameState
{
    public class StartingState : GenericGameState
    {
        public override void Start()
        {
            base.Start();
            MonoGameManager.GetInputManager().Active = false;
            
            MonoGameManager.GetEventManager().startingCountdownStartEvent?.Invoke();
            MonoGameManager.GetEventManager().startingCountdownEndEvent.AddListener(() => IsEnding = true);
        }

        public override void End()
        {
            base.End();
            MonoGameManager.GetInputManager().Active = true;
        }

        public override GameStateType? GetNext() => GameStateType.Playing;
    }
}