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

        [SerializeField] public float speed = 0.01f;
        [SerializeField] public float maxSpeed = 0.1F;
        [SerializeField] protected float cameraPaddingY = 0.2f;

        private bool recordingDistance;
        private float latestPlayerXPosition;
        private float distance;
        
        protected void Awake()
        {
            player.SetActive(false);
        }

        protected void Start()
        {
            player.SetActive(true);
            MonoGameManager.GetEventManager().playingStartEvent.AddListener(() =>
            {
                recordingDistance = true;
                latestPlayerXPosition = player.transform.position.x;
            });
        }

        protected void Update()
        {
            if (!recordingDistance) return;
            var playerXPosition = player.transform.position.x;
            if (playerXPosition < latestPlayerXPosition) return;
            
            distance += Mathf.Abs(latestPlayerXPosition - playerXPosition);
            latestPlayerXPosition = playerXPosition;
            MonoGameManager.GetGuiMenuManager().UpdateDistanceText(distance);
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