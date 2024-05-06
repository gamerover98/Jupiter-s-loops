using System;
using System.Collections.Generic;
using System.Linq;
using Api.Common;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using IBiomeManager =
    Api.Manager.IBiomeManager<
        Mono.MonoBiome,
        Mono.MonoPortal,
        Mono.Collectible.MonoCapsule,
        Mono.Entity.MonoMeteor,
        UnityEngine.Vector2,
        UnityEngine.GameObject>;
using IBiomeSettings =
    Api.Manager.IBiomeSettings<
        Mono.MonoBiome,
        Mono.MonoPortal,
        Mono.Collectible.MonoCapsule,
        Mono.Entity.MonoMeteor,
        UnityEngine.Vector2,
        UnityEngine.GameObject>;

namespace Mono.Manager
{
    public class MonoBiomeManager : MonoBehaviour, IBiomeManager
    {
        private CustomRandom random;

        [SerializeField] private bool randomSeed;

        [Tooltip("A number used to calculate a starting value for the pseudo-random number sequence.")] [SerializeField]
        private int seed;

        [SerializeField] private List<MonoBiomeSettings> biomesSettings;
        public IEnumerable<IBiomeSettings> GetBiomesSettings() => biomesSettings;

        private MonoBiome toBeRemoved;
        private MonoBiomeSettings previousBiomeSettings;
        private MonoBiomeSettings currentBiomeSettings;
        private MonoBiomeSettings nextBiomeSettings;

        public IBiomeSettings GetCurrentBiome() => currentBiomeSettings;
        public IBiomeSettings GetNextBiome() => nextBiomeSettings;

        private void Awake()
        {
            random =
                randomSeed
                    ? new CustomRandom()
                    : new CustomRandom(seed);

            // spawn and replace the prefab to real game-object instances.
            foreach (var biomeSettings in biomesSettings)
            {
                var biomeObject =
                    Instantiate(
                        biomeSettings.GetBiome(), //prefabs
                        Vector3.zero,
                        Quaternion.identity,
                        transform);
                biomeObject.SetActive(false);
                biomeSettings.SetBiome(biomeObject);
            }

            currentBiomeSettings = GetRandomBiomeSettings() as MonoBiomeSettings;
            nextBiomeSettings = GetRandomBiomeSettings() as MonoBiomeSettings;

            if (currentBiomeSettings == null) Debug.LogWarning("The current biome settings is null");
            if (nextBiomeSettings == null) Debug.LogWarning("The next biome settings is null");

            if (currentBiomeSettings != null && currentBiomeSettings.Equals(nextBiomeSettings))
                Debug.LogWarning("Current and next biomes shouldn't be the same instance!");
        }

        private void Start()
        {
            if (currentBiomeSettings != null && nextBiomeSettings != null)
                currentBiomeSettings.GetBiome().SpawnNext(nextBiomeSettings.GetBiome(), true);
        }

        [ProButton]
        public void NextLevel()
        {
            toBeRemoved?.Despawn();
            toBeRemoved = previousBiomeSettings?.GetBiome();

            previousBiomeSettings = currentBiomeSettings;
            currentBiomeSettings = nextBiomeSettings;
            nextBiomeSettings = GetRandomBiomeSettings() as MonoBiomeSettings;
            currentBiomeSettings.GetBiome().SpawnNext(nextBiomeSettings!.GetBiome(), false);

            // Disable the entry portal to grant the access to the next biome.
            previousBiomeSettings.GetBiome().GetEntryPortal().SetActive(false);
            previousBiomeSettings.GetBiome().GetExitPortal().SetActive(false);
            currentBiomeSettings.GetBiome().GetExitPortal().SetActive(false);

            MonoGameManager.GetGuiMenuManager().gameGUI.ResetCapsules();
        }

        [ProButton]
        private void CatchUpAllCapsules()
        {
            if (currentBiomeSettings == null || currentBiomeSettings.GetBiome() == null) return;
            foreach (var monoCapsule in currentBiomeSettings.GetBiome().GetCapsules())
                monoCapsule.OnTrigger(gameObject);
        }

        public IBiomeSettings GetRandomBiomeSettings()
        {
            var weightedItems = GetBiomesSettings().ToList();
            if (currentBiomeSettings != null) weightedItems.Remove(currentBiomeSettings);
            if (previousBiomeSettings != null) weightedItems.Remove(previousBiomeSettings);

            switch (weightedItems.Count)
            {
                case 0: return default;
                case 1: return weightedItems[0];
            }

            var totalWeight = GetBiomesSettings().Sum(settings => settings.GetWeight());
            var randomWeight = random.NumberInRange(0, totalWeight);
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
        internal void SetBiome(MonoBiome newBiome) => biome = newBiome;

        public int GetWeight() => weight;

        public override string ToString()
        {
            return $"Biome: {biome.name}, Weight: {weight}";
        }
    }
}