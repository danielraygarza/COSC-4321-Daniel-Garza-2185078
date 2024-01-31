using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //speed player is moving
    public float speed = 0;
    // components for player object
    public TextMeshProUGUI countText; // holds reference to Count Text component
    public GameObject winTextObject; // references Win Text component
    
    private Rigidbody rb;
    private int count;
    private float movementX; //move along x axis
    private float movementY; //move along y axis

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //  // Get and store the Rigidbody component attached to the player
        count = 0; //initializes count to 0
        
        SetCountText(); // resets count display
        winTextObject.SetActive(false); // sets win text to inactive 
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

    void SetCountText()
    {
        // displays current count
        countText.text = "Count: " + count.ToString();

        if (count >= 13) // all PickUp objects are collected
        {
            winTextObject.SetActive(true); //displays win message
        }
    }
     // called one per fixed frame rate frame
    void FixedUpdate()
    {
        // create 3D movement vector using x and y input
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // apply force to rigid body to move the player
        rb.AddForce(movement * speed);
    }

    
    // calls every time the player touches a PickUp item
    // enable trigger under box collider component
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.SetActive(false);
        
        //checking if player collided with PickUp tag objects
        if (other.gameObject.CompareTag("PickUp"))
        {
            // deactivates game objects that the player collides with. makes object disappear
            other.gameObject.SetActive(false);
            count++; // increment count score
            
            SetCountText();
        }
    }

}
