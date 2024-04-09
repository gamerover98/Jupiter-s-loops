using System.Collections.Generic;
using Mono.Collectible;
using Mono.Entity;
using UnityEngine;
using IBiome =
    Api.IBiome<
        Mono.MonoPortal,
        Mono.Collectible.MonoCapsule,
        Mono.Entity.MonoMeteor>;

namespace Mono
{
    public class MonoBiome : MonoBehaviour, IBiome
    {
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

        public void ResetBiome()
        {
            //TODO: reset all capsules, meteors, etc.
        }
    }
}