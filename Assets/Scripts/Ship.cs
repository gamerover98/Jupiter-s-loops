using UnityEngine;

public class Ship : MonoBehaviour
{
    public Camera mainCamera;

    [SerializeField] private float accelerationY = 5f;
    [SerializeField] private float maxSpeedY = 10f;
    [SerializeField] private float decelerationY = 5f;
    [SerializeField] private float speedX = 0.01f;

    private Rigidbody _rigidBody;
    private float _initDistance;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _initDistance = Mathf.Abs(_rigidBody.position.x - mainCamera.transform.position.x);
    }

    private void Update()
    {
        var cameraTransform = mainCamera.transform;
        var cameraPosition = cameraTransform.position;

        var targetPosition =
            new Vector3(
                gameObject.transform.position.x + _initDistance,
                cameraPosition.y,
                cameraPosition.z);

        cameraTransform.position = targetPosition;
    }

    private void FixedUpdate()
    {
        var verticalMovement = Input.GetAxis("Vertical");
        var newVelocity = _rigidBody.velocity;

        MoveVertically(ref newVelocity, verticalMovement);
        MoveForward(ref newVelocity);
        
        _rigidBody.MovePosition(_rigidBody.position + newVelocity * Time.fixedDeltaTime);
    }

    private void MoveForward(ref Vector3 newVelocity)
    {
        newVelocity += -transform.right.normalized * speedX; // -right is because the model is rotated by 180 degrees.
        newVelocity.x = Mathf.Clamp(newVelocity.x, speedX, speedX);
    }

    private void MoveVertically(ref Vector3 velocity, float verticalMovement)
    {
        velocity += transform.up.normalized * (verticalMovement * accelerationY);
        velocity.y = Mathf.Clamp(velocity.y, -maxSpeedY, maxSpeedY);

        if (verticalMovement == 0 && _rigidBody.velocity.magnitude > 0)
        {
            velocity -= new Vector3(0, _rigidBody.velocity.normalized.y * decelerationY);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }
}