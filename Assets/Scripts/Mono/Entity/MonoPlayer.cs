using Api.Entity;
using UnityEngine;

namespace Mono.Entity
{
    public abstract class MonoPlayer : MonoBehaviour, IPlayer<Vector2>
    {
        public bool IsActive() => gameObject.activeSelf;
        public void SetActive(bool active) => gameObject.SetActive(active);
        
        public virtual void Teleport(Vector2 position)
        {
            transform.position = position;
        }
    }
}