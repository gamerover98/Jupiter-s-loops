using Mono.Manager;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Mono.Entity
{
    public class MonoShip : MonoPlayer
    {
        [SerializeField] protected float rollSpeed = 15;
        [Range(-360, 360)] [SerializeField] protected float rollMinDegrees = -45;
        [Range(-360, 360)] [SerializeField] protected float rollMaxDegrees = 45;

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            RollHorizontally();
        }

        private void RollHorizontally()
        {
            if (!MonoGameManager.GetInputManager().ActivePlayerMovements) return;
            var verticalThreshold = MonoGameManager.GetInputManager().GetVerticalThreshold();

            var from = transform.rotation;
            var fromEulerAngles = from.eulerAngles;
            var to = verticalThreshold switch
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
    }
}