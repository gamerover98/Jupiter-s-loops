using Api.Collectible;
using Mono.Entity;
using Mono.Manager;
using UnityEngine;

namespace Mono.Collectible
{
    [RequireComponent(typeof(MeshCollider))]
    public class MonoCapsule : MonoBehaviour, ICapsule<GameObject>
    {
        public bool IsActive() => gameObject.activeSelf;
        public void SetActive(bool active) => gameObject.SetActive(active);

        public void OnCollide(GameObject colliderObject)
        {
            if (!IsActive()
                || colliderObject == null)
                return;

            if (colliderObject.TryGetComponent(out MonoPlayer monoPlayer))
            {
                //TODO: Add points
            }

            SetActive(false);
            MonoGameManager.Instance.CheckLevel();
        }
        
        public void RequireReset() => SetActive(true);
    }
}