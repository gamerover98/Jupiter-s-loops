using System.Collections.Generic;
using System.Linq;
using Mono.Entity;

namespace Mono.BiomeVariants
{
    public class MonoIceBiome : MonoBiome
    {
        private List<MonoIceCrystal> iceCrystals = new();
        public IEnumerable<MonoIceCrystal> GetIceCrystals() => iceCrystals;

        protected override void Start()
        {
            base.Start();
            iceCrystals =
                transform
                    .GetComponentsInChildren<MonoIceCrystal>(true)
                    .ToList();
        }

        public override void ResetBiome()
        {
            base.ResetBiome();
            if (iceCrystals != null)
                foreach (var monoIceCrystal in iceCrystals)
                    monoIceCrystal.RequireReset();
        }
    }
}