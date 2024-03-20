using UnityEngine;

public class Ship : MonoBehaviour
{

    public Camera mainCamera;
    
    public float accelerationY = 5f;
    public float maxSpeedY = 10f;
    public float decelerationY = 5f;

    public float speedX = 0.01f;
    
    private Rigidbody _rigidBody;
    private float _initDistance;
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _initDistance = Mathf.Abs(_rigidBody.position.x - mainCamera.transform.position.x);
    }

    private void Update()
    {
        var pos = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(_rigidBody.position.x + _initDistance, pos.y, pos.z);
    }

    private void FixedUpdate()
    {
        var verticalMovement = Input.GetAxis("Vertical");
        var newVelocity = _rigidBody.velocity;
        
        newVelocity += transform.up * (accelerationY * verticalMovement * Time.fixedDeltaTime);
        newVelocity.y = Mathf.Clamp(newVelocity.y, -maxSpeedY, maxSpeedY);

        newVelocity += -transform.right * speedX;
        newVelocity.x = Mathf.Clamp(newVelocity.x, speedX, speedX);
        
        if (verticalMovement == 0 && _rigidBody.velocity.magnitude > 0)
            newVelocity -= _rigidBody.velocity.normalized * (decelerationY * Time.fixedDeltaTime);

        _rigidBody.MovePosition(_rigidBody.position + newVelocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }
}
