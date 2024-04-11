using Api.Manager;
using Mono.Entity;
using UnityEngine;

namespace Mono.Manager
{
    public class MonoGameManager : MonoBehaviour, IGameManager<MonoShip, Vector2>
    {
        public static MonoGameManager Instance;

        [SerializeField] private MonoShip ship;
        public MonoShip GetPlayer() => ship;

        private GameState gameState;
        public GameState GetGameState() => gameState;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            ship.SetActive(false);
            gameState = GameState.Loading;
        }

        private void Start()
        {
            //TODO: place the starting biome and the player.
            gameState = GameState.Playing;
        }
    }
}