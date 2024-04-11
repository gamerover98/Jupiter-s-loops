using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Mono.Entity
{
    public class MonoShip : MonoPlayer
    {
        public Camera mainCamera;

        [SerializeField] private float accelerationY = 5f;
        [SerializeField] private float maxSpeedY = 10f;
        [SerializeField] private float decelerationY = 5f;
        [SerializeField] private float speedX = 0.01f;
        [SerializeField] private float rollSpeed = 15;
        [Range(-360, 360)] [SerializeField] private float rollMinDegrees = -45;
        [Range(-360, 360)] [SerializeField] private float rollMaxDegrees = 45;

        private Rigidbody rigidBody;
        private float cameraPadding;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            cameraPadding = Mathf.Abs(rigidBody.position.x - mainCamera.transform.position.x);
        }

        private void Update()
        {
            var cameraTransform = mainCamera.transform;
            var cameraPosition = cameraTransform.position;

            var targetPosition =
                new Vector3(
                    gameObject.transform.position.x + cameraPadding,
                    gameObject.transform.position.y,
                    cameraPosition.z);

            cameraTransform.position = targetPosition;
        }

        private void FixedUpdate()
        {
            var verticalMovement = Input.GetAxis("Vertical");

            #region MOVE_SHIP_VERTICALLY_AND_FORWARD

            var velocity = MoveVertically(verticalMovement);
            velocity = MoveForward(velocity);
            velocity *= Time.fixedDeltaTime;

            var from = rigidBody.position;
            var to = new Vector3((from + velocity).x, (from + velocity).y, from.z);
            rigidBody.MovePosition(to);

            #endregion

            RollHorizontally(verticalMovement);
        }

        public override void Teleport(Vector2 position)
        {
            base.Teleport(position);
            mainCamera.transform.position =
                new Vector3(
                    position.x + cameraPadding,
                    position.y,
                    mainCamera.transform.position.z);
        }

        private Vector3 MoveForward(Vector3 velocity)
        {
            return new Vector3(speedX, velocity.y, velocity.z);
        }

        private Vector3 MoveVertically(float verticalMovement)
        {
            var velocity = rigidBody.velocity + transform.up.normalized * (verticalMovement * accelerationY);
            velocity.y = Mathf.Clamp(velocity.y, -maxSpeedY, maxSpeedY);

            if (verticalMovement == 0 && rigidBody.velocity.magnitude > 0)
                velocity -= new Vector3(0, rigidBody.velocity.normalized.y * decelerationY);

            return velocity;
        }

        private void RollHorizontally(float verticalMovement)
        {
            var from = transform.rotation;
            var fromEulerAngles = from.eulerAngles;
            var to = verticalMovement switch
            {
                < 0 => new Vector3(rollMaxDegrees, fromEulerAngles.y, fromEulerAngles.z),
                > 0 => new Vector3(rollMinDegrees, fromEulerAngles.y, fromEulerAngles.z),
                _ => new Vector3(0F, fromEulerAngles.y, fromEulerAngles.z),
            };

            rigidBody.MoveRotation(
                Quaternion.RotateTowards(
                    from,
                    Quaternion.Euler(to),
                    rollSpeed * Time.fixedDeltaTime));
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Ship collision: " + other.gameObject.name);
        }
    }
}