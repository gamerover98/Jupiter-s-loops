using System.Collections.Generic;
using Environment.Collectible;
using UnityEngine;

namespace Environment
{
    public class MonoBiome : MonoBehaviour, IBiome<MonoPortal, MonoCapsule>
    {
        [SerializeField] private MonoPortal entryPortal;
        [SerializeField] private MonoPortal exitPortal;
        [SerializeField] private List<MonoCapsule> capsules = new();
        
        public MonoPortal GetEntryPortal() => entryPortal;
        public MonoPortal GetExitPortal() => exitPortal;
        public IEnumerable<MonoCapsule> GetCapsules() => capsules;
        
    }
}