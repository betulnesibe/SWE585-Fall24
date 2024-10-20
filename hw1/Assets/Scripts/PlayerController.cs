using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

    }

    // Update is called once per frame
    void Update()
    {

        /* version with horizontal-vertical
        // Get input from WASD or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right or A/D
        float moveVertical = Input.GetAxis("Vertical");     // Up/Down or W/S

        // Create a vector based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Apply force based on the input
        rb.AddForce(movement * moveSpeed);
         * 
         */
        Vector3 movement = new Vector3 (0,0,0);

        // Check for specific keys and adjust the movement vector accordingly
        if (Input.GetKey(KeyCode.W)) 
        {
            movement += Vector3.forward; //(0,0,1)
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back; //(0,0,-1)
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            movement += Vector3.left; //(-1,0,0)
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            movement += Vector3.right; // (1,0,0)
        }

        // Apply the force to the Rigidbody based on the movement direction
        rb.AddForce(movement * moveSpeed);

    }
}
