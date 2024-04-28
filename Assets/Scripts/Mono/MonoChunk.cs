using Api;
using Mono.Entity;
using UnityEngine;

namespace Mono
{
    [RequireComponent(typeof(Collider))]
    public class MonoChunk : MonoBehaviour, IChunk<GameObject, Collision>
    {
        public void OnCollide(GameObject colliderObject, Collision collision)
        {
            if (colliderObject == null) return;
            if (colliderObject.TryGetComponent(out MonoPlayer monoPlayer))
            {
                Debug.Log($"MonoChunk: {monoPlayer.name}");
                //monoPlayer.RigidBody.velocity += ...
                //TODO: Damage/destroy the ship.
            }
        }
    }
}