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
        private readonly CustomRandom _random = new();

        [SerializeField] private List<MonoBiomeSettings> biomes;
        public IEnumerable<IBiomeSettings> GetBiomesSettings() => biomes;

        private MonoBiomeSettings _currentBiomeSettings;
        public IBiomeSettings GetCurrentBiome() => _currentBiomeSettings;

        private MonoBiomeSettings _nextBiomeSettings;
        public IBiomeSettings GetNextBiome() => _nextBiomeSettings;

        private void Awake()
        {
            _currentBiomeSettings = GetRandomBiome() as MonoBiomeSettings;
            _nextBiomeSettings = GetRandomBiome() as MonoBiomeSettings;

            if (_currentBiomeSettings == null) Debug.LogWarning("The current biome settings is null");
            if (_nextBiomeSettings == null) Debug.LogWarning("The next biome settings is null");

            if (_currentBiomeSettings != null && _currentBiomeSettings.Equals(_nextBiomeSettings))
                Debug.LogWarning("Current and next biomes shouldn't be the same instance!");
        }

        public IBiomeSettings GetRandomBiome()
        {
            var weightedItems = GetBiomesSettings().ToList();
            if (_currentBiomeSettings != null) weightedItems.Remove(_currentBiomeSettings);

            switch (weightedItems.Count)
            {
                case 0: return default;
                case 1: return weightedItems[0];
            }

            var totalWeight = GetBiomesSettings().Sum(settings => settings.GetWeight());
            var randomWeight = _random.NumberInRange(0, totalWeight);
            var weightingSum = 0;

            foreach (var currentItem in weightedItems)
            {
                weightingSum += currentItem.GetWeight();
                if (randomWeight < weightingSum) return currentItem;
            }

            return weightingSum == 0 ? default : weightedItems[^1];
        }
    }

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