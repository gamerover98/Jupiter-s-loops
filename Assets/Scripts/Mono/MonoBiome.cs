using System.Collections.Generic;
using Mono.Collectible;
using Mono.Entity;
using Mono.Manager;
using UnityEngine;
using IBiome =
    Api.IBiome<
        Mono.MonoPortal,
        Mono.Collectible.MonoCapsule,
        Mono.Entity.MonoMeteor,
        UnityEngine.Vector2,
        UnityEngine.GameObject>;

namespace Mono
{
    public class MonoBiome : MonoBehaviour, IBiome
    {
        [SerializeField] private GameObject playerSpawnPosition;
        public Vector2 GetPlayerSpawnPosition() => playerSpawnPosition.transform.position;

        [SerializeField] private GameObject biomeSpawnPosition;
        public Vector2 GetBiomeSpawnPosition() => biomeSpawnPosition.transform.position;

        [SerializeField] private GameObject nextBiomeSpawnPosition;
        public Vector2 GetNextBiomeSpawnPosition() => nextBiomeSpawnPosition.transform.position;

        [SerializeField] private MonoPortal entryPortal;
        public MonoPortal GetEntryPortal() => entryPortal;

        [SerializeField] private MonoPortal exitPortal;
        public MonoPortal GetExitPortal() => exitPortal;

        [SerializeField] private List<MonoCapsule> capsules = new();
        public IEnumerable<MonoCapsule> GetCapsules() => capsules;

        [SerializeField] private List<MonoMeteor> meteors = new();
        public IEnumerable<MonoMeteor> GetMeteors() => meteors;

        public bool IsActive() => gameObject.activeSelf;
        public void SetActive(bool active) => gameObject.SetActive(active);

        protected void Awake()
        {
            exitPortal.SetActive(false);
        }

        public void ResetBiome()
        {
            if (capsules != null)
                foreach (var monoCapsule in capsules)
                    monoCapsule.RequireReset();
            
            if (meteors != null)
                foreach (var monoMeteor in meteors)
                    monoMeteor.RequireReset();

            entryPortal.RequireReset();
            exitPortal.RequireReset();
        }

        public void Despawn()
        {
            ResetBiome();
            SetActive(false);
        }

        public void SpawnNext(MonoBiome nextBiome, bool firstSpawn)
        {
            if (firstSpawn)
            {
                transform.position = biomeSpawnPosition.transform.position;
                var player = MonoGameManager.Instance.playerManager.GetPlayer();
                player.Teleport(playerSpawnPosition.transform.position);
                player.SetActive(true);
            }

            SetActive(true);

            nextBiome.transform.position =
                nextBiomeSpawnPosition.transform.position
                + (nextBiome.transform.position - nextBiome.biomeSpawnPosition.transform.position);
            nextBiome.SetActive(true);
        }
    }
}