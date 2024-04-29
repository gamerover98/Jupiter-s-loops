using System.Linq;
using Api.Manager;
using UnityEngine;

namespace Mono.Manager
{
    public class MonoGameManager : MonoBehaviour, IGameManager
    {
        public static MonoGameManager Instance;

        [SerializeField] internal MonoBiomeManager biomeManager;
        [SerializeField] internal MonoPlayerManager playerManager;
        [SerializeField] internal MonoInputManager inputManager;
        [SerializeField] internal GUIMenuManager guiMenuManager;
        
        [SerializeField] public int startingTimeInSeconds = 3;
        
        private GameState gameState;
        public GameState GetGameState() => gameState;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            gameState = GameState.Loading;
        }

        private void Start()
        {
            //TODO: place the starting biome and the player.
            gameState = GameState.Playing;
        }

        public void CheckLevel()
        {
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