﻿using Api.Collectible;
using Api.Entity;
using Mono.Manager;
using UnityEngine;

namespace Mono.Entity
{
    [RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
    public abstract class MonoPlayer : MonoBehaviour, IPlayer<Vector2, MonoCamera>
    {
        private const float CameraPaddingXLeft = 0.02F;
        private const float CameraPaddingXRight = 0.04F;
        
        [SerializeField] protected int health;
        [SerializeField] protected int maxHealth;

        [SerializeField] protected float maxSpeedY = 6.5F;
        [SerializeField] protected float accelerationY = 20f;
        [SerializeField] protected float decelerationY = 15f;
        [SerializeField] protected float accelerationX = 5f;
        
        public Rigidbody RigidBody { get; private set; }

        public MonoCamera GetCamera() => MonoGameManager.Instance!.playerManager.GetCamera();
        public void SetVelocity(Vector2 velocity) => RigidBody.velocity = velocity;
        public Vector2 GetVelocity() => RigidBody.velocity;

        protected virtual void Awake()
        {
            RigidBody = GetComponent<Rigidbody>();
        }

        protected virtual void FixedUpdate()
        {
            var velocity =
                new Vector3(
                    RigidBody.velocity.x,
                    RigidBody.velocity.y,
                    RigidBody.velocity.z);

            MoveVertically(ref velocity);
            MoveHorizontally(ref velocity);
            RigidBody.velocity = velocity;
        }

        protected virtual void MoveVertically(ref Vector3 velocity)
        {
            var verticalThreshold = MonoGameManager.Instance.inputManager.GetVerticalThreshold();

            // Apply deceleration
            if (Mathf.Approximately(verticalThreshold, 0) && !Mathf.Approximately(velocity.y, 0))
            {
                velocity.y =
                    Mathf.MoveTowards(
                        velocity.y,
                        0,
                        Time.fixedDeltaTime * Mathf.Abs(decelerationY));
            }
            else
            {
                velocity.y =
                    Mathf.MoveTowards(
                        velocity.y,
                        verticalThreshold * maxSpeedY,
                        Time.fixedDeltaTime * accelerationY);
            }
        }

        protected virtual void MoveHorizontally(ref Vector3 velocity)
        {
            var viewportPointPlayerPosition =
                GetCamera().UnityCamera.WorldToViewportPoint(RigidBody.position);
            var horizontalThreshold = MonoGameManager.Instance.inputManager.GetHorizontalThreshold();
            
            if (viewportPointPlayerPosition.x > CameraPaddingXLeft && horizontalThreshold < 0
                || viewportPointPlayerPosition.x < 1 - CameraPaddingXRight && horizontalThreshold > 0)
            {
                velocity.x += horizontalThreshold * accelerationX;
            }
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
            if (RigidBody != null)
                RigidBody.position = position;
            else
                transform.position = position;

            GetCamera().Teleport(position);
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