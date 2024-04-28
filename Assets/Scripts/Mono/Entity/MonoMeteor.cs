using Api.Entity;
using UnityEngine;

namespace Mono.Entity
{
    [RequireComponent(typeof(Collider))]
    public class MonoMeteor : MonoBehaviour, IMeteor<Vector2, GameObject>
    {
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

        public void RequireReset() => SetActive(true);
        
        public void OnTrigger(GameObject withObject)
        {
            SetActive(false);
            //TODO: Start the explosion of the meteor.
            //TODO: Damage/destroy the ship.
        }
    }
}