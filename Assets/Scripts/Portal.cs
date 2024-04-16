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
        var camera = GameManager.Instance!.camera;
        var shipTransform = ship.transform;
        var cameraTransform = camera.transform;

        shipTransform.position = destination.transform.position;
        var vector3 = cameraTransform.position;
        vector3.x = destination.transform.position.x;
        cameraTransform.position = vector3;
    }
}

public enum PortalType
{
    Entry,
    Exit
}