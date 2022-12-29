using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forceMagnitude;
    [SerializeField] float maxSpeed;
    [SerializeField] float rotationSpeed;
    Camera mainCamera;
    new Rigidbody rigidbody;
    private Vector3 movementDirection;

    void Start()
    {
        // Get reference to the rigidbody component
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        ProcessInput();

        KeepPlayerOnScreen();

        RotateToFaceVelocity();
    }
    
    void FixedUpdate() 
    {
        if (movementDirection == Vector3.zero) {return;}

        rigidbody.AddForce(movementDirection * forceMagnitude * Time.fixedDeltaTime, ForceMode.Force);

        // Restrict velocity to the max speed specified in the inspector
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
    }

    private void ProcessInput()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            // Getting touch position
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            // we will use camera to convert screen space to world space
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            // movementDirection = transform.position - worldPosition; // moving away from touch position
            movementDirection = worldPosition - transform.position; // moving towards touch position
            movementDirection.z = 0; // so that spaceship wont move inside or outside of the screen

            movementDirection.Normalize(); // if its magnitude increases, speed can also change very quickly
        }
        else 
        {
            movementDirection = Vector3.zero;
        } 
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;

        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if(viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f; // Adding 0.1f for smooth movement
        }
        else if(viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        if(viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if(viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;
    }
    private void RotateToFaceVelocity()
    {
        if (rigidbody.velocity == Vector3.zero) { return;}
        
        Quaternion targetRotation = Quaternion.LookRotation(rigidbody.velocity, Vector3.back);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
    }
}
