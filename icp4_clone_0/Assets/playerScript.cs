using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class playerScript : NetworkBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement

    public GameObject throwablePrefab; // Prefab to instantiate
    public Transform spawnPoint;      // Spawn location (e.g., in front of the player)
    public float throwForce = 500f;   // Force applied to the object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            HandleMovement();
            // Check for input to spawn and throw an object
            if (Input.GetKeyDown(KeyCode.Space)) // Space key to throw
            {
                Spawn_();
            }
        }
    }

    private void HandleMovement()
    {
        // Get input from WASD or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime;

        // Apply movement using Rigidbody for better physics handling
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.MovePosition(transform.position + movement);
        }
        else
        {
            transform.Translate(movement, Space.World);
        }
    }



    private void Spawn_()
    {
        if (!isServer)
        {
            Debug.LogWarning("Spawn_() can only be called on the server.");
            return;
        }

        if (throwablePrefab != null && spawnPoint != null)
        {
            // Instantiate the object at the spawn point
            GameObject spawnedObject = Instantiate(throwablePrefab, spawnPoint.position, spawnPoint.rotation);

            // Add force to the spawned object
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = spawnPoint.forward * throwForce; // Adjust forward direction and speed
            }

            // Ignore collision between the player and their own bullet
            Collider playerCollider = GetComponent<Collider>();
            Collider bulletCollider = spawnedObject.GetComponent<Collider>();
            if (playerCollider != null && bulletCollider != null)
            {
                Physics.IgnoreCollision(playerCollider, bulletCollider);
            }

            // Spawn on the network
            NetworkServer.Spawn(spawnedObject);
        }
        else
        {
            Debug.LogWarning("ThrowablePrefab or SpawnPoint is not assigned.");
        }
    }



}
