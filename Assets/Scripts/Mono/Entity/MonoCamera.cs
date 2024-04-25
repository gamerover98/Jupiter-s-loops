using Api.Entity;
using UnityEngine;

namespace Mono.Entity
{
    [RequireComponent(typeof(Camera), typeof(Rigidbody))]
    public class MonoCamera : MonoBehaviour, ICamera<Vector2>
    {
        public Camera UnityCamera { get; private set; }
        public Rigidbody RigidBody { get; private set; }

        private void Awake()
        {
            UnityCamera = GetComponent<Camera>();
            RigidBody = GetComponent<Rigidbody>();
        }

        public virtual void Teleport(Vector2 position)
        {
            var newPosition = new Vector3(position.x, position.y, RigidBody.transform.position.z);
            
            if (RigidBody != null)
                RigidBody.position = newPosition;
            else
                transform.position = newPosition;
        }
        
        public virtual void SetVelocity(Vector2 velocity) => RigidBody.velocity = velocity;
        public virtual Vector2 GetVelocity() => RigidBody.velocity;
    }
}