using System.Collections.Generic;
using Api.Manager;
using Mono.Collectible;
using Mono.Entity;
using UnityEngine;

namespace Mono.Manager
{
    public class MonoBiomeManager :
        MonoBehaviour,
        IBiomeManager<MonoBiome, MonoPortal, MonoCapsule, MonoMeteor>
    {
        [SerializeField] private List<MonoBiome> biomes;

        public IEnumerable<MonoBiome> GetBiomes() => biomes;
    }
}