using System.Linq;
using Api;
using Mono.Manager;

namespace Mono.GameState
{
    public class PlayingState : GenericGameState
    {
        public override void Start()
        {
            base.Start();
            IsUpdating = true;
            MonoGameManager.GetEventManager().playingStartEvent?.Invoke();

            if (MonoGameManager.IsFirstGame)
            {
                MonoGameManager
                    .GetGuiMenuManager()
                    .tutorialMenu
                    .ShowCommandsSuggestions();
            }
        }

        public override void Update()
        {
            base.Update();
            
            CheckPlayer();
            CheckLevel();
        }

        public override void End()
        {
            base.End();
            MonoGameManager.GetEventManager().playingEndEvent?.Invoke();
        }

        public override GameStateType? GetNext() => GameStateType.Ending;

        private void CheckPlayer()
        {
            var player = MonoGameManager.GetPlayerManager().GetPlayer();
            if (!player.IsDead()) return;

            IsEnding = true;
        }
        
        private void CheckLevel()
        {
            var biomeManager = MonoGameManager.GetBiomeManager();
            var completed =
                biomeManager
                    .GetCurrentBiome()
                    .GetBiome()
                    .GetCapsules()
                    .All(monoCapsule => !monoCapsule.IsActive());

            if (completed) biomeManager.NextLevel();
        }
    }
}