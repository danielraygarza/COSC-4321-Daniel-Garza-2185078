using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //speed player is moving
    public float speed = 5;

    private Rigidbody rb;
    private float movementX; //move along x axis
    private float movementY; //move along y axis

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // function called when move input is detected
    void OnMove(InputValue movementValue)
    {
        // convert input value into a vector2 movement
        Vector2 movementVector = movementValue.Get<Vector2>();

        // storing x and y compenents of movement
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
     // called one per fixed frame rate frame
    void FixedUpdate()
    {
        // create 3D movement vector using x and y input
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // apply force to rigid body to move the player
        rb.AddForce(movement * speed);
    }
}
