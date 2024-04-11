using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Mono.Entity
{
    public class MonoShip : MonoPlayer
    {
        [SerializeField] protected float accelerationY = 5f;
        [SerializeField] protected float maxSpeedY = 10f;
        [SerializeField] protected float decelerationY = 5f;
        [SerializeField] protected float speedX = 0.01f;
        [SerializeField] protected float rollSpeed = 15;
        [Range(-360, 360)] [SerializeField] protected float rollMinDegrees = -45;
        [Range(-360, 360)] [SerializeField] protected float rollMaxDegrees = 45;

        protected void FixedUpdate()
        {
            var verticalMovement = Input.GetAxis("Vertical");
            var velocity = MoveVertically(verticalMovement);
            velocity = MoveForward(velocity);
            velocity *= Time.fixedDeltaTime;

            var from = RigidBody.position;
            var to = new Vector3((from + velocity).x, (from + velocity).y, from.z);
            RigidBody.MovePosition(to);
            
            RollHorizontally(verticalMovement);
        }

        private Vector3 MoveForward(Vector3 velocity)
        {
            return new Vector3(speedX, velocity.y, velocity.z);
        }

        private Vector3 MoveVertically(float verticalMovement)
        {
            var velocity = RigidBody.velocity + transform.up.normalized * (verticalMovement * accelerationY);
            velocity.y = Mathf.Clamp(velocity.y, -maxSpeedY, maxSpeedY);

            if (verticalMovement == 0 && RigidBody.velocity.magnitude > 0)
                velocity -= new Vector3(0, RigidBody.velocity.normalized.y * decelerationY);

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

            RigidBody.MoveRotation(
                Quaternion.RotateTowards(
                    from,
                    Quaternion.Euler(to),
                    rollSpeed * Time.fixedDeltaTime));
        }

        protected void OnTriggerEnter(Collider other)
        {
            Debug.Log("Ship collision: " + other.gameObject.name);
        }
    }
}