using Api.Manager;
using Mono.Entity;
using UnityEngine;

namespace Mono.Manager
{
    public class MonoGameManager : MonoBehaviour, IGameManager<MonoShip>
    {
        public static MonoGameManager Instance;

        [SerializeField] private MonoShip ship;
        public MonoShip GetPlayer() => ship;

        private GameState _gameState;
        public GameState GetGameState() => _gameState;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            _gameState = GameState.Loading;
        }

        private void Start()
        {
            //TODO: place the starting biome and the player.
            _gameState = GameState.Playing;
        }
    }
}