using Api.Entity;
using UnityEngine;

namespace Mono.Entity
{
    public class MonoIceCrystal : MonoBehaviour, IIceCrystal<Vector2>
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
    }
}