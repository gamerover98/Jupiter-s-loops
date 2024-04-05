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

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
    }
}