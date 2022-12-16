using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forceMagnitude;
    [SerializeField] float maxSpeed;
    private Camera mainCamera;
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
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            // Getting touch position
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            // Debug.Log($"Touch position (screen units): {touchPosition}");

            // we will use camera to convert screen space to world space
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            // Debug.Log($"Touch position (World units): {worldPosition}");

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0; // so that spaceship wont move inside or outside of the screen

            movementDirection.Normalize(); // if its magnitude increases, speed can also change very quickly
        }
        else 
        {
            movementDirection = Vector3.zero;
        }   
    }
    
    void FixedUpdate() 
    {
        if (movementDirection == Vector3.zero) {return;}

        rigidbody.AddForce(movementDirection * forceMagnitude * Time.fixedDeltaTime, ForceMode.Force);

        // Restrict velocity to the max speed specified in the inspector
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
    }
}
