using System.Linq;
using Api.Manager;

namespace Mono.Manager.GameState
{
    public class PlayingState : GenericGameState
    {
        public override void Start()
        {
            base.Start();
            IsUpdating = true;
        }

        public override void Update()
        {
            base.Update();
            
            CheckPlayer();
            CheckLevel();
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