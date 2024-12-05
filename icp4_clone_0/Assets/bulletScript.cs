using Mirror;
using UnityEngine;

public class bulletScript : NetworkBehaviour
{
    [SerializeField] private float lifetime = 5f; // Bullet lifetime before auto-destroy

    void Start()
    {
        // Destroy the bullet after a certain time to prevent infinite objects
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object hit has a "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the player on the server
            if (isServer)
            {
                NetworkServer.Destroy(collision.gameObject);
            }

            // Destroy the bullet itself
            Destroy(gameObject);
        }
    }
}
