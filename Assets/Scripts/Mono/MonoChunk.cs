using Api;
using Mono.Entity;
using Mono.Manager;
using UnityEngine;

namespace Mono
{
    [RequireComponent(typeof(Collider))]
    public class MonoChunk : MonoBehaviour, IChunk<GameObject, Collision>
    {
        public void OnCollide(GameObject colliderObject, Collision collision)
        {
            if (colliderObject == null
                || !colliderObject.TryGetComponent(out MonoPlayer monoPlayer)) return;

            if (monoPlayer.TryToDoDamage())
            {
                MonoGameManager.GetEventManager().wallCollisionEvent?.Invoke();
            }
        }
    }
}