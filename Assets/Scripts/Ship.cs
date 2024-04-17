using System;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Ship : MonoBehaviour
{
    public Camera mainCamera;

    [SerializeField] private float accelerationY = 5f;
    [SerializeField] private float maxSpeedY = 10f;
    [SerializeField] private float decelerationY = 5f;
    [SerializeField] private float speedX = 0.01f;
    [SerializeField] private float rollSpeed = 15;

    [SerializeField] private float maxHorizontalSpeed = 10f; 
    [SerializeField] private float minHorizontalSpeed = 4f; 
    [SerializeField] private float horizontalAcceleration = 5f;

    [Range(-360, 360)] [SerializeField] private float rollMinDegrees = -45;
    [Range(-360, 360)] [SerializeField] private float rollMaxDegrees = 45;

    //variabili camera
    [SerializeField] private float cameraSpeed = 6f;
    [SerializeField] private float cameraLimitY = 0.2f;  //distanza dal bordo dello schermo
    
    
    private Transform cameraTransform;
    private Vector3 cameraPosition;
    
    private Rigidbody rigidBody;
    public float initDistance;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        initDistance = Mathf.Abs(rigidBody.position.x - mainCamera.transform.position.x);
        
        cameraTransform = mainCamera.transform;
        cameraPosition = cameraTransform.position;
        
        MoveCameraToPlayerPosition();
    }

    private void Update()
    {
        Vector3 CameraPositionY = mainCamera.WorldToViewportPoint(transform.position);

        if (CameraPositionY.y > 1 - cameraLimitY)
            cameraTransform.Translate(Vector3.up * (cameraSpeed * Time.deltaTime));
        else if (CameraPositionY.y < cameraLimitY)
            cameraTransform.Translate(Vector3.down * (cameraSpeed * Time.deltaTime));
    }

    public void MoveCameraToPlayerPosition()
    {
        cameraTransform.position = new Vector3(transform.position.x + initDistance, transform.position.y, cameraTransform.position.z);
    }
    
    // private Vector3 CameraUpdatePosition()
    // {
    //     var targetPosition =
    //         new Vector3(
    //             gameObject.transform.position.x + initDistance,
    //             cameraPosition.y,
    //             cameraPosition.z);
    //     return(targetPosition);
    // }
    
    private void FixedUpdate()
    {
        var verticalMovement = Input.GetAxis("Vertical");
        var horizontalMovement = Input.GetAxis("Horizontal");

        #region MOVE_SHIP_VERTICALLY_AND_FORWARD
        var velocity = MoveVertically(verticalMovement);
        velocity = MoveForward(velocity, horizontalMovement);
        
        velocity.x += horizontalMovement * horizontalAcceleration * Time.fixedDeltaTime;
        
        if (Mathf.Abs(velocity.x) > maxHorizontalSpeed)
        {
            velocity.x = Mathf.Sign(velocity.x) * maxHorizontalSpeed;
        }
        else if (Mathf.Abs(velocity.x) < minHorizontalSpeed)
        {
            velocity.x = Mathf.Sign(velocity.x) * minHorizontalSpeed;
        }

        var from = rigidBody.position;
        var to = from + velocity * Time.fixedDeltaTime;
        rigidBody.MovePosition(to);
        #endregion
        
        //Lo faccio nel fixedUpdate in quanto gli aggiornamenti vengono effettuati a tempi regolari 
        cameraTransform.Translate(Vector3.right * (cameraSpeed * Time.fixedDeltaTime));
        
        RollHorizontally(verticalMovement);
    }

    private Vector3 MoveForward(Vector3 velocity, float horizontalMovement)
    {
        float forwardSpeed = speedX + horizontalMovement * horizontalAcceleration;
        return new Vector3(forwardSpeed, velocity.y, velocity.z);
    }

    private Vector3 MoveVertically(float verticalMovement)
    {
        float targetVerticalVelocity = verticalMovement * maxSpeedY;
        Vector3 newVelocity = rigidBody.velocity; 
        newVelocity.y = Mathf.MoveTowards(newVelocity.y, targetVerticalVelocity, Time.deltaTime * accelerationY);
        
        if (Mathf.Approximately(verticalMovement, 0) && !Mathf.Approximately(newVelocity.y, 0))     // Se il movimento verticale � zero e il rigidBody si muove in verticale allora applica la decelerazione
        {
            float verticalDeceleration = Mathf.Sign(newVelocity.y) * decelerationY;
            newVelocity.y = Mathf.MoveTowards(newVelocity.y, 0, Time.deltaTime * Mathf.Abs(verticalDeceleration));
        }

        return newVelocity;
    }

    private void RollHorizontally(float verticalMovement)
    {
        var from = transform.rotation;
        var fromEulerAngles = from.eulerAngles;
        var to = verticalMovement switch
        {
            < 0 => new Vector3(rollMaxDegrees, fromEulerAngles.y, fromEulerAngles.z),
            > 0 => new Vector3(rollMinDegrees, fromEulerAngles.y, fromEulerAngles.z),
            _ => new Vector3(0F, fromEulerAngles.y, fromEulerAngles.z),
        };

        rigidBody.MoveRotation(
            Quaternion.RotateTowards(
                from,
                Quaternion.Euler(to),
                rollSpeed * Time.fixedDeltaTime));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Entry")
        {
            Debug.Log("Enter The Portal");
            MoveCameraToPlayerPosition();
        }
        Debug.Log("Ship collision: " + other.gameObject.name);
    }
}