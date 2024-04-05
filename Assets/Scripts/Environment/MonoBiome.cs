using System.Collections.Generic;
using Environment.Collectible;
using Environment.Entity;
using UnityEngine;

namespace Environment
{
    public class MonoBiome : MonoBehaviour, IBiome<MonoPortal, MonoCapsule, MonoMeteor>
    {
        [SerializeField] private MonoPortal entryPortal;
        [SerializeField] private MonoPortal exitPortal;
        [SerializeField] private List<MonoCapsule> capsules = new();
        [SerializeField] private List<MonoMeteor> meteors = new();
        
        public MonoPortal GetEntryPortal() => entryPortal;
        public MonoPortal GetExitPortal() => exitPortal;
        public IEnumerable<MonoCapsule> GetCapsules() => capsules;
        public IEnumerable<MonoMeteor> GetMeteors() => meteors;
    }
}