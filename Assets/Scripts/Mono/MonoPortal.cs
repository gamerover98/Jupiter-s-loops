using Api;
using Mono.Manager;
using UnityEngine;

namespace Mono
{
    public class MonoPortal : MonoBehaviour, IPortal
    {
        [SerializeField] private PortalType portalType;
        [SerializeField] private MonoPortal destinationPortal;

        public bool IsActive() => gameObject.activeSelf;
        public void SetActive(bool active) => gameObject.SetActive(active);

        public PortalType GetPortalType() => portalType;
        public IPortal GetDestinationPortal() => destinationPortal;

        private void Awake()
        {
            if (portalType == PortalType.Exit && destinationPortal != null)
            {
                Debug.LogWarning("The Entry Portal cannot have a destination Portal");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (portalType != PortalType.Entry) return;

            var player = MonoGameManager.Instance!.GetPlayer();
            var playerTransform = player.transform;

            playerTransform.position = destinationPortal.transform.position;
        }

        public void RequireReset() => SetActive(true);
    }
}