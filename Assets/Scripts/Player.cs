using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var moveInput = Input.GetAxis("Vertical");
        var moveDirection = transform.up * moveInput;
        
        _rigidBody.MovePosition(_rigidBody.position + moveDirection * (speed * Time.fixedDeltaTime));
    }
}
