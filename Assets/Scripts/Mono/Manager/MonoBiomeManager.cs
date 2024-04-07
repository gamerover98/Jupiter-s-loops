using System;
using System.Collections.Generic;
using System.Linq;
using Api.Common;
using UnityEngine;
using IBiomeManager =
    Api.Manager.IBiomeManager<
        Mono.MonoBiome,
        Mono.MonoPortal,
        Mono.Collectible.MonoCapsule,
        Mono.Entity.MonoMeteor>;
using IBiomeSettings =
    Api.Manager.IBiomeSettings<
        Mono.MonoBiome,
        Mono.MonoPortal,
        Mono.Collectible.MonoCapsule,
        Mono.Entity.MonoMeteor>;

namespace Mono.Manager
{
    public class MonoBiomeManager : MonoBehaviour, IBiomeManager
    {
        [SerializeField] private List<MonoBiomeSettings> biomes;
        public IEnumerable<IBiomeSettings> GetBiomesSettings() => biomes;

        private readonly CustomRandom _random = new();

        public MonoBiome GetRandomBiome()
        {
            var weightedItems = GetBiomesSettings().ToList();

            switch (weightedItems.Count)
            {
                case 0: return default;
                case 1: return weightedItems[0].GetBiome();
            }

            var randomWeight = _random.NumberInRange(0, GetTotalWeight());
            var weightingSum = 0;

            foreach (var currentItem in weightedItems)
            {
                weightingSum += currentItem.GetWeight();

                if (randomWeight < weightingSum)
                {
                    return currentItem.GetBiome();
                }
            }

            return weightingSum == 0 ? default : weightedItems[^1].GetBiome();
        }

        private int GetTotalWeight() =>
            GetBiomesSettings()
                .Sum(settings => settings.GetWeight());

        [Serializable]
        public class MonoBiomeSettings : IBiomeSettings
        {
            [SerializeField] private MonoBiome biome;
            [SerializeField] private int weight;

            public MonoBiomeSettings(MonoBiome biome, int weight = 50)
            {
                this.biome = biome;
                this.weight = weight;
            }

            public MonoBiome GetBiome() => biome;
            public int GetWeight() => weight;
            
            public override string ToString()
            {
                return $"Biome: {biome.name}, Weight: {weight}";
            }
        }
    }
}