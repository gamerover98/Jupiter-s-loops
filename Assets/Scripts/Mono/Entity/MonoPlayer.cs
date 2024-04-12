using Api.Collectible;
using Api.Entity;
using UnityEngine;

namespace Mono.Entity
{
    [RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
    public abstract class MonoPlayer : MonoBehaviour, IPlayer<Vector2>
    {
        [SerializeField] protected int health;
        [SerializeField] protected int maxHealth;
        [SerializeField] protected Camera mainCamera;

        protected Rigidbody RigidBody { get; private set; }
        protected float CameraPadding;

        protected virtual void Awake()
        {
            RigidBody = GetComponent<Rigidbody>();
            CameraPadding = Mathf.Abs(RigidBody.position.x - mainCamera.transform.position.x);
        }

        protected virtual void Update()
        {
            var cameraTransform = mainCamera.transform;
            var cameraPosition = cameraTransform.position;

            var targetPosition =
                new Vector3(
                    gameObject.transform.position.x + CameraPadding,
                    gameObject.transform.position.y,
                    cameraPosition.z);

            cameraTransform.position = targetPosition;
        }
        
        public virtual bool IsActive() => gameObject.activeSelf;
        public virtual void SetActive(bool active) => gameObject.SetActive(active);

        public virtual int GetHealth() => health;

        public virtual void SetHealth(int value)
        {
            if (value > GetMaxHealth()) value = GetMaxHealth();
            health = value;
        }

        public virtual int GetMaxHealth() => maxHealth;

        public virtual void SetMaxHealth(int maxValue)
        {
            maxHealth = maxValue;
            if (health > maxHealth) health = maxHealth;
        }

        public virtual bool IsDead() => health <= 0;

        public virtual void Teleport(Vector2 position)
        {
            transform.position = position;
            mainCamera.transform.position =
                new Vector3(
                    position.x + CameraPadding,
                    position.y,
                    mainCamera.transform.position.z);
        }
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out MonoBehaviour monoBehaviour)) return;
            Debug.Log("Ship collision: " + other.gameObject.name);
            
            if (monoBehaviour is ICollectible<GameObject> collectible) 
                collectible.OnCollide(gameObject);
        }
    }
}