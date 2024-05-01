using Api.Collectible;
using Mono.Entity;
using UnityEngine;

namespace Mono.Collectible
{
    [RequireComponent(typeof(Collider))]
    public class MonoCapsule : MonoBehaviour, ICapsule<GameObject>
    {
        public bool IsActive() => gameObject.activeSelf;
        public void SetActive(bool active) => gameObject.SetActive(active);

        public void OnTrigger(GameObject withObject)
        {
            if (!IsActive()
                || withObject == null)
                return;

            if (withObject.TryGetComponent(out MonoPlayer monoPlayer))
            {
                //TODO: Add points
            }

            SetActive(false);
        }
        
        public void RequireReset() => SetActive(true);
    }
}