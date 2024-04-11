using Api.Entity;
using UnityEngine;

namespace Mono.Entity
{
    public abstract class MonoPlayer : MonoBehaviour, IPlayer<Vector2>
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;
        
        public bool IsActive() => gameObject.activeSelf;
        public void SetActive(bool active) => gameObject.SetActive(active);

        public int GetHealth() => health;

        public void SetHealth(int value)
        {
            if (value > GetMaxHealth()) value = GetMaxHealth();
            health = value;
        }

        public int GetMaxHealth() => maxHealth;

        public void SetMaxHealth(int maxValue)
        {
            maxHealth = maxValue;
            if (health > maxHealth) health = maxHealth;
        }

        public bool IsDead() => health <= 0;

        public virtual void Teleport(Vector2 position) => transform.position = position;
    }
}