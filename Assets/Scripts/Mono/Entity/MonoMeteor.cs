using Api.Entity;
using Mono.Manager;
using UnityEngine;

namespace Mono.Entity
{
    [RequireComponent(typeof(Collider))]
    public class MonoMeteor : MonoBehaviour, IMeteor<Vector2, GameObject>
    {
        [SerializeField] private int damage = 1;

        public bool IsActive() => gameObject.activeSelf;
        public void SetActive(bool active) => gameObject.SetActive(active);

        public void Teleport(Vector2 position)
        {
            transform.position = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            //TODO: must be implemented.
        }

        public Vector2 GetVelocity()
        {
            //TODO: must be implemented.
            return transform.position;
        }

        public void OnTrigger(GameObject withObject)
        {
            if (!IsActive()
                || withObject == null)
                return;

            if (withObject.TryGetComponent(out MonoPlayer monoPlayer))
            {
                MonoGameManager.GetEventManager().meteorCollisionEvent?.Invoke();
                monoPlayer.TryToDoDamage(damage);
            }

            SetActive(false);
        }
        
        public void RequireReset() => SetActive(true);
    }
}