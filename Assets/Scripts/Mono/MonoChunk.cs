using Api;
using Mono.Entity;
using UnityEngine;

namespace Mono
{
    [RequireComponent(typeof(Collider))]
    public class MonoChunk : MonoBehaviour, IChunk<GameObject>
    {
        public void OnCollide(GameObject colliderObject)
        {
            if (colliderObject == null) return;
            if (colliderObject.TryGetComponent(out MonoPlayer monoPlayer))
            {
                //TODO: Damage/destroy the ship.
            }
        }
    }
}