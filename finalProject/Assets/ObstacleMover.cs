using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 2f;
    public float range = 5f;
    private Vector3 startPos;


 // to move the obstacle manually
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + new Vector3(0, 0, Mathf.PingPong(Time.time * speed, range));
    }

    
    /* // to change the update time of the obstacle carving manually
    private float updateTime = 0f;


    void Update()
    {
        transform.position = startPos + new Vector3(0, 0, Mathf.PingPong(Time.time * speed, range));

        // Cache updates to every 0.5 seconds
        if (Time.time > updateTime)
        {
            updateTime = Time.time + 0.5f;
            UpdateNavMeshObstacle();
        }
    }

    void UpdateNavMeshObstacle()
    {
        var navMeshObstacle = GetComponent<NavMeshObstacle>();
        if (navMeshObstacle != null)
        {
            navMeshObstacle.carveOnlyStationary = false; // Allow carving updates.
        }
    }
    */

/*
     // to change carving frequency and time to stationary from unity settings
        void Start()
    {
        startPos = transform.position;

        var navMeshObstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (navMeshObstacle != null)
        {
            navMeshObstacle.carvingMoveThreshold = 0.5f; // minimum movement to trigger carving.
            navMeshObstacle.carvingTimeToStationary = 1f; // time before considering stationary.
        }
    }

    void Update()
    {
        transform.position = startPos + new Vector3(0, 0, Mathf.PingPong(Time.time * speed, range));
    }
*/
}