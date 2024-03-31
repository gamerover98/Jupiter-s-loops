using UnityEngine;

namespace Environment
{
    public class MonoPortal : MonoBehaviour, IPortal
    {
        [SerializeField] private PortalType portalType;
        [SerializeField] private MonoPortal destinationPortal;
        
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

            var ship = GameManager.Instance!.ship;
            var shipTransform = ship.transform;

            shipTransform.position = destinationPortal.transform.position;
        }
    }
}