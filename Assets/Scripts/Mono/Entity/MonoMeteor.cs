using Api.Entity;
using UnityEngine;

namespace Mono.Entity
{
    public class MonoMeteor : MonoBehaviour, IMeteor<Vector2>
    {
        public bool IsActive() => gameObject.activeSelf;
        public void SetActive(bool active) => gameObject.SetActive(active);
        
        public void Teleport(Vector2 position)
        {
            transform.position = position;
        }
    }
}