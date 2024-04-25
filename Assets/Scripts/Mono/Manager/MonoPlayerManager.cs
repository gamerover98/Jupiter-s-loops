using System;
using Api.Manager;
using Mono.Entity;
using UnityEngine;

namespace Mono.Manager
{
    public class MonoPlayerManager : MonoBehaviour, IPlayerManager<MonoPlayer, MonoCamera, Vector2>
    {
        [SerializeField] private MonoPlayer player;
        public MonoPlayer GetPlayer() => player;

        [SerializeField] protected MonoCamera gameCamera;
        public MonoCamera GetCamera() => gameCamera;

        [SerializeField] protected float speed = 0.01f;
        [SerializeField] protected float maxSpeed = 0.1F;
        [SerializeField] protected float cameraPaddingY = 0.2f;

        protected void Awake()
        {
            player.SetActive(false);
        }

        protected void Start()
        {
            player.SetActive(true);
        }

        protected void FixedUpdate()
        {
            var cameraVelocity = gameCamera.RigidBody.velocity;
            var playerVelocity = player.RigidBody.velocity;

            cameraVelocity =
                new Vector3(
                    cameraVelocity.x + speed,
                    0,
                    cameraVelocity.z);

            if (Math.Abs(cameraVelocity.x) > maxSpeed)
                cameraVelocity.x = Mathf.Sign(cameraVelocity.x) * maxSpeed;

            var viewportPointPlayerPosition =
                gameCamera.UnityCamera.WorldToViewportPoint(player.RigidBody.position);

            if (viewportPointPlayerPosition.y < cameraPaddingY 
                || viewportPointPlayerPosition.y > 1 - cameraPaddingY)
            {
                cameraVelocity.y = playerVelocity.y;
            }
            
            playerVelocity =
                new Vector3(
                    cameraVelocity.x,
                    playerVelocity.y,
                    playerVelocity.z);

            gameCamera.RigidBody.velocity = cameraVelocity;
            player.RigidBody.velocity = playerVelocity;
        }
    }
}