using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player; // Reference to the player's Transform
    public Vector3 offset;
    private bool isFollowing = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
            isFollowing = true; // Start following the player
        }

    }
    void LateUpdate()
    {
        if (isFollowing)
        {
            transform.position = player.position + offset;
        }
    }
}
