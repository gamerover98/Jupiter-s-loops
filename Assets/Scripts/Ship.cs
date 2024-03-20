using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var verticalMovement = Input.GetAxis("Vertical");
        var horizontalMovement = Input.GetAxis("Horizontal");

        var mx = transform.right * (horizontalMovement * speed * Time.fixedDeltaTime);
        var my = transform.up * (verticalMovement * speed * Time.fixedDeltaTime);

        var velocity = new Vector3(mx.x, my.y);
        _rigidBody.MovePosition(_rigidBody.position + velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }
}
