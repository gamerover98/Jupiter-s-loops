using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private PortalType portalType;
    [SerializeField] private Portal destination;

    private void Awake()
    {
        if (portalType == PortalType.Exit && destination != null)
        {
            Debug.LogWarning("The Entry Portal cannot have a destination Portal");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (portalType != PortalType.Entry) return;

        var ship = GameManager.Instance!.ship;
        var shipTransform = ship.transform;

        shipTransform.position = destination.transform.position;
    }
}

public enum PortalType
{
    Entry,
    Exit
}